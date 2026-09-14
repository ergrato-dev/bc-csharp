# Ejercicio 02 — Calculadora con `switch`

> Tutorial guiado. Descomenta paso a paso en `starter/Program.cs` y ejecuta `dotnet run` tras cada paso.

## 🎯 Objetivo

Construir una calculadora de consola en bucle: leer operador y operandos, decidir con `switch` expression, validar con `TryParse`, y controlar el flujo con `while (true)`, `continue` y `break`.

**Duración**: 90 min · **Teoría relacionada**: 04, 05, 06

## 🚀 Preparación

```bash
cd starter
dotnet run
```

## Paso 1: Bucle principal con salida

Un REPL es un bucle infinito que termina con `break`. `is null or "salir"` es un patrón combinado sobre `string?`.

```csharp
while (true)
{
    Console.Write("> ");
    string? line = Console.ReadLine();
    if (line is null or "salir") break;
    Console.WriteLine($"Recibido: {line}");
}
Console.WriteLine("Adiós.");
```

Descomenta `PASO 1`. Escribe cualquier cosa; termina con `salir` o Ctrl+D.

## Paso 2: Separar la entrada en tokens

`string.Split` con `StringSplitOptions.RemoveEmptyEntries` ignora espacios repetidos. Si no hay 3 partes, `continue` vuelve al inicio del bucle.

```csharp
string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
if (parts.Length != 3)
{
    Console.WriteLine("Formato: <número> <operador> <número>  · ejemplo: 7 / 2");
    continue;
}
```

Descomenta `PASO 2` (y comenta la línea `Recibido` del paso 1, ya no hace falta). Prueba `1 +` y `1 + 2`.

## Paso 3: Parsear operandos con `TryParse`

Usa `double` para admitir decimales. `CultureInfo.InvariantCulture` garantiza que el punto sea el separador decimal en cualquier máquina.

```csharp
if (!double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double left) ||
    !double.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double right))
{
    Console.WriteLine("Los operandos deben ser números.");
    continue;
}
string op = parts[1];
```

Descomenta `PASO 3` y el `using System.Globalization;` del inicio. Prueba `1.5 + x`.

## Paso 4: Decidir con `switch` expression

Cada brazo devuelve un `double?`: `null` significa "operador desconocido". La división por cero devuelve `double.PositiveInfinity` con reales, así que la tratamos aparte.

```csharp
double? result = op switch
{
    "+" => left + right,
    "-" => left - right,
    "*" => left * right,
    "/" when right == 0 => null,
    "/" => left / right,
    "%" => left % right,
    "^" => Math.Pow(left, right),
    _ => null,
};
```

Descomenta `PASO 4`. Aún no imprime nada: falta el paso 5.

## Paso 5: Mostrar resultado o error

```csharp
Console.WriteLine(result is null
    ? $"Operación inválida: '{op}' (o división por cero)"
    : $"= {result}");
```

Descomenta `PASO 5`. Prueba `7 / 2`, `7 % 2`, `2 ^ 10`, `5 / 0`, `3 & 4`.

## Paso 6: Clasificar el resultado con patrones relacionales

Un segundo `switch` expression sobre el valor, con `and`, `or` y `not`:

```csharp
if (result is double value)
{
    string kind = value switch
    {
        double.NaN => "no es un número",
        < 0 => "negativo",
        0 => "cero",
        > 0 and < 1 => "fracción",
        >= 1 and <= 1000 => "razonable",
        _ => "enorme",
    };
    Console.WriteLine($"  ({kind})");
}
```

Descomenta `PASO 6`. `result is double value` es un patrón de tipo que además desempaqueta el `double?`: lo verás en la semana 09.

## ✅ Verificación

```
> 7 / 2
= 3.5
  (razonable)
> 5 / 0
Operación inválida: '/' (o división por cero)
> 0.5 * 0.5
= 0.25
  (fracción)
> salir
Adiós.
```

`dotnet build -warnaserror` sin warnings.

## 🧠 Preguntas de reflexión

1. ¿Por qué `"/" when right == 0` debe ir **antes** de `"/"`? ¿Qué pasa si los inviertes?
2. ¿Qué cambiarías para que `7 / 2` con enteros devolviera `3`?
3. ¿Por qué el `switch` del paso 6 necesita `_` y el del paso 4 también?
