# CLAUDE.md — bc-csharp

Bootcamp C# Zero to Hero (26 semanas, 10 h/semana, 260 h, ergrato-dev). Nivel de
entrada: desarrollador con experiencia en otro lenguaje. Nivel de salida:
desarrollador C#/.NET avanzado (lenguaje a fondo, internals y rendimiento,
concurrencia, ASP.NET Core, EF Core, gRPC/SignalR/mensajería, Blazor, MAUI,
producción). Convenciones de contenido pedagógico (estructura de semana, tono,
checklist de nueva semana, stack, objetivos) viven en
[`.github/copilot-instructions.md`](.github/copilot-instructions.md) — léelo
antes de crear o editar contenido de cualquier semana. No se duplican aquí.

## Prompts reutilizables

`.github/prompts/` tiene plantillas para tareas recurrentes — úsalas en vez de
generar contenido libre: `nueva-semana`, `nuevo-ejercicio`, `nueva-teoria`,
`nuevo-proyecto`, `svg-diagrama`, `commit-message`.

## Estructura por semana

```
week-XX-tema/
├── README.md · rubrica-evaluacion.md (30% conocimiento / 40% desempeño / 30% producto)
├── 0-assets/ · 1-teoria/ · 2-practicas/ (ejercicios con starter/)
├── 3-proyecto/starter/ · 4-recursos/ · 5-glosario/
```

`solution/` está en `.gitignore` (`**/solution/`) por política anticopia
(dominios únicos por estudiante) — nunca crees ni comitees una carpeta
`solution/` en este repo.

## Reglas que rompen fácil

- **SDK fijado**: `global.json` fija .NET 10 (`rollForward: latestPatch`). Todo
  `.csproj` usa `net10.0`, `<Nullable>enable</Nullable>`,
  `<ImplicitUsings>enable</ImplicitUsings>` y
  `<TreatWarningsAsErrors>true</TreatWarningsAsErrors>`. Sin excepciones.
- **Versiones exactas** en `<PackageReference Version="x.y.z">` — nunca
  rangos ni floating (`*`, `[1.0,)`). Si tocas un paquete compartido entre
  semanas (`xunit`, `Microsoft.EntityFrameworkCore`, `Npgsql`, `MassTransit`),
  homogeniza la MISMA versión en todas las semanas que lo usan.
- **Llaves primarias**: toda PK en EF Core es `Guid Id` con
  `HasDefaultValueSql("gen_random_uuid()")` (PostgreSQL `uuid`). Nunca `int`
  autoincrement. Las FK son `Guid`; el `{id}` de las rutas es `Guid`.
- **Ejercicios** usan patrón uncomment, sin TODOs. **Proyectos** usan TODOs
  genéricos adaptables al dominio del aprendiz.
- **Idioma**: documentación en español, código y comentarios técnicos en
  inglés, comentarios pedagógicos en español.
- Antes de comitear código: `dotnet build` sin warnings (y `dotnet test` si
  el `starter/` tiene tests) en al menos un proyecto representativo. No dejes
  `bin/`/`obj/` sin limpiar — están en `.gitignore`.
- No hay `dotnet` instalado en toda máquina de edición: si no puedes
  compilar, dilo explícitamente en el resumen del cambio.

## Enlaces

- [docs/](docs/README.md) — setup, política de versiones, dominios únicos
- [Checklist de nueva semana](.github/copilot-instructions.md) (sección final)
