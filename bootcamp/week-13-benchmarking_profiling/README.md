# Semana 13 — Benchmarking y profiling

> BenchmarkDotNet, `dotnet-counters`/`dotnet-trace`/`dotnet-dump`, boxing y asignaciones ocultas, `struct` vs `class` medidos, `FrozenDictionary`, `SearchValues`, optimización guiada por datos.

**Fase 4: Internals y rendimiento** · Dedicación: 10 horas

## 🎯 Objetivos de aprendizaje

Al finalizar esta semana, el estudiante será capaz de:

- <!-- TODO: objetivos medibles derivados de los temas de teoría -->

## 📚 Requisitos previos

- Semana 12 completada
- .NET 10 SDK instalado (`dotnet --version`)

## 🗂️ Estructura de la semana

```
week-13-benchmarking_profiling/
├── 0-assets/        # 4 diagramas SVG
├── 1-teoria/        # 5 archivos
├── 2-practicas/     # 2 ejercicios guiados (patrón uncomment)
├── 3-proyecto/      # Proyecto semanal (TODOs, dominio único)
├── 4-recursos/      # ebooks-free · videografia · webgrafia
└── 5-glosario/      # Términos clave A-Z
```

## 📝 Contenidos

### Teoría

| Archivo | Tema | Duración |
|---------|------|:--------:|
| [01-benchmarkdotnet.md](1-teoria/01-benchmarkdotnet.md) | Benchmarkdotnet | 30 min |
| [02-diagnostico-dotnet-tools.md](1-teoria/02-diagnostico-dotnet-tools.md) | Diagnostico dotnet tools | 30 min |
| [03-boxing-y-asignaciones-ocultas.md](1-teoria/03-boxing-y-asignaciones-ocultas.md) | Boxing y asignaciones ocultas | 30 min |
| [04-colecciones-alto-rendimiento.md](1-teoria/04-colecciones-alto-rendimiento.md) | Colecciones alto rendimiento | 30 min |
| [05-optimizacion-guiada-por-datos.md](1-teoria/05-optimizacion-guiada-por-datos.md) | Optimizacion guiada por datos | 30 min |

### Prácticas

| Ejercicio | Concepto | Duración |
|-----------|----------|:--------:|
| [ejercicio-01-primer-benchmark](2-practicas/ejercicio-01-primer-benchmark/README.md) | Primer benchmark | 90 min |
| [ejercicio-02-trace-y-counters](2-practicas/ejercicio-02-trace-y-counters/README.md) | Trace y counters | 90 min |

### Proyecto

[3-proyecto/README.md](3-proyecto/README.md) — Optimización del parser de la semana 12 con benchmarks documentados.

## ⏱️ Distribución del tiempo (10 horas)

| Actividad | Tiempo |
|-----------|-------:|
| Teoría (5 archivos) | 2.5 h |
| Ejercicios (2) | 3.0 h |
| Proyecto semanal | 4.0 h |
| Glosario, recursos y revisión | 0.5 h |
| **Total** | **10 h** |

## 📌 Entregables

1. ✅ Ejercicios descomentados, compilando sin warnings y ejecutando
2. ✅ Proyecto adaptado al dominio asignado
3. ✅ README del proyecto con descripción de la implementación

## 🔗 Navegación

| Anterior | Actual | Siguiente |
|----------|--------|-----------|
| [← Semana 12: Alto rendimiento y memoria](../week-12-alto_rendimiento_memoria/README.md) | **Semana 13: Benchmarking y profiling** | [Semana 14: Reflection, atributos y source generators →](../week-14-reflection_atributos_source_generators/README.md) |
