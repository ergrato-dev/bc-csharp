# Webgrafía — Semana 05

## Documentación oficial

- [Tipos de estructura (`struct`)](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/struct)
- [Elegir entre `class` y `struct`](https://learn.microsoft.com/dotnet/standard/design-guidelines/choosing-between-class-and-struct)
- [Boxing y unboxing](https://learn.microsoft.com/dotnet/csharp/programming-guide/types/boxing-and-unboxing)
- [Records](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/record) · [Expresión `with`](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/with-expression)
- [Enumeraciones](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/enum) · [`FlagsAttribute`](https://learn.microsoft.com/dotnet/api/system.flagsattribute) · [Guía de diseño de enums](https://learn.microsoft.com/dotnet/standard/design-guidelines/enum)
- [Genéricos](https://learn.microsoft.com/dotnet/csharp/fundamentals/types/generics) · [Métodos genéricos](https://learn.microsoft.com/dotnet/csharp/programming-guide/generics/generic-methods)
- [Restricciones de tipos genéricos](https://learn.microsoft.com/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters)
- [Matemáticas genéricas](https://learn.microsoft.com/dotnet/standard/generics/math) · [`static abstract` en interfaces](https://learn.microsoft.com/dotnet/csharp/whats-new/tutorials/static-virtual-interface-members)
- [Covarianza y contravarianza](https://learn.microsoft.com/dotnet/csharp/programming-guide/concepts/covariance-contravariance/)
- [`Nullable<T>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) · [`EqualityComparer<T>.Default`](https://learn.microsoft.com/dotnet/api/system.collections.generic.equalitycomparer-1.default)

## Herramientas

- [SharpLab](https://sharplab.io) — ver los ~60 miembros que genera un `record` y el IL de un boxing
- [.NET Source Browser: `List<T>`](https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Collections/Generic/List.cs) — genéricos y restricciones en la BCL real
- [BenchmarkDotNet](https://benchmarkdotnet.org/) — para medir struct vs class y boxing (se usa a fondo en la semana 13)

## Artículos

- [Performance improvements in .NET: generic math y devirtualización](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-8/)
- [C# 9 records: design notes](https://devblogs.microsoft.com/dotnet/c-9-0-on-the-record/) — por qué el diseño es como es
- [The cost of boxing](https://learn.microsoft.com/dotnet/framework/performance/performance-tips) — medidas y patrones para evitarlo
- [Strongly typed IDs en .NET](https://andrewlock.net/series/using-strongly-typed-entity-ids-to-avoid-primitive-obsession/) — la técnica del paso 3 del ejercicio 01, en profundidad
