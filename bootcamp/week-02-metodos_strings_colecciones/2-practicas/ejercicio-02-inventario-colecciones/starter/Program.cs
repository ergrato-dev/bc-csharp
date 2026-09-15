// Ejercicio 02 — Inventario con colecciones
// El programa compila y ejecuta desde el paso 0. Descomenta cada PASO en orden.

// PASO 7 necesita estos usings (ImplicitUsings no incluye Globalization ni Text):
// using System.Globalization;
// using System.Text;

Console.WriteLine("Inventario listo.");

// ============================================
// PASO 1: record struct + List<T> con collection expression
// ============================================
// Un record struct genera igualdad por valor: dos Item con los mismos campos son iguales.
// Descomenta las siguientes líneas (el record va al FINAL del archivo, PASO 1b):
// List<Item> items =
// [
//     new("KB-01", "Keyboard", "periféricos", 49.99m, 12),
//     new("MS-02", "Mouse", "periféricos", 19.50m, 30),
//     new("MN-03", "Monitor 27\"", "pantallas", 289.00m, 4),
//     new("CB-04", "Cable USB-C", "cables", 9.99m, 0),
//     new("HD-05", "Headset", "audio", 79.00m, 7),
// ];
// Console.WriteLine($"{items.Count} artículos · último: {items[^1].Name}");

// ============================================
// PASO 2: Dictionary<string, Item> indexado por SKU
// ============================================
// TryGetValue evita KeyNotFoundException; TryAdd devuelve false si la clave existe.
// Descomenta las siguientes líneas:
// var bySku = new Dictionary<string, Item>(StringComparer.OrdinalIgnoreCase);
// foreach (Item item in items) bySku[item.Sku] = item;
//
// Console.WriteLine(bySku.TryGetValue("ms-02", out Item found)
//     ? $"MS-02 → {found.Name} ({found.Quantity} uds)"
//     : "MS-02 no existe");
// Console.WriteLine($"TryAdd duplicado: {bySku.TryAdd("KB-01", items[0])}");
// Console.WriteLine($"¿Existe ZZ-99? {bySku.ContainsKey("ZZ-99")}");

// ============================================
// PASO 3: HashSet<T> para categorías y pertenencia
// ============================================
// Add devuelve false si ya existía. Contains es O(1): ideal para "¿lo he visto?".
// Descomenta las siguientes líneas:
// var categories = new HashSet<string>();
// foreach (Item item in items)
//     Console.WriteLine($"  {item.Category,-12} {(categories.Add(item.Category) ? "nueva" : "repetida")}");
// Console.WriteLine($"Categorías: {string.Join(", ", categories)}");
//
// HashSet<string> lowStockSkus = [.. FindLowStock(items, threshold: 5)];
// Console.WriteLine($"Stock bajo: {string.Join(", ", lowStockSkus)}");
//
// static List<string> FindLowStock(List<Item> items, int threshold)
// {
//     var result = new List<string>();
//     foreach (Item item in items)
//         if (item.Quantity < threshold) result.Add(item.Sku);
//     return result;
// }

// ============================================
// PASO 4: Queue<T> de pedidos y out para el resultado
// ============================================
// La cola procesa en orden de llegada (FIFO). Item es un struct: para cambiar el stock
// dentro de la lista hay que reasignar items[i] con un nuevo record (with).
// Descomenta las siguientes líneas:
// var orders = new Queue<(string Sku, int Units)>();
// orders.Enqueue(("MS-02", 5));
// orders.Enqueue(("CB-04", 1));
// orders.Enqueue(("MN-03", 4));
//
// while (orders.TryDequeue(out var order))
// {
//     bool ok = TryReserve(items, order.Sku, order.Units, out int remaining);
//     Console.WriteLine($"  pedido {order.Sku} × {order.Units}: {(ok ? $"OK, quedan {remaining}" : "sin stock")}");
// }
//
// static bool TryReserve(List<Item> items, string sku, int units, out int remaining)
// {
//     int index = items.FindIndex(i => i.Sku == sku);
//     if (index < 0 || items[index].Quantity < units)
//     {
//         remaining = index < 0 ? 0 : items[index].Quantity;
//         return false;
//     }
//     items[index] = items[index] with { Quantity = items[index].Quantity - units };
//     remaining = items[index].Quantity;
//     return true;
// }

// ============================================
// PASO 5: Stack<T> para deshacer cambios de precio
// ============================================
// LIFO: el último cambio es el primero en deshacerse.
// Descomenta las siguientes líneas:
// var history = new Stack<(string Sku, decimal OldPrice)>();
// ChangePrice(items, history, "KB-01", 44.99m);
// ChangePrice(items, history, "KB-01", 39.99m);
// Console.WriteLine($"  KB-01 ahora: {items[0].Price}");
// Undo(items, history);
// Console.WriteLine($"  KB-01 tras undo: {items[0].Price} · cambios pendientes: {history.Count}");
//
// static void ChangePrice(List<Item> items, Stack<(string, decimal)> history, string sku, decimal newPrice)
// {
//     int index = items.FindIndex(i => i.Sku == sku);
//     history.Push((sku, items[index].Price));
//     items[index] = items[index] with { Price = newPrice };
// }
//
// static void Undo(List<Item> items, Stack<(string Sku, decimal OldPrice)> history)
// {
//     if (!history.TryPop(out var last)) return;
//     int index = items.FindIndex(i => i.Sku == last.Sku);
//     items[index] = items[index] with { Price = last.OldPrice };
// }

// ============================================
// PASO 6: Ordenar, rangos y spread
// ============================================
// Sort in-place con comparador; [..2] y [^2..] cortan (copian); [.. a, .. b] concatena.
// Descomenta las siguientes líneas:
// List<Item> byValue = [.. items];
// byValue.Sort((a, b) => (b.Price * b.Quantity).CompareTo(a.Price * a.Quantity));
// List<Item> topTwo = byValue[..2];
// List<Item> bottomTwo = byValue[^2..];
// List<Item> extremes = [.. topTwo, .. bottomTwo];
// Console.WriteLine($"  extremos por valor: {string.Join(", ", extremes.ConvertAll(i => i.Sku))}");
// Console.WriteLine($"  valor total: {TotalValue(items[0], items[1], items[2])} (3 primeros) · {TotalValue([.. items])} (todos)");
//
// static decimal TotalValue(params ReadOnlySpan<Item> items)
// {
//     decimal total = 0;
//     foreach (Item item in items) total += item.Price * item.Quantity;
//     return total;
// }

// ============================================
// PASO 7: Reporte agrupado con StringBuilder
// ============================================
// Dictionary<string, List<Item>> agrupa por categoría; el reporte alinea columnas y usa cultura fija.
// Descomenta las siguientes líneas (y los usings del inicio):
// Console.WriteLine(BuildReport(items));
//
// static string BuildReport(List<Item> items)
// {
//     var groups = new Dictionary<string, List<Item>>();
//     foreach (Item item in items)
//     {
//         if (!groups.TryGetValue(item.Category, out List<Item>? group))
//             groups[item.Category] = group = [];
//         group.Add(item);
//     }
//
//     var sb = new StringBuilder();
//     sb.AppendLine(string.Create(CultureInfo.InvariantCulture, $"{"SKU",-7}{"Artículo",-14}{"Precio",10}{"Uds",5}{"Valor",11}"));
//     foreach (var (category, group) in groups)
//     {
//         sb.AppendLine($"[{category}]");
//         foreach (Item i in group)
//             sb.AppendLine(string.Create(CultureInfo.InvariantCulture, $"{i.Sku,-7}{i.Name,-14}{i.Price,10:N2}{i.Quantity,5}{i.Price * i.Quantity,11:N2}"));
//     }
//     sb.Append(string.Create(CultureInfo.InvariantCulture, $"{"TOTAL",-36}{TotalValue([.. items]),11:N2}"));
//     return sb.ToString();
// }

// ============================================
// PASO 1b: el tipo Item (va al final: las declaraciones de tipos cierran el archivo)
// ============================================
// Descomenta las siguientes líneas:
// public readonly record struct Item(string Sku, string Name, string Category, decimal Price, int Quantity);
