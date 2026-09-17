# Rúbrica de Evaluación — Semana 03: Excepciones, I/O, JSON y debugging

## 📊 Distribución de evidencias

| Tipo | Peso | Instrumento |
|------|:----:|-------------|
| Conocimiento 🧠 | 30% | Cuestionario teórico (10 preguntas) |
| Desempeño 💪 | 40% | Ejercicios prácticos |
| Producto 📦 | 30% | Proyecto semanal entregado |

**Nota mínima para aprobar**: 70% en cada tipo de evidencia

---

## 🧠 Conocimiento (30%)

| # | Pregunta | Puntaje |
|---|----------|:-------:|
| 1 | Describe las dos pasadas que hace el runtime al lanzarse una excepción. ¿En cuál se evalúa un filtro `when` y qué consecuencia práctica tiene para depurar? | 10 |
| 2 | ¿Qué diferencia hay entre `throw;`, `throw ex;` y `throw new X("...", ex)`? ¿Cuál usarías en cada caso y qué información pierde la opción incorrecta? | 10 |
| 3 | ¿Cuándo un fallo merece una excepción y cuándo el patrón `TryXxx`? Pon un ejemplo de tu dominio para cada caso y justifica el coste. | 10 |
| 4 | Enumera tres tipos de excepción que **nunca** debes lanzar y tres que **nunca** debes capturar. ¿Por qué no se hereda de `ApplicationException`? | 10 |
| 5 | ¿Qué requisitos debe cumplir una excepción personalizada bien diseñada? ¿Cuándo NO crear un tipo nuevo? | 10 |
| 6 | Tienes un `catch (FileNotFoundException)`. ¿Qué otras excepciones puede lanzar `File.ReadAllText` y cuál de ellas **no** deriva de `IOException`? | 10 |
| 7 | ¿Por qué `File.Exists(path)` antes de abrir no garantiza que la apertura funcione? ¿Qué patrón de escritura evita dejar el fichero corrupto y por qué funciona? | 10 |
| 8 | Diferencia `File.ReadLines` de `File.ReadAllLines` y `Directory.EnumerateFiles` de `GetFiles`. ¿Cuándo se nota y cuánto? | 10 |
| 9 | Con `nullable enable`, deserializas `{"sku":"A-1"}` en un `record Product(string Sku, string Name, decimal Price)`. ¿Qué vale `Name`? ¿Por qué el compilador no te protege y qué dos defensas tienes? | 10 |
| 10 | ¿Por qué `JsonSerializerOptions` debe ser `static readonly`? ¿Qué aporta un `JsonSerializerContext` generado frente a la ruta por reflexión? | 10 |

**Total**: 100 puntos → 30% de la nota final

---

## 💪 Desempeño (40%)

### Ejercicio 01 — Manejo de errores con `try`/`catch`/`when` (20 puntos)

| Criterio | Puntaje |
|----------|:-------:|
| Compila con `dotnet build -warnaserror` sin warnings | 4 |
| Los 7 pasos descomentados y la salida coincide con la sección Verificación | 6 |
| Explica por qué `throw;` conserva 4 frames y `throw ex;` solo 2, y qué se pierde | 4 |
| Explica el filtro `when(Trace(ex))` y en qué pasada del runtime se evalúa | 3 |
| Completa el extra de depuración (breakpoint condicional + *User-Unhandled Exceptions* + Call Stack) | 3 |
| **Subtotal** | **20** |

### Ejercicio 02 — Persistencia en JSON (20 puntos)

| Criterio | Puntaje |
|----------|:-------:|
| Compila con `dotnet build -warnaserror` sin warnings | 4 |
| Los 7 pasos descomentados y la salida coincide con la sección Verificación | 6 |
| Explica la trampa de los campos ausentes con `nullable enable` y propone la validación | 4 |
| Justifica la escritura `.tmp` + `File.Move` y qué garantiza exactamente | 3 |
| Responde las 3 preguntas de reflexión con argumentos | 3 |
| **Subtotal** | **20** |

---

## 📦 Producto (30%)

### Proyecto — Gestor del catálogo persistido en JSON con manejo robusto de errores

| Criterio | Puntaje |
|----------|:-------:|
| Entidad, datos y excepción propia coherentes con el dominio asignado (≥ 10 elementos) | 4 |
| `Load` tolera fichero ausente y traduce el corrupto a `CatalogLoadException` con `InnerException` | 5 |
| `Save` atómico (`.tmp` + `File.Move`) y `Backup` con rutas construidas con `Path` | 4 |
| Importación perezosa que reporta número de línea y motivo sin interrumpirse | 4 |
| Jerarquía de excepciones de dominio con un único `catch (CatalogException)` en el menú | 4 |
| Guard clauses en las altas y `TryParse` en la entrada por teclado | 3 |
| Al menos un filtro `when` que distinga dos casos del mismo tipo | 2 |
| README con tabla de excepciones, evidencia de depuración y sesión de ejemplo | 4 |
| **Subtotal** | **30** |

### Criterios transversales

- ✅ Implementación coherente con el dominio asignado
- ✅ Sin copia de implementaciones de otros aprendices
- ✅ Ningún `catch` vacío, ningún `throw ex;`, ningún stream sin `using`
- ✅ `dotnet build` sin warnings y `dotnet test` en verde (cuando aplique)
