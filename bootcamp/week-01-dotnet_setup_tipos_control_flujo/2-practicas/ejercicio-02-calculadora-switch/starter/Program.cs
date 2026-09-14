// Ejercicio 02 — Calculadora con switch
// El programa compila y ejecuta desde el paso 0. Descomenta cada PASO en orden.

// PASO 3 necesita este using (ImplicitUsings no incluye Globalization):
// using System.Globalization;

Console.WriteLine("Calculadora. Formato: <número> <operador> <número>. Escribe 'salir' para terminar.");

// ============================================
// PASO 1: Bucle principal con salida
// ============================================
// while (true) + break es el patrón estándar de un REPL.
// Descomenta las siguientes líneas (y las de los pasos siguientes irán DENTRO del bucle):
// while (true)
// {
//     Console.Write("> ");
//     string? line = Console.ReadLine();
//     if (line is null or "salir") break;
//     Console.WriteLine($"Recibido: {line}");   // comenta esta línea al llegar al paso 2
//
//     // ============================================
//     // PASO 2: Separar la entrada en tokens
//     // ============================================
//     // continue salta al inicio del bucle sin ejecutar el resto del cuerpo.
//     // Descomenta las siguientes líneas:
//     // string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//     // if (parts.Length != 3)
//     // {
//     //     Console.WriteLine("Formato: <número> <operador> <número>  · ejemplo: 7 / 2");
//     //     continue;
//     // }
//
//     // ============================================
//     // PASO 3: Parsear operandos con TryParse
//     // ============================================
//     // InvariantCulture: el punto es el separador decimal en cualquier máquina.
//     // Descomenta las siguientes líneas:
//     // if (!double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double left) ||
//     //     !double.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double right))
//     // {
//     //     Console.WriteLine("Los operandos deben ser números.");
//     //     continue;
//     // }
//     // string op = parts[1];
//
//     // ============================================
//     // PASO 4: Decidir con switch expression
//     // ============================================
//     // double? admite null para señalar "operador inválido". Los brazos se evalúan en orden.
//     // Descomenta las siguientes líneas:
//     // double? result = op switch
//     // {
//     //     "+" => left + right,
//     //     "-" => left - right,
//     //     "*" => left * right,
//     //     "/" when right == 0 => null,
//     //     "/" => left / right,
//     //     "%" => left % right,
//     //     "^" => Math.Pow(left, right),
//     //     _ => null,
//     // };
//
//     // ============================================
//     // PASO 5: Mostrar resultado o error
//     // ============================================
//     // Descomenta las siguientes líneas:
//     // Console.WriteLine(result is null
//     //     ? $"Operación inválida: '{op}' (o división por cero)"
//     //     : $"= {result}");
//
//     // ============================================
//     // PASO 6: Clasificar el resultado con patrones relacionales
//     // ============================================
//     // "result is double value" comprueba que no es null y captura el valor.
//     // Descomenta las siguientes líneas:
//     // if (result is double value)
//     // {
//     //     string kind = value switch
//     //     {
//     //         double.NaN => "no es un número",
//     //         < 0 => "negativo",
//     //         0 => "cero",
//     //         > 0 and < 1 => "fracción",
//     //         >= 1 and <= 1000 => "razonable",
//     //         _ => "enorme",
//     //     };
//     //     Console.WriteLine($"  ({kind})");
//     // }
// }
// Console.WriteLine("Adiós.");
