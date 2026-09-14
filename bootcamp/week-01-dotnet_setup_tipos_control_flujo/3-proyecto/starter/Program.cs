// ============================================
// PROYECTO SEMANA 01: Calculadora de dominio
// ============================================
// NOTA PARA EL APRENDIZ:
// Adapta los nombres, textos y cálculos a tu dominio asignado.
// - Biblioteca: multa por retraso, ocupación, préstamos por socio, categoría de socio
// - Farmacia: precio con IVA, dosis por kg, unidades por tratamiento, nivel de stock
// - Gimnasio: cuota con promoción, IMC, sesiones por mes, categoría de IMC

using System.Globalization;

Console.WriteLine("=== Calculadora de <tu dominio> ===");

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

    // TODO: reemplaza los nombres de opción por los de tu dominio.
    // Cada brazo llama a un método de DomainCalculator y muestra el resultado.
    switch (choice)
    {
        case "1":
            RunMoneyCalculation();
            break;
        case "2":
            RunMeasureCalculation();
            break;
        case "3":
            RunCountCalculation();
            break;
        case "4":
            RunClassification();
            break;
        default:
            Console.WriteLine("Opción no válida. Elige 0-4.");
            break;
    }

    Console.WriteLine();
}

static void ShowMenu()
{
    // TODO: textos de tu dominio
    Console.WriteLine("1) Cálculo monetario   (decimal)");
    Console.WriteLine("2) Cálculo de medida   (double)");
    Console.WriteLine("3) Cálculo de conteo   (int/long, checked)");
    Console.WriteLine("4) Clasificación       (switch expression)");
    Console.WriteLine("0) Salir");
}

static void RunMoneyCalculation()
{
    // TODO: pide los datos con ReadDecimal, valida (no negativos) y llama a DomainCalculator.
    // Ejemplo biblioteca: días de retraso y tarifa diaria -> multa
    decimal? amount = ReadDecimal("Importe base: ");
    if (amount is null || amount < 0)
    {
        Console.WriteLine("Importe inválido.");
        return;
    }
    Console.WriteLine($"Resultado: {DomainCalculator.CalculateMoney(amount.Value):F2}");
}

static void RunMeasureCalculation()
{
    // TODO: pide dos double con ReadDouble, valida y llama a DomainCalculator.CalculateMeasure
    double? first = ReadDouble("Primer valor: ");
    double? second = ReadDouble("Segundo valor: ");
    if (first is null || second is null)
    {
        Console.WriteLine("Valores inválidos.");
        return;
    }
    Console.WriteLine("TODO: cálculo de medida");
}

static void RunCountCalculation()
{
    // TODO: pide enteros con ReadInt; llama a DomainCalculator.CalculateCount dentro de try
    // y captura OverflowException para mostrar un mensaje claro.
    int? quantity = ReadInt("Cantidad: ");
    if (quantity is null || quantity < 0)
    {
        Console.WriteLine("Cantidad inválida.");
        return;
    }
    Console.WriteLine("TODO: cálculo de conteo");
}

static void RunClassification()
{
    // TODO: pide un valor con ReadDouble y muestra DomainCalculator.Classify(valor)
    double? value = ReadDouble("Valor a clasificar: ");
    Console.WriteLine(value is null ? "Valor inválido." : DomainCalculator.Classify(value.Value));
}

// --------------------------------------------
// Lectura segura de entrada. No modifiques la firma; puedes añadir más helpers.
// Decisión de cultura: InvariantCulture -> el separador decimal es SIEMPRE el punto.
// TODO: documenta en tu README por qué eliges Invariant o CurrentCulture.
// --------------------------------------------
static decimal? ReadDecimal(string prompt)
{
    Console.Write(prompt);
    return decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal value)
        ? value
        : null;
}

static double? ReadDouble(string prompt)
{
    Console.Write(prompt);
    return double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double value)
        ? value
        : null;
}

static int? ReadInt(string prompt)
{
    Console.Write(prompt);
    return int.TryParse(Console.ReadLine(), out int value) ? value : null;
}
