# Semana 02 — Métodos, strings y colecciones

> Métodos y paso de parámetros (`ref`/`out`/`in`/`params`), sobrecarga, recursión, `string` inmutable e interpolación, `StringBuilder`, arrays, `List<T>`, `Dictionary<K,V>`, `HashSet<T>`, `Queue`/`Stack`, índices `^` y rangos `..`, collection expressions.

**Fase 1: Fundamentos acelerados** · Dedicación: 10 horas

## 🎯 Objetivos de aprendizaje

Al finalizar esta semana, el estudiante será capaz de:

- Predecir el efecto de pasar `int`, `List<T>` y `struct` a un método, y elegir `ref`, `out`, `in` o `params` con criterio
- Escribir sobrecargas sin ambigüedad y métodos recursivos con caso base, sabiendo cuándo convertirlos en bucle o pila explícita
- Manipular texto con la API de `string` (buscar, cortar, comparar con `StringComparison`) y construir salidas grandes con `StringBuilder`
- Formatear números y fechas con alineación y cultura explícita (`InvariantCulture` vs `CurrentCulture`)
- Elegir entre array, `List<T>`, `Dictionary<K,V>`, `HashSet<T>`, `Queue<T>` y `Stack<T>` por la complejidad de la operación dominante
- Usar índices `^`, rangos `..` y collection expressions `[.. a, .. b]`, distinguiendo cuándo un corte copia y cuándo es una vista

## 📚 Requisitos previos

- Semana 01 completada
- .NET 10 SDK instalado (`dotnet --version`)

## 🗂️ Estructura de la semana

```
week-02-metodos_strings_colecciones/
├── 0-assets/        # 6 diagramas SVG
├── 1-teoria/        # 7 archivos
├── 2-practicas/     # 2 ejercicios guiados (patrón uncomment)
├── 3-proyecto/      # Proyecto semanal (TODOs, dominio único)
├── 4-recursos/      # ebooks-free · videografia · webgrafia
└── 5-glosario/      # Términos clave A-Z
```

## 📝 Contenidos

### Teoría

| Archivo | Tema | Duración |
|---------|------|:--------:|
| [01-metodos-y-parametros.md](1-teoria/01-metodos-y-parametros.md) | Anatomía, paso por valor, `ref`/`out`/`in`/`params`, funciones locales | 30 min |
| [02-sobrecarga-y-recursion.md](1-teoria/02-sobrecarga-y-recursion.md) | Resolución de sobrecarga, recursión, caso base, pila explícita | 30 min |
| [03-strings-y-stringbuilder.md](1-teoria/03-strings-y-stringbuilder.md) | Inmutabilidad, API de `string`, `StringComparison`, `StringBuilder` | 30 min |
| [04-formateo-y-cultura.md](1-teoria/04-formateo-y-cultura.md) | Formatos `N2`/`P1`/custom, alineación, `CultureInfo`, fechas | 30 min |
| [05-arrays.md](1-teoria/05-arrays.md) | Arrays 1D, `[,]` vs `[][]`, `System.Array`, layout en memoria | 30 min |
| [06-list-dictionary-hashset.md](1-teoria/06-list-dictionary-hashset.md) | `List`, `Dictionary`, `HashSet`, `Queue`/`Stack`, Big-O, hashing | 30 min |
| [07-indices-rangos-collection-expressions.md](1-teoria/07-indices-rangos-collection-expressions.md) | `^`, `..`, `Index`/`Range`, collection expressions, spread | 30 min |

### Prácticas

| Ejercicio | Concepto | Duración |
|-----------|----------|:--------:|
| [ejercicio-01-analizador-texto](2-practicas/ejercicio-01-analizador-texto/README.md) | `out`, `Dictionary`, `Sort` + rangos, `StringBuilder`, recursión sobre `Span`, `params` | 90 min |
| [ejercicio-02-inventario-colecciones](2-practicas/ejercicio-02-inventario-colecciones/README.md) | `record struct`, `Dictionary`, `HashSet`, `Queue`, `Stack`, spread, `params ReadOnlySpan` | 90 min |

### Proyecto

[3-proyecto/README.md](3-proyecto/README.md) — Inventario en memoria del dominio asignado: carga desde texto con `TryParseLine`, índice por clave, categorías, agrupación con rangos, cola de movimientos con deshacer, recursión y reporte alineado.

## ⏱️ Distribución del tiempo (10 horas)

| Actividad | Tiempo |
|-----------|-------:|
| Teoría (7 archivos) | 3.5 h |
| Ejercicios (2) | 3.0 h |
| Proyecto semanal | 3.0 h |
| Glosario, recursos y revisión | 0.5 h |
| **Total** | **10 h** |

## 📌 Entregables

1. ✅ Ejercicios descomentados, compilando sin warnings y ejecutando
2. ✅ Proyecto adaptado al dominio asignado
3. ✅ README del proyecto con descripción de la implementación

## 🔗 Navegación

| Anterior | Actual | Siguiente |
|----------|--------|-----------|
| [← Semana 01: Setup .NET, tipos y control de flujo](../week-01-dotnet_setup_tipos_control_flujo/README.md) | **Semana 02: Métodos, strings y colecciones** | [Semana 03: Excepciones, I/O, JSON y debugging →](../week-03-excepciones_io_json_debugging/README.md) |
