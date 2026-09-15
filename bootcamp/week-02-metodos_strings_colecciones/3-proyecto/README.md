## 🚀 Proyecto Semanal: Inventario en memoria con búsquedas, agrupaciones y reporte

### 🎯 Objetivo

Construir una aplicación de consola que gestione **el catálogo de tu dominio asignado** en memoria: cargar registros desde texto, buscar por clave e importar sin duplicados, agrupar y ordenar, procesar una cola de operaciones y producir un reporte de texto alineado. Aplica todo lo visto en la semana 02: métodos con `out`/`params`/argumentos con nombre, recursión, `string`/`StringBuilder`, formateo con cultura, `List`, `Dictionary`, `HashSet`, `Queue`/`Stack`, rangos y collection expressions.

### 📋 Tu dominio asignado

**Dominio**: [El instructor te asignará tu dominio]

### ✅ Requisitos funcionales (adaptables a tu dominio)

1. **Entidad del dominio** como `readonly record struct` con al menos 5 campos: una **clave única** (`string`), un nombre, una **categoría**, un valor `decimal` y un conteo `int`.
2. **Carga desde texto**: un raw string literal con ≥ 12 registros en formato `clave;nombre;categoría;valor;conteo`. Parsear con `Split`, `Trim`, `TryParse` con `CultureInfo.InvariantCulture`; una línea inválida se **reporta y se salta**, nunca rompe la carga. El método de parseo sigue el patrón `TryParseLine(string line, out Entity entity)`.
3. **Índice por clave**: `Dictionary<string, Entity>` sin distinguir mayúsculas. Buscar por clave desde el menú con `TryGetValue`; importar un lote con `TryAdd` e informar cuántos se rechazaron por duplicado.
4. **Categorías**: `HashSet<string>` con las categorías presentes; listar ordenadas; búsqueda por categoría.
5. **Agrupación y orden**: agrupar en `Dictionary<string, List<Entity>>` por categoría; dentro de cada grupo ordenar por valor descendente con `Sort` + comparador. Mostrar los **3 primeros y los 2 últimos** de cada grupo usando rangos (`[..3]`, `[^2..]`) sin repetir si el grupo es pequeño.
6. **Cola de operaciones**: `Queue<(string Key, int Delta)>` con ≥ 5 movimientos (entradas y salidas de stock, préstamos/devoluciones, altas/bajas…). Procesar en orden; un movimiento que dejaría el conteo negativo se rechaza. Cada aplicado se apila en un `Stack` para **deshacer** el último desde el menú.
7. **Búsqueda de texto**: por subcadena en el nombre, sin distinguir mayúsculas ni acentos (`StringComparison`/`CompareOptions`). Un método `Highlight(string text, params string[] terms)` marca las coincidencias.
8. **Recursión**: al menos un método recursivo con sentido en tu dominio (jerarquía de categorías con `/`, cálculo de descuento escalonado, búsqueda binaria sobre la lista ordenada…). Documenta el caso base.
9. **Reporte**: `StringBuilder` con columnas alineadas (`{x,-20}`, `{x,10:N2}`), subtotal por categoría, total general y porcentaje de cada categoría sobre el total (`:P1`). Cultura elegida de forma consciente (`Invariant` o `es-ES`), documentada en el README.

### 💡 Ejemplos de adaptación por dominio

| Dominio | Entidad (clave) | Categoría | Valor `decimal` | Conteo `int` | Movimientos en la cola |
|---------|-----------------|-----------|-----------------|--------------|------------------------|
| **Biblioteca** | Libro (ISBN) | género | precio de reposición | ejemplares | préstamo −1 / devolución +1 |
| **Farmacia** | Medicamento (código) | familia | precio | unidades | venta / recepción de pedido |
| **Gimnasio** | Clase (código) | tipo | tarifa | plazas libres | inscripción / baja |
| **Restaurante** | Plato (código) | sección de carta | precio | raciones disponibles | pedido / reposición |
| **Taller mecánico** | Repuesto (referencia) | sistema | precio | stock | uso en reparación / compra |
| **Hotel** | Habitación (número) | tipo | tarifa noche | noches libres | reserva / cancelación |

### 🧱 Requisitos técnicos

- Un único proyecto de consola (`Project.csproj` del `starter/`), sin paquetes NuGet
- `dotnet build -warnaserror` sin warnings; `Nullable` habilitado
- Código en inglés (tipos, métodos, variables), mensajes al usuario en español
- Tres archivos: `Program.cs` (menú), `Catalog.cs` (entidad + colecciones + operaciones), `ReportBuilder.cs` (reporte)
- Ninguna indexación directa `dict[key]` para lectura de claves que puedan faltar: `TryGetValue`/`GetValueOrDefault`
- Ningún `Remove` dentro de un `foreach`; ninguna concatenación `+=` de strings en bucle
- Firmas públicas con `IReadOnlyList<T>`/`IEnumerable<T>`, nunca `List<T>` expuesta

### 🛠️ Entregables

1. `starter/` completado y adaptado, compilando sin warnings
2. `README.md` propio en `starter/` con: dominio, formato de la línea de datos, descripción del método recursivo (caso base y paso), sesión de ejemplo pegada y decisión de cultura
3. Respuesta a: *¿qué operación de tu menú sería O(n²) si usaras solo `List<T>` y cómo la evitaste?*

### 📊 Evaluación

Ver [rubrica-evaluacion.md](../rubrica-evaluacion.md), sección Producto (30%).
