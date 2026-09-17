// ============================================
// Excepciones de dominio del proyecto
// ============================================
// NOTA PARA EL APRENDIZ:
// Renombra estos tipos a tu dominio (BookNotFoundException, MemberNotFoundException...).
// Regla: crea un tipo propio SOLO si quien llama va a capturarlo de forma distinta.

/// <summary>Base de todos los errores esperados de este programa: permite un catch único en el menú.</summary>
public abstract class CatalogException(string message, Exception? innerException = null)
    : Exception(message, innerException);

/// <summary>La entidad pedida no existe en el catálogo.</summary>
public sealed class ItemNotFoundException(string key)
    : CatalogException($"No existe ningún elemento con la clave '{key}'.")
{
    public string Key { get; } = key;
}

/// <summary>La entidad ya existe: alta duplicada.</summary>
public sealed class DuplicateItemException(string key)
    : CatalogException($"Ya existe un elemento con la clave '{key}'.")
{
    public string Key { get; } = key;
}

/// <summary>El fichero de datos no se pudo leer o no contiene un JSON válido.</summary>
public sealed class CatalogLoadException(string path, Exception innerException)
    : CatalogException($"No se pudo cargar el catálogo desde '{Path.GetFileName(path)}'.", innerException)
{
    public string FilePath { get; } = path;
}

/// <summary>El catálogo no se pudo guardar; el fichero anterior sigue intacto.</summary>
public sealed class CatalogSaveException(string path, Exception innerException)
    : CatalogException($"No se pudo guardar el catálogo en '{Path.GetFileName(path)}'.", innerException)
{
    public string FilePath { get; } = path;
}

// TODO: añade UNA excepción propia más que tenga sentido en tu dominio y que alguien
// vaya a capturar de forma distinta (stock insuficiente, préstamo ya devuelto,
// habitación ocupada, cita fuera de horario...). Documenta en el README por qué no
// te bastaba InvalidOperationException.
