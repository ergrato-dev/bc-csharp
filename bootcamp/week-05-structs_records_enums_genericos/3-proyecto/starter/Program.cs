// ============================================
// PROYECTO SEMANA 05: Result<T, E> genérico + dominio con records y enums
// ============================================
// NOTA PARA EL APRENDIZ:
// Adapta nombres, textos y datos a tu dominio asignado.
// Reglas de la semana: nada de excepciones para casos esperados (usa Result),
// records para los datos, readonly record struct para los valores pequeños,
// enums validados en el borde y genéricos con la restricción MÍNIMA necesaria.

using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

var repository = new InMemoryRepository<Item, ItemId>();

Console.WriteLine("=== Catálogo de <tu dominio> ===");

// TODO: da de alta al menos 6 elementos usando Item.Create y repository.Add,
// e imprime el resultado con Match (uno de ellos debe fallar a propósito).

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
        case "1": ListAll(); break;
        case "2": Add(); break;
        case "3": ChangeStatus(); break;
        case "4": ToggleFeature(); break;
        case "5": Totals(); break;
        case "6": FindById(); break;
        default: Console.WriteLine("Opción no reconocida."); break;
    }
}

static void ShowMenu()
{
    Console.WriteLine();
    Console.WriteLine("1) Listar  2) Alta  3) Cambiar estado  4) Marcar/desmarcar característica  5) Totales  6) Buscar  0) Salir");
}

void ListAll()
{
    // TODO: listar con columnas alineadas mostrando estado y características ([Flags] como texto).
    throw new NotImplementedException();
}

void Add()
{
    // TODO: pedir los datos, llamar a Item.Create y a repository.Add, y presentar el
    // resultado con Match: ninguna excepción para un dato mal escrito por el usuario.
    throw new NotImplementedException();
}

void ChangeStatus()
{
    // TODO: leer el estado con Enum.TryParse + Enum.IsDefined (validación en el borde)
    // y aplicar la transición con `with`. Recuerda: el record es inmutable, creas otro.
    throw new NotImplementedException();
}

void ToggleFeature()
{
    // TODO: añadir (|) o quitar (&= ~) una característica del [Flags] del elemento.
    throw new NotImplementedException();
}

void Totals()
{
    // TODO: total por estado y suma de precios con un método genérico restringido a INumber<T>
    // o con Money.Add. Muestra también cuántos elementos tienen cada característica.
    throw new NotImplementedException();
}

void FindById()
{
    // TODO: buscar por código, devolver Result y consumirlo con Match.
    throw new NotImplementedException();
}
