# `System.Text.Json`

## 🎯 Objetivos

Al finalizar este archivo, comprenderás:

- Cómo serializar y deserializar con `JsonSerializer` y qué hace por defecto
- Las opciones que vas a necesitar siempre: nombres, indentación, enums, tolerancia
- Cómo deserializar a `record` y qué papel juegan el constructor y los nullable
- Qué excepciones lanza y cómo tratar un JSON corrupto
- Qué es el **source generator** de JSON y por qué es la forma recomendada en .NET 10

## 📋 Conceptos clave

### 1. Ida y vuelta

```csharp
using System.Text.Json;

public sealed record Product(string Sku, string Name, decimal Price, int Stock);

var product = new Product("KB-01", "Keyboard", 49.99m, 12);

string json = JsonSerializer.Serialize(product);
// {"Sku":"KB-01","Name":"Keyboard","Price":49.99,"Stock":12}

Product? back = JsonSerializer.Deserialize<Product>(json);
```

Por defecto: serializa **propiedades públicas** (no campos), respeta el nombre exacto (PascalCase), escribe compacto, no admite comentarios ni comas finales, y al deserializar **ignora mayúsculas/minúsculas no**: `"sku"` no encaja con `Sku` salvo que lo configures.

Los números decimales viajan como números JSON; `decimal` conserva la precisión, `double` no: para dinero, siempre `decimal`.

### 2. Opciones: defínelas una vez y reutilízalas

```csharp
private static readonly JsonSerializerOptions Options = new()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,     // Sku → "sku"
    PropertyNameCaseInsensitive = true,                    // al leer, "SKU" también encaja
    WriteIndented = true,                                  // legible para humanos
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    Converters = { new JsonStringEnumConverter() },         // enum como "Active", no 1
    ReadCommentHandling = JsonCommentHandling.Skip,
    AllowTrailingCommas = true,
};
```

**Crea el `JsonSerializerOptions` una sola vez** (campo `static readonly`): cada instancia nueva construye y cachea metadatos de reflexión por tipo, y crearla dentro de un bucle es uno de los problemas de rendimiento más habituales con esta API.

### 3. Atributos por propiedad

```csharp
public sealed record Order(
    [property: JsonPropertyName("order_id")] Guid Id,
    [property: JsonIgnore] string InternalNote,
    DateTimeOffset CreatedAt);
```

- `[JsonPropertyName]` — nombre exacto en el JSON, gana sobre la naming policy.
- `[JsonIgnore]` — fuera; con `Condition = JsonIgnoreCondition.WhenWritingDefault` solo si es el valor por defecto.
- `[JsonPropertyOrder(n)]` — orden de escritura.
- `[JsonConstructor]` — cuál de varios constructores usar.
- En un `record` posicional los atributos van con el prefijo `property:`.

### 4. `record`, constructores y nulos

Al deserializar un tipo con un único constructor parametrizado, `System.Text.Json` lo usa emparejando **nombres de parámetro** con propiedades JSON (sin distinguir mayúsculas). Si falta una propiedad en el JSON, el parámetro recibe su valor por defecto: `null` para `string`, `0` para `int` — sin error, aunque el tipo esté declarado como no nullable.

```csharp
JsonSerializer.Deserialize<Product>("""{"sku":"KB-01"}""", Options);
// Product { Sku = "KB-01", Name = null!, Price = 0, Stock = 0 }  ← nullable enable NO te protege aquí
```

Dos defensas, combinables:

```csharp
public sealed record Product(
    [property: JsonRequired] string Sku,     // falta en el JSON → JsonException
    string Name, decimal Price, int Stock);
```

…y validar después de deserializar (guard clauses del archivo 01). Regla del bootcamp: **el JSON es entrada no confiable; valídalo siempre en el borde.**

`Deserialize<T>` devuelve `T?` porque el JSON puede ser literalmente `null`: trátalo (`?? throw new ...`) en vez de silenciarlo con `!`.

### 5. Colecciones, streams y ficheros

```csharp
List<Product>? all = JsonSerializer.Deserialize<List<Product>>(json, Options);

// Fichero grande: sin cargar el texto entero en memoria
await using FileStream read = File.OpenRead(path);
var items = await JsonSerializer.DeserializeAsync<List<Product>>(read, Options);

await using FileStream write = File.Create(path);
await JsonSerializer.SerializeAsync(write, items, Options);

// Streaming elemento a elemento (millones de registros)
await foreach (Product? p in JsonSerializer.DeserializeAsyncEnumerable<Product>(read, Options))
    Process(p);
```

### 6. Cuando no hay tipo: el DOM

```csharp
using JsonDocument doc = JsonDocument.Parse(json);     // solo lectura, rápido; requiere using
JsonElement root = doc.RootElement;
if (root.TryGetProperty("sku", out JsonElement sku))
    Console.WriteLine(sku.GetString());

JsonNode? node = JsonNode.Parse(json);                 // mutable
node!["price"] = 59.99m;
```

`JsonDocument` es de solo lectura y hay que liberarlo (usa memoria alquilada); `JsonNode` es mutable y más cómodo para editar al vuelo.

### 7. Errores: `JsonException`

```csharp
try
{
    return JsonSerializer.Deserialize<List<Product>>(json, Options) ?? [];
}
catch (JsonException ex)
{
    // Path, LineNumber y BytePositionInLine señalan el punto exacto del fallo
    throw new CatalogLoadException($"JSON inválido en {ex.Path} (línea {ex.LineNumber}).", ex);
}
```

`JsonException` cubre tanto el JSON mal formado como el que no encaja con el tipo. Sus propiedades `Path`, `LineNumber` y `BytePositionInLine` valen oro en un mensaje de error.

### 8. Source generator: la forma recomendada

```csharp
using System.Text.Json.Serialization;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = true)]
[JsonSerializable(typeof(List<Product>))]
internal sealed partial class CatalogJsonContext : JsonSerializerContext;

string json = JsonSerializer.Serialize(items, CatalogJsonContext.Default.ListProduct);
List<Product>? back = JsonSerializer.Deserialize(json, CatalogJsonContext.Default.ListProduct);
```

El generador escribe en tiempo de compilación el código que la versión por reflexión descubriría en runtime: arranque más rápido, menos asignaciones y compatibilidad con **AOT nativo** y *trimming* (la vía por reflexión avisa con warnings ahí). Los source generators se estudian a fondo en la semana 14; aquí basta usar uno.

## 🔬 Bajo el capó

`Utf8JsonReader` es un `ref struct` que recorre **bytes UTF-8** directamente, sin convertir a `string` intermedio: por eso `System.Text.Json` es varias veces más rápido que el viejo `Newtonsoft.Json`, que trabajaba sobre `char` UTF-16. La ruta por reflexión construye, la primera vez que ve un tipo, un `JsonTypeInfo` con delegados de acceso a cada propiedad y lo cachea **dentro del `JsonSerializerOptions`**; de ahí que reutilizar la instancia sea crítico y que la primera llamada sea la lenta. El source generator produce ese mismo `JsonTypeInfo` como código C# en compilación: sin reflexión, sin coste de arranque, analizable por el trimmer.

## ⚠️ Errores comunes

- `new JsonSerializerOptions()` dentro de un bucle o de cada llamada.
- Esperar que `nullable enable` proteja de un campo ausente en el JSON: no lo hace.
- Serializar campos públicos y sorprenderse de que no aparezcan (por defecto solo propiedades).
- Usar `double` para dinero.
- Olvidar el `using` de `JsonDocument`.
- Tragarse `JsonException` sin registrar `Path` ni `LineNumber`.

## 📚 Recursos adicionales

- [Serialización JSON en .NET](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/overview)
- [Cómo personalizar nombres y opciones](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/customize-properties)
- [Source generation](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/source-generation)
- [Migrar desde Newtonsoft.Json](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/migrate-from-newtonsoft)

## ✅ Checklist de verificación

- [ ] Serializo y deserializo un `record` con opciones camelCase reutilizadas
- [ ] Sé por qué `JsonSerializerOptions` debe ser `static readonly`
- [ ] Valido el resultado de `Deserialize` en vez de confiar en `nullable`
- [ ] Trato `JsonException` mostrando `Path` y `LineNumber`
- [ ] Uso stream + `async` para ficheros grandes
- [ ] Declaro un `JsonSerializerContext` y serializo a través de él
