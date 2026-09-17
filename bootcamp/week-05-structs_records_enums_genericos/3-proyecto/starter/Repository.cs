// ============================================
// Infraestructura genérica: no conoce tu dominio
// ============================================
// NOTA PARA EL APRENDIZ:
// Igual que Results.cs, este archivo debe poder copiarse a otro proyecto sin tocar una línea.

/// <summary>Todo lo que se guarda en el repositorio tiene identidad.</summary>
public interface IEntity<out TKey> where TKey : notnull
{
    TKey Id { get; }
}

/// <summary>Solo lectura: covariante, se puede leer como IReadOnlyRepository&lt;object, TKey&gt;… si te hace falta.</summary>
public interface IReadOnlyRepository<TEntity, in TKey>
    where TEntity : class
    where TKey : notnull
{
    TEntity? Find(TKey id);
    IReadOnlyList<TEntity> All();
}

public sealed class InMemoryRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : notnull
{
    private readonly Dictionary<TKey, TEntity> _items = [];

    public int Count => _items.Count;

    public TEntity? Find(TKey id) => _items.GetValueOrDefault(id);

    public IReadOnlyList<TEntity> All() => [.. _items.Values];

    public Result<TEntity, DomainError> Add(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        // TODO: rechazar duplicados devolviendo Fail(DomainError...), nunca lanzando.
        throw new NotImplementedException();
    }

    public Result<TEntity, DomainError> Replace(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        // TODO: exigir que exista; si no, Fail(DomainError.NotFound(...)).
        throw new NotImplementedException();
    }

    public bool Remove(TKey id) => _items.Remove(id);
}

// TODO: escribe UN método genérico de utilidad que te haga falta en el menú, por ejemplo:
//   static IReadOnlyList<TResult> MapAll<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> map)
//   static int CountEqual<T>(IReadOnlyList<T> items, T target)      // usa EqualityComparer<T>.Default
// Debe funcionar con CUALQUIER tipo, sin restricciones innecesarias.
