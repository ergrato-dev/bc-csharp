// ============================================
// PROYECTO SEMANA 03: Gestor del catálogo persistido en JSON
// ============================================
// NOTA PARA EL APRENDIZ:
// Adapta nombres, textos y datos a tu dominio asignado.
// - Biblioteca: Book / BookStore, préstamo y devolución
// - Farmacia: Medicine / MedicineStore, venta y caducidad
// - Hotel: Room / RoomStore, reserva y cancelación
// Ningún catch vacío. Ningún stream sin using. Ninguna ruta concatenada a mano.

string dataDir = Path.Combine(AppContext.BaseDirectory, "data");
var store = new JsonCatalogStore(Path.Combine(dataDir, "catalog.json"));

Console.WriteLine($"=== Catálogo de <tu dominio> === fichero: {Path.GetFileName(store.FilePath)}");

List<Item> items = [];
try
{
    items = [.. store.Load()];
    Console.WriteLine($"{items.Count} elementos cargados.");
}
catch (CatalogLoadException ex)
{
    // El fichero existe pero está corrupto: informa con la causa y arranca vacío.
    Console.WriteLine($"⚠ {ex.Message} Causa: {ex.GetBaseException().Message}");
    Console.WriteLine("Se arranca con un catálogo vacío; usa la opción 7 antes de guardar.");
}

while (true)
{
    ShowMenu();
    Console.Write("Opción: ");
    string? choice = Console.ReadLine();
    if (choice is null or "0")
    {
        Console.WriteLine("Hasta luego.");
        break;
    }

    try
    {
        switch (choice)
        {
            case "1": ListAll(); break;
            case "2": FindByKey(); break;
            case "3": Add(); break;
            case "4": UpdateCount(); break;
            case "5": Remove(); break;
            case "6": Import(); break;
            case "7": Save(); break;
            case "8": BackupNow(); break;
            default: Console.WriteLine("Opción no reconocida."); break;
        }
    }
    catch (CatalogException ex)
    {
        // Un único catch para todos los errores ESPERADOS del dominio.
        Console.WriteLine($"⚠ {ex.Message}");
        if (ex.InnerException is { } cause) Console.WriteLine($"   causa: {cause.GetType().Name}: {cause.Message}");
    }
    // Nada más se captura aquí: un bug debe subir y romper ruidosamente.
}

static void ShowMenu()
{
    Console.WriteLine();
    Console.WriteLine("1) Listar  2) Buscar por clave  3) Alta  4) Ajustar conteo  5) Baja");
    Console.WriteLine("6) Importar texto  7) Guardar  8) Copia de seguridad  0) Salir");
}

void ListAll()
{
    // TODO: listar agrupado por categoría con columnas alineadas ({x,-20}, {x,10:N2}).
    throw new NotImplementedException();
}

void FindByKey()
{
    Console.Write("Clave: ");
    string key = Console.ReadLine() ?? "";
    // TODO: buscar sin distinguir mayúsculas; si no está, lanza ItemNotFoundException.
    throw new NotImplementedException();
}

void Add()
{
    // TODO: pedir los campos, validarlos con guard clauses (ArgumentException.ThrowIfNullOrWhiteSpace,
    // ArgumentOutOfRangeException.ThrowIfNegative) y rechazar duplicados con DuplicateItemException.
    // Usa TryParse para los numéricos: escribir "abc" es un caso esperado, no excepcional.
    throw new NotImplementedException();
}

void UpdateCount()
{
    // TODO: sumar/restar al conteo. Un ajuste que deje el conteo negativo se rechaza
    // con la excepción de dominio que hayas añadido en DomainErrors.cs.
    throw new NotImplementedException();
}

void Remove()
{
    // TODO: baja por clave; si no existe, ItemNotFoundException.
    throw new NotImplementedException();
}

void Import()
{
    Console.Write("Ruta del fichero de texto: ");
    string path = Console.ReadLine() ?? "";
    // TODO: llamar a store.ImportFromText, fusionar sin duplicados y mostrar el informe de
    // líneas rechazadas (número de línea + motivo). Un fichero inexistente se informa, no revienta.
    throw new NotImplementedException();
}

void Save()
{
    // TODO: store.Save(items) y confirmar con el tamaño del fichero resultante.
    throw new NotImplementedException();
}

void BackupNow()
{
    // TODO: store.Backup() e informar de la ruta creada.
    throw new NotImplementedException();
}
