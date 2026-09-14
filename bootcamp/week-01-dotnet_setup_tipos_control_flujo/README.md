# Semana 01 — Setup .NET, tipos y control de flujo

> SDK .NET 10, CLI `dotnet`, proyectos y soluciones, `Program.cs` top-level, sistema de tipos, conversiones, operadores y control de flujo (incl. `switch` expression).

**Fase 1: Fundamentos acelerados** · Dedicación: 10 horas

## 🎯 Objetivos de aprendizaje

Al finalizar esta semana, el estudiante será capaz de:

- Explicar qué son SDK, runtime, CLR, BCL, IL y JIT, y cómo se ejecuta un programa C#
- Crear, compilar y ejecutar proyectos de consola con la CLI `dotnet`, y leer un `.csproj`
- Elegir el tipo numérico correcto (`int`, `long`, `double`, `decimal`) y escribir literales con sufijos
- Convertir entre tipos con criterio: implícita, cast, `TryParse` con cultura, y `checked` ante desbordamientos
- Controlar el flujo con `if`, `while`, `do-while`, `for`, `foreach`, `break` y `continue`
- Reemplazar cadenas de `if` por `switch` expression con patrones relacionales y guardas `when`

## 📚 Requisitos previos

- Conocer otro lenguaje de programación (variables, funciones, bucles) y manejar la terminal
- .NET 10 SDK instalado (`dotnet --version`)

## 🗂️ Estructura de la semana

```
week-01-dotnet_setup_tipos_control_flujo/
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
| [01-ecosistema-dotnet.md](1-teoria/01-ecosistema-dotnet.md) | Ecosistema .NET | 30 min |
| [02-cli-proyectos-y-soluciones.md](1-teoria/02-cli-proyectos-y-soluciones.md) | CLI `dotnet`, proyectos y soluciones | 30 min |
| [03-tipos-primitivos-y-variables.md](1-teoria/03-tipos-primitivos-y-variables.md) | Tipos primitivos y variables | 30 min |
| [04-conversiones-y-operadores.md](1-teoria/04-conversiones-y-operadores.md) | Conversiones y operadores | 30 min |
| [05-condicionales-y-bucles.md](1-teoria/05-condicionales-y-bucles.md) | Condicionales y bucles | 30 min |
| [06-switch-expression.md](1-teoria/06-switch-expression.md) | `switch` expression | 30 min |

### Prácticas

| Ejercicio | Concepto | Duración |
|-----------|----------|:--------:|
| [ejercicio-01-hola-dotnet](2-practicas/ejercicio-01-hola-dotnet/README.md) | Hola .NET: CLI, tipos, `checked`, `TryParse` | 90 min |
| [ejercicio-02-calculadora-switch](2-practicas/ejercicio-02-calculadora-switch/README.md) | Calculadora REPL con `switch` expression | 90 min |

### Proyecto

[3-proyecto/README.md](3-proyecto/README.md) — Calculadora de consola con menú, validación de entrada y operaciones del dominio asignado.

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
| — | **Semana 01: Setup .NET, tipos y control de flujo** | [Semana 02: Métodos, strings y colecciones →](../week-02-metodos_strings_colecciones/README.md) |
