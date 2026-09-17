# Rúbrica de Evaluación — Semana 04: Clases, herencia e interfaces

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
| 1 | ¿Qué guarda exactamente una variable de tipo clase? Explica qué imprime `var a = new Box(); var b = a; b.Value = 5;` y por qué. ¿Qué hay en el encabezado de un objeto? | 10 |
| 2 | Diferencia campo, propiedad autoimplementada y propiedad calculada. ¿Qué aporta `init` frente a `set`, y `required` frente a un constructor con parámetros? | 10 |
| 3 | ¿Qué hace la palabra clave `field` de C# 14 y qué código ahorra? Escribe una propiedad que recorte espacios al asignarse. | 10 |
| 4 | Enumera el orden exacto de inicialización al crear una instancia de una clase derivada. ¿Por qué no se debe llamar a un método `virtual` desde el constructor? | 10 |
| 5 | Diferencia `const` de `static readonly`. ¿Qué problema de versionado tiene `const` en una biblioteca? ¿Qué es `beforefieldinit`? | 10 |
| 6 | ¿Qué genera el compilador a partir de un constructor primario en una `class`? ¿En qué se diferencia de un `record`? ¿Dónde pones las guard clauses? | 10 |
| 7 | Explica la diferencia entre `override` y `new` con un ejemplo donde el resultado cambie según el tipo de la variable. ¿Qué warning emite el compilador y qué significa? | 10 |
| 8 | ¿Cuándo eliges clase abstracta y cuándo interfaz? ¿Qué aporta cada una que la otra no puede? Pon un caso de tu dominio para cada opción. | 10 |
| 9 | ¿Qué son los miembros de interfaz por defecto, qué problema resuelven y por qué no son visibles desde la clase que implementa la interfaz? | 10 |
| 10 | Explica el problema de la clase base frágil con un ejemplo. ¿Qué señales delatan una violación de Liskov en un `override`? | 10 |

**Total**: 100 puntos → 30% de la nota final

---

## 💪 Desempeño (40%)

### Ejercicio 01 — Cuentas bancarias (20 puntos)

| Criterio | Puntaje |
|----------|:-------:|
| Compila con `dotnet build -warnaserror` sin warnings | 4 |
| Los 7 pasos y los 3 bloques de tipos descomentados; la salida coincide con Verificación | 6 |
| Explica qué protege `protected set` en `Balance` y qué se rompería con `public set` | 3 |
| Demuestra el efecto de quitar `GetHashCode` sobre el `HashSet` y lo explica | 4 |
| Explica la diferencia observada entre `Label()` (`override`) y `Tag()` (`new`) | 3 |
| **Subtotal** | **20** |

### Ejercicio 02 — Figuras y polimorfismo (20 puntos)

| Criterio | Puntaje |
|----------|:-------:|
| Compila con `dotnet build -warnaserror` sin warnings | 4 |
| Los 7 pasos y los 5 bloques de tipos descomentados; la salida coincide con Verificación | 6 |
| Añade una política `IPricing` propia sin modificar `Quote` y lo justifica | 4 |
| Explica por qué `ShortLabel()` necesita el cast a la interfaz | 3 |
| Responde las 3 preguntas de reflexión con argumentos | 3 |
| **Subtotal** | **20** |

---

## 📦 Producto (30%)

### Proyecto — Modelo de dominio con jerarquía, interfaces y polimorfismo

| Criterio | Puntaje |
|----------|:-------:|
| Base abstracta con guard clauses, miembro abstracto, `virtual Describe()` y `Equals`/`GetHashCode` por clave | 5 |
| Tres derivadas `sealed` con diferencias reales; al menos dos usan `base.Describe()` | 5 |
| `IReservable` implementada solo por los tipos que la necesitan + una interfaz de capacidad propia | 4 |
| Repositorio tras interfaz: `Find` sin excepciones, `All()` como `IReadOnlyList<T>`, nada interno expuesto | 4 |
| Dos políticas `IPricingPolicy` + decorador, intercambiables sin tocar `CatalogService` | 5 |
| Listar/agrupar/totalizar resueltos con polimorfismo, sin cadenas de `is TipoConcreto` | 3 |
| README con diagrama de la jerarquía, tabla por derivada y justificación de dónde va cada interfaz | 4 |
| **Subtotal** | **30** |

### Criterios transversales

- ✅ Implementación coherente con el dominio asignado
- ✅ Sin copia de implementaciones de otros aprendices
- ✅ `sealed` por defecto, campos privados, sin estado estático mutable
- ✅ `dotnet build` sin warnings y `dotnet test` en verde (cuando aplique)
