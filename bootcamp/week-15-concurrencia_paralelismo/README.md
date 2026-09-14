# Semana 15 — Concurrencia y paralelismo

> `Thread` y thread pool, `lock`/`Lock`, `Monitor`, `Interlocked`, `SemaphoreSlim`, colecciones concurrentes, `Parallel`/PLINQ, `Channel<T>`, TPL Dataflow intro, race conditions y deadlocks.

**Fase 5: Concurrencia y plataforma** · Dedicación: 10 horas

## 🎯 Objetivos de aprendizaje

Al finalizar esta semana, el estudiante será capaz de:

- <!-- TODO: objetivos medibles derivados de los temas de teoría -->

## 📚 Requisitos previos

- Semana 14 completada
- .NET 10 SDK instalado (`dotnet --version`)

## 🗂️ Estructura de la semana

```
week-15-concurrencia_paralelismo/
├── 0-assets/        # 6 diagramas SVG
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
| [01-threads-y-threadpool.md](1-teoria/01-threads-y-threadpool.md) | Threads y threadpool | 30 min |
| [02-sincronizacion.md](1-teoria/02-sincronizacion.md) | Sincronizacion | 30 min |
| [03-colecciones-concurrentes.md](1-teoria/03-colecciones-concurrentes.md) | Colecciones concurrentes | 30 min |
| [04-parallel-y-plinq.md](1-teoria/04-parallel-y-plinq.md) | Parallel y plinq | 30 min |
| [05-channels.md](1-teoria/05-channels.md) | Channels | 30 min |
| [06-race-conditions-y-deadlocks.md](1-teoria/06-race-conditions-y-deadlocks.md) | Race conditions y deadlocks | 30 min |

### Prácticas

| Ejercicio | Concepto | Duración |
|-----------|----------|:--------:|
| [ejercicio-01-lock-interlocked](2-practicas/ejercicio-01-lock-interlocked/README.md) | Lock interlocked | 90 min |
| [ejercicio-02-channels-pipeline](2-practicas/ejercicio-02-channels-pipeline/README.md) | Channels pipeline | 90 min |

### Proyecto

[3-proyecto/README.md](3-proyecto/README.md) — Crawler/procesador concurrente con pipeline de Channels sobre datos del dominio.

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
| [← Semana 14: Reflection, atributos y source generators](../week-14-reflection_atributos_source_generators/README.md) | **Semana 15: Concurrencia y paralelismo** | [Semana 16: ASP.NET Core Minimal API →](../week-16-aspnet_core_minimal_api/README.md) |
