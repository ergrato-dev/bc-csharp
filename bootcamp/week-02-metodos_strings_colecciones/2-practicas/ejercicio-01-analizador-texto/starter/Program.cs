// Ejercicio 01 — Analizador de texto
// El programa compila y ejecuta desde el paso 0. Descomenta cada PASO en orden.

// PASO 5 necesita estos usings (ImplicitUsings no incluye Globalization ni Text):
// using System.Globalization;
// using System.Text;

const string Text = """
    La programación es el arte de decirle a otra persona lo que quieres que
    haga la computadora. Programar bien es programar claro; programar claro
    es pensar claro. El código se lee muchas más veces de las que se escribe.
    """;

Console.WriteLine($"Analizador de texto listo. Texto de {Text.Length} caracteres.");

// ============================================
// PASO 1: Tokenizar en palabras
// ============================================
// Split + Trim de puntuación + minúsculas. Devuelve un array con collection expression.
// Descomenta las siguientes líneas:
// string[] words = Tokenize(Text);
// Console.WriteLine($"Palabras: {words.Length}");
// Console.WriteLine($"Primeras 5: {string.Join(" | ", words[..5])}");
//
// static string[] Tokenize(string text)
// {
//     string[] raw = text.Split([' ', '\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
//     var result = new List<string>(raw.Length);
//     foreach (string token in raw)
//     {
//         string clean = token.Trim('.', ',', ';', ':', '!', '?').ToLowerInvariant();
//         if (clean.Length > 0) result.Add(clean);
//     }
//     return [.. result];
// }

// ============================================
// PASO 2: Estadísticas con parámetros out
// ============================================
// Un método puede "devolver" varios valores con out. Debe asignarlos en todos los caminos.
// Descomenta las siguientes líneas:
// ComputeStats(words, out int totalChars, out string longest);
// Console.WriteLine($"Caracteres (sin espacios): {totalChars} · media: {(double)totalChars / words.Length:F2} por palabra");
// Console.WriteLine($"Más larga: {longest} ({longest.Length})");
//
// static void ComputeStats(string[] words, out int totalChars, out string longest)
// {
//     totalChars = 0;
//     longest = "";
//     foreach (string w in words)
//     {
//         totalChars += w.Length;
//         if (w.Length > longest.Length) longest = w;
//     }
// }

// ============================================
// PASO 3: Frecuencias con Dictionary
// ============================================
// GetValueOrDefault devuelve 0 si la clave no existe: evita el TryGetValue manual.
// Descomenta las siguientes líneas:
// Dictionary<string, int> freq = CountFrequencies(words);
// Console.WriteLine($"Palabras distintas: {freq.Count}");
// Console.WriteLine($"'programar' aparece {freq.GetValueOrDefault("programar")} veces");
// Console.WriteLine($"'python' aparece {freq.GetValueOrDefault("python")} veces");
//
// static Dictionary<string, int> CountFrequencies(string[] words)
// {
//     var freq = new Dictionary<string, int>();
//     foreach (string w in words)
//         freq[w] = freq.GetValueOrDefault(w) + 1;
//     return freq;
// }

// ============================================
// PASO 4: Top N con List, Sort y rangos
// ============================================
// [.. freq] copia los pares a una List; Sort con comparador; [..5] corta los 5 primeros.
// Descomenta las siguientes líneas:
// List<KeyValuePair<string, int>> ranking = [.. freq];
// ranking.Sort((a, b) => b.Value != a.Value ? b.Value.CompareTo(a.Value) : string.CompareOrdinal(a.Key, b.Key));
// var top = ranking[..5];
// foreach (var (word, count) in top) Console.WriteLine($"  {word} → {count}");

// ============================================
// PASO 5: Reporte alineado con StringBuilder
// ============================================
// {word,-12} alinea a la izquierda en 12 columnas; {count,7} a la derecha en 7; :P1 es porcentaje.
// string.Create(InvariantCulture, $"...") formatea con cultura fija sin string intermedios.
// Descomenta las siguientes líneas (y los usings del inicio):
// Console.WriteLine(BuildReport(top, words.Length));
//
// static string BuildReport(List<KeyValuePair<string, int>> top, int totalWords)
// {
//     var sb = new StringBuilder();
//     sb.AppendLine("Palabra        Veces    %");
//     sb.AppendLine(new string('-', 26));
//     foreach (var (word, count) in top)
//         sb.AppendLine(string.Create(CultureInfo.InvariantCulture, $"{word,-12}{count,7}{(double)count / totalWords,7:P1}"));
//     sb.AppendLine(new string('-', 26));
//     sb.Append($"Total de palabras: {totalWords}");
//     return sb.ToString();
// }

// ============================================
// PASO 6: Palíndromos con recursión sobre ReadOnlySpan<char>
// ============================================
// Caso base: 0 o 1 chars. Paso: extremos iguales Y el interior (s[1..^1]) es palíndromo.
// Cortar un Span no asigna: cada llamada recursiva es solo puntero + longitud.
// Descomenta las siguientes líneas:
// string[] candidates = ["ana", "reconocer", "codigo", "Anita lava la tina"];
// foreach (string candidate in candidates)
//     Console.WriteLine($"{candidate,-20} palíndromo: {IsPalindrome(Normalize(candidate))}");
//
// static string Normalize(string s) => s.Replace(" ", "").ToLowerInvariant();
//
// static bool IsPalindrome(ReadOnlySpan<char> s)
// {
//     if (s.Length <= 1) return true;
//     return s[0] == s[^1] && IsPalindrome(s[1..^1]);
// }

// ============================================
// PASO 7: params y argumentos con nombre
// ============================================
// params va siempre al final; prefix: "..." salta el orden posicional usando el nombre.
// Descomenta las siguientes líneas:
// Console.WriteLine(Highlight(Text, prefix: ">> ", "programar", "claro"));
//
// static string Highlight(string text, string prefix = "", params string[] keywords)
// {
//     string result = text;
//     foreach (string k in keywords)
//         result = result.Replace(k, k.ToUpperInvariant(), StringComparison.OrdinalIgnoreCase);
//     return prefix + result.ReplaceLineEndings("\n" + prefix);
// }
