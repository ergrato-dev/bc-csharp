// Ejercicio 02 — Un Result<T, E> genérico
// El programa compila y ejecuta desde el paso 0. Descomenta cada PASO en orden.
// Los TIPOS van al final: en top-level statements toda declaración de tipo se escribe
// DESPUÉS de la última instrucción (error CS8803 si no).

// Desde el paso 1 hacen falta estas líneas (System.Numerics es para INumber<T> del paso 5):
// using System.Globalization;
// using System.Numerics;
// CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

Console.WriteLine("Ejercicio 02 — genéricos y Result<T, E>. Sigue los pasos del README.");

// ============================================
// PASO 1: Un tipo genérico con dos parámetros
// ============================================
// Result<TValue, TError> representa éxito o fallo SIN excepciones (semana 03).
// Es un readonly record struct: valor pequeño, inmutable y con igualdad generada.
// Descomenta también TIPOS A y las líneas de using/cultura.
// Descomenta las siguientes líneas:
// var okInt = Result<int, string>.Ok(42);
// var failInt = Result<int, string>.Fail("no es un número");
// Console.WriteLine($"{okInt} · {failInt}");
// Console.WriteLine($"valor con respaldo: {okInt.ValueOr(-1)} / {failInt.ValueOr(-1)}");

// ============================================
// PASO 2: Devolver Result en vez de lanzar, y consumirlo con Match
// ============================================
// ParseQuantity distingue dos fallos distintos sin construir ninguna excepción.
// Match obliga a tratar AMBOS caminos: no hay forma de olvidarse del error.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// foreach (string raw in (string[])["12", "abc", "-3"])
// {
//     Result<int, string> parsed = ParseQuantity(raw);
//     string message = parsed.Match(
//         onOk: value => $"cantidad válida: {value}",
//         onError: error => $"rechazado ({error})");
//     Console.WriteLine($"{raw,-5} → {message}");
// }
//
// static Result<int, string> ParseQuantity(string raw)
// {
//     if (!int.TryParse(raw, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
//         return Result<int, string>.Fail("no es un entero");
//     return value > 0 ? Result<int, string>.Ok(value) : Result<int, string>.Fail("debe ser positivo");
// }

// ============================================
// PASO 3: Map: transformar solo el camino feliz
// ============================================
// Map<TNext> cambia el tipo del valor y propaga el error intacto.
// Fíjate en la firma: un método genérico dentro de un tipo genérico.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// Result<string, string> label = ParseQuantity("7").Map(v => $"{v} unidades");
// Console.WriteLine($"Map sobre Ok:   {label}");
// Console.WriteLine($"Map sobre Fail: {ParseQuantity("x").Map(v => $"{v} unidades")}");

// ============================================
// PASO 4: Restricciones: un repositorio genérico reutilizable
// ============================================
// where TEntity : class, IEntity<TKey> permite leer entity.Id sin conocer el tipo.
// where TKey : notnull es lo que exige Dictionary para la clave.
// Descomenta también TIPOS B.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// var repo = new InMemoryRepository<Room, RoomId>();
// repo.Save(new Room(new RoomId(101), "Doble", 89.90m));
// repo.Save(new Room(new RoomId(102), "Suite", 159.00m));
// Console.WriteLine($"repositorio con {repo.Count} elementos");
// Console.WriteLine(repo.Find(new RoomId(101)) is { } found ? $"encontrada: {found.Name}" : "no encontrada");
// Console.WriteLine(repo.Find(new RoomId(999)) is null ? "id 999: no encontrada (null, sin excepción)" : "??");

// ============================================
// PASO 5: Matemáticas genéricas con INumber<T>
// ============================================
// static abstract en interfaces (C# 11) permite exigir T.Zero y los operadores.
// El mismo algoritmo sirve para int, decimal o double, y se compila especializado.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// Console.WriteLine($"Sum<int>:     {Sum<int>([1, 2, 3, 4])}");
// Console.WriteLine($"Sum<decimal>: {Sum<decimal>([10.5m, 0.25m])}");
// Console.WriteLine($"Average<double>: {Average<double>([1, 2, 4]):F3}");
//
// static T Sum<T>(IReadOnlyList<T> values) where T : INumber<T>
// {
//     T total = T.Zero;
//     foreach (T value in values) total += value;
//     return total;
// }
//
// static T Average<T>(IReadOnlyList<T> values) where T : INumber<T>
//     => values.Count == 0 ? T.Zero : Sum(values) / T.CreateChecked(values.Count);

// ============================================
// PASO 6: Comparar sin pedir restricciones
// ============================================
// EqualityComparer<T>.Default funciona con cualquier T y sin boxing.
// Es lo que usan las colecciones de la BCL en vez de exigir IEquatable<T>.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// Console.WriteLine($"CountEqual sin restricción (string): {CountEqual(["a", "b", "a"], "a")}");
// Console.WriteLine($"CountEqual sin restricción (int):    {CountEqual([1, 2, 1, 1], 1)}");
// Console.WriteLine($"CountEqual con records:              {CountEqual([new RoomId(1), new RoomId(2)], new RoomId(2))}");
//
// static int CountEqual<T>(IReadOnlyList<T> items, T target)
// {
//     int count = 0;
//     foreach (T item in items)
//         if (EqualityComparer<T>.Default.Equals(item, target)) count++;   // sin where, sin boxing
//     return count;
// }

// ============================================
// PASO 7: Varianza: out, in y un comparador más general
// ============================================
// IReadOnlyBox<out T>: la T solo sale, así que Box<Room> vale como IReadOnlyBox<object>.
// IWriter<in T>: la T solo entra, así que un IWriter<object> vale como IWriter<Room>.
// Descomenta también TIPOS C.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// IReadOnlyBox<Room> rooms = new Box<Room>(new Room(new RoomId(103), "Individual", 59m));
// IReadOnlyBox<object> asObjects = rooms;                 // covarianza: out T
// Console.WriteLine($"covarianza (out): {asObjects.Get()}");
//
// IWriter<object> anyWriter = new ConsoleWriter();
// IWriter<Room> roomWriter = anyWriter;                   // contravarianza: in T
// roomWriter.Write(new Room(new RoomId(104), "Doble", 89m));
//
// List<string> names = ["b", "a"];
// names.Sort(Comparer<object>.Create((x, y) => string.CompareOrdinal(x!.ToString(), y!.ToString())));
// Console.WriteLine($"IComparer<object> ordenando strings: {string.Join(",", names)}");

// ============================================
// TIPOS A: Result<TValue, TError> (pasos 1 a 3)
// ============================================
// Estructura inmutable con factorías Ok/Fail, ValueOr, Match y Map.
// Descomenta las siguientes líneas:
// public readonly record struct Result<TValue, TError>
// {
//     private Result(bool isOk, TValue value, TError error)
//     {
//         IsOk = isOk;
//         _value = value;
//         _error = error;
//     }
//
//     private readonly TValue _value;
//     private readonly TError _error;
//
//     public bool IsOk { get; }
//
//     public static Result<TValue, TError> Ok(TValue value) => new(true, value, default!);
//     public static Result<TValue, TError> Fail(TError error) => new(false, default!, error);
//
//     public TValue ValueOr(TValue fallback) => IsOk ? _value : fallback;
//
//     public TResult Match<TResult>(Func<TValue, TResult> onOk, Func<TError, TResult> onError)
//     {
//         ArgumentNullException.ThrowIfNull(onOk);
//         ArgumentNullException.ThrowIfNull(onError);
//         return IsOk ? onOk(_value) : onError(_error);
//     }
//
//     public Result<TNext, TError> Map<TNext>(Func<TValue, TNext> map)
//     {
//         ArgumentNullException.ThrowIfNull(map);
//         return IsOk ? Result<TNext, TError>.Ok(map(_value)) : Result<TNext, TError>.Fail(_error);
//     }
//
//     public override string ToString() => IsOk ? $"Ok({_value})" : $"Fail({_error})";
// }

// ============================================
// TIPOS B: IEntity, RoomId, Room y InMemoryRepository (paso 4)
// ============================================
// Infraestructura genérica con restricciones: no conoce ninguna entidad concreta.
// Descomenta las siguientes líneas:
// public interface IEntity<out TKey> where TKey : notnull
// {
//     TKey Id { get; }
// }
//
// public readonly record struct RoomId(int Value);
//
// public sealed record Room(RoomId Id, string Name, decimal Rate) : IEntity<RoomId>;
//
// public sealed class InMemoryRepository<TEntity, TKey>
//     where TEntity : class, IEntity<TKey>
//     where TKey : notnull
// {
//     private readonly Dictionary<TKey, TEntity> _items = [];
//
//     public int Count => _items.Count;
//
//     public void Save(TEntity entity)
//     {
//         ArgumentNullException.ThrowIfNull(entity);
//         _items[entity.Id] = entity;
//     }
//
//     public TEntity? Find(TKey id) => _items.GetValueOrDefault(id);
//
//     public IReadOnlyList<TEntity> All() => [.. _items.Values];
// }

// ============================================
// TIPOS C: Interfaces variantes y sus implementaciones (paso 7)
// ============================================
// IReadOnlyBox<out T> e IWriter<in T> con Box<T> y ConsoleWriter.
// Descomenta las siguientes líneas:
// public interface IReadOnlyBox<out T>
// {
//     T Get();
// }
//
// public sealed class Box<T>(T value) : IReadOnlyBox<T>
// {
//     public T Get() => value;
// }
//
// public interface IWriter<in T>
// {
//     void Write(T value);
// }
//
// public sealed class ConsoleWriter : IWriter<object>
// {
//     public void Write(object value) => Console.WriteLine($"contravarianza (in): {value}");
// }
