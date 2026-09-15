// ============================================
// Catalog: la entidad y las colecciones de tu dominio
// ============================================
// NOTA PARA EL APRENDIZ:
// Renombra Item y Catalog según tu dominio (Book/BookCatalog, Medicine/MedicineCatalog...).
// Mantén las firmas públicas con IReadOnlyList / IEnumerable: nunca expongas la List interna.

using System.Globalization;

/// <summary>Entidad del dominio. TODO: renombra y añade los campos que necesites (mínimo 5).</summary>
public readonly record struct Item(string Key, string Name, string Category, decimal Value, int Count);

public sealed class Catalog
{
    private readonly List<Item> _items = [];
    private readonly Dictionary<string, Item> _byKey = new(StringComparer.OrdinalIgnoreCase);
    private readonly HashSet<string> _categories = [];
    private readonly Stack<(string Key, int Delta)> _applied = new();

    public int Count => _items.Count;

    /// <summary>Categorías presentes, ordenadas. TODO: decide el orden (alfabético, por tamaño...).</summary>
    public IReadOnlyList<string> Categories
    {
        get
        {
            List<string> sorted = [.. _categories];
            sorted.Sort(StringComparer.CurrentCultureIgnoreCase);
            return sorted;
        }
    }

    /// <summary>Carga líneas "clave;nombre;categoría;valor;conteo". Devuelve cuántas se rechazaron.</summary>
    public int Load(string data)
    {
        ArgumentNullException.ThrowIfNull(data);
        int rejected = 0;
        foreach (string line in data.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            if (!TryParseLine(line, out Item item) || !_byKey.TryAdd(item.Key, item))
            {
                Console.WriteLine($"  línea rechazada: {line}");
                rejected++;
                continue;
            }
            _items.Add(item);
            _categories.Add(item.Category);
        }
        return rejected;
    }

    /// <summary>Patrón TryXxx: nunca lanza. TODO: adapta el número y tipo de campos.</summary>
    public static bool TryParseLine(string line, out Item item)
    {
        ArgumentNullException.ThrowIfNull(line);
        item = default;
        string[] parts = line.Split(';', StringSplitOptions.TrimEntries);
        if (parts.Length != 5) return false;
        if (!decimal.TryParse(parts[3], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal value)) return false;
        if (!int.TryParse(parts[4], out int count) || count < 0) return false;
        // TODO: valida que la clave y el nombre no estén vacíos
        item = new Item(parts[0], parts[1], parts[2], value, count);
        return true;
    }

    public bool TryFind(string key, out Item item) => _byKey.TryGetValue(key, out item);

    /// <summary>Búsqueda por subcadena en el nombre, sin distinguir mayúsculas ni acentos.</summary>
    public IEnumerable<Item> Search(string term)
    {
        // TODO: usa CompareInfo.IndexOf con CompareOptions.IgnoreCase | IgnoreNonSpace
        // para que "cafe" encuentre "Café".
        foreach (Item item in _items)
            if (item.Name.Contains(term, StringComparison.OrdinalIgnoreCase))
                yield return item;
    }

    /// <summary>Marca cada término entre [ ] en el texto. params: cualquier número de términos.</summary>
    public static string Highlight(string text, params string[] terms)
    {
        // TODO: implementar con Replace + StringComparison.OrdinalIgnoreCase, o con StringBuilder
        throw new NotImplementedException();
    }

    /// <summary>Agrupa por categoría; cada grupo ordenado por Value descendente.</summary>
    public IReadOnlyDictionary<string, IReadOnlyList<Item>> GroupByCategory()
    {
        // TODO: Dictionary<string, List<Item>> con el patrón TryGetValue + crear si falta,
        // luego Sort en cada grupo con un comparador.
        throw new NotImplementedException();
    }

    /// <summary>Aplica un movimiento de conteo. Rechaza si dejaría el conteo negativo.</summary>
    public bool TryApply(string key, int delta, out int remaining)
    {
        // TODO: buscar en _byKey; calcular el nuevo conteo; si < 0 rechazar.
        // Item es un struct: hay que reasignar en _byKey Y en _items (FindIndex + with).
        // Si se aplica, apilar (key, delta) en _applied para poder deshacer.
        remaining = 0;
        return false;
    }

    /// <summary>Deshace el último movimiento aplicado.</summary>
    public bool TryUndo(out string key)
    {
        // TODO: TryPop de _applied y aplicar el delta inverso sin volver a apilarlo.
        key = "";
        return false;
    }

    /// <summary>Método recursivo del dominio. TODO: sustituye por uno con sentido en tu dominio.</summary>
    /// <remarks>Ejemplo: profundidad de una categoría "a/b/c". Caso base: sin '/', profundidad 1.</remarks>
    public static int CategoryDepth(ReadOnlySpan<char> category)
    {
        int slash = category.IndexOf('/');
        return slash < 0 ? 1 : 1 + CategoryDepth(category[(slash + 1)..]);
    }

    /// <summary>Vista de solo lectura para el reporte.</summary>
    public IReadOnlyList<Item> Items => _items;
}
