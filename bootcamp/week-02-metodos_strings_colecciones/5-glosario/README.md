# Glosario — Semana 02

Términos técnicos clave introducidos esta semana, ordenados alfabéticamente.

## A

**Amortizado (O(1))** — Coste medio por operación cuando ocasionalmente una es cara: `List<T>.Add` es O(1) amortizado porque solo copia al duplicar capacidad.

**Argumento con nombre** — `Greet(name: "Ada", shout: true)`: pasa argumentos por nombre; permite saltar opcionales y aclara llamadas con booleanos.

**Array** — Bloque contiguo de tamaño fijo en el heap: `int[] xs = new int[5]`. Acceso O(1), `Length` inmutable.

**Array jagged** — `int[][]`: array de arrays, cada fila con su propio tamaño. Distinto de `int[,]` (rectangular).

## B

**Bounds check** — Comprobación `i < Length` que hace el JIT en cada `xs[i]`; lanza `IndexOutOfRangeException`. Se elimina en `for (i < xs.Length)`.

**Bucket** — Casilla de una tabla hash. `Dictionary` reduce `GetHashCode()` a un índice de bucket y solo compara las entradas de esa cadena.

## C

**Capacity** — Tamaño del array interno de `List<T>`/`StringBuilder`; `Count`/`Length` es lo usado. `new List<T>(n)` reserva `n` de golpe.

**Caso base** — Condición de parada de una recursión. Sin él: `StackOverflowException`.

**Collection expression** — `[1, 2, 3]`, `[]`, `[.. a, .. b]`: sintaxis única para crear cualquier colección según el tipo destino (C# 12).

**Colisión** — Dos claves distintas con el mismo bucket. Se encadenan; con buen hash son raras.

**`CultureInfo`** — Reglas de formato y comparación de una cultura (`es-ES`, `en-US`). `InvariantCulture`: fija, para datos entre máquinas; `CurrentCulture`: la del usuario, para pantalla.

## D

**Deconstrucción** — `var (key, value) = pair`: descompone tuplas y `KeyValuePair` en variables.

**`Dictionary<TKey, TValue>`** — Tabla hash clave → valor. `TryGetValue`, `TryAdd`, `GetValueOrDefault`; O(1) medio; orden de iteración no garantizado.

## E

**`Equals` / `GetHashCode`** — Par que define igualdad de claves. Contrato: si `a.Equals(b)` entonces mismo hash. `record` los genera por valor.

**Expression-bodied** — `static int Twice(int n) => n * 2;`: método de una sola expresión sin llaves ni `return`.

## F

**FIFO / LIFO** — First-In-First-Out (`Queue<T>`) / Last-In-First-Out (`Stack<T>`).

**Firma** — Nombre del método + tipos de sus parámetros (no el retorno). Dos sobrecargas deben diferir en firma.

**Formato compuesto** — `{valor,alineación:formato}`: `{price,10:N2}` → ancho 10, 2 decimales con separador de miles.

**Función local** — Método declarado dentro de otro. `static` si no captura variables externas.

## H

**`HashSet<T>`** — Conjunto sin duplicados con `Add`/`Contains` O(1). Operaciones de conjuntos: `UnionWith`, `IntersectWith`, `IsSubsetOf`.

## I

**`in`** — Parámetro por referencia de solo lectura; evita copiar structs grandes.

**`Index`** — Tipo de `^n`: posición desde el final. `^1` es el último; `^0` es `Length`.

**Inmutabilidad** — Un `string` nunca cambia: cada "modificación" devuelve un string nuevo.

**Intern pool** — Tabla de literales de string compartidos por el runtime: `"a"` es el mismo objeto en todo el programa.

**Interpolación** — `$"Hola, {name}"`: incrusta expresiones en un string. Con C# 10+ usa un handler sin strings intermedios.

**`IReadOnlyList<T>` / `IEnumerable<T>`** — Interfaces para exponer colecciones sin permitir mutación. Preferidas en firmas públicas frente a `List<T>`.

## M

**Managed pointer** — Referencia gestionada a una variable (`int&` en IL). Lo que realmente pasa `ref`/`out`/`in`.

## O

**`out`** — Parámetro que el método debe asignar en todos los caminos. Base del patrón `TryXxx`.

**Overload resolution** — Algoritmo del compilador que elige la sobrecarga "más específica" según los tipos de los argumentos.

## P

**`params`** — Último parámetro que acepta N argumentos: `params int[]` (asigna array) o `params ReadOnlySpan<int>` (no asigna, C# 13).

**Paso por valor** — Regla única de C#: el método recibe una copia del argumento. Con tipos por referencia, se copia la referencia (no el objeto).

**`PriorityQueue<TElement, TPriority>`** — Cola que extrae siempre el elemento de menor prioridad.

## Q

**`Queue<T>`** — Cola FIFO: `Enqueue`, `Dequeue`, `TryDequeue`, `Peek`. Array circular, O(1).

## R

**`Range`** — Tipo de `a..b`: inicio inclusivo, fin exclusivo. `xs[1..3]` tiene 2 elementos.

**Raw string literal** — `"""..."""`: string multilínea sin escapes; la indentación de la línea de cierre se elimina.

**`ReadOnlySpan<T>`** — Vista sin copia sobre memoria contigua (array, string, stack). Cortarlo no asigna. Detalle en la semana 12.

**Recursión** — Método que se llama a sí mismo con un problema más pequeño. Requiere caso base; cada llamada es un stack frame.

**`ref`** — Parámetro que es alias de la variable del llamador; debe estar inicializada; `ref` obligatorio también en la llamada.

**Rehash** — Reconstrucción de la tabla hash con más buckets cuando `count` supera `buckets.Length`.

## S

**Sobrecarga** — Varios métodos con el mismo nombre y distinta firma.

**`Span<T>`** — Como `ReadOnlySpan<T>` pero con escritura: `arr.AsSpan(1..3)[0] = 9` modifica `arr[1]`.

**Spread (`..` en collection expression)** — `[.. a, .. b]`: expande una colección dentro de otra.

**Stack frame** — Bloque del stack con parámetros y locales de una llamada; se libera al `return`.

**`Stack<T>`** — Pila LIFO: `Push`, `Pop`, `TryPop`, `Peek`. Deshacer, DFS, parsers.

**`StackOverflowException`** — Recursión sin fin agota el stack (~1 MB por hilo). No se puede capturar: termina el proceso.

**`StringBuilder`** — Buffer mutable de `char` para construir strings en bucles. `Append`, `AppendLine`, `ToString()`.

**`StringComparison`** — Modo de comparación: `Ordinal` (bytes, rápido), `OrdinalIgnoreCase`, `CurrentCulture`, `InvariantCulture`. Nunca `ToLower() ==`.

**`string.Join`** — Une elementos con un separador: `string.Join(", ", names)`. Más eficiente que `+=` en bucle.

**Substring** — `s.Substring(start, length)` o `s[start..end]`: crea un string nuevo (copia).

## T

**`TryParse` / patrón `TryXxx`** — Devuelve `bool` y el resultado por `out`; nunca lanza. `int.TryParse`, `Dictionary.TryGetValue`, `Queue.TryDequeue`.

## V

**Versión de colección** — Contador interno que el enumerador comprueba; modificar la colección durante `foreach` lanza `InvalidOperationException`.

**Verbatim string** — `@"C:\dir\file"`: sin secuencias de escape; `""` para comillas.

## W

**`with`** — `item with { Quantity = 3 }`: copia un `record` cambiando algunos campos. Necesario para "mutar" un struct dentro de una `List`.
