# `switch` expression

## 🎯 Objetivos

Al finalizar este archivo, comprenderás:

- La diferencia entre `switch` statement y `switch` expression
- Patrones básicos: constante, relacional, `and`/`or`/`not`, descarte `_`, `when`
- Cómo el compilador exige exhaustividad y cómo aprovecharla
- Cuándo un `switch` expression es más claro que una cadena de `if`

## 📋 Conceptos clave

### 1. De statement a expression

Un `switch` **statement** ejecuta bloques; un `switch` **expression** (C# 8+) **devuelve un valor**. Mismo problema, dos formas:

```csharp
// Statement: verboso, con variable mutable y break repetidos
string label;
switch (score)
{
    case 90: label = "A"; break;
    case 80: label = "B"; break;
    default: label = "F"; break;
}

// Expression: una sola expresión, sin break, sin variable temporal
string label = score switch
{
    90 => "A",
    80 => "B",
    _  => "F",       // _ es el descarte: "cualquier otro valor"
};
```

Sintaxis: `valor switch { patrón => resultado, ... }`. Los brazos se evalúan **en orden** y gana el primero que encaja. Todos los brazos deben producir un tipo compatible.

### 2. Patrones relacionales y combinados

```csharp
string grade = score switch
{
    >= 90 => "A",
    >= 80 => "B",
    >= 70 => "C",
    >= 0 and < 70 => "F",
    _ => throw new ArgumentOutOfRangeException(nameof(score)),
};

string size = width switch
{
    < 0 => "inválido",
    0 => "vacío",
    > 0 and <= 10 => "pequeño",
    > 10 and not 42 => "grande",
    _ => "la respuesta",
};
```

Patrones disponibles ya en esta semana:

| Patrón | Ejemplo | Encaja si |
|--------|---------|-----------|
| Constante | `0`, `"ok"`, `null` | igual a la constante |
| Relacional | `> 10`, `<= 0.5` | comparación verdadera |
| Combinado | `> 0 and < 10`, `0 or 1`, `not null` | combinación lógica |
| Descarte | `_` | siempre |
| `var` | `var x` | siempre; captura el valor |

Los patrones de tipo, propiedad, posición y lista llegan en la semana 09.

### 3. Guardas con `when`

Cuando la condición no cabe en un patrón:

```csharp
string status = (temperature, humidity) switch
{
    ( > 30, > 70) => "bochorno",
    ( > 30, _) => "calor seco",
    (_, _) when IsRaining() => "lluvia",
    _ => "normal",
};
```

Aquí también aparece el **switch sobre tupla** `(a, b)`: compara varios valores a la vez sin anidar `if`. Las tuplas se tratan en la semana 09; úsalas aquí como "varios valores entre paréntesis".

### 4. Exhaustividad

Si los patrones no cubren todos los valores posibles, el compilador avisa con **CS8509** (`The switch expression does not handle all possible values`). Con `TreatWarningsAsErrors` no compila. Si en runtime llega un valor sin brazo, lanza `SwitchExpressionException`.

```csharp
bool flag = GetFlag();
string text = flag switch
{
    true => "sí",
    false => "no",     // exhaustivo: no necesita _
};
```

Con enums (semana 05), el compilador sabe cuántos valores hay y exige cubrirlos o poner `_`. Es una de las razones para preferir `switch` expression: **el compilador te dice qué caso olvidaste**.

### 5. `switch` expression en métodos expression-bodied

```csharp
static decimal ApplyDiscount(decimal price, string tier) => tier switch
{
    "gold" => price * 0.8m,
    "silver" => price * 0.9m,
    _ => price,
};
```

Un método de una sola expresión se declara con `=>`. Combinado con `switch` expression queda una tabla de decisión legible.

### 6. Cuándo NO usarlo

- Cuando cada brazo necesita **varias instrucciones** con efectos (escribir, llamar, asignar varias cosas): usa `switch` statement o `if`.
- Cuando el resultado de cada brazo es de **tipo distinto** sin conversión común.
- Cuando solo hay **dos casos**: un ternario `cond ? a : b` es más corto.

## 🔬 Bajo el capó

El compilador transforma un `switch` expression en un árbol de decisión. Para constantes enteras o `string` densas genera una tabla de saltos (`switch` en IL) o un hash de strings: O(1). Para patrones relacionales genera comparaciones encadenadas ordenadas para minimizar saltos. Los brazos no se evalúan todos: el orden importa solo para elegir cuál gana, no para el coste. Puedes verificar el IL con `ilspy` o SharpLab (https://sharplab.io): pega el código y mira la pestaña "C#" con el lowering.

## ⚠️ Errores comunes

- Olvidar el brazo `_` con un tipo no acotado (`int`, `string`): warning CS8509 → error en este repo.
- Poner `_` **antes** de otros brazos: los siguientes nunca se alcanzan (`CS8510`).
- Brazos con tipos distintos sin tipo común: `1 => "uno", 2 => 2` no compila.
- Usar `switch` expression para ejecutar efectos y descartar el resultado.

## 📚 Recursos adicionales

- [Expresión `switch`](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/switch-expression)
- [Patrones](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/patterns)
- [SharpLab — ver el lowering del compilador](https://sharplab.io)

## ✅ Checklist de verificación

- [ ] Reescribo una cadena de `if/else if` como `switch` expression
- [ ] Uso patrones relacionales y `and`/`or`/`not`
- [ ] Explico qué es la exhaustividad y qué hace el compilador si falta
- [ ] Uso `when` para condiciones que no son patrones
- [ ] Decido cuándo un `switch` expression NO es adecuado
