// Ejercicio 01 — Manejo de errores con try/catch/when
// El programa compila y ejecuta desde el paso 0. Descomenta cada PASO en orden.

// Todos los pasos con parseo necesitan este using (ImplicitUsings no incluye Globalization):
// using System.Globalization;

Console.WriteLine("Ejercicio 01 — manejo de errores. Sigue los pasos del README.");

// ============================================
// PASO 1: try / catch / finally y orden de los catch
// ============================================
// Tres catch de más específico a más general y un finally que se ejecuta siempre.
// int.Parse lanza FormatException con "abc" y OverflowException con un número enorme.
// Descomenta las siguientes líneas:
// string[] inputs = ["120", "0", "abc", "99999999999999"];
// foreach (string input in inputs)
// {
//     try
//     {
//         int divisor = int.Parse(input, CultureInfo.InvariantCulture);
//         Console.WriteLine($"1000 / {divisor} = {1000 / divisor}");
//     }
//     catch (DivideByZeroException)
//     {
//         Console.WriteLine($"'{input}': divisor cero");
//     }
//     catch (FormatException)
//     {
//         Console.WriteLine($"'{input}': no es un número");
//     }
//     catch (OverflowException)
//     {
//         Console.WriteLine($"'{input}': no cabe en un int");
//     }
//     finally
//     {
//         Console.WriteLine($"  -- fin del intento con '{input}'");
//     }
// }

// ============================================
// PASO 2: El patrón TryXxx: el fallo esperado no es excepcional
// ============================================
// TryParse devuelve bool y entrega el valor por out. Nunca lanza, así que no cuesta microsegundos.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// foreach (string input in inputs)
// {
//     bool ok = int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value);
//     Console.WriteLine($"TryParse('{input}') = {ok} · valor = {value}");
// }

// ============================================
// PASO 3: Filtros when: capturar solo el caso reintentable
// ============================================
// El filtro se evalúa ANTES de desenrollar la pila. Solo el 429 se reintenta; el 500 se abandona.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// foreach (int code in (int[])[500, 429, 404])
// {
//     int attempts = 0;
//     while (true)
//     {
//         try
//         {
//             Send(code, attempts);
//             Console.WriteLine($"HTTP {code}: enviado en el intento {attempts + 1}");
//             break;
//         }
//         catch (InvalidOperationException ex) when (code == 429 && attempts < 2)
//         {
//             attempts++;
//             Console.WriteLine($"HTTP {code}: reintento {attempts} tras '{ex.Message}'");
//         }
//         catch (InvalidOperationException ex)
//         {
//             Console.WriteLine($"HTTP {code}: abandonado ({ex.Message})");
//             break;
//         }
//     }
// }
//
// static void Send(int statusCode, int attempts)
// {
//     if (statusCode == 429 && attempts < 2) throw new InvalidOperationException("too many requests");
//     if (statusCode >= 500) throw new InvalidOperationException("server error");
//     if (statusCode == 404) return;
// }

// ============================================
// PASO 4: when(Log(ex)) para trazar sin capturar
// ============================================
// Trace escribe y devuelve false: el catch no se entra y la excepción sigue su camino intacta.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// try
// {
//     throw new TimeoutException("la operación tardó demasiado");
// }
// catch (TimeoutException ex) when (Trace(ex))
// {
//     Console.WriteLine("nunca se llega aquí: el filtro devolvió false");
// }
// catch (TimeoutException)
// {
//     Console.WriteLine("capturado por el segundo catch, ya con la pila desenrollada");
// }
//
// static bool Trace(Exception ex)
// {
//     Console.WriteLine($"[trace] {ex.GetType().Name}: {ex.Message} (la pila sigue intacta)");
//     return false;
// }

// ============================================
// PASO 5: throw; conserva la traza · throw ex; la reinicia
// ============================================
// Contamos los frames del StackTrace de cada variante. El analizador CA2200 avisa del antipatrón.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// Console.WriteLine($"throw;    conserva {FrameCount(Capture(Rethrow))} frames");
// Console.WriteLine($"throw ex; conserva {FrameCount(Capture(ThrowSame))} frames");
//
// static Exception Capture(Action action)
// {
//     try { action(); } catch (InvalidOperationException ex) { return ex; }
//     return new InvalidOperationException("no lanzó");
// }
//
// static void Rethrow()
// {
//     try { Level1(); } catch (InvalidOperationException) { throw; }       // conserva la traza original
// }
//
// static void ThrowSame()
// {
//     // El analizador CA2200 avisa de este antipatrón; lo silenciamos SOLO para verlo en acción.
// #pragma warning disable CA2200
//     try { Level1(); } catch (InvalidOperationException ex) { throw ex; } // la reinicia en esta línea
// #pragma warning restore CA2200
// }
//
// static void Level1() => Level2();
// static void Level2() => throw new InvalidOperationException("origen real");
// static int FrameCount(Exception ex) => ex.StackTrace?.Split('\n', StringSplitOptions.RemoveEmptyEntries).Length ?? 0;

// ============================================
// PASO 6: Excepción propia envolviendo la causa en InnerException
// ============================================
// La capa de dominio traduce FormatException a CatalogLoadException sin perder la causa original.
// Descomenta también el bloque TIPOS del final del fichero.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// try
// {
//     LoadCatalog("kb-01;Keyboard;49,99");
// }
// catch (CatalogLoadException ex)
// {
//     Console.WriteLine($"error de dominio: {ex.Message}");
//     Console.WriteLine($"  línea culpable: '{ex.Line}'");
//     for (Exception? cause = ex.InnerException; cause is not null; cause = cause.InnerException)
//         Console.WriteLine($"  causado por: {cause.GetType().Name}: {cause.Message}");
//     Console.WriteLine($"  causa raíz: {ex.GetBaseException().GetType().Name}");
// }
//
// static void LoadCatalog(string line)
// {
//     try
//     {
//         string[] parts = line.Split(';');
//         decimal price = decimal.Parse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture);  // "49,99" no es válido así
//         Console.WriteLine($"cargado {parts[0]} a {price}");
//     }
//     catch (Exception ex) when (ex is FormatException or IndexOutOfRangeException)
//     {
//         throw new CatalogLoadException(line, ex);
//     }
// }

// ============================================
// PASO 7: Guard clauses de la BCL y throw expression
// ============================================
// ThrowIfNullOrWhiteSpace y ThrowIfNegativeOrZero rellenan ParamName solas.
// Describe() usa throw como expresión en la rama falsa de ?:.
// Descomenta también el bloque TIPOS del final del fichero.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// foreach ((string code, int nights) in (( string, int )[])[("H-101", 3), ("   ", 3), ("H-102", 0)])
// {
//     try
//     {
//         Reservation reservation = Reservation.Create(code, nights);
//         Console.WriteLine($"reserva aceptada: {reservation.Describe()}");
//     }
//     catch (ArgumentException ex)
//     {
//         Console.WriteLine($"rechazada: {ex.GetType().Name} en el parámetro '{ex.ParamName}'");
//     }
// }

// ============================================
// TIPOS de los PASOS 6 y 7
// ============================================
// Los tipos se declaran DESPUÉS de todas las instrucciones top-level (error CS8803 si no).
// Descomenta las siguientes líneas al llegar a los pasos 6 y 7:
// // ============================================
// public sealed class CatalogLoadException : Exception
// {
//     public CatalogLoadException(string line, Exception innerException)
//         : base("No se pudo cargar la línea del catálogo.", innerException) => Line = line;
//
//     public string Line { get; }
// }
//
// public sealed record Reservation(string Code, int Nights)
// {
//     public static Reservation Create(string code, int nights)
//     {
//         ArgumentException.ThrowIfNullOrWhiteSpace(code);
//         ArgumentOutOfRangeException.ThrowIfNegativeOrZero(nights);
//         return new Reservation(code, nights);
//     }
//
//     public string Describe() => Code is { Length: > 0 }
//         ? $"{Code} × {Nights}"
//         : throw new InvalidOperationException("Reserva sin código.");
// }
