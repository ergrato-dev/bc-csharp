// ============================================
// Contratos del dominio: interfaces
// ============================================
// NOTA PARA EL APRENDIZ:
// Renombra a tu dominio (IBookRepository, IMemberRepository...).
// Regla: el servicio depende de ESTAS interfaces, nunca de una implementación concreta.

/// <summary>Acceso a los elementos del catálogo. Una interfaz por responsabilidad.</summary>
public interface IItemRepository
{
    CatalogItem? Find(string code);
    IReadOnlyList<CatalogItem> All();
    void Save(CatalogItem item);
    bool Remove(string code);
}

/// <summary>Política de precio: se inyecta, no se hereda (teoría 07).</summary>
public interface IPricingPolicy
{
    string Name { get; }
    decimal Compute(CatalogItem item);
}

/// <summary>Capacidad opcional: solo la implementan los elementos que se pueden reservar/prestar.</summary>
public interface IReservable
{
    bool IsAvailable { get; }
    void Reserve(string holder);
    void Release();

    // Miembro por defecto: quien implemente la interfaz lo hereda sin escribirlo.
    string ReservationLabel() => IsAvailable ? "disponible" : "reservado";
}

// TODO: añade UNA interfaz más que represente una capacidad de tu dominio
// (IRenewable, IPerishable, IDiscountable, IMaintainable...). Debe implementarla
// solo una parte de tus tipos: si la implementan todos, va en la clase base.
