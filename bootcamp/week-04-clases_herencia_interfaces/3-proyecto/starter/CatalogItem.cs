// ============================================
// Jerarquía del dominio
// ============================================
// NOTA PARA EL APRENDIZ:
// Renombra CatalogItem y sus derivadas a tu dominio:
// - Biblioteca: LibraryItem → Book / Magazine / Dvd
// - Farmacia:   Product    → Medicine / Cosmetic / MedicalDevice
// - Hotel:      Bookable   → Room / MeetingRoom / ParkingSpot

/// <summary>Base abstracta: estado e invariantes comunes a todo el catálogo.</summary>
public abstract class CatalogItem
{
    protected CatalogItem(string code, string name, decimal baseValue)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegative(baseValue);
        Code = code;
        Name = name;
        BaseValue = baseValue;
    }

    public string Code { get; }
    public string Name { get; }
    public decimal BaseValue { get; }

    /// <summary>Categoría que cada tipo concreto declara. TODO: decide qué devuelve cada derivada.</summary>
    public abstract string Category { get; }

    /// <summary>Regla de negocio que cambia por tipo. TODO: adapta el nombre a tu dominio.</summary>
    public abstract decimal MonthlyCost();

    /// <summary>Descripción extensible: las derivadas llaman a base.Describe() y añaden lo suyo.</summary>
    public virtual string Describe() => $"[{Code}] {Name} · {Category} · {BaseValue:N2}";

    public override string ToString() => Describe();

    // La identidad del dominio es el código, no la referencia.
    public override bool Equals(object? obj) => obj is CatalogItem other && Code == other.Code;
    public override int GetHashCode() => Code.GetHashCode(StringComparison.Ordinal);
}

// TODO: crea TRES derivadas selladas de tu dominio.
// - Cada una implementa Category y MonthlyCost de forma distinta (esa es la razón de que existan).
// - Al menos DOS deben redefinir Describe() llamando a base.Describe().
// - Al menos UNA implementa IReservable (y solo esa: si la implementan todas, va en la base).
// - Ninguna debe lanzar NotSupportedException en un override: eso rompe Liskov (teoría 07).
public sealed class SampleItem(string code, string name, decimal baseValue)
    : CatalogItem(code, name, baseValue)
{
    public override string Category => "sin-clasificar";

    public override decimal MonthlyCost() => 0m;
}
