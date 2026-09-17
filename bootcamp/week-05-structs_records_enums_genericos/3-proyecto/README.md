## 🚀 Proyecto Semanal: Librería genérica `Result<T, E>` + dominio con records y enums

### 🎯 Objetivo

Escribir la parte **reutilizable** y la parte **de dominio** de una aplicación, y mantenerlas separadas: una librería genérica (`Result<T, E>`, repositorio con restricciones, métodos genéricos) que no menciona tu dominio en ninguna línea, y un modelo de datos con `record`, `readonly record struct`, `enum` y `[Flags]` que la usa sin lanzar excepciones para los casos esperados.

### 📋 Tu dominio asignado

**Dominio**: [El instructor te asignará tu dominio]

### ✅ Requisitos funcionales (adaptables a tu dominio)

1. **`Result<TValue, TError>` completo**: `Ok`/`Fail`, `Match`, `ValueOr`, `Map` y `Then` (encadenar sin anidar). `Map` y `Then` **no** deben ejecutar el lambda sobre un `Fail`.
2. **`DomainError` como dato**: `readonly record struct` con `Code` y `Message`, y al menos **tres** factorías propias de tu dominio (`NotFound`, más dos tuyas).
3. **Identificadores tipados**: al menos **dos** `readonly record struct` distintos (`ItemId` y uno más). Demuestra en el README que el compilador impide intercambiarlos.
4. **Value object**: `Money` (u otro valor de tu dominio) como `readonly record struct` inmutable, con una operación que devuelva un valor nuevo y un `ToString()` formateado.
5. **Entidad como `record`**: mínimo **6** campos, incluyendo el id tipado, el `enum` de estado, el `[Flags]` de características y el value object. Creada mediante una factoría `Create` que devuelve `Result<Item, DomainError>` **sin lanzar**.
6. **`enum` + `[Flags]`**: estado con miembro 0 neutro, validado siempre con `Enum.TryParse` + `Enum.IsDefined`; características en potencias de dos con las cuatro operaciones (combinar, comprobar, añadir, quitar) usadas desde el menú.
7. **Repositorio genérico**: `InMemoryRepository<TEntity, TKey>` con `where TEntity : class, IEntity<TKey>` y `where TKey : notnull`; `Add` y `Replace` devuelven `Result`, nunca lanzan para un caso esperado.
8. **Un método genérico propio** con la restricción **mínima** necesaria (o ninguna: usa `EqualityComparer<T>.Default` si solo comparas) y **un cálculo numérico genérico** con `INumber<T>`.
9. **Inmutabilidad**: los cambios de estado se hacen con `with`, nunca mutando. Documenta en el README un punto donde `with` haría copia superficial y cómo lo has evitado.
10. **Separación estricta**: `Results.cs` y `Repository.cs` no pueden contener ni una palabra de tu dominio. Si aparece, el diseño está mal.

### 💡 Ejemplos de adaptación por dominio

| Dominio | Id tipado | Entidad (`record`) | `enum` estado | `[Flags]` | Value object |
|---------|-----------|--------------------|---------------|-----------|--------------|
| **Biblioteca** | `BookId`, `MemberId` | `Book` | `Draft/Available/Loaned/Retired` | `Featured/Reference/Fragile` | `Money` (reposición) |
| **Farmacia** | `MedicineId`, `PatientId` | `Medicine` | `Draft/Active/Reserved/Withdrawn` | `Prescription/Cold/Generic` | `Dosage` |
| **Gimnasio** | `ClassId`, `MemberId` | `GymClass` | `Draft/Open/Full/Cancelled` | `Outdoor/Beginner/Equipment` | `Duration` |
| **Hotel** | `RoomId`, `GuestId` | `Room` | `Draft/Available/Reserved/Maintenance` | `Wifi/Breakfast/Parking/Gym` | `Money` (tarifa) |
| **Taller** | `PartId`, `VehicleId` | `Part` | `Draft/InStock/Reserved/Discontinued` | `Original/Warranty/Heavy` | `Money` |
| **Cine** | `ScreeningId`, `HallId` | `Screening` | `Draft/OnSale/SoldOut/Cancelled` | `Imax/Subtitled/Premiere` | `Money` |

### 🧱 Requisitos técnicos

- Un único proyecto de consola (`Project.csproj` del `starter/`), sin paquetes NuGet
- `dotnet build -warnaserror` sin warnings; `Nullable` habilitado
- Cuatro archivos: `Results.cs` (genérico), `Repository.cs` (genérico), `Domain.cs` (tu dominio), `Program.cs` (menú)
- Ninguna excepción para casos esperados: entrada de usuario, no encontrado, duplicado, transición inválida
- Guard clauses (`ArgumentNullException.ThrowIfNull`) sí: un `null` donde no cabe es un **bug**, no un caso esperado

### 🛠️ Entregables

1. `starter/` completado y adaptado, compilando sin warnings
2. `README.md` propio en `starter/` con:
   - Tabla de tus `DomainError` (código → cuándo se produce → qué hace el menú)
   - Justificación de cada elección `record` / `readonly record struct` / `class` usando los cuatro criterios de la teoría 01
   - Captura del error de compilación al intentar intercambiar tus dos identificadores tipados
   - Sesión de ejemplo pegada con un alta correcta y otra rechazada
3. Respuesta a: *¿qué gana tu programa al devolver `Result` en vez de lanzar en `Add`, y cuál es el precio en legibilidad?*

### 📊 Evaluación

Ver [rubrica-evaluacion.md](../rubrica-evaluacion.md), sección Producto (30%).
