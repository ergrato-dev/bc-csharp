# Ejercicio 01 — Manejo de errores con `try`/`catch`/`when`

> Tutorial guiado. Descomenta paso a paso en `starter/Program.cs` y ejecuta `dotnet run` tras cada paso.

## 🎯 Objetivo

Recorrer el manejo de errores completo: ordenar `catch` de específico a general con `finally`, sustituir excepciones por el patrón `TryXxx` cuando el fallo es esperado, reintentar con filtros `when`, trazar sin capturar, medir qué destruye `throw ex;`, envolver una causa en `InnerException` y validar argumentos con las guard clauses de la BCL.

**Duración**: 90 min · **Teoría relacionada**: 01, 02, 03

## 🚀 Preparación

```bash
cd starter
dotnet run
```

El fichero compila desde el paso 0. Los tipos de los pasos 6 y 7 viven al final del fichero: en un programa con instrucciones top-level, **toda declaración de tipo va después de la última instrucción** (si no, error CS8803).

## Paso 1: `try` / `catch` / `finally` y orden de los `catch`

Tres `catch` de más específico a más general, y un `finally` que se ejecuta pase lo que pase. `int.Parse` lanza `FormatException` con `"abc"` y `OverflowException` con un número que no cabe en `int`.

```csharp
catch (DivideByZeroException) { }
catch (FormatException) { }
catch (OverflowException) { }
finally { }
```

Descomenta `PASO 1` y el `using System.Globalization;` del inicio. Prueba a mover el `catch (FormatException)` **después** de un `catch (Exception)`: error CS0160, porque el segundo ya lo cubría.

## Paso 2: el patrón `TryXxx`

Que el usuario escriba `"abc"` no es excepcional: es lo normal. `TryParse` devuelve `bool` y entrega el valor por `out`, sin construir ningún objeto de excepción.

```csharp
bool ok = int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value);
```

Descomenta `PASO 2`. Observa que con `"abc"` el `out` vale `0`, no queda sin asignar.

## Paso 3: filtros `when` para reintentar solo lo reintentable

Un `catch` con filtro solo se entra si la condición es cierta. Aquí el 429 se reintenta hasta dos veces; el 500 se abandona en el primer intento.

```csharp
catch (InvalidOperationException ex) when (code == 429 && attempts < 2) { attempts++; }
catch (InvalidOperationException ex) { break; }
```

Descomenta `PASO 3`. Cambia `attempts < 2` por `attempts < 5` y mira cuántas veces reintenta.

## Paso 4: `when(Trace(ex))` — trazar sin capturar

El filtro se evalúa en la primera pasada del runtime, **antes** de desenrollar la pila. Si devuelve `false`, el `catch` no se entra y la excepción continúa como si nada.

```csharp
catch (TimeoutException ex) when (Trace(ex)) { }
static bool Trace(Exception ex) { Console.WriteLine(...); return false; }
```

Descomenta `PASO 4`. Cambia el `return false;` por `return true;`: ahora sí entra en el primer `catch` y el segundo ya no se evalúa.

## Paso 5: `throw;` conserva la traza, `throw ex;` la reinicia

Dos métodos idénticos salvo por una palabra. Contamos las líneas del `StackTrace` resultante.

```csharp
static void Rethrow()  { try { Level1(); } catch (InvalidOperationException) { throw; } }
static void ThrowSame(){ try { Level1(); } catch (InvalidOperationException ex) { throw ex; } }
```

Descomenta `PASO 5`. Fíjate en el `#pragma warning disable CA2200`: el analizador ya marca `throw ex;` como antipatrón y, con `TreatWarningsAsErrors`, el proyecto **no compilaría** sin silenciarlo. Es la única vez en el bootcamp que lo silenciamos: para verlo fallar.

## Paso 6: excepción propia envolviendo la causa

La capa de dominio traduce un error técnico (`FormatException`) a uno con significado (`CatalogLoadException`) **sin perder la causa**: viaja en `InnerException`.

```csharp
catch (Exception ex) when (ex is FormatException or IndexOutOfRangeException)
{
    throw new CatalogLoadException(line, ex);
}
```

Descomenta `PASO 6` **y** el bloque `TIPOS` del final del fichero. El bucle recorre la cadena de causas; `GetBaseException()` salta directo a la raíz.

## Paso 7: guard clauses y `throw` expression

Las guard clauses de la BCL lanzan el tipo correcto y rellenan `ParamName` con el nombre del argumento, sin escribir `nameof` a mano.

```csharp
ArgumentException.ThrowIfNullOrWhiteSpace(code);
ArgumentOutOfRangeException.ThrowIfNegativeOrZero(nights);

public string Describe() => Code is { Length: > 0 }
    ? $"{Code} × {Nights}"
    : throw new InvalidOperationException("Reserva sin código.");
```

Descomenta `PASO 7` (los tipos del final ya están descomentados desde el paso 6). `ArgumentOutOfRangeException` deriva de `ArgumentException`, por eso un solo `catch` recoge los dos casos.

## ✅ Verificación

```
Ejercicio 01 — manejo de errores. Sigue los pasos del README.
1000 / 120 = 8
  -- fin del intento con '120'
'0': divisor cero
  -- fin del intento con '0'
'abc': no es un número
  -- fin del intento con 'abc'
'99999999999999': no cabe en un int
  -- fin del intento con '99999999999999'

TryParse('120') = True · valor = 120
TryParse('0') = True · valor = 0
TryParse('abc') = False · valor = 0
TryParse('99999999999999') = False · valor = 0

HTTP 500: abandonado (server error)
HTTP 429: reintento 1 tras 'too many requests'
HTTP 429: reintento 2 tras 'too many requests'
HTTP 429: enviado en el intento 3
HTTP 404: enviado en el intento 1

[trace] TimeoutException: la operación tardó demasiado (la pila sigue intacta)
capturado por el segundo catch, ya con la pila desenrollada

throw;    conserva 4 frames
throw ex; conserva 2 frames

error de dominio: No se pudo cargar la línea del catálogo.
  línea culpable: 'kb-01;Keyboard;49,99'
  causado por: FormatException: The input string '49,99' was not in a correct format.
  causa raíz: FormatException

reserva aceptada: H-101 × 3
rechazada: ArgumentException en el parámetro 'code'
rechazada: ArgumentOutOfRangeException en el parámetro 'nights'
```

`dotnet build -warnaserror` sin warnings.

## 🐞 Extra de depuración (teoría 03)

1. Pon un breakpoint **condicional** en la línea del `Console.WriteLine` del paso 1 con la expresión `input == "abc"`.
2. Marca *User-Unhandled Exceptions* en el panel Breakpoints y ejecuta el paso 6: el depurador se detiene en el `decimal.Parse`, no en el `catch`.
3. Con la ejecución detenida, cambia de frame en la **Call Stack** y comprueba que ves el valor de `line` en el frame de `LoadCatalog`.

## 🧠 Preguntas de reflexión

1. ¿Por qué `when (Trace(ex))` ve la pila intacta y `catch (Exception ex) { if (...) throw; }` no?
2. Los frames de `throw;` y `throw ex;` difieren: ¿qué información concreta se pierde y qué te costaría eso en un incidente en producción?
3. El paso 1 y el paso 2 resuelven el mismo problema. ¿Cuál usarías para validar un formulario con 10 000 filas de CSV y por qué?
