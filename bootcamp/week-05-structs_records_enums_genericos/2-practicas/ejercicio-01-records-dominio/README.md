# Ejercicio 01 — Records para el dominio

> Tutorial guiado. Descomenta paso a paso en `starter/Program.cs` y ejecuta `dotnet run` tras cada paso.

## 🎯 Objetivo

Modelar datos como se hace hoy en C#: `record` posicional con igualdad por valor, `with` (y su copia superficial), `readonly record struct` para identificadores tipados, validación con factoría, `enum` validado en el borde, `[Flags]` con operaciones de bits y herencia de records con `EqualityContract`.

**Duración**: 90 min · **Teoría relacionada**: 01, 02, 03

## 🚀 Preparación

```bash
cd starter
dotnet run
```

Los tipos viven al final en cinco bloques (`TIPOS A` … `E`) que se descomentan junto a los pasos 1, 2, 3, 5 y 7.

## Paso 1: un `record` posicional

Una línea genera propiedades `init`, constructor, `Equals`, `GetHashCode`, `==`/`!=`, `ToString`, `Deconstruct` y constructor de copia.

```csharp
public sealed record Booking(string Code, DateOnly Date, int Nights);
var (code, date, nights) = a;
```

Descomenta `PASO 1`, `TIPOS A` y las dos líneas de `using`/cultura. Dos objetos **distintos** (`ReferenceEquals` es `False`) son **iguales** (`==` es `True`): eso es igualdad por valor.

## Paso 2: `with` y la copia superficial

```csharp
var extended = a with { Nights = 5 };     // objeto nuevo, original intacto
copy.Guests.Add("Linus");                 // ⚠️ la List<T> se comparte entre original y copia
```

Descomenta `PASO 2` y `TIPOS B`. Fíjate en la salida: **ambos** ven 2 invitados. `with` copia los campos, y un campo que es una referencia sigue apuntando a la misma lista.

## Paso 3: `readonly record struct` e identificadores tipados

```csharp
public readonly record struct RoomId(Guid Value);
public readonly record struct GuestId(Guid Value);
```

Descomenta `PASO 3` y `TIPOS C`. Prueba a comparar `id1 == new GuestId(id1.Value)`: no compila. Ese error en compilación es exactamente el bug de "pasé el id del huésped donde iba el de la habitación" que ya no puede ocurrir.

## Paso 4: validar un `record`

La sintaxis posicional acepta cualquier valor. La validación la pones tú: aquí con una factoría estática y guard clauses (semana 03).

```csharp
public static Booking Create(string code, DateOnly date, int nights)
{
    ArgumentException.ThrowIfNullOrWhiteSpace(code);
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(nights);
    return new Booking(code, date, nights);
}
```

Descomenta `PASO 4`. La otra vía es redeclarar la propiedad con validación en el inicializador; pruébala con `Nights`.

## Paso 5: `enum` validado y `switch` exhaustivo

```csharp
if (Enum.TryParse(input, ignoreCase: true, out BookingStatus status) && Enum.IsDefined(status))
```

Descomenta `PASO 5` y `TIPOS D`. Quita el `Enum.IsDefined`: `TryParse("99")` devuelve `true` y te cuela un estado que no existe. El caso `_` del `switch` es la red de seguridad cuando alguien añada `NoShow`.

## Paso 6: `[Flags]`

```csharp
var room = Amenities.Wifi | Amenities.Breakfast;   // combinar
(room & Amenities.Wifi) != 0                       // comprobar
room |= Amenities.Gym;                             // añadir
room &= ~Amenities.Wifi;                           // quitar
```

Descomenta `PASO 6`. Quita el atributo `[Flags]` de la declaración y vuelve a ejecutar: `ToString()` pasa de `"Wifi, Breakfast"` a `"3"`.

## Paso 7: herencia de records y patrones

```csharp
public record Vehicle(string Plate);
public sealed record Car(string Plate, int Doors) : Vehicle(Plate);

car switch { Car { Doors: >= 5 } c => ..., Car c => ..., _ => ... }
```

Descomenta `PASO 7` y `TIPOS E`. `vehicle == car` con la misma matrícula es `False`: `EqualityContract` compara los tipos reales antes que los datos. Los patrones de propiedad se ven a fondo en la semana 09.

## ✅ Verificación

```
Ejercicio 01 — records para el dominio. Sigue los pasos del README.
Booking { Code = H-1, Date = 04/01/2026, Nights = 3 }
a == b: True · ReferenceEquals: False · mismo hash: True
deconstruido: H-1 / 2026-04-01 / 3

original 3 noches · copia 5 noches · misma referencia: False
P-1 ve 2 invitados · P-2 ve 2

readonly record struct · id1 == id2: True
identificador tipado: room:11111111111111111111111111111111
GuestId es OTRO tipo: RoomId == GuestId ni siquiera compila

Booking { Code = H-9, Date = 05/01/2026, Nights = 2 }
rechazado: parámetro 'nights'

confirmed          → Confirmed (1) · confirmada
CheckedIn          → CheckedIn (2) · en curso
teletransportada   → estado desconocido, rechazado
valores declarados: Draft, Confirmed, CheckedIn, Cancelled

valor numérico: 3 · texto: Wifi, Breakfast
¿wifi? True · ¿gimnasio? False
tras añadir gym y quitar wifi: Breakfast, Gym (10)
¿incluye todo? False

vehicle == car con la misma matrícula: False
ToString del derivado: Car { Plate = 1234-AB, Doors = 5 }
familiar de 5 puertas
```

`dotnet build -warnaserror` sin warnings.

## 🧠 Preguntas de reflexión

1. `Party` demuestra que `with` no clona en profundidad. ¿Cómo rediseñarías `Party` para que la copia fuera segura sin renunciar al `record`?
2. `RoomId` es un `readonly record struct` y no una `class`. Justifícalo con los cuatro criterios de la teoría 01.
3. En el paso 5 se valida con `TryParse` **y** `IsDefined`. ¿Qué caso concreto deja pasar cada uno por separado?
