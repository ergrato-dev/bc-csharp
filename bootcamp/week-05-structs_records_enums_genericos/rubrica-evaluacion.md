# Rúbrica de Evaluación — Semana 05: Structs, records, enums y genéricos

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
| 1 | ¿Qué imprime `var a = new P{X=1}; var b = a; b.X = 9; Console.WriteLine(a.X);` si `P` es `struct` y si es `class`? ¿Dónde vive cada uno en memoria? | 10 |
| 2 | Enumera los cuatro criterios para elegir `struct` y explica por qué un `struct` mutable es peligroso dentro de una `List<T>` pero no dentro de un array. | 10 |
| 3 | ¿Qué es el boxing, en qué tres situaciones ocurre y cómo lo evitan los genéricos? ¿Por qué `EqualityComparer<T>.Default` no boxea? | 10 |
| 4 | Enumera los miembros que genera un `record` posicional. ¿Qué es `EqualityContract` y por qué `new Car("X") == new Vehicle("X")` es `false`? | 10 |
| 5 | ¿Qué copia exactamente `with`? Escribe un ejemplo donde el resultado sorprenda y explica cómo evitarlo. | 10 |
| 6 | ¿Por qué `(BookingStatus)99` compila y se ejecuta? ¿Cómo se valida un `enum` que llega por JSON y por qué se serializa como texto? | 10 |
| 7 | Reglas de un `[Flags]`: valores, miembro 0, atributo. Escribe las cuatro operaciones (combinar, comprobar, añadir, quitar). | 10 |
| 8 | ¿Qué genera el JIT para `List<int>` y para `List<string>`? ¿Por qué `Counter<int>.Instances` y `Counter<string>.Instances` son campos distintos? | 10 |
| 9 | ¿Qué desbloquean `where T : new()`, `where T : notnull`, `where T : struct` y `where T : INumber<T>`? ¿Qué significa `T?` en cada caso? | 10 |
| 10 | Explica covarianza y contravarianza con un ejemplo de cada una. ¿Por qué `List<T>` es invariante y por qué la covarianza de arrays es insegura? | 10 |

**Total**: 100 puntos → 30% de la nota final

---

## 💪 Desempeño (40%)

### Ejercicio 01 — Records para el dominio (20 puntos)

| Criterio | Puntaje |
|----------|:-------:|
| Compila con `dotnet build -warnaserror` sin warnings | 4 |
| Los 7 pasos y los 5 bloques de tipos descomentados; la salida coincide con Verificación | 6 |
| Explica el resultado del paso 2 (`with` superficial) y propone un diseño que lo evite | 4 |
| Demuestra que `RoomId` y `GuestId` no son intercambiables y justifica el `readonly record struct` | 3 |
| Explica qué deja pasar `TryParse` sin `IsDefined` y viceversa | 3 |
| **Subtotal** | **20** |

### Ejercicio 02 — `Result<T, E>` genérico (20 puntos)

| Criterio | Puntaje |
|----------|:-------:|
| Compila con `dotnet build -warnaserror` sin warnings | 4 |
| Los 7 pasos y los 3 bloques de tipos descomentados; la salida coincide con Verificación | 6 |
| Explica qué desbloquea cada restricción del repositorio y qué falla al quitar `notnull` | 4 |
| Provoca el error CS1961 añadiendo un `Set(T)` a la interfaz `out` y lo explica | 3 |
| Responde las 3 preguntas de reflexión con argumentos | 3 |
| **Subtotal** | **20** |

---

## 📦 Producto (30%)

### Proyecto — Librería genérica `Result<T, E>` + dominio con records y enums

| Criterio | Puntaje |
|----------|:-------:|
| `Result<T, E>` completo (`Match`, `Map`, `Then`) sin ejecutar el lambda sobre `Fail` | 5 |
| `Results.cs` y `Repository.cs` sin una sola referencia al dominio | 4 |
| Dos identificadores tipados no intercambiables + un value object inmutable | 4 |
| Entidad `record` con ≥ 6 campos y factoría `Create` que devuelve `Result` sin lanzar | 4 |
| `enum` validado con `TryParse` + `IsDefined` y `[Flags]` con las cuatro operaciones | 4 |
| Repositorio genérico con restricciones mínimas; `Add`/`Replace` devuelven `Result` | 4 |
| Un método genérico propio con la restricción mínima y un cálculo con `INumber<T>` | 3 |
| README con tabla de errores, justificación de tipos y sesión de ejemplo | 2 |
| **Subtotal** | **30** |

### Criterios transversales

- ✅ Implementación coherente con el dominio asignado
- ✅ Sin copia de implementaciones de otros aprendices
- ✅ Ninguna excepción para casos esperados; guard clauses solo para bugs
- ✅ `dotnet build` sin warnings y `dotnet test` en verde (cuando aplique)
