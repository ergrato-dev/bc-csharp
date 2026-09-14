# Conversiones y operadores

## 🎯 Objetivos

Al finalizar este archivo, comprenderás:

- Cuándo una conversión es implícita, cuándo exige cast y cuándo hay que parsear
- La diferencia entre `(int)x`, `Convert.ToInt32`, `int.Parse` y `int.TryParse`
- Los operadores aritméticos, de comparación, lógicos, de bits y de asignación compuesta
- El comportamiento de `checked`/`unchecked` ante desbordamientos

## 📋 Conceptos clave

### 1. Conversiones implícitas: sin pérdida, sin sintaxis

El compilador permite convertir cuando no se pierde información: de un tipo "más pequeño" a uno "más grande".

```csharp
int i = 100;
long l = i;        // int → long: implícita
double d = l;      // long → double: implícita (puede perder precisión en valores enormes, pero está permitida)
float f = i;
// int back = l;   // ERROR CS0266: long → int puede perder datos
```

Cadena de ampliación: `byte → short → int → long → float → double`; `decimal` no se mezcla implícitamente con `float`/`double`.

### 2. Conversiones explícitas: cast `(tipo)`

Cuando hay riesgo de pérdida, tú asumes la responsabilidad con un cast.

```csharp
double price = 9.99;
int truncated = (int)price;          // 9: trunca hacia cero, NO redondea
long big = 3_000_000_000L;
int overflowed = (int)big;           // -1294967296: desbordamiento silencioso
int rounded = (int)Math.Round(price); // 10
```

Casts numéricos no lanzan excepción salvo en contexto `checked`:

```csharp
checked
{
    int boom = (int)big;             // OverflowException
}
int wrapped = unchecked((int)big);   // explícitamente silencioso
```

Activar `checked` globalmente: `<CheckForOverflowUnderflow>true</CheckForOverflowUnderflow>` en el `.csproj`. Cuesta rendimiento; se usa en cálculos financieros o cuando un desbordamiento sería un bug grave.

### 3. De texto a número: `Parse`, `TryParse`, `Convert`

```csharp
string input = "42";
int a = int.Parse(input);                 // lanza FormatException si no es número
int b = Convert.ToInt32(input);           // igual, pero Convert.ToInt32(null) devuelve 0
if (int.TryParse(input, out int c))       // no lanza: devuelve bool y el valor por out
{
    Console.WriteLine($"Parsed {c}");
}
```

Regla del bootcamp: **entrada de usuario o de red → `TryParse`**. `Parse` solo con datos que controlas.

Cultura: `double.Parse("3,14")` falla en cultura `en-US` y funciona en `es-ES`. Para datos de archivos o APIs usa siempre `CultureInfo.InvariantCulture`:

```csharp
double value = double.Parse("3.14", CultureInfo.InvariantCulture);
```

### 4. Operadores aritméticos

```csharp
int q = 7 / 2;        // 3: división entera entre enteros
double r = 7 / 2.0;   // 3.5: basta que un operando sea real
int m = 7 % 2;        // 1: resto; con negativos, el signo sigue al dividendo: -7 % 2 == -1
int n = 5; n++; ++n;  // incremento; n-- y --n
n += 3; n *= 2; n /= 4; n %= 3;   // asignación compuesta
```

`Math` cubre el resto: `Math.Pow`, `Math.Sqrt`, `Math.Abs`, `Math.Max`, `Math.Clamp(value, min, max)`.

### 5. Comparación y lógica

```csharp
bool eq = a == b, ne = a != b, lt = a < b, ge = a >= b;
bool both = eq && lt;    // AND con cortocircuito: si eq es false no evalúa lt
bool any  = eq || lt;    // OR con cortocircuito
bool not  = !eq;
```

Cortocircuito importa cuando el segundo operando tiene efectos o puede fallar: `if (list != null && list.Count > 0)`.

### 6. Operadores de bits

```csharp
int flags = 0b0000_0101;         // literal binario
int masked = flags & 0b0100;     // AND: 4
int set = flags | 0b0010;        // OR: 7
int toggled = flags ^ 0b0001;    // XOR: 4
int shifted = 1 << 3;            // 8
int inverted = ~flags;           // complemento
```

Se usan en `[Flags]` enums (semana 05) y en código de alto rendimiento (semana 12).

### 7. Operadores de null y ternario

```csharp
string? nickname = null;
string display = nickname ?? "anónimo";     // coalescencia: si es null, usa el otro
int length = nickname?.Length ?? 0;         // acceso condicional: no lanza si es null
nickname ??= "auto";                        // asigna solo si es null
string label = length > 3 ? "largo" : "corto"; // ternario
```

`?.` y `??` se ven a fondo con nullable reference types (semana 09); aquí basta reconocerlos.

### 8. Precedencia

De mayor a menor: postfijos (`x++`, `x.y`, `f()`) → unarios (`!`, `-`, `++x`, cast) → `* / %` → `+ -` → `<< >>` → `< > <= >=` → `== !=` → `&` → `^` → `|` → `&&` → `||` → `??` → `?:` → asignación. Ante la duda, paréntesis: no cuestan nada y evitan revisar la tabla.

## 🔬 Bajo el capó

Una conversión implícita `int → long` emite `conv.i8` en IL; un cast `(int)long` emite `conv.i4`, que descarta los 32 bits altos. En contexto `checked` el compilador emite `conv.ovf.i4`, que verifica el rango y lanza. Ninguna de estas es una llamada a método: son instrucciones de una sola operación en el JIT. `int.Parse`, en cambio, es un método de la BCL con validación completa, cultura y manejo de signos: ~100× más caro que un `conv`. En la semana 12 aprenderás a parsear con `Span<char>` sin asignar memoria.

## ⚠️ Errores comunes

- `7 / 2` esperando `3.5`.
- `(int)3.99` esperando `4`: trunca. Usa `Math.Round`, `Math.Floor` o `Math.Ceiling` explícitamente.
- `int.Parse` sobre entrada de usuario sin `try`: la app se cae con `FormatException`.
- Olvidar la cultura al parsear decimales con punto o coma.
- `if (x = 5)` no compila en C# (a diferencia de C): el compilador te protege porque `int` no es `bool`.

## 📚 Recursos adicionales

- [Conversiones de tipos](https://learn.microsoft.com/dotnet/csharp/programming-guide/types/casting-and-type-conversions)
- [Operadores y expresiones](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/)
- [`checked` y `unchecked`](https://learn.microsoft.com/dotnet/csharp/language-reference/statements/checked-and-unchecked)

## ✅ Checklist de verificación

- [ ] Predigo si una conversión compila, y si necesita cast
- [ ] Elijo `TryParse` para entrada externa y explico por qué
- [ ] Sé qué produce `7 / 2`, `7 % 2`, `(int)3.99` y `int.MaxValue + 1`
- [ ] Uso `checked` cuando el desbordamiento sería un bug
- [ ] Aplico `??` y `?.` en expresiones simples
