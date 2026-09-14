# Política de versiones de dependencias

## SDK

- `global.json` fija el SDK de .NET 10 con `rollForward: latestPatch`. Se actualiza en un único commit para todo el repo.
- Todo `.csproj` apunta a `net10.0`. No se mezclan target frameworks.

## Paquetes NuGet

- **Versión exacta siempre**: `<PackageReference Include="Xunit" Version="2.9.3" />`. Nunca `*`, rangos `[1.0,2.0)` ni floating `1.*`.
- **Homogeneidad entre semanas**: un paquete compartido (`xunit`, `FluentAssertions`, `NSubstitute`, `Microsoft.EntityFrameworkCore`, `Npgsql.EntityFrameworkCore.PostgreSQL`, `MassTransit`, `BenchmarkDotNet`, `OpenTelemetry.*`) lleva la MISMA versión en todas las semanas que lo usan. Al subir una versión, cambiar todas a la vez y compilar al menos un `starter/` representativo.
- **Sin lockfiles**: no se comitea `packages.lock.json`; cada `starter/` resuelve su árbol.
- **Sin `Directory.Packages.props`** central: los `starter/` deben ser autocontenidos para que el aprendiz pueda copiarlos fuera del repo.

## Versiones de referencia (2026-09)

| Paquete | Versión |
|---------|---------|
| `xunit` | 2.9.3 |
| `xunit.runner.visualstudio` | 4.0.0 |
| `Microsoft.NET.Test.Sdk` | 18.10.0 |
| `FluentAssertions` | 8.10.0 |
| `NSubstitute` | 6.2.0 |
| `BenchmarkDotNet` | 0.15.8 |
| `Microsoft.EntityFrameworkCore` | 10.0.12 |
| `Npgsql.EntityFrameworkCore.PostgreSQL` | 10.0.3 |
| `MassTransit` | 9.2.1 |
| `Testcontainers.PostgreSql` | 4.15.0 |

> Verificadas en nuget.org el 2026-09-13. Revalidar antes de usar en una semana nueva; actualizar esta tabla en el mismo commit. MassTransit 9.x es de pago para uso comercial: el bootcamp lo usa bajo licencia educativa/comunidad; alternativa libre: `Wolverine` o `RabbitMQ.Client` directo.

## Verificación antes de comitear

```bash
dotnet build -warnaserror
dotnet test          # si el starter tiene tests
rm -rf bin obj       # nunca se comitean
```
