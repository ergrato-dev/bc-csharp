# Semana 05 — Structs, records, enums y genéricos

> `struct`/`readonly struct`, `record`/`record struct`, igualdad por valor y `with`, `enum` y `[Flags]`, genéricos, restricciones `where`, varianza `in`/`out`, `Nullable<T>`.

**Fase 2: POO y diseño** · Dedicación: 10 horas

## 🎯 Objetivos de aprendizaje

Al finalizar esta semana, el estudiante será capaz de:

- Predecir qué copia una asignación según sea `struct` o `class`, y aplicar los cuatro criterios para elegir entre ambos
- Identificar dónde ocurre boxing y eliminarlo con genéricos y `readonly struct`
- Modelar datos con `record`, `record struct` y `readonly record struct`, sabiendo qué genera el compilador y qué copia `with`
- Explicar la igualdad de records con herencia (`EqualityContract`) y validar records con factorías
- Declarar enums seguros (miembro 0, validación con `TryParse` + `IsDefined`, serialización como texto) y conjuntos con `[Flags]`
- Escribir tipos y métodos genéricos con nombres e inferencia correctos, y explicar qué genera el JIT por instanciación
- Elegir la restricción `where` mínima necesaria, incluida `INumber<T>` para código numérico genérico
- Anotar interfaces y delegados con `in`/`out` y justificar por qué `List<T>` es invariante

## 📚 Requisitos previos

- Semana 04 completada
- .NET 10 SDK instalado (`dotnet --version`)

## 🗂️ Estructura de la semana

```
week-05-structs_records_enums_genericos/
├── 0-assets/        # 5 diagramas SVG
├── 1-teoria/        # 6 archivos
├── 2-practicas/     # 2 ejercicios guiados (patrón uncomment)
├── 3-proyecto/      # Proyecto semanal (TODOs, dominio único)
├── 4-recursos/      # ebooks-free · videografia · webgrafia
└── 5-glosario/      # Términos clave A-Z
```

## 📝 Contenidos

### Teoría

| Archivo | Tema | Duración |
|---------|------|:--------:|
| [01-structs.md](1-teoria/01-structs.md) | Tipos por valor, `readonly struct`, boxing, `default`, criterios de elección | 30 min |
| [02-records.md](1-teoria/02-records.md) | Miembros generados, `record struct`, `with`, `EqualityContract`, validación | 30 min |
| [03-enums-y-flags.md](1-teoria/03-enums-y-flags.md) | Tipo subyacente, validación en el borde, `switch` exhaustivo, `[Flags]`, serialización | 30 min |
| [04-genericos.md](1-teoria/04-genericos.md) | Tipos y métodos genéricos, inferencia, `default(T)`, estáticos por instanciación, JIT | 30 min |
| [05-restricciones-genericas.md](1-teoria/05-restricciones-genericas.md) | Catálogo de `where`, `T?` según restricción, `static abstract`, `INumber<T>` | 30 min |
| [06-varianza-in-out.md](1-teoria/06-varianza-in-out.md) | Covarianza, contravarianza, invarianza, arrays covariantes y límites | 30 min |

### Prácticas

| Ejercicio | Concepto | Duración |
|-----------|----------|:--------:|
| [ejercicio-01-records-dominio](2-practicas/ejercicio-01-records-dominio/README.md) | `record` posicional, `with` superficial, identificadores tipados, validación, `enum` validado, `[Flags]`, herencia de records | 90 min |
| [ejercicio-02-result-generico](2-practicas/ejercicio-02-result-generico/README.md) | `Result<T,E>` con `Match`/`Map`, repositorio con restricciones, `INumber<T>`, `EqualityComparer<T>.Default`, varianza `in`/`out` | 90 min |

### Proyecto

[3-proyecto/README.md](3-proyecto/README.md) — Librería genérica (`Result<T,E>` con `Match`/`Map`/`Then` y repositorio con restricciones) sin una sola referencia al dominio, más el modelo del alumno con identificadores tipados, value object, `record` validado por factoría, `enum` y `[Flags]`.

## ⏱️ Distribución del tiempo (10 horas)

| Actividad | Tiempo |
|-----------|-------:|
| Teoría (6 archivos) | 3.0 h |
| Ejercicios (2) | 3.0 h |
| Proyecto semanal | 3.5 h |
| Glosario, recursos y revisión | 0.5 h |
| **Total** | **10 h** |

## 📌 Entregables

1. ✅ Ejercicios descomentados, compilando sin warnings y ejecutando
2. ✅ Proyecto adaptado al dominio asignado
3. ✅ README del proyecto con descripción de la implementación

## 🔗 Navegación

| Anterior | Actual | Siguiente |
|----------|--------|-----------|
| [← Semana 04: Clases, herencia e interfaces](../week-04-clases_herencia_interfaces/README.md) | **Semana 05: Structs, records, enums y genéricos** | [Semana 06: SOLID, patrones y xUnit →](../week-06-solid_patrones_xunit/README.md) |
