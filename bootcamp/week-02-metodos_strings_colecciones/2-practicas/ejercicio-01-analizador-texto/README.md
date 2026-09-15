# Ejercicio 01 — Analizador de texto

> Tutorial guiado. Descomenta paso a paso en `starter/Program.cs` y ejecuta `dotnet run` tras cada paso.

## 🎯 Objetivo

Construir un analizador de texto en consola: tokenizar con `Split`/`Trim`, devolver varios valores con `out`, contar frecuencias con `Dictionary`, ordenar y cortar con `List`/rangos, formatear un reporte alineado con `StringBuilder`, detectar palíndromos con recursión sobre `ReadOnlySpan<char>` y usar `params` con argumentos con nombre.

**Duración**: 90 min · **Teoría relacionada**: 01, 02, 03, 04, 06, 07

## 🚀 Preparación

```bash
cd starter
dotnet run
```

El texto de muestra es un raw string literal (`"""`): ni escapes ni concatenación.

## Paso 1: Tokenizar en palabras

`Split` con varios separadores y `RemoveEmptyEntries`; cada token pierde la puntuación con `Trim(chars)` y pasa a minúsculas. El método devuelve `[.. result]`: una collection expression que copia la `List` a un `string[]`.

```csharp
static string[] Tokenize(string text)
{
    string[] raw = text.Split([' ', '\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
    var result = new List<string>(raw.Length);
    foreach (string token in raw)
    {
        string clean = token.Trim('.', ',', ';', ':', '!', '?').ToLowerInvariant();
        if (clean.Length > 0) result.Add(clean);
    }
    return [.. result];
}
```

Descomenta `PASO 1`. `words[..5]` corta los cinco primeros: el fin es exclusivo.

## Paso 2: Estadísticas con parámetros `out`

Un método `void` que "devuelve" dos valores. El compilador exige asignar `totalChars` y `longest` en todos los caminos.

```csharp
ComputeStats(words, out int totalChars, out string longest);
```

Descomenta `PASO 2`. Prueba a comentar `longest = "";` dentro del método: error CS0177.

## Paso 3: Frecuencias con `Dictionary`

El patrón de conteo: `freq[w] = freq.GetValueOrDefault(w) + 1`. Sin `GetValueOrDefault` harían falta un `TryGetValue` y un `if`.

```csharp
foreach (string w in words)
    freq[w] = freq.GetValueOrDefault(w) + 1;
```

Descomenta `PASO 3`. `GetValueOrDefault("python")` devuelve 0 sin lanzar; `freq["python"]` lanzaría `KeyNotFoundException`.

## Paso 4: Top N con `List`, `Sort` y rangos

`[.. freq]` copia los `KeyValuePair` a una `List`. El comparador ordena por valor descendente y desempata por clave. `ranking[..5]` devuelve una `List` nueva con los cinco primeros.

```csharp
List<KeyValuePair<string, int>> ranking = [.. freq];
ranking.Sort((a, b) => b.Value != a.Value ? b.Value.CompareTo(a.Value) : string.CompareOrdinal(a.Key, b.Key));
var top = ranking[..5];
```

Descomenta `PASO 4`. `foreach (var (word, count) in top)` deconstruye cada par.

## Paso 5: Reporte alineado con `StringBuilder`

`{word,-12}` alinea a la izquierda en 12 columnas, `{count,7}` a la derecha en 7, `:P1` formatea porcentaje con un decimal. `string.Create(CultureInfo.InvariantCulture, $"...")` fija la cultura para que el separador decimal sea siempre el punto.

```csharp
sb.AppendLine(string.Create(CultureInfo.InvariantCulture, $"{word,-12}{count,7}{(double)count / totalWords,7:P1}"));
```

Descomenta `PASO 5` y los dos `using` del inicio. Cambia `Invariant` por `CultureInfo.GetCultureInfo("es-ES")` y observa la coma.

## Paso 6: Palíndromos con recursión sobre `ReadOnlySpan<char>`

Caso base: longitud 0 o 1. Paso recursivo: los extremos coinciden (`s[0] == s[^1]`) y el interior (`s[1..^1]`) es palíndromo. Cortar un `Span` no asigna memoria: cada frame recibe puntero + longitud.

```csharp
static bool IsPalindrome(ReadOnlySpan<char> s)
{
    if (s.Length <= 1) return true;
    return s[0] == s[^1] && IsPalindrome(s[1..^1]);
}
```

Descomenta `PASO 6`. `Normalize` quita espacios y pasa a minúsculas para que "Anita lava la tina" cuente.

## Paso 7: `params` y argumentos con nombre

`Highlight(text, prefix = "", params string[] keywords)`: `params` va al final; `prefix: ">> "` se pasa por nombre para no confundirlo con la primera keyword.

```csharp
Console.WriteLine(Highlight(Text, prefix: ">> ", "programar", "claro"));
```

Descomenta `PASO 7`. Quita `prefix:` y observa cómo `">> "` pasa a ser una keyword.

## ✅ Verificación

```
Analizador de texto listo. Texto de 217 caracteres.
Palabras: 39
Primeras 5: la | programación | es | el | arte
Caracteres (sin espacios): 175 · media: 4.49 por palabra
Más larga: programación (12)
Palabras distintas: 27
'programar' aparece 3 veces
'python' aparece 0 veces
  claro → 3
  es → 3
  programar → 3
  que → 3
  de → 2
Palabra        Veces    %
--------------------------
claro             3  7.7 %
es                3  7.7 %
programar         3  7.7 %
que               3  7.7 %
de                2  5.1 %
--------------------------
Total de palabras: 39
ana                  palíndromo: True
reconocer            palíndromo: True
codigo               palíndromo: False
Anita lava la tina   palíndromo: True
>> La programación es el arte de decirle a otra persona lo que quieres que
>> haga la computadora. PROGRAMAR bien es PROGRAMAR CLARO; PROGRAMAR CLARO
>> es pensar CLARO. El código se lee muchas más veces de las que se escribe.
```

`dotnet build -warnaserror` sin warnings.

## 🧠 Preguntas de reflexión

1. ¿Por qué `ComputeStats` usa `out` en vez de devolver una tupla `(int, string)`? ¿Cuál preferirías y por qué?
2. `IsPalindrome` recibe `ReadOnlySpan<char>` y no `string`: ¿cuántos strings se asignan al comprobar "reconocer"? ¿Y si recibiera `string` y cortara con `s[1..^1]`?
3. Si el texto tuviera un millón de palabras, ¿qué paso sería el más lento y qué cambiarías?
