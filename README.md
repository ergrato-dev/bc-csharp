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

---

## 📋 Descripción

Bootcamp intensivo de **26 semanas (~6 meses, 10 h/semana, 260 h)** que lleva a desarrolladores con experiencia previa en otro lenguaje hasta **desarrollador C#/.NET avanzado**: dominio profundo del lenguaje (C# 14), internals del CLR y rendimiento, concurrencia, backend con ASP.NET Core y EF Core, comunicación con gRPC/SignalR/mensajería, UI con Blazor y .NET MAUI, y despliegue en producción con Docker y CI/CD.

### 🎯 Objetivos

Al finalizar el bootcamp, los estudiantes serán capaces de:

- ✅ Dominar la sintaxis y el sistema de tipos de C# 14: clases, structs, records, enums, genéricos y varianza
- ✅ Aplicar POO, SOLID y patrones de diseño con inyección de dependencias
- ✅ Usar delegados, eventos, lambdas, LINQ y pattern matching con fluidez
- ✅ Escribir código asíncrono correcto con `async`/`await`, cancelación y `IAsyncEnumerable`
- ✅ Explicar el CLR, el JIT, el GC y el layout de memoria, y medir con BenchmarkDotNet y dotnet-tools
- ✅ Escribir código de alto rendimiento con `Span<T>`, `ArrayPool`, `ref struct` y parsing zero-allocation
- ✅ Usar reflection, atributos, source generators y analyzers Roslyn
- ✅ Programar concurrencia segura: `lock`, `Interlocked`, colecciones concurrentes, `Parallel`, `Channel<T>`
- ✅ Construir APIs con ASP.NET Core Minimal API, EF Core + PostgreSQL y OpenAPI
- ✅ Testear con xUnit, NSubstitute, `WebApplicationFactory` y Testcontainers
- ✅ Comunicar servicios con gRPC, SignalR y mensajería (RabbitMQ/MassTransit, outbox, idempotencia)
- ✅ Construir interfaces con Blazor (SSR/Server/WASM) y apps móviles con .NET MAUI
- ✅ Contenedorizar, desplegar con GitHub Actions y operar con OpenTelemetry, health checks y resiliencia

### 🚀 ¿Por qué C# y .NET 10?

> **Un lenguaje, toda la plataforma** — backend, tiempo real, móvil, web y alto rendimiento con el mismo runtime.

C# es un lenguaje moderno con evolución anual, tipado fuerte, rendimiento cercano a nativo y un ecosistema unificado. Este bootcamp usa **.NET 10 LTS** y **C# 14**, Linux-first (WSL válido), sin código legacy (.NET Framework, WebForms) y con foco en las prácticas que se usan en producción hoy.

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

**Total: 26 semanas** | **260 horas** | 150 archivos de teoría · 122 diagramas SVG · 50 ejercicios · 26 proyectos

---

## 📚 Contenido por Semana

| Semana | Slug | Tema | Teoría | SVG | Ejercicios |
|:------:|------|------|:------:|:---:|:----------:|
| 01 | `dotnet_setup_tipos_control_flujo` | Setup .NET, tipos y control de flujo | 6 | 5 | 2 |
| 02 | `metodos_strings_colecciones` | Métodos, strings y colecciones | 7 | 6 | 2 |
| 03 | `excepciones_io_json_debugging` | Excepciones, I/O, JSON y debugging | 5 | 3 | 2 |
| 04 | `clases_herencia_interfaces` | Clases, herencia e interfaces | 7 | 6 | 2 |
| 05 | `structs_records_enums_genericos` | Structs, records, enums y genéricos | 6 | 5 | 2 |
| 06 | `solid_patrones_xunit` | SOLID, patrones y xUnit | 6 | 5 | 2 |
| 07 | `delegados_eventos_lambdas` | Delegados, eventos y lambdas | 5 | 4 | 2 |
| 08 | `linq` | LINQ | 6 | 5 | 2 |
| 09 | `pattern_matching_nullable` | Pattern matching y nullable | 5 | 4 | 2 |
| 10 | `async_await` | Async/await | 6 | 5 | 2 |
| 11 | `clr_memoria_gc` | CLR, memoria y GC | 6 | 6 | 2 |
| 12 | `alto_rendimiento_memoria` | Alto rendimiento y memoria | 6 | 5 | 2 |
| 13 | `benchmarking_profiling` | Benchmarking y profiling | 5 | 4 | 2 |
| 14 | `reflection_atributos_source_generators` | Reflection, atributos y source generators | 6 | 5 | 2 |
| 15 | `concurrencia_paralelismo` | Concurrencia y paralelismo | 6 | 6 | 2 |
| 16 | `aspnet_core_minimal_api` | ASP.NET Core Minimal API | 6 | 5 | 2 |
| 17 | `ef_core_persistencia` | EF Core y persistencia | 6 | 5 | 2 |
| 18 | `testing_calidad` | Testing y calidad | 6 | 4 | 2 |
| 19 | `grpc_signalr` | gRPC y SignalR | 6 | 5 | 2 |
| 20 | `mensajeria_eventos` | Mensajería y arquitectura orientada a eventos | 6 | 5 | 2 |
| 21 | `blazor_fundamentos` | Blazor fundamentos | 6 | 4 | 2 |
| 22 | `blazor_avanzado` | Blazor avanzado | 6 | 4 | 2 |
| 23 | `maui_multiplataforma` | .NET MAUI multiplataforma | 6 | 4 | 2 |
| 24 | `docker_cicd` | Docker y CI/CD | 5 | 4 | 2 |
| 25 | `observabilidad_resiliencia_seguridad` | Observabilidad, resiliencia y seguridad | 6 | 5 | 2 |
| 26 | `proyecto_final` | Proyecto final | 3 | 3 | 0 |

Cada semana incluye:

```
bootcamp/week-XX-tema_principal/
├── README.md                 # Descripción y objetivos
├── rubrica-evaluacion.md     # Criterios de evaluación (30/40/30)
├── 0-assets/                 # Diagramas SVG
├── 1-teoria/                 # Material teórico
├── 2-practicas/              # Ejercicios guiados (patrón uncomment)
├── 3-proyecto/               # Proyecto semanal (TODOs, dominio único)
├── 4-recursos/               # ebooks-free · videografia · webgrafia
└── 5-glosario/               # Términos clave
```

## ⏱️ Dedicación semanal (10 h)

| Actividad | Tiempo |
|-----------|-------:|
| Teoría | ~3 h |
| Ejercicios guiados | ~3 h |
| Proyecto semanal | ~3.5 h |
| Glosario, recursos y revisión | ~0.5 h |

## 🛠️ Stack

- .NET 10 SDK (LTS) · C# 14 · VS Code + C# Dev Kit
- xUnit · FluentAssertions · NSubstitute · BenchmarkDotNet · Testcontainers
- ASP.NET Core · EF Core 10 · PostgreSQL 16 · RabbitMQ · Redis
- gRPC · SignalR · MassTransit · OpenTelemetry
- Blazor · .NET MAUI (Android en Linux)
- Docker · GitHub Actions

Ver [docs/setup](docs/setup/README.md) para instalar el entorno.

## 📊 Evaluación

| Evidencia | Peso |
|-----------|:----:|
| Conocimiento 🧠 | 30% |
| Desempeño 💪 | 40% |
| Producto 📦 | 30% |

Mínimo 70% por evidencia. Cada aprendiz trabaja sobre un **dominio único** asignado por el instructor (política anticopia).

## 📄 Licencia

[CC BY-NC-SA 4.0](LICENSE) — ergrato-dev.
