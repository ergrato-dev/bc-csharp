// ============================================
// DomainCalculator: los cuatro cálculos de tu dominio
// ============================================
// NOTA PARA EL APRENDIZ:
// Renombra la clase y los métodos según tu dominio (LibraryCalculator, PharmacyCalculator...).
// Cada método recibe datos ya validados y devuelve un valor: sin Console aquí dentro.

public static class DomainCalculator
{
    /// <summary>Cálculo monetario. Usa decimal: nunca double para dinero.</summary>
    public static decimal CalculateMoney(decimal baseAmount)
    {
        // TODO: reemplaza por la fórmula de tu dominio (IVA, descuento, multa por día...).
        const decimal TaxRate = 0.21m;
        return baseAmount * (1 + TaxRate);
    }

    /// <summary>Cálculo con medidas o proporciones. Usa double.</summary>
    public static double CalculateMeasure(double first, double second)
    {
        // TODO: por ejemplo IMC = peso / altura², o consumo l/100 km, o porcentaje de ocupación.
        throw new NotImplementedException();
    }

    /// <summary>Cálculo de conteo. Multiplica en contexto checked.</summary>
    public static long CalculateCount(int quantity, int factor)
    {
        // TODO: multiplica en checked y deja que OverflowException suba al llamador,
        // que la captura y muestra un mensaje claro.
        throw new NotImplementedException();
    }

    /// <summary>Clasifica un valor con switch expression y patrones relacionales.</summary>
    public static string Classify(double value)
    {
        // TODO: al menos 4 categorías, sin huecos ni solapamientos, con brazo _ o exhaustivo.
        return value switch
        {
            < 0 => "inválido",
            _ => "TODO",
        };
    }
}
