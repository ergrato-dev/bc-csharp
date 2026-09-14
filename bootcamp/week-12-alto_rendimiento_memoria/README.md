# Semana 12 — Alto rendimiento y memoria

> `Span<T>`/`ReadOnlySpan<T>`/`Memory<T>`, `stackalloc`, `ArrayPool`, `ref` locals/returns, `ref struct`, `in`, `unsafe` y punteros, parsing zero-allocation, `System.Buffers`.

**Fase 4: Internals y rendimiento** · Dedicación: 10 horas

## 🎯 Objetivos de aprendizaje

Al finalizar esta semana, el estudiante será capaz de:

- <!-- TODO: objetivos medibles derivados de los temas de teoría -->

## 📚 Requisitos previos

- Semana 11 completada
- .NET 10 SDK instalado (`dotnet --version`)

## 🗂️ Estructura de la semana

```
week-12-alto_rendimiento_memoria/
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
| [01-span-y-memory.md](1-teoria/01-span-y-memory.md) | Span y memory | 30 min |
| [02-stackalloc-y-arraypool.md](1-teoria/02-stackalloc-y-arraypool.md) | Stackalloc y arraypool | 30 min |
| [03-ref-semantics.md](1-teoria/03-ref-semantics.md) | Ref semantics | 30 min |
| [04-ref-struct.md](1-teoria/04-ref-struct.md) | Ref struct | 30 min |
| [05-unsafe-y-punteros.md](1-teoria/05-unsafe-y-punteros.md) | Unsafe y punteros | 30 min |
| [06-parsing-zero-alloc.md](1-teoria/06-parsing-zero-alloc.md) | Parsing zero alloc | 30 min |

### Prácticas

| Ejercicio | Concepto | Duración |
|-----------|----------|:--------:|
| [ejercicio-01-span-parsing](2-practicas/ejercicio-01-span-parsing/README.md) | Span parsing | 90 min |
| [ejercicio-02-arraypool-buffers](2-practicas/ejercicio-02-arraypool-buffers/README.md) | Arraypool buffers | 90 min |

### Proyecto

[3-proyecto/README.md](3-proyecto/README.md) — Parser binario/CSV zero-allocation para registros del dominio.

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
| [← Semana 11: CLR, memoria y GC](../week-11-clr_memoria_gc/README.md) | **Semana 12: Alto rendimiento y memoria** | [Semana 13: Benchmarking y profiling →](../week-13-benchmarking_profiling/README.md) |
