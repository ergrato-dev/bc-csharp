---
name: "Nuevo ejercicio"
description: "Crea un ejercicio guiado (patrón uncomment) para 2-practicas/ del bootcamp C#, con README por pasos y starter/ que compila desde el paso 0."
argument-hint: "Semana, nombre del ejercicio (ej: ejercicio-02-channels-pipeline), concepto y pasos"
mode: "agent"
---

# Nuevo ejercicio — Bootcamp C#

## Estructura

```
2-practicas/ejercicio-XX-tema/
├── README.md
└── starter/
    ├── Exercise.csproj      # net10.0, Nullable, ImplicitUsings, TreatWarningsAsErrors
    └── Program.cs           # secciones PASO N comentadas
```

Añadir archivos `.cs` extra en `starter/` solo si el concepto lo exige (tipos, servicios).

## Formato README

Por cada paso: título, explicación breve del concepto, ejemplo de código, instrucción
"**Abre `starter/Program.cs`** y descomenta la sección `PASO N`", y salida esperada de `dotnet run`.

Cierre: sección "✅ Verificación" con lo que debe imprimir el programa completo y
"🧠 Preguntas de reflexión" (3 preguntas).

## Formato Program.cs

```csharp
// ============================================
// PASO 1: Título
// ============================================
// Explicación pedagógica en español.
// Descomenta las siguientes líneas:
// var channel = Channel.CreateBounded<int>(10);
```

## Reglas

- SIN TODOs, sin `solution/`
- Compila en el paso 0 y en cada paso intermedio (los pasos son acumulativos)
- 4–7 pasos, 60–90 minutos
- Sin dependencias NuGet salvo que la semana las enseñe; versión exacta si las hay

## Datos

$input
