// ============================================
// Implementación del repositorio en memoria
// ============================================
// NOTA PARA EL APRENDIZ:
// Esta clase es UNA implementación del contrato. En la semana 17 habrá otra contra PostgreSQL
// y el servicio no cambiará: esa es toda la gracia de depender de la interfaz.

public sealed class InMemoryItemRepository : IItemRepository
{
    private readonly Dictionary<string, CatalogItem> _items = new(StringComparer.OrdinalIgnoreCase);

    public CatalogItem? Find(string code)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code);
        // TODO: devolver el elemento o null SIN lanzar (TryGetValue / GetValueOrDefault).
        throw new NotImplementedException();
    }

    public IReadOnlyList<CatalogItem> All()
    {
        // TODO: devolver una vista de solo lectura; nunca expongas el Dictionary ni una List interna.
        throw new NotImplementedException();
    }

    public void Save(CatalogItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        // TODO: alta o actualización por código (sin distinguir mayúsculas).
        throw new NotImplementedException();
    }

    public bool Remove(string code)
    {
        // TODO: devolver true si existía, false si no. Nada de excepciones para un caso esperado.
        throw new NotImplementedException();
    }
}

// TODO: implementa DOS políticas de precio (IPricingPolicy) con reglas distintas de tu dominio
// y UN decorador que envuelva a cualquier política (recargo, descuento, mínimo facturable).
// El decorador implementa IPricingPolicy y recibe otro IPricingPolicy por constructor.
