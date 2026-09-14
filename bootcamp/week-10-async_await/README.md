# Semana 10 — Async/await

> `Task`/`Task<T>`, `async`/`await` y máquina de estados, `ConfigureAwait`, `CancellationToken`, `IAsyncEnumerable`, `ValueTask`, antipatrones (`async void`, `.Result`), `Task.WhenAll`/`WhenAny`, `HttpClient`.

**Fase 3: C# moderno** · Dedicación: 10 horas

## 🎯 Objetivos de aprendizaje

Al finalizar esta semana, el estudiante será capaz de:

- <!-- TODO: objetivos medibles derivados de los temas de teoría -->

## 📚 Requisitos previos

- Semana 09 completada
- .NET 10 SDK instalado (`dotnet --version`)

## 🗂️ Estructura de la semana

```
week-10-async_await/
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
| [01-modelo-asincrono.md](1-teoria/01-modelo-asincrono.md) | Modelo asincrono | 30 min |
| [02-task-y-async-await.md](1-teoria/02-task-y-async-await.md) | Task y async await | 30 min |
| [03-cancelacion.md](1-teoria/03-cancelacion.md) | Cancelacion | 30 min |
| [04-iasyncenumerable-y-valuetask.md](1-teoria/04-iasyncenumerable-y-valuetask.md) | Iasyncenumerable y valuetask | 30 min |
| [05-antipatrones.md](1-teoria/05-antipatrones.md) | Antipatrones | 30 min |
| [06-httpclient.md](1-teoria/06-httpclient.md) | Httpclient | 30 min |

### Prácticas

| Ejercicio | Concepto | Duración |
|-----------|----------|:--------:|
| [ejercicio-01-async-basico](2-practicas/ejercicio-01-async-basico/README.md) | Async basico | 90 min |
| [ejercicio-02-cancelacion-whenall](2-practicas/ejercicio-02-cancelacion-whenall/README.md) | Cancelacion whenall | 90 min |

### Proyecto

[3-proyecto/README.md](3-proyecto/README.md) — Cliente de API pública con descargas concurrentes, cancelación y streaming asíncrono.

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
| [← Semana 09: Pattern matching y nullable](../week-09-pattern_matching_nullable/README.md) | **Semana 10: Async/await** | [Semana 11: CLR, memoria y GC →](../week-11-clr_memoria_gc/README.md) |
