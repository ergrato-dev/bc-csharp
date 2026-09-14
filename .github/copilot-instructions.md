# 🤖 Instrucciones para GitHub Copilot

## 📋 Contexto del Bootcamp

Este es un **Bootcamp de C# Zero to Hero** estructurado para llevar a
desarrolladores con experiencia en otro lenguaje hasta un nivel **avanzado en
C# y .NET**: lenguaje a fondo, internals del CLR y rendimiento, concurrencia,
backend con ASP.NET Core y EF Core, comunicación entre servicios, UI con Blazor
y .NET MAUI, y operación en producción.

### 📊 Datos del Bootcamp

- **Duración**: 26 semanas (~6 meses)
- **Dedicación semanal**: 10 horas
- **Total de horas**: 260 horas
- **Nivel de entrada**: Desarrollador con experiencia en otro lenguaje (variables, funciones, bucles, terminal)
- **Nivel de salida**: Desarrollador C#/.NET avanzado
- **Enfoque**: C# 14 moderno, rendimiento, concurrencia y plataforma .NET completa
- **Stack**: .NET 10 LTS, C# 14, xUnit, BenchmarkDotNet, ASP.NET Core, EF Core 10, PostgreSQL 16, RabbitMQ, Redis, gRPC, SignalR, MassTransit, OpenTelemetry, Blazor, .NET MAUI, Docker, GitHub Actions
- **Plataforma de desarrollo**: Linux-first (WSL válido). MAUI solo compila Android en Linux; iOS/Windows se documentan como opcionales.

---

## 🎯 Objetivos de Aprendizaje

Al finalizar el bootcamp, los estudiantes serán capaces de:

- ✅ Dominar la sintaxis y el sistema de tipos de C# 14: clases, structs, records, enums, genéricos y varianza
- ✅ Aplicar POO, SOLID y patrones de diseño con inyección de dependencias
- ✅ Usar delegados, eventos, lambdas, LINQ y pattern matching con fluidez
- ✅ Escribir código asíncrono correcto con `async`/`await`, cancelación e `IAsyncEnumerable`
- ✅ Explicar CLR, JIT, GC y layout de memoria; medir con BenchmarkDotNet y dotnet-tools
- ✅ Escribir código de alto rendimiento con `Span<T>`, `ArrayPool`, `ref struct` y parsing zero-allocation
- ✅ Usar reflection, atributos, source generators y analyzers Roslyn
- ✅ Programar concurrencia segura: `lock`, `Interlocked`, colecciones concurrentes, `Parallel`, `Channel<T>`
- ✅ Construir APIs con ASP.NET Core Minimal API, EF Core + PostgreSQL y OpenAPI
- ✅ Testear con xUnit, NSubstitute, `WebApplicationFactory` y Testcontainers
- ✅ Comunicar servicios con gRPC, SignalR y mensajería (RabbitMQ/MassTransit, outbox, idempotencia)
- ✅ Construir interfaces con Blazor (SSR/Server/WASM/Auto) y apps móviles con .NET MAUI
- ✅ Contenedorizar, desplegar con GitHub Actions y operar con OpenTelemetry, health checks y resiliencia

---

## 📚 Estructura del Bootcamp

### Distribución por Fases

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

### Contenido Semana a Semana

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

El número de archivos de teoría, diagramas y ejercicios por semana lo dicta el
contenido, no una cuota fija. La tabla es el plan de referencia; ajustar solo
con justificación pedagógica y actualizando README raíz, esta tabla y el
README de la semana a la vez.

---

## 🗂️ Estructura de Carpetas

Cada semana sigue esta estructura estándar:

```
bootcamp/week-XX-tema_principal/
├── README.md                 # Descripción y objetivos de la semana
├── rubrica-evaluacion.md     # Criterios de evaluación detallados
├── 0-assets/                 # Diagramas SVG (README.md lista los planificados)
├── 1-teoria/                 # Material teórico (archivos .md numerados)
├── 2-practicas/              # Ejercicios guiados paso a paso
│   └── ejercicio-XX-tema/
│       ├── README.md
│       └── starter/          # Exercise.csproj + Program.cs (patrón uncomment)
├── 3-proyecto/               # Proyecto semanal integrador
│   ├── README.md             # Instrucciones genéricas por dominio
│   ├── starter/              # Project.csproj + código con TODOs
│   └── solution/             # ⚠️ OCULTA - Solo instructores (.gitignore)
├── 4-recursos/
│   ├── ebooks-free/
│   ├── videografia/
│   └── webgrafia/
└── 5-glosario/
    └── README.md             # Términos clave A-Z
```

### 📁 Carpetas Raíz

- **`assets/`**: Recursos visuales globales (header del bootcamp)
- **`docs/`**: Setup del entorno y documentación transversal
- **`bootcamp/`**: Contenido semanal
- **`global.json`**: SDK fijado (.NET 10, `latestPatch`)

---

## 🎓 Componentes de Cada Semana

### 1. Teoría (1-teoria/)

- Archivos markdown con explicaciones conceptuales en español
- Ejemplos de código C# con nombres en inglés y comentarios pedagógicos en español
- Diagramas SVG cuando aporten (nunca ASCII art), vinculados desde `../0-assets/`
- Referencias a [learn.microsoft.com/dotnet](https://learn.microsoft.com/dotnet/) y a la especificación del lenguaje
- **Extensión objetivo: ~150 líneas por archivo** (no superar 200 — dividir si hace falta)
- Cuando aplique, incluir sección **"Bajo el capó"** (qué genera el compilador / qué hace el runtime) — es el diferencial de nivel avanzado

### 2. Prácticas (2-practicas/)

Los ejercicios son **tutoriales guiados**, NO tareas con TODOs. El estudiante aprende descomentando código y ejecutando `dotnet run`:

**README.md del ejercicio:**

```markdown
### Paso 1: Declarar un record inmutable

Explicación del concepto con ejemplo:

\`\`\`csharp
public record Product(string Name, decimal Price);
\`\`\`

**Abre `starter/Program.cs`** y descomenta la sección `PASO 1`.
```

**starter/Program.cs:**

```csharp
// ============================================
// PASO 1: Record inmutable
// ============================================
// Un record genera Equals, GetHashCode y ToString por valor.
// Descomenta las siguientes líneas:
// var product = new Product("Keyboard", 49.99m);
// Console.WriteLine(product);
```

> ⚠️ Los ejercicios NO tienen carpeta `solution/`. Cada `starter/` es un proyecto de consola independiente (`Exercise.csproj`) que compila desde el paso 0.

❌ NO usar en ejercicios: `// TODO: implementar` con cuerpo vacío.
✅ Usar en ejercicios: código completo comentado para descomentar.

### 3. Proyecto (3-proyecto/)

- Proyecto integrador con instrucciones genéricas adaptables a cualquier dominio
- Código inicial en `starter/` con TODOs (aquí SÍ)
- `solution/` oculta en `.gitignore`, solo instructores
- **Política de Dominios Únicos** (anticopia): cada aprendiz recibe un dominio distinto (biblioteca, farmacia, gimnasio, escuela, tienda de mascotas, restaurante, banco, taxis, hospital, cine, hotel, agencia de viajes, concesionario, tienda de ropa, taller mecánico, …). El instructor asigna, registra y no repite dominios en el grupo.

**starter con TODOs:**

```csharp
// NOTA PARA EL APRENDIZ:
// Adapta este servicio a tu dominio asignado.
// - Biblioteca: LibroService · Farmacia: MedicamentoService · Gimnasio: MiembroService
public sealed class ItemService(IItemRepository repository)
{
    public Task<IReadOnlyList<Item>> GetAllAsync(CancellationToken ct)
    {
        // TODO: listar con paginación
        throw new NotImplementedException();
    }
}
```

**README.md del proyecto** incluye: objetivo, dominio asignado, requisitos funcionales adaptables, ejemplos de adaptación por dominio, entregables.

### 4. Recursos (4-recursos/) — ebooks gratuitos, vídeos, documentación oficial y artículos.

### 5. Glosario (5-glosario/) — términos A-Z en español con ejemplo cuando aplique.

---

## 📝 Convenciones de Código

### C# moderno (C# 14 / .NET 10)

```csharp
// ✅ BIEN — file-scoped namespace, records para DTOs, nullable habilitado
namespace Bootcamp.Catalog;

public sealed record CreateProductDto(string Name, decimal Price);

public sealed class ProductService(IProductRepository repository)
{
    public async Task<Product> CreateAsync(CreateProductDto dto, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(dto);
        // Guid como PK: se genera en la base de datos (gen_random_uuid)
        var product = new Product { Name = dto.Name, Price = dto.Price };
        await repository.AddAsync(product, ct);
        return product;
    }
}

// ❌ MAL — namespace con llaves, sin nullable, sin CancellationToken, PK int
```

- `<Nullable>enable</Nullable>`, `<ImplicitUsings>enable</ImplicitUsings>`, `<TreatWarningsAsErrors>true</TreatWarningsAsErrors>` en todo `.csproj`
- Constructores primarios, `record` para datos inmutables, `sealed` por defecto en clases no diseñadas para herencia
- Todo método asíncrono termina en `Async` y acepta `CancellationToken`
- Nunca `async void` (salvo event handlers de UI), nunca `.Result`/`.Wait()`
- `var` cuando el tipo es evidente; tipo explícito cuando aporta claridad

### Nomenclatura

- **Tipos, métodos, propiedades**: PascalCase (`ProductService`, `GetByIdAsync`)
- **Variables locales y parámetros**: camelCase (`accessToken`)
- **Campos privados**: `_camelCase`
- **Interfaces**: prefijo `I` (`IProductRepository`)
- **Constantes**: PascalCase (`MaxRetries`)
- **Archivos**: un tipo público por archivo, mismo nombre (`ProductService.cs`)
- **Idioma**: inglés para código y comentarios técnicos, español para documentación y comentarios pedagógicos

### Llaves primarias en EF Core

- **Toda PK es `Guid`**: `public Guid Id { get; init; }` con
  `builder.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()")` (PostgreSQL `uuid`).
- Nunca `int` autoincrement. Las FK son `Guid`. El `{id}` de las rutas se bindea como `Guid`.

### Paquetes NuGet

- Versiones exactas en `<PackageReference Include="..." Version="x.y.z" />` — nunca `*` ni rangos
- Paquetes compartidos entre semanas llevan la MISMA versión en todas
- Sin `packages.lock.json` por diseño (cada `starter/` resuelve su árbol)

### Arquitectura de referencia (semanas 16+)

```
src/
├── Domain/          # Entidades, value objects, reglas (sin dependencias)
├── Application/     # Casos de uso, DTOs, interfaces de puertos
├── Infrastructure/  # EF Core, mensajería, clientes externos
└── Api/             # Minimal API, endpoints, DI, middleware
tests/
├── Domain.Tests/
└── Api.IntegrationTests/
```

En semanas tempranas (1–15) se usa un único proyecto de consola por ejercicio/proyecto; no introducir capas antes de la semana 6 (SOLID).

---

## 🧪 Testing

xUnit + FluentAssertions + NSubstitute. Integración con `WebApplicationFactory` y Testcontainers (PostgreSQL).

```csharp
public sealed class ProductServiceTests
{
    [Fact]
    public async Task CreateAsync_PersistsProduct()
    {
        var repository = Substitute.For<IProductRepository>();
        var sut = new ProductService(repository);

        var product = await sut.CreateAsync(new("Keyboard", 49.99m), CancellationToken.None);

        product.Name.Should().Be("Keyboard");
        await repository.Received(1).AddAsync(product, Arg.Any<CancellationToken>());
    }
}
```

---

## 📖 Documentación

### README.md de semana

1. Título y descripción · 2. 🎯 Objetivos · 3. 📚 Requisitos previos · 4. 🗂️ Estructura ·
5. 📝 Contenidos (enlaces) · 6. ⏱️ Distribución del tiempo (10 h) · 7. 📌 Entregables · 8. 🔗 Navegación

### Archivo de teoría

```markdown
# Título del Tema

## 🎯 Objetivos
## 📋 Conceptos clave
### 1. …
### 2. …
## 🔬 Bajo el capó (cuando aplique)
## 📚 Recursos adicionales
## ✅ Checklist de verificación
```

---

## 🎨 Recursos Visuales

- ✅ SVG para diagramas; ❌ nunca ASCII art; PNG solo para screenshots
- Todo SVG vinculado desde al menos un archivo de teoría o práctica: `![Descripción](../0-assets/01-nombre.svg)`
- Nombres numerados en orden de lectura: `01-pipeline-compilacion-il-jit.svg`
- 🌙 Tema dark (`#0d1117`), sin degradés, colores sólidos
- Paleta de acento **C# / .NET púrpura `#512BD4`** (claro `#7a5cf0`, oscuro `#3f21a6`); estado: success `#3fb950`, warning `#d29922`, error `#f85149`, info `#58a6ff`; texto `#f0f6fc` / `#8b949e` / `#484f58`; superficies `#161b22` / `#21262d`; bordes `#30363d`
- Fuentes sans-serif (`system-ui, -apple-system, sans-serif`)
- Accesibilidad: `role="img"`, `<title>` y `<desc>`

---

## 🔐 Mejores Prácticas

- Nunca secretos en código ni en `appsettings.json` comiteado: user-secrets en desarrollo, variables de entorno en producción
- Validar toda entrada en el borde (endpoint) con `DataAnnotations`/FluentValidation
- Nunca exponer stack traces: `ProblemDetails`
- Contraseñas con `PasswordHasher<T>` (Identity) o Argon2/bcrypt; JWT con expiración corta
- Rate limiting en endpoints públicos y de auth
- `CancellationToken` propagado en toda operación de I/O
- Sin `GC.Collect()`, sin `Thread.Sleep` en código asíncrono, sin `lock(this)`

---

## 📊 Evaluación

1. **Conocimiento 🧠** (30%): cuestionario teórico
2. **Desempeño 💪** (40%): ejercicios prácticos
3. **Producto 📦** (30%): proyecto entregable

Mínimo **70%** por evidencia. `dotnet build` sin warnings, `dotnet test` en verde cuando aplique, implementación coherente con el dominio asignado, sin copia.

### Distribución del tiempo (10 h/semana)

- Teoría: ~3 h · Ejercicios: ~3 h · Proyecto: ~3.5 h · Glosario/recursos/revisión: ~0.5 h

---

## 🤖 Instrucciones para Copilot

### Límites de respuesta

- Nunca generar respuestas que superen los límites de tokens; dividir semanas completas por carpetas (teoría → prácticas → proyecto) e indicar qué se entrega y qué falta.

### Generación de código

- C# 14 / .NET 10, nullable y warnings-as-errors siempre
- Proyectos de consola por ejercicio (`Exercise.csproj`) hasta la semana 15; a partir de la 16, plantillas web/worker según la semana
- Comandos: `dotnet new console`, `dotnet add package Xunit --version 2.9.3`, `dotnet run`, `dotnet test`, `dotnet build -warnaserror`

### ✅ Checklist de nueva semana

1. Carpeta `week-XX-slug/` con la estructura estándar
2. `README.md` con objetivos medibles, tabla de contenidos y distribución de 10 h
3. `rubrica-evaluacion.md` con 10 preguntas reales y criterios por ejercicio/proyecto
4. Teoría: N archivos según el plan, ~150 líneas, sección "Bajo el capó" cuando aplique
5. SVG en `0-assets/` según el plan, todos vinculados desde teoría
6. Ejercicios con patrón uncomment y `starter/` que compila desde el paso 0
7. Proyecto con TODOs genéricos y README adaptable a dominios
8. Recursos (3 subcarpetas) y glosario A-Z
9. Navegación anterior/siguiente correcta
10. Actualizar tabla de semanas en README raíz y en este archivo si cambió el plan
11. NO crear `solution/`
