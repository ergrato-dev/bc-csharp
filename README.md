<p align="center">
  <img src="assets/bootcamp-header.svg" alt="Bootcamp C# Zero to Hero" width="1200">
</p>

<p align="center">
  <a href="LICENSE"><img src="https://img.shields.io/badge/license-CC%20BY--NC--SA%204.0-lightgrey.svg" alt="License CC BY-NC-SA 4.0"></a>
  <a href="#"><img src="https://img.shields.io/badge/semanas-26-yellow.svg" alt="26 Semanas"></a>
  <a href="#"><img src="https://img.shields.io/badge/horas-260-orange.svg" alt="260 Horas"></a>
  <a href="#"><img src="https://img.shields.io/badge/C%23-14-512BD4?logo=csharp&logoColor=white" alt="C# 14"></a>
  <a href="#"><img src="https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white" alt=".NET 10"></a>
</p>

<p align="center">
  <a href="README_EN.md"><img src="https://img.shields.io/badge/🇺🇸_English-0969DA?style=for-the-badge&logoColor=white" alt="English Version"></a>
</p>

---

## 📋 Descripción

Bootcamp intensivo de **26 semanas (~6 meses, 10 h/semana, 260 h)** enfocado en el dominio de **C# y la plataforma .NET**. Diseñado para llevar a desarrolladores con experiencia previa en otro lenguaje hasta **desarrollador C#/.NET avanzado**: lenguaje a fondo (C# 14), internals del CLR y rendimiento, concurrencia, backend con ASP.NET Core y EF Core, comunicación con gRPC/SignalR/mensajería, UI con Blazor y .NET MAUI, y despliegue en producción con Docker y CI/CD.

### 🎯 Objetivos

Al finalizar el bootcamp, los estudiantes serán capaces de:

- ✅ Dominar la sintaxis y el sistema de tipos de C# 14: clases, structs, records, enums, genéricos y varianza
- ✅ Aplicar POO, SOLID y patrones de diseño con inyección de dependencias
- ✅ Usar delegados, eventos, lambdas, LINQ y pattern matching con fluidez
- ✅ Escribir código asíncrono correcto con `async`/`await`, cancelación e `IAsyncEnumerable`
- ✅ Explicar el CLR, el JIT, el GC y el layout de memoria, y medir con BenchmarkDotNet y dotnet-tools
- ✅ Escribir código de alto rendimiento con `Span<T>`, `ArrayPool`, `ref struct` y parsing zero-allocation
- ✅ Usar reflection, atributos, source generators y analyzers Roslyn
- ✅ Programar concurrencia segura: `lock`, `Interlocked`, colecciones concurrentes, `Parallel`, `Channel<T>`
- ✅ Construir APIs con ASP.NET Core Minimal API, EF Core + PostgreSQL y OpenAPI
- ✅ Testear con xUnit, NSubstitute, `WebApplicationFactory` y Testcontainers
- ✅ Comunicar servicios con gRPC, SignalR y mensajería (RabbitMQ/MassTransit, outbox, idempotencia)
- ✅ Construir interfaces con Blazor (SSR/Server/WASM/Auto) y apps móviles con .NET MAUI
- ✅ Contenedorizar, desplegar con GitHub Actions y operar con OpenTelemetry, health checks y resiliencia

### 🚀 ¿Por qué C# y .NET 10?

> **Un lenguaje, toda la plataforma** — backend, tiempo real, móvil, web y alto rendimiento con el mismo runtime.

C# es un lenguaje moderno con evolución anual, tipado fuerte, rendimiento cercano a nativo y un ecosistema unificado. Este bootcamp usa **.NET 10 LTS** y **C# 14**, es Linux-first (WSL válido), no toca código legacy (.NET Framework, WebForms, WCF) y se centra en las prácticas que se usan en producción hoy.

---

## 🗓️ Estructura del Bootcamp

| Fase | Semanas | Horas |
|:----:|:-------:|:-----:|
| **Fundamentos acelerados** | 01-03 | 30h |
| **POO y diseño** | 04-06 | 30h |
| **C# moderno** | 07-10 | 40h |
| **Internals y rendimiento** | 11-14 | 40h |
| **Concurrencia y plataforma** | 15-18 | 40h |
| **Comunicación y eventos** | 19-20 | 20h |
| **UI: Blazor y MAUI** | 21-23 | 30h |
| **Producción y proyecto final** | 24-26 | 30h |

**Total: 26 semanas** | **260 horas** de formación intensiva | 150 archivos de teoría · 122 diagramas SVG · 50 ejercicios · 26 proyectos

---

## 📚 Contenido por Semana

Cada semana incluye:

```
bootcamp/week-XX-tema_principal/
├── README.md                 # Descripción y objetivos
├── rubrica-evaluacion.md     # Criterios de evaluación (30/40/30)
├── 0-assets/                 # Diagramas SVG
├── 1-teoria/                 # Material teórico
├── 2-practicas/              # Ejercicios guiados (patrón uncomment)
├── 3-proyecto/               # Proyecto semanal (TODOs, dominio único)
├── 4-recursos/               # Recursos adicionales
│   ├── ebooks-free/
│   ├── videografia/
│   └── webgrafia/
└── 5-glosario/               # Términos clave
```

| Semana | Tema | Descripción |
|:------:|------|-------------|
| 01 | `dotnet_setup_tipos_control_flujo` | SDK .NET 10, CLI `dotnet`, proyectos y soluciones, `Program.cs` top-level, sistema de tipos, conversiones, operadores y control de flujo (incl. `switch` expression) |
| 02 | `metodos_strings_colecciones` | Métodos y paso de parámetros (`ref`/`out`/`in`/`params`), sobrecarga, recursión, `string` inmutable e interpolación, `StringBuilder`, arrays, `List<T>`, `Dictionary<K,V>`, `HashSet<T>`, `Queue`/`Stack`, índices `^` y rangos `..`, collection expressions |
| 03 | `excepciones_io_json_debugging` | Excepciones y filtros `when`, excepciones personalizadas, `throw` expressions, depurador en VS Code, `System.IO` (File/Path/Directory/streams), `System.Text.Json` |
| 04 | `clases_herencia_interfaces` | Clases, propiedades (`init`, `required`, `field`), constructores primarios, `static`, `partial`, herencia, `virtual`/`override`/`abstract`/`sealed`, `object` (`Equals`/`GetHashCode`/`ToString`), interfaces y miembros por defecto, composición vs herencia |
| 05 | `structs_records_enums_genericos` | `struct`/`readonly struct`, `record`/`record struct`, igualdad por valor y `with`, `enum` y `[Flags]`, genéricos, restricciones `where`, varianza `in`/`out`, `Nullable<T>` |
| 06 | `solid_patrones_xunit` | SOLID, DRY/KISS, inyección de dependencias manual, patrones Factory, Strategy, Observer, Builder, Repository, Decorator; introducción a xUnit para validar diseño |
| 07 | `delegados_eventos_lambdas` | `delegate`, `Func`/`Action`/`Predicate`, multicast, lambdas y closures, `event`/`EventHandler<T>`, extension methods y extension members (C# 14), expression trees intro |
| 08 | `linq` | `IEnumerable<T>` y `yield`, ejecución diferida, sintaxis de método vs query, filtrado, proyección, agrupación, joins, set, agregación, `IQueryable` intro, rendimiento |
| 09 | `pattern_matching_nullable` | Tuplas y deconstrucción, patrones (type, property, positional, relational, list, `and`/`or`/`not`), `switch` avanzado, nullable reference types, `?.`/`??`/`!`, atributos de nulabilidad |
| 10 | `async_await` | `Task`/`Task<T>`, `async`/`await` y máquina de estados, `ConfigureAwait`, `CancellationToken`, `IAsyncEnumerable`, `ValueTask`, antipatrones (`async void`, `.Result`), `Task.WhenAll`/`WhenAny`, `HttpClient` |
| 11 | `clr_memoria_gc` | CLR, JIT tiered/ReadyToRun/Native AOT, assemblies e IL, stack/heap, generaciones GC y LOH, `IDisposable`/`using`/finalizadores, `SafeHandle`, `WeakReference` |
| 12 | `alto_rendimiento_memoria` | `Span<T>`/`ReadOnlySpan<T>`/`Memory<T>`, `stackalloc`, `ArrayPool`, `ref` locals/returns, `ref struct`, `in`, `unsafe` y punteros, parsing zero-allocation, `System.Buffers` |
| 13 | `benchmarking_profiling` | BenchmarkDotNet, `dotnet-counters`/`dotnet-trace`/`dotnet-dump`, boxing y asignaciones ocultas, `struct` vs `class` medidos, `FrozenDictionary`, `SearchValues`, optimización guiada por datos |
| 14 | `reflection_atributos_source_generators` | Atributos personalizados, reflection, `dynamic`, expression trees, source generators (`IIncrementalGenerator`), analyzers Roslyn, `[GeneratedRegex]`, interceptors |
| 15 | `concurrencia_paralelismo` | `Thread` y thread pool, `lock`/`Lock`, `Monitor`, `Interlocked`, `SemaphoreSlim`, colecciones concurrentes, `Parallel`/PLINQ, `Channel<T>`, TPL Dataflow intro, race conditions y deadlocks |
| 16 | `aspnet_core_minimal_api` | Hosting y pipeline de middleware, contenedor DI, `IOptions` y configuración, logging, minimal APIs, routing y binding, validación y `ProblemDetails`, OpenAPI, `HttpClientFactory`, `BackgroundService` |
| 17 | `ef_core_persistencia` | `DbContext` y modelado, migraciones, relaciones, traducción LINQ a SQL, tracking vs no-tracking, N+1, transacciones, concurrencia optimista, Dapper comparativa, PostgreSQL con Npgsql. PK `Guid` |
| 18 | `testing_calidad` | xUnit avanzado (theories, fixtures), FluentAssertions, NSubstitute, `WebApplicationFactory`, Testcontainers, cobertura, mutation testing intro, vertical slice, analyzers y EditorConfig |
| 19 | `grpc_signalr` | Protobuf y contratos, servicios gRPC, streaming (server/client/bidi), interceptors, gRPC-Web, SignalR hubs, grupos, autenticación en hubs, escalado con backplane |
| 20 | `mensajeria_eventos` | RabbitMQ con MassTransit, publish/subscribe, consumidores, reintentos y dead-letter, outbox, idempotencia, sagas intro, workers desacoplados, Kafka comparativa |
| 21 | `blazor_fundamentos` | Modelo de componentes, render modes (SSR, Server, WebAssembly, Auto), routing, parámetros y cascading, eventos, formularios y validación, ciclo de vida |
| 22 | `blazor_avanzado` | Gestión de estado, DI en componentes, JS interop, autenticación y autorización, consumo de API tipado, PWA, testing con bUnit |
| 23 | `maui_multiplataforma` | XAML y layouts, MVVM con CommunityToolkit.Mvvm, navegación Shell, acceso a plataforma, Blazor Hybrid, publicación Android (Linux) — iOS/Windows requieren host propio |
| 24 | `docker_cicd` | `dotnet publish` (trimming, AOT, single-file), Dockerfile multi-stage, docker-compose con PostgreSQL y RabbitMQ, secretos, GitHub Actions, versionado y NuGet propio |
| 25 | `observabilidad_resiliencia_seguridad` | `ILogger` estructurado, OpenTelemetry, health checks, `Microsoft.Extensions.Resilience`/Polly, rate limiting, JWT e Identity mínima, OWASP en .NET, `System.Security.Cryptography` |
| 26 | `proyecto_final` | Integrador: API + worker de mensajería + gRPC/SignalR + Blazor + librería de dominio + tests + Docker + CI. Code review y presentación |

### 🔑 Componentes Clave

- 📖 **Teoría**: conceptos con ejemplos reales y sección "Bajo el capó" (qué hace el compilador y el runtime)
- 💻 **Práctica**: ejercicios guiados progresivos y proyectos hands-on
- 📝 **Evaluación**: evidencias de conocimiento, desempeño y producto
- 🎓 **Recursos**: glosarios, referencias y material complementario

---

## 🛠️ Stack Tecnológico

| Tecnología | Versión | Uso |
|------------|---------|-----|
| .NET SDK | **10.0 (LTS)** | Runtime y herramientas |
| C# | **14** | Lenguaje principal |
| VS Code + C# Dev Kit | última | Entorno de desarrollo |
| xUnit | **2.9.x** | Testing unitario |
| FluentAssertions | **8.x** | Aserciones legibles |
| NSubstitute | **6.x** | Mocks y fakes |
| BenchmarkDotNet | **0.15.x** | Benchmarking |
| dotnet-counters / trace / dump | **10.x** | Diagnóstico y profiling |
| ASP.NET Core | **10.0** | APIs, Minimal API, SignalR |
| EF Core + Npgsql | **10.0** | Persistencia relacional |
| PostgreSQL | **16+** | Base de datos |
| Testcontainers | **4.x** | Tests de integración con contenedores |
| gRPC (Grpc.AspNetCore) | **2.x** | Comunicación entre servicios |
| MassTransit + RabbitMQ | **9.x / 4.x** | Mensajería y eventos |
| Redis | **7+** | Caché y backplane |
| OpenTelemetry | **1.x** | Trazas y métricas |
| Blazor | **10.0** | UI web (SSR, Server, WASM, Auto) |
| .NET MAUI | **10.0** | UI móvil (Android en Linux) |
| Docker | **26+** | Contenedores |
| GitHub Actions | — | CI/CD |

**Entorno de desarrollo**: Linux / WSL2 + VS Code
**Despliegue**: contenedores vía GitHub Actions

---

## 🚀 Inicio Rápido

### Prerrequisitos

- **.NET 10 SDK** instalado (`global.json` en la raíz fija la versión) — ver [`docs/setup`](docs/setup/README.md)
- **Docker** para levantar PostgreSQL, RabbitMQ y Redis en local (a partir de la semana 17)
- **Git** para control de versiones
- **VS Code** (recomendado) con las extensiones incluidas en `.vscode/extensions.json`

### 1. Clonar el Repositorio

```bash
git clone https://github.com/ergrato-dev/bc-csharp.git
cd bc-csharp
dotnet --version   # debe mostrar 10.0.x
```

### 2. Instalar Extensiones de VS Code

```bash
code .
# Las extensiones recomendadas aparecerán automáticamente
# O ejecutar: Ctrl+Shift+P → "Extensions: Show Recommended Extensions"
```

### 3. Navegar a la Semana Actual

```bash
cd bootcamp/week-01-dotnet_setup_tipos_control_flujo
```

### 4. Seguir las Instrucciones

Cada semana contiene un `README.md` con objetivos, contenidos, distribución del tiempo y entregables. Los ejercicios se ejecutan con `dotnet run` dentro de su carpeta `starter/`.

---

## 📊 Metodología de Aprendizaje

### Estrategias Didácticas

- 🎯 **Aprendizaje Basado en Proyectos (ABP)**
- 🏛️ **Dominios Únicos**: cada aprendiz aplica conceptos a su dominio asignado (anticopia)
- 🧩 **Práctica Deliberada**: ejercicios guiados por descomentar, con verificación inmediata
- 🔬 **Bajo el capó**: cada tema explica qué genera el compilador y qué hace el runtime
- 📏 **Medir antes de optimizar**: benchmarks y profiling como hábito desde la fase 4
- 👥 **Code Review entre pares**
- 🎮 **Live Coding**

### Distribución del Tiempo (10 h/semana)

- **Teoría**: ~3 horas
- **Ejercicios**: ~3 horas
- **Proyecto**: ~3.5 horas
- **Glosario, recursos y revisión**: ~0.5 horas

### Evaluación

Cada semana incluye tres tipos de evidencias:

1. **Conocimiento 🧠** (30%): cuestionarios y evaluaciones teóricas
2. **Desempeño 💪** (40%): ejercicios prácticos en clase
3. **Producto 📦** (30%): entregables evaluables (proyectos funcionales)

**Criterio de aprobación**: mínimo 70% en cada tipo de evidencia. `dotnet build -warnaserror` limpio. Implementación coherente con el dominio asignado. Originalidad: sin copia entre aprendices.

---

## 🏛️ Política de Dominios Únicos (Anticopia)

Cada aprendiz recibe un **dominio único asignado por el instructor** desde la primera clase, que usa en todos los proyectos del bootcamp.

Ejemplos de dominios: 📖 Biblioteca, 💊 Farmacia, 🏋️ Gimnasio, 🏫 Escuela, 🏬 Tienda de mascotas, 🍽️ Restaurante, 🏦 Banco, 🚕 Taxis, 🏥 Hospital, 🎥 Cine, 🏞️ Hotel, ✈️ Viajes, 🏎️ Concesionario, 👗 Ropa, 🛠️ Taller, y más — lista completa en [docs/dominios-unicos.md](docs/dominios-unicos.md).

**Objetivo:**

- ✅ Prevenir copia entre estudiantes
- ✅ Fomentar implementaciones originales
- ✅ Aplicar conceptos generales a contextos específicos
- ✅ Desarrollar capacidad de abstracción y adaptación

**Responsabilidades del instructor:**

1. Asignar un dominio único a cada aprendiz al inicio
2. Mantener registro de dominios asignados
3. No repetir dominios en el mismo grupo
4. Validar coherencia con el dominio en evaluaciones

---

## 📞 Soporte

- 💬 **Discussions**: [GitHub Discussions](https://github.com/ergrato-dev/bc-csharp/discussions)
- 🐛 **Issues**: [GitHub Issues](https://github.com/ergrato-dev/bc-csharp/issues)

---

## ⚠️ Exención de Responsabilidad

Este repositorio es un recurso **educativo** creado con fines de aprendizaje. Al utilizarlo, aceptas los siguientes términos:

- **Solo fines educativos**: el contenido, los ejemplos de código y los proyectos están diseñados exclusivamente para la enseñanza y el aprendizaje. No constituyen asesoramiento profesional, legal ni de seguridad.
- **Sin garantías**: el material se proporciona **"tal cual"**, sin garantías de ningún tipo, expresas o implícitas, incluyendo idoneidad para un propósito particular o ausencia de errores.
- **Código en producción**: los ejemplos de código son ilustrativos. Antes de usarlos en entornos productivos, debes realizar revisiones de seguridad, rendimiento y adaptación a tu contexto específico.
- **Versiones de software**: las versiones de librerías y herramientas mencionadas pueden quedar desactualizadas. Consulta siempre la documentación oficial más reciente.
- **Licencias de terceros**: algunas librerías usadas en semanas avanzadas (por ejemplo MassTransit 9) tienen licencias comerciales para uso en producción; el bootcamp las usa con fines educativos y documenta alternativas libres.
- **Limitación de responsabilidad**: los autores y contribuidores no se responsabilizan por pérdidas de datos, daños directos o indirectos, interrupciones de servicio ni cualquier otro perjuicio derivado del uso de este material.
- **Responsabilidad del estudiante**: cada estudiante es responsable de sus propias implementaciones, entornos de desarrollo y decisiones técnicas.

---

## 📄 Licencia

Este proyecto está bajo la licencia **[CC BY-NC-SA 4.0](https://creativecommons.org/licenses/by-nc-sa/4.0/)** (Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International).

**Puedes:** compartir y adaptar el material, incluso crear forks educativos.
**No puedes:** usar este material con fines comerciales.
**Debes:** dar crédito apropiado y distribuir las adaptaciones bajo la misma licencia.

Ver el archivo [LICENSE](LICENSE) para el texto completo.

---

## 🏆 Agradecimientos

- [.NET](https://dotnet.microsoft.com/) — por la plataforma unificada y de código abierto
- [Roslyn](https://github.com/dotnet/roslyn) — por el compilador de C# y su ecosistema de analyzers
- [BenchmarkDotNet](https://benchmarkdotnet.org/) — por hacer medible el rendimiento
- [xUnit](https://xunit.net/) — por el framework de tests
- [Npgsql](https://www.npgsql.org/) — por el proveedor PostgreSQL para .NET
- [SharpLab](https://sharplab.io/) — por mostrar lo que genera el compilador
- Comunidad .NET — por los recursos y ejemplos
- Todos los contribuidores

---

## 📚 Documentación Adicional

- [🤖 Instrucciones de Copilot](.github/copilot-instructions.md)
- [📜 Código de Conducta](CODE_OF_CONDUCT.md)
- [🔒 Política de Seguridad](SECURITY.md)
- [🛠️ Setup del entorno](docs/setup/README.md)
- [📌 Política de versiones de dependencias](docs/politica-versiones-dependencias.md)
- [🏛️ Dominios únicos por aprendiz](docs/dominios-unicos.md)

---

<p align="center">
  <strong>🎓 Bootcamp C# - Zero to Hero</strong><br>
  <em>De desarrollador en otro lenguaje a desarrollador C#/.NET avanzado en 6 meses</em>
</p>

<p align="center">
  <a href="bootcamp/week-01-dotnet_setup_tipos_control_flujo">Comenzar Semana 1</a> •
  <a href="docs">Ver Documentación</a> •
  <a href="https://github.com/ergrato-dev/bc-csharp/issues">Reportar Issue</a>
</p>

<p align="center">
  Hecho con ❤️ para la comunidad de desarrolladores
</p>
