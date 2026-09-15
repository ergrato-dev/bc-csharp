# Rúbrica de Evaluación — Semana 02: Métodos, strings y colecciones

## 📊 Distribución de evidencias

| Tipo | Peso | Instrumento |
|------|:----:|-------------|
| Conocimiento 🧠 | 30% | Cuestionario teórico (10 preguntas) |
| Desempeño 💪 | 40% | Ejercicios 01 y 02 |
| Producto 📦 | 30% | Proyecto: inventario en memoria |

**Nota mínima para aprobar**: 70% en cada tipo de evidencia

---

## 🧠 Conocimiento (30%)

| # | Pregunta | Puntaje |
|---|----------|:-------:|
| 1 | ¿Qué imprime este programa y por qué? `static void M(List<int> xs) { xs.Add(1); xs = []; } var l = new List<int>(); M(l); Console.WriteLine(l.Count);` | 10 |
| 2 | Explica en una frase cada uno `ref`, `out` e `in`. ¿Qué exige el compilador a un parámetro `out` y qué error da si no se cumple? | 10 |
| 3 | ¿Por qué `s += c` dentro de un bucle de 100 000 iteraciones es O(n²)? ¿Qué usarías en su lugar y cuántos strings se crean al final? | 10 |
| 4 | ¿Qué diferencia hay entre `ToString("N2")` con `CultureInfo.InvariantCulture` y con `CurrentCulture`? ¿Cuál usas para un archivo CSV y cuál para pantalla? | 10 |
| 5 | ¿Qué hace `Array.Resize` realmente? ¿Por qué `int[,]` y `int[][]` no son intercambiables? | 10 |
| 6 | ¿Por qué `Add` en `List<T>` es O(1) amortizado? ¿Qué pasa cuando `Count == Capacity`? | 10 |
| 7 | ¿Cuántos elementos tiene `xs[2..5]`? ¿Qué es `xs[^0]` y por qué falla? ¿`int[] b = a[1..]` comparte memoria con `a`? | 10 |
| 8 | ¿Cuándo aporta `params ReadOnlySpan<T>` frente a `params T[]`? ¿Qué se asigna en cada llamada `Sum(1, 2, 3)`? | 10 |
| 9 | Dado `Area(int)`, `Area(double)` y `Area(long)`, ¿cuál elige `Area(5)` y cuál `Area(5f)`? ¿Qué falla en una recursión sin caso base y por qué el límite es ~1 MB? | 10 |
| 10 | ¿Qué contrato deben cumplir `Equals` y `GetHashCode` en una clave de `Dictionary`? ¿Qué pasa si la clave muta después de insertarla? | 10 |

**Total**: 100 puntos → 30% de la nota final

---

## 💪 Desempeño (40%)

### Ejercicio 01 — Analizador de texto (20 puntos)

| Criterio | Puntaje |
|----------|:-------:|
| Compila con `dotnet build -warnaserror` sin warnings | 4 |
| Los 7 pasos descomentados y la salida coincide con la sección Verificación | 6 |
| Explica por qué `ComputeStats` asigna `out` en todos los caminos y qué error da si no | 3 |
| Explica cuántos strings asigna `IsPalindrome` sobre `ReadOnlySpan<char>` frente a `string` | 4 |
| Responde las 3 preguntas de reflexión con argumentos | 3 |
| **Subtotal** | **20** |

### Ejercicio 02 — Inventario con colecciones (20 puntos)

| Criterio | Puntaje |
|----------|:-------:|
| Compila con `dotnet build -warnaserror` sin warnings | 4 |
| Los 7 pasos descomentados y la salida coincide con la sección Verificación | 6 |
| Justifica la colección elegida en cada paso (List/Dictionary/HashSet/Queue/Stack) por su Big-O | 4 |
| Explica por qué `items[index].Quantity -= units` no compila con un struct en una `List` | 3 |
| Responde las 3 preguntas de reflexión con argumentos | 3 |
| **Subtotal** | **20** |

---

## 📦 Producto (30%)

### Proyecto — Inventario en memoria con búsquedas, agrupaciones y reporte

| Criterio | Puntaje |
|----------|:-------:|
| Entidad, datos, categorías y movimientos coherentes con el dominio asignado (≥ 12 registros) | 5 |
| Carga con `TryParseLine` que reporta y salta líneas inválidas sin romper | 3 |
| Índice `Dictionary` + `TryGetValue`/`TryAdd`; categorías en `HashSet`; ninguna lectura `dict[key]` a ciegas | 4 |
| Agrupación + `Sort` con comparador + rangos `[..3]`/`[^2..]` sin repetir en grupos pequeños | 4 |
| `Queue` de movimientos con rechazo de negativos y `Stack` para deshacer | 4 |
| Método recursivo con caso base documentado y búsqueda de texto con `Highlight(params)` | 3 |
| Reporte `StringBuilder` alineado, subtotales, `:P1`, cultura documentada | 3 |
| Código en inglés, `IReadOnlyList`/`IEnumerable` en firmas públicas, sin `+=` de strings en bucle, sin warnings | 2 |
| README propio: formato de línea, recursión, sesión de ejemplo y respuesta sobre O(n²) | 2 |
| **Subtotal** | **30** |

### Criterios transversales

- ✅ Implementación coherente con el dominio asignado
- ✅ Sin copia de implementaciones de otros aprendices
- ✅ `dotnet build` sin warnings y `dotnet test` en verde (cuando aplique)
