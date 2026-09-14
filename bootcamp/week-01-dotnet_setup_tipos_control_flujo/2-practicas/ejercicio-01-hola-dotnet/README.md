# Ejercicio 01 — Hola .NET

> Tutorial guiado. Descomenta paso a paso en `starter/Program.cs` y ejecuta `dotnet run` tras cada paso.

## 🎯 Objetivo

Crear, compilar y ejecutar tu primer programa C#, entender qué genera la CLI y practicar tipos, literales, `var` y conversiones seguras.

**Duración**: 90 min · **Teoría relacionada**: 01, 02, 03, 04

## 🚀 Preparación

```bash
cd starter
dotnet --version        # 10.0.x
dotnet run              # imprime "Ejercicio listo..." — el paso 0 ya compila
ls bin/Debug/net10.0    # Exercise.dll, Exercise (apphost), Exercise.pdb, *.json
```

Abre `Exercise.csproj` y lee las cinco propiedades. `TreatWarningsAsErrors` hará que cualquier warning detenga la compilación: es intencional.

## Paso 1: Salida y entrada por consola

`Console.WriteLine` escribe una línea; `Console.Write` no añade salto; `Console.ReadLine()` devuelve `string?` (puede ser `null` si la entrada se cierra).

```csharp
Console.Write("¿Cómo te llamas? ");
string? name = Console.ReadLine();
Console.WriteLine($"Hola, {name ?? "anónimo"}. Bienvenido a .NET 10.");
```

**Abre `starter/Program.cs`** y descomenta la sección `PASO 1`. Ejecuta y escribe tu nombre.

## Paso 2: Tipos y literales

Declara una variable de cada familia con el literal correcto. Observa los sufijos `L`, `f`, `m` y el separador `_`.

```csharp
int year = 2026;
long worldPopulation = 8_200_000_000L;
double pi = 3.14159;
float ratio = 0.75f;
decimal price = 19.99m;
bool isLts = true;
char grade = 'A';
```

Descomenta `PASO 2`. Prueba a quitar la `m` de `19.99m`: lee el error `CS0664` y vuelve a ponerla.

## Paso 3: `var`, `const` y `typeof`

`var` infiere el tipo; `GetType()` te lo muestra en runtime; `const` se incrusta en compilación.

```csharp
var inferred = 42;                 // int
var text = "cuarenta y dos";       // string
const int MaxRetries = 3;
Console.WriteLine($"{inferred.GetType()} · {text.GetType()} · {MaxRetries}");
```

Descomenta `PASO 3`. Salida esperada: `System.Int32 · System.String · 3`. Fíjate: `int` es un alias de `System.Int32`.

## Paso 4: Tamaños y rangos

Cada tipo numérico expone `MinValue` y `MaxValue`. `sizeof` devuelve bytes.

```csharp
Console.WriteLine($"int: {sizeof(int)} bytes, {int.MinValue}..{int.MaxValue}");
Console.WriteLine($"long: {sizeof(long)} bytes, máx {long.MaxValue}");
Console.WriteLine($"decimal: {sizeof(decimal)} bytes, máx {decimal.MaxValue}");
```

Descomenta `PASO 4`.

## Paso 5: Desbordamiento y `checked`

```csharp
int max = int.MaxValue;
int wrapped = unchecked(max + 1);
Console.WriteLine($"int.MaxValue + 1 = {wrapped}");    // -2147483648

try
{
    int boom = checked(max + 1);
    Console.WriteLine(boom);
}
catch (OverflowException ex)
{
    Console.WriteLine($"checked detectó: {ex.Message}");
}
```

Descomenta `PASO 5`. Las excepciones se ven a fondo en la semana 03; aquí solo observa que `checked` convierte un bug silencioso en un error explícito.

## Paso 6: Parseo seguro de entrada

Nunca uses `int.Parse` sobre lo que escribe el usuario.

```csharp
Console.Write("Escribe un número entero: ");
string? raw = Console.ReadLine();
if (int.TryParse(raw, out int number))
{
    Console.WriteLine($"El doble es {number * 2}, la mitad real es {number / 2.0}");
}
else
{
    Console.WriteLine($"'{raw}' no es un entero válido.");
}
```

Descomenta `PASO 6`. Prueba con `21`, con `abc` y con `2147483648` (fuera de rango: `TryParse` devuelve `false`).

## ✅ Verificación

Con todo descomentado, `dotnet build -warnaserror` no muestra warnings y el programa:

1. Saluda por tu nombre
2. Imprime los tipos `System.Int32 · System.String · 3`
3. Muestra `int.MaxValue + 1 = -2147483648` y luego el mensaje de `checked`
4. Rechaza `abc` sin caerse

## 🧠 Preguntas de reflexión

1. ¿Por qué `19.99` sin sufijo no puede asignarse a `decimal` si sí puede asignarse `19` a `long`?
2. ¿Qué archivo de `bin/Debug/net10.0/` contiene el IL? ¿Y cuál es el apphost?
3. ¿En qué situación preferirías `int.Parse` a `TryParse`?
