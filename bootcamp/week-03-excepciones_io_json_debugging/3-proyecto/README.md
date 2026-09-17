## 🚀 Proyecto Semanal: Gestor del catálogo persistido en JSON con manejo robusto de errores

### 🎯 Objetivo

Convertir el inventario en memoria de la semana 02 en una aplicación que **sobrevive a un reinicio y a un fichero corrupto**: carga y guarda en JSON, importa desde texto reportando cada línea mala, valida en el borde con guard clauses, traduce los errores técnicos a errores de dominio y nunca deja el fichero bueno a medio escribir.

### 📋 Tu dominio asignado

**Dominio**: [El instructor te asignará tu dominio]

### ✅ Requisitos funcionales (adaptables a tu dominio)

1. **Entidad** como `record` con al menos 5 campos: clave única (`string`), nombre, categoría, un `decimal`, un `int` y un `enum` de estado. Serializada en JSON **camelCase** y con el enum como texto.
2. **Carga tolerante**: al arrancar, `Load()` devuelve lista vacía si el fichero no existe (primer arranque, **no** es un error) y lanza `CatalogLoadException` con la causa en `InnerException` si existe pero está corrupto. El menú informa y arranca vacío en vez de morir.
3. **Guardado atómico**: `Save()` escribe en `<fichero>.tmp` y hace `File.Move(..., overwrite: true)`. Si falla, `CatalogSaveException` y el fichero anterior queda intacto.
4. **Copia de seguridad**: `Backup()` crea `<nombre>-yyyyMMdd-HHmmss.json` en el mismo directorio usando `Path.GetFileNameWithoutExtension`/`Path.GetExtension`/`Path.Combine`. Nunca concatenes rutas a mano.
5. **Importación desde texto**: `ImportFromText` recorre con `File.ReadLines` (perezoso) líneas `clave;nombre;categoría;valor;conteo;estado`. Cada línea inválida se acumula con su **número de línea y motivo**, se informa al final y **no** interrumpe la importación. El parseo usa `TryParseLine` (patrón `TryXxx`, nunca lanza) y `CultureInfo.InvariantCulture`.
6. **Excepciones de dominio**: una base `CatalogException` y, como mínimo, `ItemNotFoundException`, `DuplicateItemException`, `CatalogLoadException`, `CatalogSaveException` y **una propia de tu dominio** (stock insuficiente, préstamo ya devuelto, habitación ocupada…). El bucle del menú las captura con un **único** `catch (CatalogException)`.
7. **Validación en el borde**: toda alta pasa por guard clauses (`ArgumentException.ThrowIfNullOrWhiteSpace`, `ArgumentOutOfRangeException.ThrowIfNegative`). La entrada por teclado se parsea con `TryParse`: que el usuario escriba "abc" es esperado, no excepcional.
8. **Filtro `when`**: al menos un `catch` con filtro que distinga dos casos del mismo tipo de excepción (por ejemplo `IOException` de "fichero en uso" frente al resto, o reintento limitado al guardar).
9. **Nada de lo prohibido**: ningún `catch` vacío, ningún `throw ex;`, ningún stream sin `using`, ninguna captura de `Exception` en las capas bajas, ningún `File.Exists` usado como garantía.

### 💡 Ejemplos de adaptación por dominio

| Dominio | Entidad (clave) | Categoría | `decimal` | `int` | Excepción propia |
|---------|-----------------|-----------|-----------|-------|------------------|
| **Biblioteca** | Libro (ISBN) | género | precio de reposición | ejemplares | `BookAlreadyReturnedException` |
| **Farmacia** | Medicamento (código) | familia | precio | unidades | `InsufficientStockException` |
| **Gimnasio** | Clase (código) | tipo | tarifa | plazas | `ClassFullException` |
| **Hotel** | Habitación (número) | tipo | tarifa noche | noches libres | `RoomOccupiedException` |
| **Taller mecánico** | Repuesto (referencia) | sistema | precio | stock | `PartDiscontinuedException` |
| **Cine** | Sala (código) | formato | precio entrada | butacas libres | `ShowtimeClosedException` |

### 🧱 Requisitos técnicos

- Un único proyecto de consola (`Project.csproj` del `starter/`), sin paquetes NuGet
- `dotnet build -warnaserror` sin warnings; `Nullable` habilitado
- Tres archivos: `Program.cs` (menú), `JsonCatalogStore.cs` (persistencia), `DomainErrors.cs` (excepciones)
- Un **único** `JsonSerializerOptions` `static readonly` en todo el programa
- Los datos viven en `AppContext.BaseDirectory/data` (dentro de `bin/`, ya ignorado por git)
- Firmas públicas con `IReadOnlyList<T>`, nunca `List<T>` expuesta

### 🐞 Evidencia de depuración (obligatoria)

Incluye en tu README una captura o descripción de:

1. Un **breakpoint condicional** que se detenga solo en una línea concreta de la importación.
2. La ejecución detenida en el `throw` con *User-Unhandled Exceptions* activado, mostrando la **Call Stack**.

### 🛠️ Entregables

1. `starter/` completado y adaptado, compilando sin warnings
2. `README.md` propio en `starter/` con: dominio, formato de la línea de importación, tabla de excepciones (tipo → cuándo → quién la captura), evidencia de depuración y una sesión de ejemplo pegada
3. Un `catalog.json` de ejemplo con ≥ 10 elementos y un fichero de texto de importación con al menos 2 líneas inválidas
4. Respuesta a: *¿qué pasa exactamente si el proceso muere entre el `WriteAllText` del `.tmp` y el `File.Move`, y por qué es aceptable?*

### 📊 Evaluación

Ver [rubrica-evaluacion.md](../rubrica-evaluacion.md), sección Producto (30%).
