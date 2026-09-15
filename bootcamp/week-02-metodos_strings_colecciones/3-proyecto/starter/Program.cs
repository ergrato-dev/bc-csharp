// ============================================
// PROYECTO SEMANA 02: Inventario en memoria
// ============================================
// NOTA PARA EL APRENDIZ:
// Adapta los nombres, textos y datos a tu dominio asignado.
// - Biblioteca: Book / BookCatalog, préstamo y devolución
// - Farmacia: Medicine / MedicineCatalog, venta y recepción
// - Hotel: Room / RoomCatalog, reserva y cancelación

using System.Globalization;

// TODO: sustituye estos datos por ≥ 12 registros de tu dominio. Deja al menos una línea inválida
// para comprobar que la carga la reporta y la salta.
const string SeedData = """
    KB-01;Keyboard;periféricos;49.99;12
    MS-02;Mouse;periféricos;19.50;30
    MN-03;Monitor 27;pantallas;289.00;4
    XX-99;Línea rota;sin-precio;abc;1
    """;

var catalog = new Catalog();
int rejected = catalog.Load(SeedData);
Console.WriteLine($"=== Inventario de <tu dominio> === {catalog.Count} registros cargados, {rejected} rechazados");

// TODO: cola de movimientos de tu dominio (≥ 5). Se procesa con la opción 5.
var pending = new Queue<(string Key, int Delta)>();
pending.Enqueue(("MS-02", -5));
pending.Enqueue(("MN-03", -10));   // debe rechazarse: dejaría el conteo en negativo
pending.Enqueue(("KB-01", +3));

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

    switch (choice)
    {
        case "1":
            Console.Write("Clave: ");
            string key = Console.ReadLine() ?? "";
            Console.WriteLine(catalog.TryFind(key, out Item item) ? item : "No existe.");
            break;
        case "2":
            Console.Write("Texto a buscar: ");
            string term = Console.ReadLine() ?? "";
            foreach (Item match in catalog.Search(term))
                Console.WriteLine(Catalog.Highlight(match.Name, term));
            break;
        case "3":
            Console.WriteLine($"Categorías: {string.Join(", ", catalog.Categories)}");
            break;
        case "4":
            // TODO: mostrar los 3 primeros y 2 últimos de cada grupo usando rangos.
            foreach (var (category, items) in catalog.GroupByCategory())
                Console.WriteLine($"[{category}] {items.Count} artículos");
            break;
        case "5":
            while (pending.TryDequeue(out var movement))
            {
                bool ok = catalog.TryApply(movement.Key, movement.Delta, out int remaining);
                Console.WriteLine($"  {movement.Key} {movement.Delta:+#;-#;0}: {(ok ? $"OK → {remaining}" : "rechazado")}");
            }
            break;
        case "6":
            Console.WriteLine(catalog.TryUndo(out string undoneKey) ? $"Deshecho: {undoneKey}" : "Nada que deshacer.");
            break;
        case "7":
            Console.WriteLine(ReportBuilder.Build(catalog, CultureInfo.InvariantCulture));
            break;
        default:
            Console.WriteLine("Opción no válida. Elige 0-7.");
            break;
    }

    Console.WriteLine();
}

static void ShowMenu()
{
    // TODO: textos de tu dominio
    Console.WriteLine("1) Buscar por clave        (Dictionary.TryGetValue)");
    Console.WriteLine("2) Buscar por texto        (StringComparison + params)");
    Console.WriteLine("3) Listar categorías       (HashSet)");
    Console.WriteLine("4) Agrupar y ordenar       (Dictionary<string, List>, Sort, rangos)");
    Console.WriteLine("5) Procesar movimientos    (Queue)");
    Console.WriteLine("6) Deshacer último         (Stack)");
    Console.WriteLine("7) Reporte                 (StringBuilder, formato, cultura)");
    Console.WriteLine("0) Salir");
}
