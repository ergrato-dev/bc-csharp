# Ejercicio 02 — Persistencia en JSON

> Tutorial guiado. Descomenta paso a paso en `starter/Program.cs` y ejecuta `dotnet run` tras cada paso.

## 🎯 Objetivo

Guardar y recuperar el catálogo en JSON como se hace en producción: rutas con `Path`, un único `JsonSerializerOptions`, la trampa de los campos ausentes frente a `nullable`, diagnóstico de `JsonException` con `Path`/`LineNumber`, escritura atómica con fichero temporal, lectura por stream y perezosa, y serialización con **source generator**.

**Duración**: 90 min · **Teoría relacionada**: 04, 05 (y 01 para los `catch`)

## 🚀 Preparación

```bash
cd starter
dotnet run
```

Los ficheros se crean en `bin/Debug/net10.0/data/` (`AppContext.BaseDirectory`), que está en `.gitignore`. Los tipos viven al final del fichero: en top-level statements toda declaración de tipo va después de la última instrucción.

## Paso 1: rutas con `Path` y creación del directorio

`Path.Combine` pone el separador del sistema operativo; `Directory.CreateDirectory` es idempotente. Borramos la carpeta al empezar para que cada ejecución dé la misma salida.

```csharp
string dataDir = Path.Combine(AppContext.BaseDirectory, "data");
Directory.CreateDirectory(dataDir);
string catalogPath = Path.Combine(dataDir, "catalog.json");
```

Descomenta `PASO 1`. Prueba `Path.Combine("/a", "/b")` en la Debug Console: devuelve `"/b"`, porque un segmento absoluto descarta lo anterior.

## Paso 2: serializar con opciones reutilizadas

Un **único** `JsonSerializerOptions` para todo el programa: cada instancia cachea los metadatos de reflexión por tipo, así que crear una nueva en cada llamada tira ese trabajo a la basura.

```csharp
var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    Converters = { new JsonStringEnumConverter() },
};
```

Descomenta `PASO 2`, los dos `using` del inicio y el bloque `TIPOS` del final. Quita el `JsonStringEnumConverter` y observa que `status` pasa a ser `0` y `1`.

## Paso 3: deserializar y la trampa de los campos ausentes

`Deserialize<T>` devuelve `T?` (el JSON puede ser `null`). Y un campo **ausente** no es error: el `record` recibe el valor por defecto aunque la propiedad sea `string` no nullable.

```csharp
Product? incomplete = JsonSerializer.Deserialize<Product>("""{"sku":"XX-99"}""", options);
// Name = null · Price = 0 · Stock = 0
```

Descomenta `PASO 3`. Añade `[property: JsonRequired]` a `Sku` en el record y prueba con un JSON sin `sku`: ahora sí lanza `JsonException`.

## Paso 4: leer un `JsonException`

Dos JSON rotos: uno mal formado (`"price":}`) y otro con el tipo equivocado (`"price":"caro"`). Ambos lanzan `JsonException`, y sus propiedades dicen exactamente dónde.

```csharp
catch (JsonException ex)
{
    Console.WriteLine($"Path='{ex.Path}' línea={ex.LineNumber} byte={ex.BytePositionInLine}");
}
```

Descomenta `PASO 4`. `$[0].price` es la ruta JSONPath del elemento culpable: eso es lo que debe llegar al mensaje de error del usuario, no "algo falló".

## Paso 5: escritura segura con fichero temporal

Si el proceso muere a mitad de un `WriteAllText`, el fichero queda truncado. Se escribe aparte y se renombra: el rename es atómico dentro del mismo volumen.

```csharp
static void SaveAtomically(string path, string content)
{
    string temp = path + ".tmp";
    File.WriteAllText(temp, content);
    File.Move(temp, path, overwrite: true);
}
```

Descomenta `PASO 5`. Comenta el `File.Move` y ejecuta: el `.tmp` se queda huérfano y el contador lo delata.

## Paso 6: streams, lectura perezosa y errores de E/S

`DeserializeAsync` sobre un `FileStream` no materializa el texto completo; `await using` libera el stream aunque haya excepción; `File.ReadLines` recorre sin cargar el fichero entero.

```csharp
await using (FileStream stream = File.OpenRead(catalogPath))
{
    var fromStream = await JsonSerializer.DeserializeAsync<List<Product>>(stream, options);
}
```

Descomenta `PASO 6`. Quita el `await using` dejando solo `File.OpenRead(...)`: el analizador avisa y, sin liberar, el fichero queda bloqueado para el resto del programa.

## Paso 7: source generator

`JsonSerializerContext` genera en **tiempo de compilación** el código que la ruta por reflexión deduciría en runtime: arranque más rápido, menos asignaciones y compatible con AOT y trimming.

```csharp
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = true,
    UseStringEnumConverter = true)]
[JsonSerializable(typeof(List<Product>))]
internal sealed partial class CatalogJsonContext : JsonSerializerContext;

string generated = JsonSerializer.Serialize(seed, CatalogJsonContext.Default.ListProduct);
```

Descomenta `PASO 7`. El JSON generado es idéntico al del paso 2 (la última línea lo comprueba). Quita `partial` de la clase y mira el error del generador.

## ✅ Verificación

```
Ejercicio 02 — persistencia en JSON. Sigue los pasos del README.
carpeta: data · fichero: catalog.json
extensión: .json · ¿existe ya? False

[
  {
    "sku": "KB-01",
    "name": "Keyboard",
    "price": 49.99,
    "stock": 12,
    "status": "InStock"
  },
  {
    "sku": "MS-02",
    "name": "Mouse",
    "price": 19.50,
    "stock": 30,
    "status": "InStock"
  },
  {
    "sku": "MN-03",
    "name": "Monitor 27",
    "price": 289.00,
    "stock": 0,
    "status": "OutOfStock"
  }
]

deserializados: 3 · primero: Keyboard a 49.99
campos ausentes → Name = null · Price = 0 · Stock = 0
nullable enable NO protege del JSON: hay que validar.

JsonException en Path='$[0].price' línea=0 byte=22
JsonException en Path='$[0].price' línea=0 byte=28

guardado: 346 bytes · quedan 0 ficheros .tmp

leídos desde el stream: 3
el fichero tiene 23 líneas (ReadLines no lo carga entero en memoria)
FileNotFoundException para no-existe.json

source generator: 3 productos · mismo JSON que el paso 2: True
```

`dotnet build -warnaserror` sin warnings.

## 🧠 Preguntas de reflexión

1. `nullable enable` está activo y aun así `incomplete.Name` es `null`. ¿Dónde pondrías la validación para que eso no llegue al resto del programa?
2. El paso 5 escribe en `.tmp` y renombra. ¿Qué garantiza y qué **no** garantiza ese patrón si el disco se llena a mitad?
3. ¿En qué casos concretos merece la pena el source generator frente a la ruta por reflexión, y qué mides para justificarlo?
