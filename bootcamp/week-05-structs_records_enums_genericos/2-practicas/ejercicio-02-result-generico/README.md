# Ejercicio 02 — Un `Result<T, E>` genérico

> Tutorial guiado. Descomenta paso a paso en `starter/Program.cs` y ejecuta `dotnet run` tras cada paso.

## 🎯 Objetivo

Escribir código genérico de verdad: un `Result<TValue, TError>` como `readonly record struct` con `Match` y `Map`, un repositorio con restricciones (`where TEntity : class, IEntity<TKey>`), matemáticas genéricas con `INumber<T>`, comparación sin restricciones con `EqualityComparer<T>.Default` y varianza `in`/`out` en interfaces propias.

**Duración**: 90 min · **Teoría relacionada**: 04, 05, 06 (y 01–02 para el `readonly record struct`)

## 🚀 Preparación

```bash
cd starter
dotnet run
```

Los tipos viven al final en tres bloques (`TIPOS A`, `B`, `C`) que se descomentan junto a los pasos 1, 4 y 7.

## Paso 1: un tipo genérico con dos parámetros

`Result<TValue, TError>` representa "salió bien con este valor" o "falló con este error" **sin lanzar excepciones**: el complemento del patrón `TryXxx` de la semana 03 cuando el fallo necesita datos.

```csharp
public readonly record struct Result<TValue, TError>
{
    public static Result<TValue, TError> Ok(TValue value) => new(true, value, default!);
    public static Result<TValue, TError> Fail(TError error) => new(false, default!, error);
}
```

Descomenta `PASO 1`, `TIPOS A` y las líneas de `using`/cultura. Fíjate en los constructores privados y las factorías: es imposible construir un `Result` incoherente.

## Paso 2: devolver `Result` y consumirlo con `Match`

```csharp
string message = parsed.Match(
    onOk: value => $"cantidad válida: {value}",
    onError: error => $"rechazado ({error})");
```

Descomenta `PASO 2`. `Match` obliga a tratar **los dos caminos**: no existe la vía "me olvidé del error". Compáralo con el `try/catch` del mismo caso y compara también el coste: aquí no se construye ninguna excepción.

## Paso 3: `Map` transforma solo el camino feliz

```csharp
public Result<TNext, TError> Map<TNext>(Func<TValue, TNext> map)
    => IsOk ? Result<TNext, TError>.Ok(map(_value)) : Result<TNext, TError>.Fail(_error);
```

Descomenta `PASO 3`. Es un **método genérico dentro de un tipo genérico**: `TNext` se infiere del lambda. Sobre un `Fail`, el lambda ni se ejecuta y el error viaja intacto.

## Paso 4: restricciones — un repositorio reutilizable

```csharp
public sealed class InMemoryRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : notnull
```

Descomenta `PASO 4` y `TIPOS B`. Cada `where` desbloquea algo concreto: `IEntity<TKey>` permite leer `entity.Id`; `notnull` es lo que exige `Dictionary` para una clave. Quita `where TKey : notnull` y observa el error del `Dictionary`.

## Paso 5: matemáticas genéricas con `INumber<T>`

```csharp
static T Sum<T>(IReadOnlyList<T> values) where T : INumber<T>
{
    T total = T.Zero;                       // miembro static abstract de la interfaz
    foreach (T value in values) total += value;
    return total;
}
```

Descomenta `PASO 5`. Antes de C# 11 esto era imposible: una interfaz no podía exigir miembros estáticos ni operadores. `T.CreateChecked(values.Count)` convierte el `int` al `T` que toque.

## Paso 6: comparar sin pedir restricciones

```csharp
if (EqualityComparer<T>.Default.Equals(item, target)) count++;
```

Descomenta `PASO 6`. No hace falta `where T : IEquatable<T>`: `EqualityComparer<T>.Default` resuelve la mejor comparación disponible para cada tipo, sin boxing. Es lo que hacen `List<T>.Contains` y `Dictionary<K,V>` por dentro.

## Paso 7: varianza `out` e `in`

```csharp
public interface IReadOnlyBox<out T> { T Get(); }      // la T solo SALE
public interface IWriter<in T> { void Write(T value); } // la T solo ENTRA

IReadOnlyBox<object> asObjects = rooms;     // covarianza
IWriter<Room> roomWriter = anyWriter;       // contravarianza
```

Descomenta `PASO 7` y `TIPOS C`. Añade `void Set(T value)` a `IReadOnlyBox<out T>`: error CS1961, porque la T pasaría a entrar. Prueba también `IReadOnlyBox<int>` → `IReadOnlyBox<object>`: no compila, la varianza no aplica a tipos por valor.

## ✅ Verificación

```
Ejercicio 02 — genéricos y Result<T, E>. Sigue los pasos del README.
Ok(42) · Fail(no es un número)
valor con respaldo: 42 / -1

12    → cantidad válida: 12
abc   → rechazado (no es un entero)
-3    → rechazado (debe ser positivo)

Map sobre Ok:   Ok(7 unidades)
Map sobre Fail: Fail(no es un entero)

repositorio con 2 elementos
encontrada: Doble
id 999: no encontrada (null, sin excepción)

Sum<int>:     10
Sum<decimal>: 10.75
Average<double>: 2.333

CountEqual sin restricción (string): 2
CountEqual sin restricción (int):    3
CountEqual con records:              1

covarianza (out): Room { Id = RoomId { Value = 103 }, Name = Individual, Rate = 59 }
contravarianza (in): Room { Id = RoomId { Value = 104 }, Name = Doble, Rate = 89 }
IComparer<object> ordenando strings: a,b
```

`dotnet build -warnaserror` sin warnings.

## 🧠 Preguntas de reflexión

1. `Result<T, E>` es un `readonly record struct` y no una `class`. ¿Qué ganas y qué arriesgas si `TValue` es un tipo grande?
2. `Match` recibe dos lambdas; `ValueOr` recibe un valor. ¿Cuándo usarías cada uno y qué pasa con el error en el segundo caso?
3. El repositorio pide `where TEntity : class`. ¿Qué dejaría de funcionar si permitieras también tipos por valor?
