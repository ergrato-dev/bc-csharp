# Webgrafía — Semana 03

## Documentación oficial

- [Excepciones y manejo de excepciones](https://learn.microsoft.com/dotnet/csharp/fundamentals/exceptions/)
- [Mejores prácticas con excepciones](https://learn.microsoft.com/dotnet/standard/exceptions/best-practices-for-exceptions)
- [Sentencias `try`/`catch`/`finally` y filtros](https://learn.microsoft.com/dotnet/csharp/language-reference/statements/exception-handling-statements)
- [Crear excepciones personalizadas](https://learn.microsoft.com/dotnet/standard/design-guidelines/designing-custom-exceptions)
- [`ArgumentNullException.ThrowIfNull` y familia](https://learn.microsoft.com/dotnet/api/system.argumentnullexception.throwifnull)
- [CA2200: no re-lanzar con `throw ex;`](https://learn.microsoft.com/dotnet/fundamentals/code-analysis/quality-rules/ca2200)
- [E/S de ficheros y streams](https://learn.microsoft.com/dotnet/standard/io/)
- [Manejar errores de E/S](https://learn.microsoft.com/dotnet/standard/io/handling-io-errors)
- [`System.Text.Json`: visión general](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/overview) y [source generation](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/source-generation)
- [Depurar C# en VS Code](https://code.visualstudio.com/docs/csharp/debugging) y [opciones de `launch.json`](https://github.com/dotnet/vscode-csharp/blob/main/debugger-launchjson.md)

## Herramientas

- [SharpLab](https://sharplab.io) — ver a qué IL baja un `try/catch/finally` y dónde quedan las EH tables
- [JSONLint](https://jsonlint.com/) — validar rápido un JSON antes de culpar al código
- [.NET Source Browser: `FileStream`](https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/IO/FileStream.cs) — la implementación real de los buffers
- [`dotnet-dump` y `dotnet-trace`](https://learn.microsoft.com/dotnet/core/diagnostics/) — cuando el depurador no basta (semanas 13 y 25)

## Artículos

- [The cost of exceptions — Performance improvements in .NET](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-9/) — medidas reales del camino de excepción
- [File IO improvements in .NET 6](https://devblogs.microsoft.com/dotnet/file-io-improvements-in-dotnet-6/) — por qué `FileStream` cambió por dentro
- [Try-catch-finally y `when`: el orden de evaluación](https://learn.microsoft.com/archive/msdn-magazine/2016/june/essential-net-exception-filters) — las dos pasadas explicadas con ejemplos
- [System.Text.Json en .NET 9/10: novedades](https://devblogs.microsoft.com/dotnet/dotnet-9-json-improvements/)
