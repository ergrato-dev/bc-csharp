// ============================================
// Persistencia del catálogo en JSON
// ============================================
// NOTA PARA EL APRENDIZ:
// Esta clase es la ÚNICA que toca el disco y la única que conoce System.Text.Json.
// El resto del programa habla de entidades, no de ficheros.

using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>Entidad del dominio. TODO: renombra y adapta los campos (mínimo 5, uno de ellos DateOnly o enum).</summary>
public sealed record Item(
    string Key,
    string Name,
    string Category,
    decimal Value,
    int Count,
    ItemStatus Status);

public enum ItemStatus { Active, Inactive, Retired }

public sealed class JsonCatalogStore
{
    // Una sola instancia para todo el programa: cada JsonSerializerOptions cachea metadatos por tipo.
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() },
    };

    private readonly string _path;

    public JsonCatalogStore(string path)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);
        _path = path;
        Directory.CreateDirectory(Path.GetDirectoryName(path) ?? ".");
    }

    public string FilePath => _path;

    /// <summary>Carga el catálogo. Si el fichero no existe devuelve una lista vacía (primer arranque).</summary>
    public IReadOnlyList<Item> Load()
    {
        // TODO: leer el fichero y deserializar a List<Item>.
        // - Fichero ausente → lista vacía, NO excepción: es el primer arranque.
        // - JsonException o IOException → envuélvelas en CatalogLoadException conservando InnerException.
        // - Deserialize devuelve null si el JSON es literalmente "null": trátalo.
        throw new NotImplementedException();
    }

    /// <summary>Guarda el catálogo de forma atómica: escribe en .tmp y renombra.</summary>
    public void Save(IReadOnlyList<Item> items)
    {
        ArgumentNullException.ThrowIfNull(items);
        // TODO: serializar con Options, escribir en _path + ".tmp" y File.Move(..., overwrite: true).
        // Envuelve IOException y UnauthorizedAccessException en CatalogSaveException.
        throw new NotImplementedException();
    }

    /// <summary>Copia de seguridad con marca de tiempo antes de sobrescribir.</summary>
    public string Backup()
    {
        // TODO: copiar _path a "<nombre>-yyyyMMdd-HHmmss.json" en el mismo directorio y devolver la ruta.
        // Usa Path.GetFileNameWithoutExtension, Path.GetExtension y Path.Combine. Si no hay fichero, informa.
        throw new NotImplementedException();
    }

    /// <summary>Importa líneas "clave;nombre;categoría;valor;conteo;estado" de un fichero de texto.</summary>
    public IReadOnlyList<Item> ImportFromText(string textPath, out IReadOnlyList<string> errors)
    {
        // TODO: recorrer con File.ReadLines (perezoso, no ReadAllLines).
        // Cada línea inválida se acumula en errors con su NÚMERO DE LÍNEA y no rompe la importación.
        // Reutiliza TryParseLine. Usa decimal.TryParse con CultureInfo.InvariantCulture.
        throw new NotImplementedException();
    }

    /// <summary>Patrón TryXxx: nunca lanza. TODO: adapta el número y el tipo de campos.</summary>
    public static bool TryParseLine(string line, out Item item)
    {
        ArgumentNullException.ThrowIfNull(line);
        item = default!;
        // TODO: Split(';'), validar el número de campos, TryParse de los numéricos
        // y Enum.TryParse del estado. Devuelve false en vez de lanzar.
        return false;
    }
}
