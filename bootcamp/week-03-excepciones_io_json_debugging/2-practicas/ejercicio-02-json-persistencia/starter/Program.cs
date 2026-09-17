// Ejercicio 02 — Persistencia en JSON
// El programa compila y ejecuta desde el paso 0. Descomenta cada PASO en orden.

// Los pasos 2 en adelante necesitan estos usings:
// using System.Text.Json;
// using System.Text.Json.Serialization;

Console.WriteLine("Ejercicio 02 — persistencia en JSON. Sigue los pasos del README.");

// ============================================
// PASO 1: Rutas con Path y creación del directorio
// ============================================
// Path.Combine usa el separador del SO; Directory.CreateDirectory es idempotente.
// Borramos la carpeta al empezar para que el ejercicio dé siempre la misma salida.
// Descomenta las siguientes líneas:
// string dataDir = Path.Combine(AppContext.BaseDirectory, "data");
// if (Directory.Exists(dataDir)) Directory.Delete(dataDir, recursive: true);   // para que el ejercicio sea repetible
// Directory.CreateDirectory(dataDir);                       // idempotente: no lanza si ya existe
// string catalogPath = Path.Combine(dataDir, "catalog.json");
// Console.WriteLine($"carpeta: {Path.GetFileName(dataDir)} · fichero: {Path.GetFileName(catalogPath)}");
// Console.WriteLine($"extensión: {Path.GetExtension(catalogPath)} · ¿existe ya? {File.Exists(catalogPath)}");

// ============================================
// PASO 2: Serializar con opciones reutilizadas
// ============================================
// UN solo JsonSerializerOptions para todo el programa: cachea los metadatos de cada tipo.
// camelCase en el JSON, enum como texto, indentado para que lo lea un humano.
// Descomenta las siguientes líneas:
// var options = new JsonSerializerOptions
// {
//     PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//     PropertyNameCaseInsensitive = true,
//     WriteIndented = true,
//     Converters = { new JsonStringEnumConverter() },
// };
//
// List<Product> seed =
// [
//     new("KB-01", "Keyboard", 49.99m, 12, Availability.InStock),
//     new("MS-02", "Mouse", 19.50m, 30, Availability.InStock),
//     new("MN-03", "Monitor 27", 289.00m, 0, Availability.OutOfStock),
// ];
//
// string json = JsonSerializer.Serialize(seed, options);
// Console.WriteLine();
// Console.WriteLine(json);

// ============================================
// PASO 3: Deserializar y la trampa de los campos ausentes
// ============================================
// Deserialize devuelve T? porque el JSON puede ser null.
// Un campo ausente NO es error: el record recibe el valor por defecto aunque sea string no nullable.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// List<Product> back = JsonSerializer.Deserialize<List<Product>>(json, options) ?? [];
// Console.WriteLine($"deserializados: {back.Count} · primero: {back[0].Name} a {back[0].Price}");
//
// const string Partial = """{"sku":"XX-99"}""";
// Product? incomplete = JsonSerializer.Deserialize<Product>(Partial, options);
// Console.WriteLine($"campos ausentes → Name = {incomplete!.Name ?? "null"} · Price = {incomplete.Price} · Stock = {incomplete.Stock}");
// Console.WriteLine("nullable enable NO protege del JSON: hay que validar.");

// ============================================
// PASO 4: JsonException: Path, LineNumber y BytePositionInLine
// ============================================
// Dos JSON rotos: uno mal formado y otro con el tipo equivocado. Ambos lanzan JsonException.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// foreach (string bad in (string[])["""[{"sku":"A-1","price":}]""", """[{"sku":"A-1","price":"caro"}]"""])
// {
//     try
//     {
//         JsonSerializer.Deserialize<List<Product>>(bad, options);
//     }
//     catch (JsonException ex)
//     {
//         Console.WriteLine($"JsonException en Path='{ex.Path}' línea={ex.LineNumber} byte={ex.BytePositionInLine}");
//     }
// }

// ============================================
// PASO 5: Escritura segura: fichero .tmp + File.Move atómico
// ============================================
// Si el proceso muere a mitad de la escritura, el fichero bueno sigue intacto.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// SaveAtomically(catalogPath, json);
// Console.WriteLine($"guardado: {new FileInfo(catalogPath).Length} bytes · quedan {Directory.GetFiles(dataDir, "*.tmp").Length} ficheros .tmp");
//
// static void SaveAtomically(string path, string content)
// {
//     string temp = path + ".tmp";
//     File.WriteAllText(temp, content);          // si el proceso muere aquí, el fichero bueno sigue intacto
//     File.Move(temp, path, overwrite: true);    // el rename es atómico dentro del mismo volumen
// }

// ============================================
// PASO 6: Streams, lectura perezosa y errores de E/S
// ============================================
// DeserializeAsync sobre un FileStream no carga el texto entero en memoria.
// await using libera el stream aunque haya excepción. ReadLines recorre sin materializar.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// await using (FileStream stream = File.OpenRead(catalogPath))
// {
//     List<Product>? fromStream = await JsonSerializer.DeserializeAsync<List<Product>>(stream, options);
//     Console.WriteLine($"leídos desde el stream: {fromStream!.Count}");
// }
//
// int lines = 0;
// foreach (string _ in File.ReadLines(catalogPath)) lines++;   // perezoso: no carga el fichero entero
// Console.WriteLine($"el fichero tiene {lines} líneas (ReadLines no lo carga entero en memoria)");
//
// try
// {
//     File.ReadAllText(Path.Combine(dataDir, "no-existe.json"));
// }
// catch (FileNotFoundException ex)
// {
//     Console.WriteLine($"FileNotFoundException para {Path.GetFileName(ex.FileName)}");
// }

// ============================================
// PASO 7: Source generator: JsonSerializerContext
// ============================================
// El generador escribe en compilación lo que la reflexión descubriría en runtime.
// Descomenta también el bloque TIPOS del final del fichero.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// string generated = JsonSerializer.Serialize(seed, CatalogJsonContext.Default.ListProduct);
// List<Product>? roundTrip = JsonSerializer.Deserialize(generated, CatalogJsonContext.Default.ListProduct);
// Console.WriteLine($"source generator: {roundTrip!.Count} productos · mismo JSON que el paso 2: {generated == json}");

// ============================================
// TIPOS de los PASOS 2 a 7
// ============================================
// Los tipos van DESPUÉS de todas las instrucciones top-level (error CS8803 si no).
// Descomenta las siguientes líneas al llegar al paso 2:
// public enum Availability { InStock, OutOfStock }
//
// public sealed record Product(string Sku, string Name, decimal Price, int Stock, Availability Status);
//
// [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, WriteIndented = true,
//     UseStringEnumConverter = true)]
// [JsonSerializable(typeof(List<Product>))]
// internal sealed partial class CatalogJsonContext : JsonSerializerContext;
