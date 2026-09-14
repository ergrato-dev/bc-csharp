// Ejercicio 01 — Hola .NET
// El programa compila y ejecuta desde el paso 0. Descomenta cada PASO en orden.

Console.WriteLine("Ejercicio 01 listo. Sigue los pasos del README.");

// ============================================
// PASO 1: Salida y entrada por consola
// ============================================
// Console.ReadLine() devuelve string? : puede ser null si se cierra la entrada.
// Descomenta las siguientes líneas:
// Console.Write("¿Cómo te llamas? ");
// string? name = Console.ReadLine();
// Console.WriteLine($"Hola, {name ?? "anónimo"}. Bienvenido a .NET 10.");

// ============================================
// PASO 2: Tipos y literales
// ============================================
// Cada literal lleva el sufijo de su tipo; sin sufijo, un real es double y un entero es int.
// Descomenta las siguientes líneas:
// int year = 2026;
// long worldPopulation = 8_200_000_000L;
// double pi = 3.14159;
// float ratio = 0.75f;
// decimal price = 19.99m;
// bool isLts = true;
// char grade = 'A';
// Console.WriteLine($"{year} · {worldPopulation} · {pi} · {ratio} · {price} · {isLts} · {grade}");

// ============================================
// PASO 3: var, const y GetType
// ============================================
// var no es dinámico: el compilador fija el tipo al inicializar.
// Descomenta las siguientes líneas:
// var inferred = 42;
// var text = "cuarenta y dos";
// const int MaxRetries = 3;
// Console.WriteLine($"{inferred.GetType()} · {text.GetType()} · {MaxRetries}");

// ============================================
// PASO 4: Tamaños y rangos
// ============================================
// sizeof funciona con tipos primitivos sin contexto unsafe.
// Descomenta las siguientes líneas:
// Console.WriteLine($"int: {sizeof(int)} bytes, {int.MinValue}..{int.MaxValue}");
// Console.WriteLine($"long: {sizeof(long)} bytes, máx {long.MaxValue}");
// Console.WriteLine($"decimal: {sizeof(decimal)} bytes, máx {decimal.MaxValue}");

// ============================================
// PASO 5: Desbordamiento y checked
// ============================================
// Por defecto la aritmética entera desborda en silencio; checked lanza OverflowException.
// Descomenta las siguientes líneas:
// int max = int.MaxValue;
// int wrapped = unchecked(max + 1);
// Console.WriteLine($"int.MaxValue + 1 = {wrapped}");
// try
// {
//     int boom = checked(max + 1);
//     Console.WriteLine(boom);
// }
// catch (OverflowException ex)
// {
//     Console.WriteLine($"checked detectó: {ex.Message}");
// }

// ============================================
// PASO 6: Parseo seguro de entrada
// ============================================
// TryParse devuelve bool y entrega el valor por el parámetro out; nunca lanza.
// Descomenta las siguientes líneas:
// Console.Write("Escribe un número entero: ");
// string? raw = Console.ReadLine();
// if (int.TryParse(raw, out int number))
// {
//     Console.WriteLine($"El doble es {number * 2}, la mitad real es {number / 2.0}");
// }
// else
// {
//     Console.WriteLine($"'{raw}' no es un entero válido.");
// }
