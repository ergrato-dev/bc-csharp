# Restricciones genéricas (`where`)

## 🎯 Objetivos

Al finalizar este archivo, comprenderás:

- Qué restricciones existen y qué capacidad desbloquea cada una
- Cómo combinarlas y en qué orden deben escribirse
- Por qué `where T : struct` y `where T : class` cambian el significado de `T?`
- Qué son los miembros `static abstract` y las matemáticas genéricas (`INumber<T>`)
- Cómo elegir la restricción mínima que hace falta

## 📋 Conceptos clave

### 1. El catálogo completo

```csharp
where T : class            // tipo por referencia (T? = puede ser null)
where T : class?           // referencia, sin exigir no-nulabilidad
where T : struct           // tipo por valor no nullable (T? = Nullable<T>)
where T : notnull          // cualquier tipo, pero no nullable
where T : unmanaged        // struct sin referencias: interop, Span, blittable
where T : new()            // tiene constructor público sin parámetros (va SIEMPRE el último)
where T : Account          // deriva de esa clase
where T : IComparable<T>   // implementa esa interfaz
where T : U                // T deriva de (o implementa) otro parámetro de tipo
where T : default          // desambigua en overrides con T? sin restricción
```

### 2. Lo que cada restricción desbloquea

```csharp
public static T Create<T>() where T : new() => new T();                     // instanciar

public static T Max<T>(T a, T b) where T : IComparable<T>                   // comparar
    => a.CompareTo(b) >= 0 ? a : b;

public static bool IsEmpty<T>(T value) where T : class => value is null;    // comparar con null

public static int SizeOf<T>() where T : unmanaged => System.Runtime.CompilerServices.Unsafe.SizeOf<T>();

public sealed class Repository<TEntity, TKey>                               // varias a la vez
    where TEntity : class, IEntity<TKey>
    where TKey : notnull
{
    private readonly Dictionary<TKey, TEntity> _items = [];
    public TEntity? Find(TKey key) => _items.GetValueOrDefault(key);
}
```

Sin restricción, `T` solo ofrece lo de `object`: `ToString`, `Equals`, `GetHashCode`, `GetType`. Cada `where` es un permiso adicional que pagas exigiendo más a quien te use: **pide lo mínimo que necesites**.

### 3. `struct` / `class` y el significado de `T?`

```csharp
public static T? FindOrDefault<T>(IEnumerable<T> items, Func<T, bool> match) where T : class
    => items.FirstOrDefault(match);            // T? = referencia que puede ser null

public static T? FindOrNull<T>(IEnumerable<T> items, Func<T, bool> match) where T : struct
{
    foreach (T item in items) if (match(item)) return item;
    return null;                               // T? = Nullable<T>, con HasValue
}
```

El mismo `T?` significa dos cosas distintas según la restricción: anotación de nulabilidad (referencias, semana 09) o el `struct` `Nullable<T>`. Sin restricción, `T?` solo significa "puede ser `default`".

### 4. Restricción de tipo base: contratos del dominio

```csharp
public interface IEntity<TKey> where TKey : notnull
{
    TKey Id { get; }
}

public sealed class InMemoryRepository<TEntity, TKey> where TEntity : IEntity<TKey> where TKey : notnull
{
    private readonly Dictionary<TKey, TEntity> _items = [];

    public void Save(TEntity entity) => _items[entity.Id] = entity;   // puede leer Id gracias al where
    public IReadOnlyList<TEntity> All() => [.. _items.Values];
}
```

Esta es la forma habitual de escribir infraestructura reutilizable: el repositorio no conoce tus entidades, solo exige que tengan `Id`.

### 5. `static abstract`: matemáticas genéricas (C# 11+)

```csharp
using System.Numerics;

public static T Sum<T>(IEnumerable<T> values) where T : INumber<T>
{
    T total = T.Zero;                       // miembro estático exigido por la interfaz
    foreach (T value in values) total += value;   // operador exigido por la interfaz
    return total;
}

Console.WriteLine(Sum<int>([1, 2, 3]));         // 6
Console.WriteLine(Sum<decimal>([1.5m, 2.5m]));  // 4.0
```

Antes de C# 11 esto era imposible sin trucos: una interfaz no podía exigir miembros `static` ni operadores. Hoy `INumber<T>`, `IParsable<T>`, `IAdditionOperators<,,>` y compañía permiten escribir un algoritmo numérico una sola vez para todos los tipos numéricos.

```csharp
public interface IIdentifier<TSelf> where TSelf : IIdentifier<TSelf>
{
    static abstract TSelf Parse(string text);      // fábrica exigida por contrato
}
```

El patrón `where TSelf : IIdentifier<TSelf>` (tipo curiosamente recurrente) es el que usa toda la BCL para estos contratos.

### 6. Elegir la restricción mínima

| Quieres… | Restricción |
|---|---|
| Comparar con `null` | `where T : class` |
| Devolver `Nullable<T>` | `where T : struct` |
| Usarlo como clave de diccionario | `where T : notnull` |
| Instanciarlo | `where T : new()` |
| Ordenarlo | `where T : IComparable<T>` |
| Sumarlo / operarlo | `where T : INumber<T>` |
| Interop, `Span`, `stackalloc` | `where T : unmanaged` |

Si necesitas comparar por igualdad, **no hace falta restricción**: `EqualityComparer<T>.Default.Equals(a, b)` funciona con cualquier `T` y sin boxing. Es el truco que usan las colecciones de la BCL.

## 🔬 Bajo el capó

Las restricciones viven en los metadatos del IL: el CLR las **verifica al cargar** el tipo cerrado, así que no hay comprobación en tiempo de ejecución en cada llamada. `where T : new()` no llama al constructor por reflexión en .NET moderno: el JIT lo resuelve igual que un `newobj` normal para tipos por valor y con un helper barato para referencias.

Las restricciones son también lo que hace posible el **despacho sin boxing**: cuando `T` está restringido a una interfaz y el argumento es un `struct`, el compilador emite `constrained.callvirt`, que llama al método del `struct` directamente en vez de boxearlo. Es por esto que `Max<T>(a, b)` con `where T : IComparable<T>` no asigna memoria y la versión con `IComparable` sin genéricos sí.

Los miembros `static abstract` se despachan a través de la **method table del tipo cerrado**, que el JIT conoce: `T.Zero` acaba siendo una constante inlineada para `int`. Las matemáticas genéricas no son un envoltorio caro, sino código especializado por instanciación.

## ⚠️ Errores comunes

- Pedir `where T : class, new()` cuando bastaba `notnull`: complicas a quien te usa.
- Usar `where T : IEquatable<T>` en vez de `EqualityComparer<T>.Default`.
- Olvidar que `new()` va siempre al final de la lista de restricciones.
- Suponer que `T?` significa lo mismo con `class`, con `struct` y sin restricción.
- Crear una jerarquía de interfaces recursivas cuando un simple delegado (`Func<T, T, int>`) resolvía.

## 📚 Recursos adicionales

- [Restricciones de tipos genéricos](https://learn.microsoft.com/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters)
- [Matemáticas genéricas](https://learn.microsoft.com/dotnet/standard/generics/math)
- [`static abstract` en interfaces](https://learn.microsoft.com/dotnet/csharp/whats-new/tutorials/static-virtual-interface-members)
- [`EqualityComparer<T>.Default`](https://learn.microsoft.com/dotnet/api/system.collections.generic.equalitycomparer-1.default)

## ✅ Checklist de verificación

- [ ] Enumero las restricciones y qué desbloquea cada una
- [ ] Elijo la mínima restricción que hace falta para el algoritmo
- [ ] Explico las tres lecturas posibles de `T?`
- [ ] Escribo un método numérico genérico con `INumber<T>`
- [ ] Uso `EqualityComparer<T>.Default` en vez de exigir `IEquatable<T>`
