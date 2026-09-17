# Glosario — Semana 03

Términos técnicos clave introducidos esta semana, ordenados alfabéticamente.

## A

**`AggregateException`** — Excepción que agrupa varias: la lanzan `Task.WhenAll` y `Parallel`. `Flatten()` aplana los agregados anidados y `InnerExceptions` da la lista.

**Atómico (rename)** — Un `File.Move` dentro del mismo volumen se completa o no ocurre: no hay estado intermedio visible. Base del patrón `.tmp` + `Move`.

## B

**BOM (Byte Order Mark)** — Bytes iniciales que declaran la codificación (`EF BB BF` en UTF-8). `File.WriteAllText` no lo escribe; leer un fichero ajeno que sí lo lleva sin `detectEncodingFromByteOrderMarks` produce un `JsonException` en el primer carácter.

**Breakpoint condicional** — Punto de interrupción que solo detiene si una expresión es cierta (`item.Key == "KB-01"`). Sustituye a cientos de `F5`.

**Buffer** — Memoria intermedia de un stream (4096 bytes por defecto en `FileStream`) para no hacer una llamada al sistema por byte. Sin `Flush`/`Dispose` su contenido nunca llega al disco.

## C

**Call Stack** — Panel del depurador con la pila viva. Cambiar de frame muestra los locales del llamador: la vía rápida para saber quién pasó el argumento malo.

**`[Conditional("DEBUG")]`** — Atributo que hace que el **compilador elimine la llamada** en Release, argumentos incluidos. Lo llevan `Debug.Assert` y `Debug.WriteLine`.

## D

**DAP (Debug Adapter Protocol)** — Protocolo con el que VS Code habla con el depurador; del lado .NET lo implementa `vsdbg` sobre la API del CLR.

**Desenrollar la pila (stack unwinding)** — Segunda pasada del manejo de excepciones: descarta frames ejecutando sus `finally` hasta llegar al `catch` elegido.

**`Dispose`** — Método de `IDisposable` que libera recursos no gestionados. `using` lo garantiza traduciendo a `try/finally`.

## E

**EH tables** — Tablas de manejo de excepciones que el compilador emite por método. Un `try` que no lanza no cuesta nada porque no hay código en el camino normal.

**`ExceptionDispatchInfo`** — Permite re-lanzar una excepción capturada conservando la traza original, incluso desde otro hilo. Mecanismo detrás de `await`.

## F

**Filtro de excepción (`when`)** — Condición evaluada en la **primera** pasada, antes de desenrollar: si es `false` el `catch` no se entra y la pila queda intacta.

**`finally`** — Bloque que se ejecuta siempre, haya excepción o `return`. Nunca debe lanzar: sustituiría a la excepción original.

**`FileMode` / `FileAccess` / `FileShare`** — Qué hacer con el fichero (crear, truncar, abrir), qué vas a hacer tú (leer, escribir) y qué pueden hacer otros procesos mientras tanto.

## G

**Guard clause** — Validación al principio del método que lanza si el argumento es inválido: `ArgumentNullException.ThrowIfNull(x)`, `ArgumentException.ThrowIfNullOrWhiteSpace(s)`.

## H

**Hit count** — Condición de breakpoint por número de pasadas (`>500`): detiene a partir de la iteración indicada.

## I

**`InnerException`** — La causa original conservada al envolver una excepción en otra de más alto nivel. `GetBaseException()` salta directo a la raíz de la cadena.

**`IOException`** — Base de los errores de E/S (`FileNotFoundException`, `DirectoryNotFoundException`, "fichero en uso"). Ojo: `UnauthorizedAccessException` **no** deriva de ella.

## J

**`JsonDocument` / `JsonNode`** — DOM de JSON sin tipo: el primero es de solo lectura y hay que liberarlo con `using`; el segundo es mutable.

**`JsonException`** — Error de JSON mal formado o incompatible con el tipo. Sus propiedades `Path`, `LineNumber` y `BytePositionInLine` señalan el punto exacto.

**`JsonSerializerContext`** — Clase `partial` generada en compilación por el source generator de JSON: sin reflexión, arranque más rápido y compatible con AOT y trimming.

**`JsonSerializerOptions`** — Configuración de serialización. Cachea metadatos por tipo, así que debe ser `static readonly` y reutilizarse.

## L

**`launch.json`** — Configuración de depuración de VS Code. `console: "integratedTerminal"` es obligatorio si el programa usa `Console.ReadLine`.

**Lectura perezosa** — `File.ReadLines` y `Directory.EnumerateFiles` devuelven según recorren; `ReadAllLines` y `GetFiles` materializan todo en memoria.

**Logpoint** — Breakpoint que imprime una expresión sin detener la ejecución ni tocar el código fuente.

## N

**Naming policy** — Regla de conversión de nombres al serializar: `JsonNamingPolicy.CamelCase` convierte `Sku` en `"sku"`. `[JsonPropertyName]` gana sobre ella.

## P

**`Path.Combine`** — Une segmentos con el separador del sistema operativo. Un segmento absoluto descarta lo anterior: `Path.Combine("/a", "/b") == "/b"`.

**PDB portable** — Fichero de símbolos que relaciona offsets IL con fichero y línea. Sin él, un `StackTrace` muestra métodos pero no líneas.

**Primera pasada / segunda pasada** — Búsqueda del manejador (con evaluación de filtros, sin tocar la pila) y desenrollado posterior ejecutando los `finally`.

## R

**Re-lanzar (`throw;`)** — Continuar la propagación conservando el `StackTrace` original. `throw ex;` lo reinicia en esa línea y el analizador CA2200 lo marca.

## S

**Source generator** — Generador que produce código C# en tiempo de compilación. El de `System.Text.Json` sustituye la reflexión por código analizable.

**`Stream`** — Secuencia de bytes con `Read`/`Write`/`Seek`/`Dispose`. Se envuelven en capas: `FileStream` → `GZipStream` → `StreamReader`.

**`StreamReader` / `StreamWriter`** — Capas que traducen entre bytes y `char` aplicando una codificación (UTF-8 por defecto).

## T

**TOCTOU (time-of-check to time-of-use)** — Condición de carrera entre comprobar (`File.Exists`) y usar (`File.Open`): entre ambas el estado puede cambiar. Por eso el `try/catch` es obligatorio.

**`TryXxx` (patrón)** — Método que devuelve `bool` y entrega el resultado por `out` sin lanzar nunca: `int.TryParse`, `Dictionary.TryGetValue`, tu `TryParseLine`.

## U

**`UnauthorizedAccessException`** — Permisos insuficientes o la ruta es un directorio. Deriva de `SystemException`, **no** de `IOException`: hay que capturarla aparte.

**`using` (declaración/instrucción)** — Garantiza `Dispose` al salir del ámbito; `await using` hace lo mismo con `IAsyncDisposable`.

**`Utf8JsonReader`** — Lector `ref struct` que recorre bytes UTF-8 directamente, sin crear `string` intermedios: la razón del rendimiento de `System.Text.Json`.

## W

**Watch** — Panel del depurador con expresiones reevaluadas en cada parada. Evita expresiones con efectos secundarios.

**Wrapping (envolver)** — Capturar un error técnico y lanzar uno de dominio pasándolo como `innerException`: traduce sin perder la causa.
