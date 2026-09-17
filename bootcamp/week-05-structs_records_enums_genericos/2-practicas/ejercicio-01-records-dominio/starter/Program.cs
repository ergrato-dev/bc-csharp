// Ejercicio 01 — Records para el dominio
// El programa compila y ejecuta desde el paso 0. Descomenta cada PASO en orden.
// Los TIPOS van al final: en top-level statements toda declaración de tipo se escribe
// DESPUÉS de la última instrucción (error CS8803 si no).

// Desde el paso 1 hacen falta estas dos líneas (cultura fija = misma salida en cualquier máquina):
// using System.Globalization;
// CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

Console.WriteLine("Ejercicio 01 — records para el dominio. Sigue los pasos del README.");

// ============================================
// PASO 1: Un record posicional: igualdad, ToString y Deconstruct
// ============================================
// Una línea genera propiedades init, Equals, GetHashCode, ==, ToString y Deconstruct.
// Dos objetos distintos con los mismos datos son IGUALES.
// Descomenta también TIPOS A y las dos líneas del using/cultura.
// Descomenta las siguientes líneas:
// var a = new Booking("H-1", new DateOnly(2026, 4, 1), 3);
// var b = new Booking("H-1", new DateOnly(2026, 4, 1), 3);
// Console.WriteLine(a);
// Console.WriteLine($"a == b: {a == b} · ReferenceEquals: {ReferenceEquals(a, b)} · mismo hash: {a.GetHashCode() == b.GetHashCode()}");
// var (code, date, nights) = a;                       // Deconstruct generado
// Console.WriteLine($"deconstruido: {code} / {date:yyyy-MM-dd} / {nights}");

// ============================================
// PASO 2: with: copia con cambios… y superficial
// ============================================
// with crea un objeto nuevo sin tocar el original.
// Si el record contiene una List<T>, la copia COMPARTE la lista: cuidado.
// Descomenta también TIPOS B.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// var extended = a with { Nights = 5 };
// Console.WriteLine($"original {a.Nights} noches · copia {extended.Nights} noches · misma referencia: {ReferenceEquals(a, extended)}");
//
// var withGuests = new Party("P-1", ["Ada"]);
// var copy = withGuests with { Code = "P-2" };
// copy.Guests.Add("Linus");                           // ⚠️ copia SUPERFICIAL: la lista se comparte
// Console.WriteLine($"P-1 ve {withGuests.Guests.Count} invitados · P-2 ve {copy.Guests.Count}");

// ============================================
// PASO 3: readonly record struct: identificadores tipados
// ============================================
// Un valor pequeño e inmutable con igualdad generada y sin asignar en el heap.
// RoomId y GuestId son tipos distintos: el compilador impide confundirlos.
// Descomenta también TIPOS C.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// var id1 = new RoomId(Guid.Parse("11111111-1111-1111-1111-111111111111"));
// var id2 = new RoomId(Guid.Parse("11111111-1111-1111-1111-111111111111"));
// Console.WriteLine($"readonly record struct · id1 == id2: {id1 == id2}");
// Console.WriteLine($"identificador tipado: {id1}");
// Console.WriteLine($"GuestId es OTRO tipo: RoomId == GuestId ni siquiera compila");

// ============================================
// PASO 4: Validar un record: factoría con guard clauses
// ============================================
// La sintaxis posicional acepta cualquier valor; la validación la pones tú.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// Console.WriteLine(Booking.Create("H-9", new DateOnly(2026, 5, 1), 2));
// try
// {
//     _ = Booking.Create("H-9", new DateOnly(2026, 5, 1), 0);
// }
// catch (ArgumentOutOfRangeException ex)
// {
//     Console.WriteLine($"rechazado: parámetro '{ex.ParamName}'");
// }

// ============================================
// PASO 5: enum: TryParse + IsDefined y switch exhaustivo
// ============================================
// Un enum NO valida: cualquier número cabe. Lo externo se valida siempre.
// El caso _ del switch es la defensa cuando alguien añade un miembro.
// Descomenta también TIPOS D.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// foreach (string input in (string[])["confirmed", "CheckedIn", "teletransportada"])
// {
//     if (Enum.TryParse(input, ignoreCase: true, out BookingStatus status) && Enum.IsDefined(status))
//         Console.WriteLine($"{input,-18} → {status} ({(int)status}) · {Describe(status)}");
//     else
//         Console.WriteLine($"{input,-18} → estado desconocido, rechazado");
// }
// Console.WriteLine($"valores declarados: {string.Join(", ", Enum.GetNames<BookingStatus>())}");
//
// static string Describe(BookingStatus status) => status switch
// {
//     BookingStatus.Draft => "borrador",
//     BookingStatus.Confirmed => "confirmada",
//     BookingStatus.CheckedIn => "en curso",
//     BookingStatus.Cancelled => "cancelada",
//     _ => throw new ArgumentOutOfRangeException(nameof(status), status, "Estado no contemplado"),
// };

// ============================================
// PASO 6: [Flags]: combinar, comprobar, añadir y quitar
// ============================================
// Cada opción es un bit. |, &, ~ son las cuatro operaciones del conjunto.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// var room = Amenities.Wifi | Amenities.Breakfast;
// Console.WriteLine($"valor numérico: {(int)room} · texto: {room}");
// Console.WriteLine($"¿wifi? {(room & Amenities.Wifi) != 0} · ¿gimnasio? {room.HasFlag(Amenities.Gym)}");
// room |= Amenities.Gym;
// room &= ~Amenities.Wifi;
// Console.WriteLine($"tras añadir gym y quitar wifi: {room} ({(int)room})");
// Console.WriteLine($"¿incluye todo? {(Amenities.All & room) == Amenities.All}");

// ============================================
// PASO 7: Records con herencia y patrones posicionales
// ============================================
// EqualityContract compara los tipos REALES: un Car nunca es igual a un Vehicle.
// El switch con patrón de propiedad lee directamente los datos del record.
// Descomenta también TIPOS E.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// Vehicle vehicle = new Vehicle("1234-AB");
// Vehicle car = new Car("1234-AB", Doors: 5);
// Console.WriteLine($"vehicle == car con la misma matrícula: {vehicle == car}");
// Console.WriteLine($"ToString del derivado: {car}");
// Console.WriteLine(car switch
// {
//     Car { Doors: >= 5 } c => $"familiar de {c.Doors} puertas",
//     Car c => $"turismo de {c.Doors} puertas",
//     _ => "otro vehículo",
// });

// ============================================
// TIPOS A: Booking (pasos 1, 2 y 4)
// ============================================
// Record posicional con factoría de validación y un método propio.
// Descomenta las siguientes líneas:
// public sealed record Booking(string Code, DateOnly Date, int Nights)
// {
//     public static Booking Create(string code, DateOnly date, int nights)
//     {
//         ArgumentException.ThrowIfNullOrWhiteSpace(code);
//         ArgumentOutOfRangeException.ThrowIfNegativeOrZero(nights);
//         return new Booking(code, date, nights);
//     }
//
//     public decimal Total(decimal rate) => rate * Nights;
// }

// ============================================
// TIPOS B: Party con una List<string> (paso 2)
// ============================================
// Sirve para ver que with NO clona en profundidad.
// Descomenta las siguientes líneas:
// public sealed record Party(string Code, List<string> Guests);

// ============================================
// TIPOS C: RoomId y GuestId (paso 3)
// ============================================
// readonly record struct: valores inmutables con igualdad generada.
// Descomenta las siguientes líneas:
// public readonly record struct RoomId(Guid Value)
// {
//     public override string ToString() => $"room:{Value:N}";
// }
//
// public readonly record struct GuestId(Guid Value);

// ============================================
// TIPOS D: BookingStatus y Amenities (pasos 5 y 6)
// ============================================
// Un enum normal con 0 declarado y un [Flags] con potencias de dos.
// Descomenta las siguientes líneas:
// public enum BookingStatus
// {
//     Draft = 0,
//     Confirmed = 1,
//     CheckedIn = 2,
//     Cancelled = 3,
// }
//
// [Flags]
// public enum Amenities
// {
//     None = 0,
//     Wifi = 1 << 0,
//     Breakfast = 1 << 1,
//     Parking = 1 << 2,
//     Gym = 1 << 3,
//     All = Wifi | Breakfast | Parking | Gym,
// }

// ============================================
// TIPOS E: Vehicle y Car (paso 7)
// ============================================
// Herencia entre records: solo un record puede heredar de otro record.
// Descomenta las siguientes líneas:
// public record Vehicle(string Plate);
//
// public sealed record Car(string Plate, int Doors) : Vehicle(Plate);
