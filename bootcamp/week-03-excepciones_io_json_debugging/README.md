# Semana 03 — Excepciones, I/O, JSON y debugging

> Excepciones y filtros `when`, excepciones personalizadas, `throw` expressions, depurador en VS Code, `System.IO` (File/Path/Directory/streams), `System.Text.Json`.

**Fase 1: Fundamentos acelerados** · Dedicación: 10 horas

## 🎯 Objetivos de aprendizaje

Al finalizar esta semana, el estudiante será capaz de:

- Elegir entre lanzar una excepción y devolver `false` con el patrón `TryXxx` según si el fallo es excepcional o esperado
- Escribir `catch` ordenados de específico a general, con filtros `when` que distingan casos del mismo tipo, y explicar las dos pasadas del runtime
- Conservar el diagnóstico: `throw;` frente a `throw ex;`, y envolver la causa en `InnerException`
- Diseñar una jerarquía de excepciones de dominio y validar argumentos con las guard clauses de la BCL
- Depurar en VS Code con breakpoints condicionales, logpoints, Call Stack y parada en el `throw` original
- Leer y escribir ficheros con `Path`, `File`, `Directory` y streams, distinguiendo API perezosas de las que materializan todo
- Guardar sin corromper: fichero temporal + `File.Move` atómico, y capturar `IOException` **y** `UnauthorizedAccessException`
- Serializar y deserializar con `System.Text.Json` reutilizando `JsonSerializerOptions`, tratando `JsonException` y usando un `JsonSerializerContext` generado

## 📚 Requisitos previos

- Semana 02 completada
- .NET 10 SDK instalado (`dotnet --version`)

## 🗂️ Estructura de la semana

```
week-03-excepciones_io_json_debugging/
├── 0-assets/        # 3 diagramas SVG
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
| [01-excepciones.md](1-teoria/01-excepciones.md) | `try`/`catch`/`finally`, filtros `when`, `throw;` vs `throw ex;`, guard clauses, `TryXxx` | 30 min |
| [02-excepciones-personalizadas.md](1-teoria/02-excepciones-personalizadas.md) | Jerarquía de `Exception`, diseño de excepciones propias, `InnerException`, `AggregateException` | 30 min |
| [03-debugging-vscode.md](1-teoria/03-debugging-vscode.md) | `launch.json`, breakpoints condicionales y logpoints, Call Stack, parada en el `throw`, `Debug.Assert` | 30 min |
| [04-system-io-y-streams.md](1-teoria/04-system-io-y-streams.md) | `Path`, `File`, `Directory`, `Stream`/`StreamReader`, lectura perezosa, escritura atómica | 30 min |
| [05-system-text-json.md](1-teoria/05-system-text-json.md) | `JsonSerializer`, opciones, records y campos ausentes, `JsonException`, source generator | 30 min |

### Prácticas

| Ejercicio | Concepto | Duración |
|-----------|----------|:--------:|
| [ejercicio-01-try-catch-when](2-practicas/ejercicio-01-try-catch-when/README.md) | Orden de `catch`, `finally`, `TryParse`, filtros `when`, `throw;` vs `throw ex;`, excepción propia con `InnerException`, guard clauses | 90 min |
| [ejercicio-02-json-persistencia](2-practicas/ejercicio-02-json-persistencia/README.md) | `Path`/`Directory`, `JsonSerializerOptions` reutilizadas, campos ausentes, `JsonException`, escritura `.tmp` + `File.Move`, streams y source generator | 90 min |

### Proyecto

[3-proyecto/README.md](3-proyecto/README.md) — Gestor del catálogo del dominio persistido en JSON: carga tolerante a fichero ausente o corrupto, guardado atómico, copia de seguridad con marca de tiempo, importación desde texto que reporta cada línea mala, jerarquía de excepciones de dominio con un único `catch` en el menú y evidencia de depuración.

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
| [← Semana 02: Métodos, strings y colecciones](../week-02-metodos_strings_colecciones/README.md) | **Semana 03: Excepciones, I/O, JSON y debugging** | [Semana 04: Clases, herencia e interfaces →](../week-04-clases_herencia_interfaces/README.md) |
