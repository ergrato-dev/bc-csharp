// ============================================
// PROYECTO SEMANA 04: Modelo de dominio con jerarquía, interfaces y polimorfismo
// ============================================
// NOTA PARA EL APRENDIZ:
// Adapta nombres, textos y datos a tu dominio asignado.
// - Biblioteca: Book / Magazine / Dvd, préstamo y devolución
// - Farmacia:   Medicine / Cosmetic / MedicalDevice, receta y caducidad
// - Hotel:      Room / MeetingRoom / ParkingSpot, reserva y liberación
//
// Reglas de la semana: campos privados, estado público como propiedad, sealed por defecto,
// el servicio depende de interfaces, y ningún catálogo de if (x is TipoConcreto) para decidir
// comportamiento que debería ser un método virtual.

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

IItemRepository repository = new InMemoryItemRepository();
var service = new CatalogService(repository, new NoPricingPolicy());

Console.WriteLine("=== Catálogo de <tu dominio> ===");

// TODO: da de alta al menos 6 elementos repartidos entre tus TRES derivadas.
// repository.Save(new Book("LIB-001", "Clean Code", 42.50m, pages: 464));

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
            case "2": ShowByCategory(); break;
            case "3": Reserve(); break;
            case "4": Release(); break;
            case "5": ChangePolicy(); break;
            case "6": ShowTotals(); break;
            default: Console.WriteLine("Opción no reconocida."); break;
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"⚠ dato inválido en '{ex.ParamName}': {ex.Message}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"⚠ {ex.Message}");
    }
}

static void ShowMenu()
{
    Console.WriteLine();
    Console.WriteLine("1) Listar  2) Por categoría  3) Reservar  4) Liberar  5) Cambiar política  6) Totales  0) Salir");
}

void ListAll()
{
    // TODO: recorrer service.All() y escribir item.Describe() (polimorfismo: un solo bucle).
    throw new NotImplementedException();
}

void ShowByCategory()
{
    // TODO: agrupar por la propiedad Category (abstracta en la base) y mostrar el recuento.
    throw new NotImplementedException();
}

void Reserve()
{
    // TODO: pedir el código, buscar y reservar SOLO si el elemento implementa IReservable
    // (usa `is IReservable r`). Si no lo implementa, informa; no lances NotSupportedException.
    throw new NotImplementedException();
}

void Release()
{
    // TODO: simétrico de Reserve.
    throw new NotImplementedException();
}

void ChangePolicy()
{
    // TODO: elegir entre tus dos políticas y la decorada; llamar a service.UsePolicy(...).
    // Demuestra que cambiar la política NO cambia ni una línea de CatalogService.
    throw new NotImplementedException();
}

void ShowTotals()
{
    // TODO: total mensual con MonthlyCost() y total con la política activa, alineados y con :N2.
    throw new NotImplementedException();
}

// ============================================
// Servicio: solo conoce interfaces
// ============================================
public sealed class CatalogService(IItemRepository repository, IPricingPolicy pricing)
{
    private IPricingPolicy _pricing = pricing;

    public string PolicyName => _pricing.Name;

    public IReadOnlyList<CatalogItem> All() => repository.All();

    public void UsePolicy(IPricingPolicy policy)
    {
        ArgumentNullException.ThrowIfNull(policy);
        _pricing = policy;
    }

    public decimal Price(CatalogItem item) => _pricing.Compute(item);

    // TODO: añade un método de negocio propio de tu dominio que use el repositorio
    // y la política, sin conocer ninguna clase concreta (por ejemplo: presupuesto de una
    // categoría entera, elementos por encima de un precio, informe alineado...).
}

/// <summary>Política neutra de arranque. TODO: sustitúyela por las tuyas desde el menú.</summary>
public sealed class NoPricingPolicy : IPricingPolicy
{
    public string Name => "sin política";

    public decimal Compute(CatalogItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        return item.BaseValue;
    }
}
