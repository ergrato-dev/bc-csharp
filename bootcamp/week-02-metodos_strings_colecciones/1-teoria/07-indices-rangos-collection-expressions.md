# Índices `^`, rangos `..` y collection expressions

## 🎯 Objetivos

Al finalizar este archivo, comprenderás:

- Cómo indexar desde el final con `^` y cortar con `..` en arrays, strings, `List<T>` y `Span<T>`
- Qué tipos son `Index` y `Range` y por qué funcionan sobre tus propias clases
- La sintaxis de collection expressions `[a, b, .. rest]` y a qué tipo se convierte
- Cuándo un corte copia y cuándo es una vista sobre la memoria original

## 📋 Conceptos clave

### 1. Índice desde el final: `^`

```csharp
int[] xs = [10, 20, 30, 40, 50];
xs[^1];      // 50: el último (^1 == Length - 1)
xs[^2];      // 40
xs[^0];      // IndexOutOfRangeException: ^0 es Length, fuera del array

string s = "hello";
s[^1];       // 'o'
```

`^n` es "n desde el final". `^0` no existe como elemento: es la posición justo después del último, útil solo como fin de rango.

### 2. Rangos: `..`

```csharp
int[] xs = [10, 20, 30, 40, 50];
xs[1..3];    // [20, 30]: inicio inclusivo, fin EXCLUSIVO
xs[..2];     // [10, 20]: desde el principio
xs[3..];     // [40, 50]: hasta el final
xs[^2..];    // [40, 50]: los dos últimos
xs[..^1];    // [10, 20, 30, 40]: todos menos el último
xs[..];      // copia completa

string path = "reports/2026/q3.csv";
path[^3..];                              // "csv"
path[..path.IndexOf('/')];               // "reports"
```

Misma convención que `Substring(start, length)` pero con posiciones en vez de longitud: `xs[a..b]` tiene `b - a` elementos. Un rango fuera de límites lanza `ArgumentOutOfRangeException`.

### 3. `Index` y `Range` son tipos

```csharp
Index last = ^1;
Range firstHalf = ..(xs.Length / 2);

xs[last];                    // 50
xs[firstHalf];               // [10, 20]
last.GetOffset(xs.Length);   // 4: resuelve ^1 a un índice real
var (offset, length) = firstHalf.GetOffsetAndLength(xs.Length);   // (0, 2)
```

Son `readonly struct` de `System`. El compilador acepta `[Index]` en cualquier tipo con `int Length` (o `Count`) y un indexador `this[int]`; y `[Range]` en cualquier tipo con `Length` y un método `Slice(int start, int length)`. Sin implementar nada más, tus propias colecciones ganan `^` y `..`.

### 4. Cortar: ¿copia o vista?

```csharp
int[] arr = [1, 2, 3, 4];
int[] slice = arr[1..3];         // COPIA: array nuevo, modificarlo no toca arr

string text = "hello world";
string word = text[..5];         // COPIA: Substring, string nuevo

ReadOnlySpan<char> view = text.AsSpan()[..5];   // VISTA: sin asignar, apunta al mismo buffer
Span<int> window = arr.AsSpan(1..3);            // VISTA: window[0] = 9 cambia arr[1]
```

Sobre `array` y `string`, un rango llama a `RuntimeHelpers.GetSubArray` / `Substring`: asigna. Sobre `Span<T>` / `ReadOnlySpan<T>` es un puntero + longitud: cero asignaciones. Cuando parsees texto en un bucle caliente, corta el `Span`, no el `string` (semana 12 a fondo).

### 5. Collection expressions (C# 12)

```csharp
int[] a = [1, 2, 3];                         // array
List<string> b = ["x", "y"];                 // List<T>
HashSet<int> c = [1, 1, 2];                  // HashSet: {1, 2}
ReadOnlySpan<byte> d = [0x01, 0x02];         // Span sobre datos estáticos, sin heap
IEnumerable<int> e = [];                     // colección vacía del tipo adecuado

int[] tail = [4, 5];
int[] all = [0, .. a, .. tail, 6];           // spread: [0, 1, 2, 3, 4, 5, 6]
List<int> copy = [.. a];                     // copia independiente de a
```

Una sola sintaxis para todo tipo de colección: el compilador elige la construcción óptima según el **tipo destino**. El `..` dentro de corchetes es el operador **spread**: expande cualquier `IEnumerable<T>`. No hay inferencia sin tipo destino: `var x = [1, 2];` no compila (CS9176).

### 6. Collection expressions en parámetros y retornos

```csharp
static int Sum(ReadOnlySpan<int> values) { /* ... */ }
static IReadOnlyList<string> DefaultTags() => ["untagged"];

Sum([1, 2, 3]);                              // sin asignar array: datos en el stack
Sum([.. someList]);                          // copia la lista a un span temporal

var tags = DefaultTags();                    // tipo real: array de 1 elemento
```

Para `ReadOnlySpan<T>` de literales constantes el compilador emite los datos en el assembly (como un `static readonly`): la llamada no asigna. Para `IEnumerable<T>` / `IReadOnlyList<T>` genera el tipo más barato que satisface la interfaz (un array, o una colección vacía compartida para `[]`).

### 7. Patrones sobre listas (adelanto)

```csharp
string Describe(int[] xs) => xs switch
{
    [] => "vacío",
    [var only] => $"uno: {only}",
    [var first, .., var last] => $"de {first} a {last}",
};
```

La misma sintaxis `[..]` sirve para **descomponer** en pattern matching: `[]`, `[x]`, `[first, .. rest]`. Lo verás con calma en la semana 09; aquí basta con reconocerlo.

## 🔬 Bajo el capó

`xs[^1]` se compila a `xs[xs.Length - 1]`: el compilador ni siquiera crea un `Index`. `xs[1..3]` sobre un array baja a `RuntimeHelpers.GetSubArray(xs, new Range(1, 3))`, que hace `new T[2]` + `Array.Copy`. Sobre `string` es `Substring`. Sobre `Span<T>` es `Slice`, una aritmética de punteros sin copia. Una collection expression con destino `List<T>` de N elementos se compila a `new List<T>(N)` + `Add` × N (o `CollectionsMarshal.SetCount` + escritura directa en .NET 8+, sin comprobaciones por elemento). Con destino `ReadOnlySpan<T>` y literales constantes primitivos, los bytes van a la sección `.data` del assembly y el span apunta ahí: `ReadOnlySpan<byte> magic = [0x50, 0x4B]` es gratis en cada llamada. `[.. a, .. b]` con tipos que exponen `Count` calcula la capacidad total antes de copiar: una sola asignación.

## ⚠️ Errores comunes

- `xs[^0]`: fuera de rango; el último es `^1`.
- Pensar que `xs[1..3]` incluye el índice 3: el fin es exclusivo, son 2 elementos.
- Cortar `string` en un bucle intensivo: cada corte asigna. Usa `AsSpan()`.
- `var list = [1, 2];`: no compila, la collection expression necesita tipo destino.
- Suponer que `int[] slice = arr[1..3]` comparte memoria con `arr`: es una copia.

## 📚 Recursos adicionales

- [Índices y rangos](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/member-access-operators#range-operator-)
- [Collection expressions](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/collection-expressions)
- [Tutorial: explorar índices y rangos](https://learn.microsoft.com/dotnet/csharp/tutorials/ranges-indexes)

## ✅ Checklist de verificación

- [ ] Uso `^1`, `[..n]`, `[n..]` y `[^n..]` sin contar con los dedos
- [ ] Explico por qué el fin de un rango es exclusivo y cuántos elementos tiene `[a..b]`
- [ ] Distingo cuándo un corte copia (array, string) y cuándo es vista (`Span`)
- [ ] Escribo `[.. a, .. b]` para concatenar y `[.. a]` para copiar
- [ ] Sé que una collection expression necesita tipo destino y cómo lo elige el compilador
