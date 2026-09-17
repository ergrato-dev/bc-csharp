# `enum` y `[Flags]`

## 🎯 Objetivos

Al finalizar este archivo, comprenderás:

- Qué es realmente un `enum` y qué tipo subyacente tiene
- Por qué un `enum` puede contener valores que no declaraste
- Cómo convertir entre `enum`, número y texto de forma segura
- Cómo se modela un conjunto de opciones con `[Flags]` y operadores de bits
- Cómo se comportan los enums al serializar y qué convenciones seguir

## 📋 Conceptos clave

### 1. Un `enum` es un número con nombres

```csharp
public enum BookingStatus          // int por defecto: Draft = 0, Confirmed = 1, ...
{
    Draft,
    Confirmed,
    CheckedIn,
    Cancelled,
}

public enum Priority : byte        // tipo subyacente explícito
{
    Low = 10,
    Normal = 20,
    High = 30,
}
```

El **valor 0 importa**: es el que tendrá un campo no inicializado, un `default(BookingStatus)` o una propiedad ausente al deserializar. Declara siempre un miembro sensato en 0 (`None`, `Unknown`, `Draft`), nunca uno que signifique algo destructivo.

### 2. Un `enum` no valida nada

```csharp
var weird = (BookingStatus)99;             // compila y se ejecuta
Console.WriteLine(weird);                  // "99"
Console.WriteLine(Enum.IsDefined(weird));  // False
```

Un `enum` es un `int` con nombres, no un tipo cerrado: cualquier número cabe. Por eso todo valor que venga de fuera (JSON, base de datos, query string) se valida en el borde:

```csharp
if (!Enum.TryParse<BookingStatus>(input, ignoreCase: true, out var status) || !Enum.IsDefined(status))
    throw new ArgumentException($"Estado desconocido: {input}", nameof(input));
```

### 3. Conversiones y utilidades

```csharp
int number = (int)BookingStatus.Confirmed;              // 1
var status = (BookingStatus)1;                          // Confirmed
string text = BookingStatus.Confirmed.ToString();       // "Confirmed"
var parsed = Enum.Parse<BookingStatus>("Confirmed");    // lanza si no existe
Enum.TryParse<BookingStatus>("confirmed", true, out var s);   // patrón TryXxx (semana 03)
BookingStatus[] all = Enum.GetValues<BookingStatus>();  // genérico, sin boxing
string[] names = Enum.GetNames<BookingStatus>();
```

`Enum.GetValues<T>()` y `Enum.GetNames<T>()` (genéricos, desde .NET 5) sustituyen a las versiones antiguas con `typeof` que devolvían `Array` y boxeaban.

### 4. `switch` exhaustivo

```csharp
string Describe(BookingStatus status) => status switch
{
    BookingStatus.Draft => "borrador",
    BookingStatus.Confirmed => "confirmada",
    BookingStatus.CheckedIn => "en curso",
    BookingStatus.Cancelled => "cancelada",
    _ => throw new ArgumentOutOfRangeException(nameof(status), status, "Estado no contemplado"),
};
```

El `_` no sobra: como el `enum` admite valores no declarados, es la única defensa real. Y si mañana alguien añade `NoShow`, ese `throw` aparece en el primer test en vez de devolver silenciosamente un texto vacío.

### 5. `[Flags]`: un conjunto de opciones en un número

```csharp
[Flags]
public enum Amenities
{
    None      = 0,
    Wifi      = 1 << 0,   // 1
    Breakfast = 1 << 1,   // 2
    Parking   = 1 << 2,   // 4
    Gym       = 1 << 3,   // 8
    All       = Wifi | Breakfast | Parking | Gym,   // 15
}

var room = Amenities.Wifi | Amenities.Breakfast;      // combinar
bool hasWifi = room.HasFlag(Amenities.Wifi);          // true
bool hasWifi2 = (room & Amenities.Wifi) != 0;         // igual, sin boxing
var withGym = room | Amenities.Gym;                   // añadir
var withoutWifi = room & ~Amenities.Wifi;             // quitar
Console.WriteLine(room);                              // "Wifi, Breakfast"
```

![Un [Flags] guarda varias opciones en los bits de un entero](../0-assets/03-flags-bits.svg)

Reglas: valores potencia de dos (`1 << n`), `None = 0` obligatorio, `[Flags]` presente (sin él, `ToString()` imprime el número suelto), y combinaciones con nombre solo si aportan.

### 6. Enums y serialización

```csharp
// JSON (semana 03): por defecto se escribe el NÚMERO
var options = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };
```

Guardar el número acopla el formato al orden de declaración: insertar un miembro en medio corrompe los datos históricos. Guardar el nombre es estable frente a reordenaciones y legible en un log. Convención del bootcamp: **enums como texto** en JSON y APIs; si hay que persistir números, se asignan explícitamente (`Confirmed = 1`) y no se reutilizan nunca.

### 7. Cuándo NO usar un `enum`

- Si cada valor arrastra **comportamiento distinto**, un `switch` repetido por todo el código es olor a jerarquía o a diccionario de estrategias (semana 04, archivo 07).
- Si los valores los define el negocio y cambian sin desplegar, van en la base de datos, no en el código.
- Si necesitas datos asociados (descripción, color, tarifa), un `readonly record struct` o una clase de constantes tipadas encaja mejor.

## 🔬 Bajo el capó

Un `enum` se emite como un tipo que hereda de `System.Enum` con un campo `value__` del tipo subyacente; en tiempo de ejecución **es** ese número: `sizeof(BookingStatus)` son 4 bytes y una comparación es una comparación de enteros. Por eso el cast a `int` es gratis y por eso cabe cualquier valor.

`ToString()` y `Enum.IsDefined` sí cuestan: consultan metadatos y, en el caso de `IsDefined`, hacen boxing en las sobrecargas antiguas (`Enum.IsDefined(typeof(T), value)`). `HasFlag` boxeaba en .NET Framework; en .NET moderno el JIT lo reconoce y lo convierte en la operación de bits, así que ya es equivalente a `(x & flag) != 0` — pero en código de alto rendimiento se sigue escribiendo la máscara explícita.

`[Flags]` no cambia la representación: es un atributo que solo afecta a `ToString()` y a la intención del diseño. Los operadores `|`, `&`, `~` funcionan igual con o sin él.

## ⚠️ Errores comunes

- No declarar un miembro con valor 0 (o poner ahí algo peligroso).
- Confiar en que un `enum` recibido de fuera es válido.
- `[Flags]` con valores que no son potencia de dos.
- Serializar el número y luego reordenar los miembros.
- Un `switch` sin caso por defecto que revienta silenciosamente al añadir un miembro.
- Enums gigantes con 40 valores que en realidad son datos de configuración.

## 📚 Recursos adicionales

- [Tipos de enumeración](https://learn.microsoft.com/dotnet/csharp/language-reference/builtin-types/enum)
- [`System.Enum`](https://learn.microsoft.com/dotnet/api/system.enum)
- [Enumeración como conjunto de marcas](https://learn.microsoft.com/dotnet/api/system.flagsattribute)
- [Guía de diseño: enums](https://learn.microsoft.com/dotnet/standard/design-guidelines/enum)

## ✅ Checklist de verificación

- [ ] Declaro siempre un miembro en 0 con significado neutro
- [ ] Valido todo `enum` que llegue de fuera con `TryParse` + `IsDefined`
- [ ] Uso potencias de dos y `[Flags]` para conjuntos de opciones
- [ ] Serializo enums como texto y asigno números explícitos si persisto
- [ ] Reconozco cuándo un `enum` con `switch` repetido pide una jerarquía
