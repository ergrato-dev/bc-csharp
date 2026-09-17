// ============================================
// Dominio modelado con records, structs y enums
// ============================================
// NOTA PARA EL APRENDIZ:
// Renombra TODO a tu dominio asignado:
// - Biblioteca: BookId / Book / LoanStatus / BookFeatures
// - Farmacia:   MedicineId / Medicine / SaleStatus / Requirements
// - Hotel:      RoomId / Room / BookingStatus / Amenities

/// <summary>Identificador tipado: el compilador impide confundirlo con el de otra entidad.</summary>
public readonly record struct ItemId(Guid Value)
{
    public static ItemId New() => new(Guid.CreateVersion7());

    public override string ToString() => $"item:{Value:N}"[..12];
}

// TODO: declara UN segundo identificador tipado de tu dominio (ClientId, MemberId, PatientId...)
// y comprueba en el menú que no se puede pasar donde va un ItemId.

/// <summary>Estado del ciclo de vida. TODO: adapta los nombres; el 0 debe ser neutro.</summary>
public enum ItemStatus
{
    Draft = 0,
    Active = 1,
    Reserved = 2,
    Retired = 3,
}

/// <summary>Conjunto de características opcionales. TODO: adapta y mantén las potencias de dos.</summary>
[Flags]
public enum ItemFeatures
{
    None = 0,
    Featured = 1 << 0,
    Discounted = 1 << 1,
    Fragile = 1 << 2,
    // TODO: añade al menos una más de tu dominio
    All = Featured | Discounted | Fragile,
}

/// <summary>Valor monetario: pequeño, inmutable y con igualdad por valor.</summary>
public readonly record struct Money(decimal Amount, string Currency = "EUR")
{
    public Money Add(Money other) => Currency == other.Currency
        ? this with { Amount = Amount + other.Amount }
        : throw new InvalidOperationException("Monedas distintas.");

    public override string ToString() => $"{Amount:N2} {Currency}";
}

/// <summary>Entidad del catálogo. TODO: renombra y adapta los campos (mínimo 6).</summary>
public sealed record Item(ItemId Id, string Code, string Name, Money Price, ItemStatus Status, ItemFeatures Features)
    : IEntity<ItemId>
{
    // TODO: valida Code y Name. Dos vías: factoría estática Create con guard clauses,
    // o redeclarar la propiedad con la validación en el inicializador.
    public static Result<Item, DomainError> Create(string code, string name, decimal amount)
    {
        // TODO: devolver Ok(...) o Fail(DomainError...) SIN lanzar excepciones.
        throw new NotImplementedException();
    }

    public bool Has(ItemFeatures feature) => (Features & feature) != 0;
}
