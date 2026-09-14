# Glosario — Semana 01

Términos técnicos clave introducidos esta semana, ordenados alfabéticamente.

## A

**Alias de tipo** — Nombre corto en minúscula para un tipo de la BCL: `int` = `System.Int32`, `string` = `System.String`. Por convención se usa el alias.

**Apphost** — Ejecutable nativo mínimo (`bin/Debug/net10.0/App`) que localiza el runtime y carga `App.dll`.

**Assembly** — Unidad de despliegue de .NET: un `.dll` o `.exe` con IL y metadatos.

## B

**BCL (Base Class Library)** — Biblioteca estándar de .NET (`System.*`): `Console`, `List<T>`, `HttpClient`, `Math`.

**`break`** — Sale del bucle o `switch` más interno.

## C

**Cast** — Conversión explícita con `(tipo)valor`. Puede perder datos; no lanza salvo en contexto `checked`.

**`checked` / `unchecked`** — Contexto que activa/desactiva la detección de desbordamiento aritmético (`OverflowException`).

**CLI `dotnet`** — Herramienta de línea de comandos del SDK: `new`, `build`, `run`, `test`, `add package`.

**CLR (Common Language Runtime)** — Máquina virtual de .NET: carga assemblies, compila IL con el JIT, gestiona memoria con el GC.

**Collection expression** — Sintaxis `[1, 2, 3]` para crear arrays y colecciones (C# 12+).

**`const`** — Constante evaluada en compilación e incrustada en el IL. Solo tipos primitivos y `string`.

**`continue`** — Salta al final de la iteración actual y evalúa de nuevo la condición del bucle.

**Conversión implícita** — Conversión que el compilador aplica sin sintaxis porque no pierde información (`int` → `long`).

**`.csproj`** — Archivo MSBuild del proyecto: framework objetivo, propiedades del compilador, paquetes.

**Cultura (`CultureInfo`)** — Configuración regional que afecta a formato y parseo de números y fechas. `InvariantCulture` fija el punto decimal.

## D

**`decimal`** — Tipo de 128 bits en base 10, exacto para dinero. Literal con sufijo `m`.

**`do-while`** — Bucle que ejecuta el cuerpo al menos una vez y evalúa la condición después.

**`double`** — Real de 64 bits, tipo por defecto para literales con punto. No apto para dinero.

## E

**Early return** — Salir del método en cuanto se conoce el resultado para evitar anidamiento.

**Exhaustividad** — Propiedad de un `switch` expression que cubre todos los valores posibles. Si falta, warning CS8509.

## F

**`foreach`** — Bucle sobre cualquier enumerable. La variable de iteración es de solo lectura.

## G

**GC (Garbage Collector)** — Componente del CLR que libera automáticamente objetos sin referencias.

**`global.json`** — Archivo que fija la versión del SDK para un repositorio.

## I

**IL (Intermediate Language)** — Código intermedio independiente de CPU al que Roslyn compila C#. Lo ejecuta el CLR vía JIT.

**`ImplicitUsings`** — Propiedad del `.csproj` que añade automáticamente `using System;` y otros comunes.

**Interpolación** — String con expresiones incrustadas: `$"Hola, {name}"`.

## J

**JIT (Just-In-Time)** — Compilador del CLR que traduce IL a código nativo en tiempo de ejecución, método a método.

## L

**Literal** — Valor escrito directamente en el código: `42`, `3.5f`, `19.99m`, `'A'`, `"texto"`.

**LTS (Long-Term Support)** — Versión con 3 años de soporte (.NET 8, 10). Las STS tienen 18 meses.

## N

**`Nullable`** — Propiedad del `.csproj` que activa el análisis de referencias anulables (`string?`).

**NuGet** — Gestor de paquetes de .NET. Los paquetes se declaran como `PackageReference` con versión exacta.

## P

**`Parse` / `TryParse`** — Métodos para convertir texto a número. `Parse` lanza excepción; `TryParse` devuelve `bool` y el valor por `out`.

**Patrón (pattern)** — Forma de comprobar un valor en `switch` o `is`: constante, relacional (`> 10`), combinado (`and`/`or`/`not`), descarte (`_`).

## R

**Raw string** — Literal `"""..."""` sin escapes, multilínea.

**REPL** — Bucle leer-evaluar-imprimir; en consola, `while (true)` + `ReadLine` + `break`.

**Roslyn** — Compilador de C# (y VB.NET) escrito en C#. Convierte `.cs` en IL.

**Runtime** — CLR + BCL. Suficiente para ejecutar, no para compilar.

## S

**SDK** — Runtime + herramientas (CLI, Roslyn, MSBuild, NuGet). Necesario para desarrollar.

**Solución (`.slnx` / `.sln`)** — Agrupa varios proyectos que se compilan y prueban juntos.

**`switch` expression** — Expresión que devuelve un valor según patrones: `x switch { 0 => "cero", _ => "otro" }`.

**`switch` statement** — Instrucción con `case`/`break` que ejecuta bloques.

## T

**Tiered compilation** — Estrategia del JIT: compila rápido (Tier 0) y recompila los métodos calientes optimizados (Tier 1).

**Tipo por referencia** — La variable guarda una dirección a un objeto en el heap: `string`, arrays, `class`.

**Tipo por valor** — La variable guarda el dato directamente: numéricos, `bool`, `char`, `struct`.

**Top-level statements** — Código directamente en `Program.cs` sin declarar `class Program` ni `Main`.

**`TreatWarningsAsErrors`** — Propiedad que convierte cualquier warning en error de compilación.

## V

**`var`** — Inferencia de tipo en compilación. No es dinámico: el tipo queda fijado al inicializar.

**Verbatim string** — Literal `@"..."` que no interpreta escapes.

## W

**`when`** — Guarda adicional en un brazo de `switch`: `"/" when right == 0 => ...`.

**`while`** — Bucle que evalúa la condición antes de cada iteración; puede no ejecutarse.
