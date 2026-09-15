# Ejercicio 02 — Inventario con colecciones

> Tutorial guiado. Descomenta paso a paso en `starter/Program.cs` y ejecuta `dotnet run` tras cada paso.

## 🎯 Objetivo

Modelar un inventario en memoria y elegir la colección correcta para cada operación: `List<T>` para el catálogo, `Dictionary` para buscar por SKU, `HashSet` para categorías y pertenencia, `Queue` para pedidos en orden de llegada, `Stack` para deshacer, rangos y spread para cortar y combinar, `params ReadOnlySpan<T>` para sumar y `StringBuilder` para un reporte agrupado.

**Duración**: 90 min · **Teoría relacionada**: 01, 04, 05, 06, 07

## 🚀 Preparación

```bash
cd starter
dotnet run
```

## Paso 1: `record struct` + `List<T>` con collection expression

`Item` es un `readonly record struct`: igualdad por valor, inmutable, sin asignar en el heap. La lista se construye con una collection expression; `new(...)` infiere el tipo del destino.

```csharp
public readonly record struct Item(string Sku, string Name, string Category, decimal Price, int Quantity);

List<Item> items =
[
    new("KB-01", "Keyboard", "periféricos", 49.99m, 12),
    // ...
];
```

Descomenta `PASO 1` **y** `PASO 1b` (el record va al final del archivo: las declaraciones de tipos cierran un `Program.cs` con top-level statements). `items[^1]` es el último.

## Paso 2: `Dictionary<string, Item>` indexado por SKU

`StringComparer.OrdinalIgnoreCase` hace que `"ms-02"` y `"MS-02"` sean la misma clave. `TryGetValue` no lanza; `TryAdd` devuelve `false` en vez de `ArgumentException`.

```csharp
var bySku = new Dictionary<string, Item>(StringComparer.OrdinalIgnoreCase);
foreach (Item item in items) bySku[item.Sku] = item;
```

Descomenta `PASO 2`. Cambia `TryAdd` por `Add` y observa la excepción.

## Paso 3: `HashSet<T>` para categorías y pertenencia

`Add` devuelve `false` si el elemento ya estaba. `[.. FindLowStock(...)]` convierte la `List<string>` devuelta en un `HashSet<string>` por el tipo destino.

```csharp
HashSet<string> lowStockSkus = [.. FindLowStock(items, threshold: 5)];
```

Descomenta `PASO 3`. `threshold: 5` es un argumento con nombre.

## Paso 4: `Queue<T>` de pedidos y `out` para el resultado

`TryDequeue` en un `while` vacía la cola en orden FIFO. `TryReserve` sigue el patrón `TryXxx`: `bool` + `out`. Como `Item` es un struct, mutar el stock es reasignar `items[index]` con `with`.

```csharp
while (orders.TryDequeue(out var order))
{
    bool ok = TryReserve(items, order.Sku, order.Units, out int remaining);
    // ...
}
items[index] = items[index] with { Quantity = items[index].Quantity - units };
```

Descomenta `PASO 4`. Prueba a escribir `items[index].Quantity -= units`: error CS1612, un struct dentro de una `List` se devuelve por copia.

## Paso 5: `Stack<T>` para deshacer cambios de precio

Cada cambio apila el precio anterior; `Undo` hace `TryPop` y restaura. LIFO: se deshace primero el último cambio.

```csharp
var history = new Stack<(string Sku, decimal OldPrice)>();
ChangePrice(items, history, "KB-01", 44.99m);
ChangePrice(items, history, "KB-01", 39.99m);
Undo(items, history);   // vuelve a 44.99
```

Descomenta `PASO 5`. Llama a `Undo` dos veces más: la segunda no hace nada (`TryPop` devuelve `false`).

## Paso 6: Ordenar, rangos y spread

`[.. items]` copia la lista para no reordenar el original. `Sort` con comparador por valor de stock descendente. `[..2]` y `[^2..]` cortan (copian) y `[.. topTwo, .. bottomTwo]` concatena. `TotalValue` recibe `params ReadOnlySpan<Item>`: la llamada con 3 argumentos no asigna un array.

```csharp
static decimal TotalValue(params ReadOnlySpan<Item> items) { /* ... */ }

TotalValue(items[0], items[1], items[2]);   // sin array en el heap
TotalValue([.. items]);                      // copia la lista a un span temporal
```

Descomenta `PASO 6`.

## Paso 7: Reporte agrupado con `StringBuilder`

`Dictionary<string, List<Item>>` agrupa por categoría con el patrón `TryGetValue` + crear si falta. El reporte alinea columnas (`{i.Price,10:N2}`) y fija la cultura con `string.Create(CultureInfo.InvariantCulture, ...)`.

```csharp
if (!groups.TryGetValue(item.Category, out List<Item>? group))
    groups[item.Category] = group = [];
group.Add(item);
```

Descomenta `PASO 7` y los dos `using` del inicio.

## ✅ Verificación

```
Inventario listo.
5 artículos · último: Headset
MS-02 → Mouse (30 uds)
TryAdd duplicado: False
¿Existe ZZ-99? False
  periféricos  nueva
  periféricos  repetida
  pantallas    nueva
  cables       nueva
  audio        nueva
Categorías: periféricos, pantallas, cables, audio
Stock bajo: MN-03, CB-04
  pedido MS-02 × 5: OK, quedan 25
  pedido CB-04 × 1: sin stock
  pedido MN-03 × 4: OK, quedan 0
  KB-01 ahora: 39.99
  KB-01 tras undo: 44.99 · cambios pendientes: 1
  extremos por valor: HD-05, KB-01, MN-03, CB-04
  valor total: 1027.38 (3 primeros) · 1580.38 (todos)
SKU    Artículo          Precio  Uds      Valor
[periféricos]
KB-01  Keyboard           44.99   12     539.88
MS-02  Mouse              19.50   25     487.50
[pantallas]
MN-03  Monitor 27"       289.00    0       0.00
[cables]
CB-04  Cable USB-C         9.99    0       0.00
[audio]
HD-05  Headset            79.00    7     553.00
TOTAL                                  1,580.38
```

`dotnet build -warnaserror` sin warnings.

## 🧠 Preguntas de reflexión

1. `bySku` y `items` guardan copias distintas de cada `Item` (es un struct). Tras el paso 4, ¿qué `Quantity` tiene `bySku["MS-02"]`? ¿Cómo evitarías la incoherencia?
2. `FindIndex` en `TryReserve` es O(n). Si hubiera 100 000 artículos y 1 000 pedidos por segundo, ¿qué estructura usarías y qué cambia en `Item`?
3. ¿Por qué `TotalValue(items[0], items[1], items[2])` no asigna memoria en el heap y `TotalValue([.. items])` sí?
