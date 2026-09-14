# Semana 11 — CLR, memoria y GC

> CLR, JIT tiered/ReadyToRun/Native AOT, assemblies e IL, stack/heap, generaciones GC y LOH, `IDisposable`/`using`/finalizadores, `SafeHandle`, `WeakReference`.

**Fase 4: Internals y rendimiento** · Dedicación: 10 horas

## 🎯 Objetivos de aprendizaje

Al finalizar esta semana, el estudiante será capaz de:

- <!-- TODO: objetivos medibles derivados de los temas de teoría -->

## 📚 Requisitos previos

- Semana 10 completada
- .NET 10 SDK instalado (`dotnet --version`)

## 🗂️ Estructura de la semana

```
week-11-clr_memoria_gc/
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
| [01-clr-y-jit.md](1-teoria/01-clr-y-jit.md) | Clr y jit | 30 min |
| [02-assemblies-e-il.md](1-teoria/02-assemblies-e-il.md) | Assemblies e il | 30 min |
| [03-stack-heap-detalle.md](1-teoria/03-stack-heap-detalle.md) | Stack heap detalle | 30 min |
| [04-garbage-collector.md](1-teoria/04-garbage-collector.md) | Garbage collector | 30 min |
| [05-idisposable-y-finalizacion.md](1-teoria/05-idisposable-y-finalizacion.md) | Idisposable y finalizacion | 30 min |
| [06-native-aot.md](1-teoria/06-native-aot.md) | Native aot | 30 min |

### Prácticas

| Ejercicio | Concepto | Duración |
|-----------|----------|:--------:|
| [ejercicio-01-inspeccion-il](2-practicas/ejercicio-01-inspeccion-il/README.md) | Inspeccion il | 90 min |
| [ejercicio-02-dispose-correcto](2-practicas/ejercicio-02-dispose-correcto/README.md) | Dispose correcto | 90 min |

### Proyecto

[3-proyecto/README.md](3-proyecto/README.md) — Inspector de assemblies y medidor de asignaciones por operación del dominio.

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
| [← Semana 10: Async/await](../week-10-async_await/README.md) | **Semana 11: CLR, memoria y GC** | [Semana 12: Alto rendimiento y memoria →](../week-12-alto_rendimiento_memoria/README.md) |
