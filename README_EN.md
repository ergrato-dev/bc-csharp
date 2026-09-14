<p align="center">
  <img src="assets/bootcamp-header.svg" alt="C# Zero to Hero Bootcamp" width="1200">
</p>

<p align="center">
  <a href="LICENSE"><img src="https://img.shields.io/badge/license-CC%20BY--NC--SA%204.0-lightgrey.svg" alt="License CC BY-NC-SA 4.0"></a>
  <a href="#"><img src="https://img.shields.io/badge/weeks-26-yellow.svg" alt="26 Weeks"></a>
  <a href="#"><img src="https://img.shields.io/badge/hours-260-orange.svg" alt="260 Hours"></a>
  <a href="#"><img src="https://img.shields.io/badge/C%23-14-512BD4?logo=csharp&logoColor=white" alt="C# 14"></a>
  <a href="#"><img src="https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white" alt=".NET 10"></a>
</p>

<p align="center">
  <a href="README.md"><img src="https://img.shields.io/badge/🇪🇸_Español-0969DA?style=for-the-badge&logoColor=white" alt="Versión en español"></a>
</p>

---

## 📋 Overview

A **26-week (~6 months, 10 h/week, 260 h)** intensive bootcamp focused on mastering **C# and the .NET platform**. Designed to take developers with prior experience in another language to **advanced C#/.NET developer**: deep language mastery (C# 14), CLR internals and performance, concurrency, backend with ASP.NET Core and EF Core, service communication with gRPC/SignalR/messaging, UI with Blazor and .NET MAUI, and production deployment with Docker and CI/CD.

> All course content (theory, exercises, projects) is written in **Spanish**. Code, identifiers and technical comments are in English.

### 🎯 Outcomes

By the end of the bootcamp, students will be able to:

- ✅ Master C# 14 syntax and type system: classes, structs, records, enums, generics and variance
- ✅ Apply OOP, SOLID and design patterns with dependency injection
- ✅ Use delegates, events, lambdas, LINQ and pattern matching fluently
- ✅ Write correct async code with `async`/`await`, cancellation and `IAsyncEnumerable`
- ✅ Explain the CLR, JIT, GC and memory layout; measure with BenchmarkDotNet and dotnet-tools
- ✅ Write high-performance code with `Span<T>`, `ArrayPool`, `ref struct` and zero-allocation parsing
- ✅ Use reflection, attributes, source generators and Roslyn analyzers
- ✅ Program safe concurrency: `lock`, `Interlocked`, concurrent collections, `Parallel`, `Channel<T>`
- ✅ Build APIs with ASP.NET Core Minimal API, EF Core + PostgreSQL and OpenAPI
- ✅ Test with xUnit, NSubstitute, `WebApplicationFactory` and Testcontainers
- ✅ Connect services with gRPC, SignalR and messaging (RabbitMQ/MassTransit, outbox, idempotency)
- ✅ Build UIs with Blazor (SSR/Server/WASM/Auto) and mobile apps with .NET MAUI
- ✅ Containerize, deploy with GitHub Actions and operate with OpenTelemetry, health checks and resilience

### 🚀 Why C# and .NET 10?

> **One language, the whole platform** — backend, real-time, mobile, web and high performance on the same runtime.

C# is a modern language with yearly evolution, strong typing, near-native performance and a unified ecosystem. This bootcamp uses **.NET 10 LTS** and **C# 14**, is Linux-first (WSL works), skips legacy code (.NET Framework, WebForms, WCF) and focuses on the practices used in production today.

---

## 🗓️ Bootcamp Structure

| Phase | Weeks | Hours |
|:-----:|:-----:|:-----:|
| **Accelerated fundamentals** | 01-03 | 30h |
| **OOP and design** | 04-06 | 30h |
| **Modern C#** | 07-10 | 40h |
| **Internals and performance** | 11-14 | 40h |
| **Concurrency and platform** | 15-18 | 40h |
| **Communication and events** | 19-20 | 20h |
| **UI: Blazor and MAUI** | 21-23 | 30h |
| **Production and final project** | 24-26 | 30h |

**Total: 26 weeks** | **260 hours** of intensive training | 150 theory files · 122 SVG diagrams · 50 exercises · 26 projects

---

## 📚 Weekly Content

Each week includes:

```
bootcamp/week-XX-topic/
├── README.md                 # Goals and contents
├── rubrica-evaluacion.md     # Grading rubric (30/40/30)
├── 0-assets/                 # SVG diagrams
├── 1-teoria/                 # Theory
├── 2-practicas/              # Guided exercises (uncomment pattern)
├── 3-proyecto/               # Weekly project (TODOs, unique domain per student)
├── 4-recursos/               # Extra resources
│   ├── ebooks-free/
│   ├── videografia/
│   └── webgrafia/
└── 5-glosario/               # Glossary
```

| Week | Topic | Description |
|:----:|-------|-------------|
| 01 | `dotnet_setup_tipos_control_flujo` | SDK .NET 10, `dotnet` CLI, projects and solutions, top-level `Program.cs`, type system, conversions, operators and control flow (incl. `switch` expression) |
| 02 | `metodos_strings_colecciones` | Methods and parameter passing (`ref`/`out`/`in`/`params`), overloading, recursion, immutable `string` and interpolation, `StringBuilder`, arrays, `List<T>`, `Dictionary<K,V>`, `HashSet<T>`, `Queue`/`Stack`, indices `^` and ranges `..`, collection expressions |
| 03 | `excepciones_io_json_debugging` | Exceptions and `when` filters, custom exceptions, `throw` expressions, VS Code debugger, `System.IO` (File/Path/Directory/streams), `System.Text.Json` |
| 04 | `clases_herencia_interfaces` | Classes, properties (`init`, `required`, `field`), primary constructors, `static`, `partial`, inheritance, `virtual`/`override`/`abstract`/`sealed`, `object` (`Equals`/`GetHashCode`/`ToString`), interfaces and default members, composition vs inheritance |
| 05 | `structs_records_enums_genericos` | `struct`/`readonly struct`, `record`/`record struct`, value equality and `with`, `enum` and `[Flags]`, generics, `where` constraints, `in`/`out` variance, `Nullable<T>` |
| 06 | `solid_patrones_xunit` | SOLID, DRY/KISS, manual dependency injection, Factory, Strategy, Observer, Builder, Repository, Decorator patterns; xUnit intro to validate design |
| 07 | `delegados_eventos_lambdas` | `delegate`, `Func`/`Action`/`Predicate`, multicast, lambdas and closures, `event`/`EventHandler<T>`, extension methods and extension members (C# 14), expression trees intro |
| 08 | `linq` | `IEnumerable<T>` and `yield`, deferred execution, method vs query syntax, filtering, projection, grouping, joins, set, aggregation, `IQueryable` intro, performance |
| 09 | `pattern_matching_nullable` | Tuples and deconstruction, patterns (type, property, positional, relational, list, `and`/`or`/`not`), advanced `switch`, nullable reference types, `?.`/`??`/`!`, nullability attributes |
| 10 | `async_await` | `Task`/`Task<T>`, `async`/`await` and the state machine, `ConfigureAwait`, `CancellationToken`, `IAsyncEnumerable`, `ValueTask`, anti-patterns (`async void`, `.Result`), `Task.WhenAll`/`WhenAny`, `HttpClient` |
| 11 | `clr_memoria_gc` | CLR, tiered JIT/ReadyToRun/Native AOT, assemblies and IL, stack/heap, GC generations and LOH, `IDisposable`/`using`/finalizers, `SafeHandle`, `WeakReference` |
| 12 | `alto_rendimiento_memoria` | `Span<T>`/`ReadOnlySpan<T>`/`Memory<T>`, `stackalloc`, `ArrayPool`, `ref` locals/returns, `ref struct`, `in`, `unsafe` and pointers, zero-allocation parsing, `System.Buffers` |
| 13 | `benchmarking_profiling` | BenchmarkDotNet, `dotnet-counters`/`dotnet-trace`/`dotnet-dump`, boxing and hidden allocations, measured `struct` vs `class`, `FrozenDictionary`, `SearchValues`, data-driven optimization |
| 14 | `reflection_atributos_source_generators` | Custom attributes, reflection, `dynamic`, expression trees, source generators (`IIncrementalGenerator`), Roslyn analyzers, `[GeneratedRegex]`, interceptors |
| 15 | `concurrencia_paralelismo` | `Thread` and thread pool, `lock`/`Lock`, `Monitor`, `Interlocked`, `SemaphoreSlim`, concurrent collections, `Parallel`/PLINQ, `Channel<T>`, TPL Dataflow intro, race conditions and deadlocks |
| 16 | `aspnet_core_minimal_api` | Hosting and middleware pipeline, DI container, `IOptions` and configuration, logging, minimal APIs, routing and binding, validation and `ProblemDetails`, OpenAPI, `HttpClientFactory`, `BackgroundService` |
| 17 | `ef_core_persistencia` | `DbContext` and modeling, migrations, relationships, LINQ-to-SQL translation, tracking vs no-tracking, N+1, transactions, optimistic concurrency, Dapper comparison, PostgreSQL with Npgsql. `Guid` PKs |
| 18 | `testing_calidad` | Advanced xUnit (theories, fixtures), FluentAssertions, NSubstitute, `WebApplicationFactory`, Testcontainers, coverage, mutation testing intro, vertical slice, analyzers and EditorConfig |
| 19 | `grpc_signalr` | Protobuf and contracts, gRPC services, streaming (server/client/bidi), interceptors, gRPC-Web, SignalR hubs, groups, hub authentication, backplane scaling |
| 20 | `mensajeria_eventos` | RabbitMQ with MassTransit, publish/subscribe, consumers, retries and dead-letter, outbox, idempotency, sagas intro, decoupled workers, Kafka comparison |
| 21 | `blazor_fundamentos` | Component model, render modes (SSR, Server, WebAssembly, Auto), routing, parameters and cascading values, events, forms and validation, lifecycle |
| 22 | `blazor_avanzado` | State management, DI in components, JS interop, authentication and authorization, typed API consumption, PWA, testing with bUnit |
| 23 | `maui_multiplataforma` | XAML and layouts, MVVM with CommunityToolkit.Mvvm, Shell navigation, platform access, Blazor Hybrid, Android publishing (Linux) — iOS/Windows need their own host |
| 24 | `docker_cicd` | `dotnet publish` (trimming, AOT, single-file), multi-stage Dockerfile, docker-compose with PostgreSQL and RabbitMQ, secrets, GitHub Actions, versioning and private NuGet |
| 25 | `observabilidad_resiliencia_seguridad` | Structured `ILogger`, OpenTelemetry, health checks, `Microsoft.Extensions.Resilience`/Polly, rate limiting, JWT and minimal Identity, OWASP in .NET, `System.Security.Cryptography` |
| 26 | `proyecto_final` | Capstone: API + messaging worker + gRPC/SignalR + Blazor + domain library + tests + Docker + CI. Code review and presentation |

### 🔑 Key Components

- 📖 **Theory**: concepts with real examples and an "Under the hood" section (what the compiler and runtime do)
- 💻 **Practice**: progressive guided exercises and hands-on projects
- 📝 **Assessment**: knowledge, performance and product evidence
- 🎓 **Resources**: glossaries, references and complementary material

---

## 🛠️ Tech Stack

| Technology | Version | Purpose |
|------------|---------|---------|
| .NET SDK | **10.0 (LTS)** | Runtime and tooling |
| C# | **14** | Main language |
| VS Code + C# Dev Kit | latest | Development environment |
| xUnit | **2.9.x** | Unit testing |
| FluentAssertions | **8.x** | Readable assertions |
| NSubstitute | **6.x** | Mocks and fakes |
| BenchmarkDotNet | **0.15.x** | Benchmarking |
| dotnet-counters / trace / dump | **10.x** | Diagnostics and profiling |
| ASP.NET Core | **10.0** | APIs, Minimal API, SignalR |
| EF Core + Npgsql | **10.0** | Relational persistence |
| PostgreSQL | **16+** | Database |
| Testcontainers | **4.x** | Container-based integration tests |
| gRPC (Grpc.AspNetCore) | **2.x** | Service-to-service communication |
| MassTransit + RabbitMQ | **9.x / 4.x** | Messaging and events |
| Redis | **7+** | Cache and backplane |
| OpenTelemetry | **1.x** | Traces and metrics |
| Blazor | **10.0** | Web UI (SSR, Server, WASM, Auto) |
| .NET MAUI | **10.0** | Mobile UI (Android on Linux) |
| Docker | **26+** | Containers |
| GitHub Actions | — | CI/CD |

**Development environment**: Linux / WSL2 + VS Code
**Deployment**: containers via GitHub Actions

---

## 🚀 Quick Start

### Prerequisites

- **.NET 10 SDK** installed (`global.json` at the root pins the version) — see [`docs/setup`](docs/setup/README.md)
- **Docker** to run PostgreSQL, RabbitMQ and Redis locally (from week 17 on)
- **Git** for version control
- **VS Code** (recommended) with the extensions listed in `.vscode/extensions.json`

### 1. Clone the Repository

```bash
git clone https://github.com/ergrato-dev/bc-csharp.git
cd bc-csharp
dotnet --version   # should print 10.0.x
```

### 2. Install VS Code Extensions

```bash
code .
# Recommended extensions will be suggested automatically
# Or run: Ctrl+Shift+P → "Extensions: Show Recommended Extensions"
```

### 3. Go to the Current Week

```bash
cd bootcamp/week-01-dotnet_setup_tipos_control_flujo
```

### 4. Follow the Instructions

Each week has a `README.md` with goals, contents, time allocation and deliverables. Exercises run with `dotnet run` inside their `starter/` folder.

---

## 📊 Learning Methodology

### Teaching Strategies

- 🎯 **Project-Based Learning (PBL)**
- 🏛️ **Unique Domains**: each learner applies concepts to their assigned domain (anti-plagiarism)
- 🧩 **Deliberate Practice**: uncomment-driven guided exercises with immediate verification
- 🔬 **Under the hood**: every topic explains what the compiler generates and what the runtime does
- 📏 **Measure before optimizing**: benchmarks and profiling as a habit from phase 4
- 👥 **Peer Code Review**
- 🎮 **Live Coding**

### Time Allocation (10 h/week)

- **Theory**: ~3 hours
- **Exercises**: ~3 hours
- **Project**: ~3.5 hours
- **Glossary, resources and review**: ~0.5 hours

### Assessment

Each week includes three types of evidence:

1. **Knowledge 🧠** (30%): quizzes and theory assessments
2. **Performance 💪** (40%): in-class practical exercises
3. **Product 📦** (30%): gradable deliverables (working projects)

**Passing criteria**: minimum 70% in each evidence type. Clean `dotnet build -warnaserror`. Implementation consistent with the assigned domain. Originality: no copying between learners.

---

## 🏛️ Unique Domain Policy (Anti-plagiarism)

Each learner receives a **unique domain assigned by the instructor** from the first class and uses it in every project of the bootcamp.

Example domains: 📖 Library, 💊 Pharmacy, 🏋️ Gym, 🏫 School, 🏬 Pet shop, 🍽️ Restaurant, 🏦 Bank, 🚕 Taxi agency, 🏥 Hospital, 🎥 Cinema, 🏞️ Hotel, ✈️ Travel agency, 🏎️ Car dealership, 👗 Clothing store, 🛠️ Auto repair shop, and more — full list in [docs/dominios-unicos.md](docs/dominios-unicos.md).

**Goals:**

- ✅ Prevent copying between students
- ✅ Encourage original implementations
- ✅ Apply general concepts to specific contexts
- ✅ Develop abstraction and adaptation skills

**Instructor responsibilities:**

1. Assign a unique domain to each learner at the start
2. Keep a record of assigned domains
3. Never repeat domains within the same group
4. Validate domain consistency during assessments

---

## 📞 Support

- 💬 **Discussions**: [GitHub Discussions](https://github.com/ergrato-dev/bc-csharp/discussions)
- 🐛 **Issues**: [GitHub Issues](https://github.com/ergrato-dev/bc-csharp/issues)

---

## ⚠️ Disclaimer

This repository is an **educational** resource created for learning purposes. By using it, you accept the following terms:

- **Educational use only**: the content, code examples and projects are designed exclusively for teaching and learning. They do not constitute professional, legal or security advice.
- **No warranties**: the material is provided **"as is"**, without warranties of any kind, express or implied, including fitness for a particular purpose or absence of errors.
- **Production code**: code examples are illustrative. Before using them in production environments you must perform security, performance and context-specific reviews.
- **Software versions**: library and tool versions mentioned may become outdated. Always consult the latest official documentation.
- **Third-party licenses**: some libraries used in advanced weeks (e.g. MassTransit 9) carry commercial licenses for production use; the bootcamp uses them for educational purposes and documents free alternatives.
- **Limitation of liability**: the authors and contributors are not responsible for data loss, direct or indirect damages, service interruptions or any other harm arising from the use of this material.
- **Student responsibility**: each student is responsible for their own implementations, development environments and technical decisions.

---

## 📄 License

This project is licensed under **[CC BY-NC-SA 4.0](https://creativecommons.org/licenses/by-nc-sa/4.0/)** (Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International).

**You may:** share and adapt the material, including educational forks.
**You may not:** use this material for commercial purposes.
**You must:** give appropriate credit and distribute adaptations under the same license.

See the [LICENSE](LICENSE) file for the full text.

---

## 🏆 Acknowledgements

- [.NET](https://dotnet.microsoft.com/) — for the unified, open-source platform
- [Roslyn](https://github.com/dotnet/roslyn) — for the C# compiler and its analyzer ecosystem
- [BenchmarkDotNet](https://benchmarkdotnet.org/) — for making performance measurable
- [xUnit](https://xunit.net/) — for the testing framework
- [Npgsql](https://www.npgsql.org/) — for the PostgreSQL provider for .NET
- [SharpLab](https://sharplab.io/) — for showing what the compiler generates
- The .NET community — for resources and examples
- All contributors

---

## 📚 Additional Documentation

- [🤖 Copilot Instructions](.github/copilot-instructions.md)
- [📜 Code of Conduct](CODE_OF_CONDUCT.md)
- [🔒 Security Policy](SECURITY.md)
- [🛠️ Environment setup](docs/setup/README.md)
- [📌 Dependency version policy](docs/politica-versiones-dependencias.md)
- [🏛️ Unique domains per learner](docs/dominios-unicos.md)

---

<p align="center">
  <strong>🎓 C# Bootcamp - Zero to Hero</strong><br>
  <em>From developer in another language to advanced C#/.NET developer in 6 months</em>
</p>

<p align="center">
  <a href="bootcamp/week-01-dotnet_setup_tipos_control_flujo">Start Week 1</a> •
  <a href="docs">Documentation</a> •
  <a href="https://github.com/ergrato-dev/bc-csharp/issues">Report an Issue</a>
</p>

<p align="center">
  Made with ❤️ for the developer community
</p>
