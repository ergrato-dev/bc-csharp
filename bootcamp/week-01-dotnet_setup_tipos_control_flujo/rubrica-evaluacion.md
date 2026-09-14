# Rúbrica de Evaluación — Semana 01: Setup .NET, tipos y control de flujo

## 📊 Distribución de evidencias

| Tipo | Peso | Instrumento |
|------|:----:|-------------|
| Conocimiento 🧠 | 30% | Cuestionario teórico (10 preguntas) |
| Desempeño 💪 | 40% | Ejercicios 01 y 02 |
| Producto 📦 | 30% | Proyecto: calculadora de dominio |

**Nota mínima para aprobar**: 70% en cada tipo de evidencia

---

## 🧠 Conocimiento (30%)

| # | Pregunta | Puntaje |
|---|----------|:-------:|
| 1 | ¿Qué diferencia hay entre el SDK y el runtime de .NET? ¿Cuál instalas en un servidor de producción y por qué? | 10 |
| 2 | Describe el camino desde `Program.cs` hasta código máquina: ¿qué hace Roslyn, qué es IL y qué hace el JIT? | 10 |
| 3 | ¿Qué significa que .NET 10 sea LTS? ¿Cómo fija este repo la versión del SDK? | 10 |
| 4 | ¿Para qué sirven `bin/` y `obj/`? ¿Por qué no se comitean? | 10 |
| 5 | ¿Por qué `decimal price = 19.99;` no compila y `long n = 19;` sí? | 10 |
| 6 | ¿Cuándo usarías `decimal` en lugar de `double`? Da un ejemplo de bug al usar `double` para dinero. | 10 |
| 7 | ¿Qué imprime `Console.WriteLine(7 / 2)` y `Console.WriteLine((int)3.99)`? Justifica. | 10 |
| 8 | ¿Qué diferencia hay entre `int.Parse`, `Convert.ToInt32` e `int.TryParse`? ¿Cuál usas con entrada de usuario? | 10 |
| 9 | ¿Qué hace `checked` y qué pasa con `int.MaxValue + 1` sin él? | 10 |
| 10 | ¿Qué es la exhaustividad en un `switch` expression y qué avisa el compilador si falta? ¿Por qué `_` no puede ir primero? | 10 |

**Total**: 100 puntos → 30% de la nota final

---

## 💪 Desempeño (40%)

### Ejercicio 01 — Hola .NET (20 puntos)

| Criterio | Puntaje |
|----------|:-------:|
| Compila con `dotnet build -warnaserror` sin warnings | 4 |
| Los 6 pasos descomentados y funcionando en orden | 6 |
| Explica en vivo qué hay en `bin/Debug/net10.0/` (dll, apphost, pdb) | 4 |
| Demuestra el comportamiento de `checked` frente a `unchecked` | 3 |
| Responde correctamente las 3 preguntas de reflexión | 3 |
| **Subtotal** | **20** |

### Ejercicio 02 — Calculadora con `switch` (20 puntos)

| Criterio | Puntaje |
|----------|:-------:|
| Compila con `dotnet build -warnaserror` sin warnings | 4 |
| Bucle REPL termina con `salir` y con Ctrl+D sin excepción | 3 |
| Entrada mal formada y operandos no numéricos se rechazan con `continue` | 4 |
| `switch` expression con guarda `when` para división por cero, en el orden correcto | 5 |
| Clasificación con patrones relacionales `and`/`or`/`not` y brazo `_` | 4 |
| **Subtotal** | **20** |

**Total Desempeño**: 40 puntos → 40% de la nota final

---

## 📦 Producto (30%)

### Proyecto — Calculadora de dominio en consola

| Criterio | Puntaje |
|----------|:-------:|
| Implementación coherente con el dominio asignado (nombres, textos, fórmulas) | 5 |
| Menú en bucle: opción 0 sale, opción inválida no rompe, vuelve al menú tras cada cálculo | 4 |
| Cuatro cálculos con los tipos correctos: `decimal` dinero, `double` medida, `int`/`long` conteo | 6 |
| Toda entrada de usuario con `TryParse`; negativos y división por cero rechazados con mensaje | 4 |
| `checked` en el cálculo de conteo con `OverflowException` capturada y explicada en el README | 3 |
| Clasificación con `switch` expression: ≥ 4 categorías, sin huecos ni solapamientos | 3 |
| Código en inglés, sin warnings, cálculos en `DomainCalculator` sin `Console` | 3 |
| README del proyecto: dominio, 4 cálculos, sesión de ejemplo, decisión de cultura | 2 |
| **Subtotal** | **30** |

### Criterios transversales

- ✅ Implementación coherente con el dominio asignado
- ✅ Sin copia de implementaciones de otros aprendices
- ✅ `dotnet build -warnaserror` limpio
- ✅ Sin `int.Parse`/`Convert.*` sobre entrada de usuario; sin `goto`
