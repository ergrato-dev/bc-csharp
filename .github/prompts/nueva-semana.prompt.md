---
name: "Nueva semana"
description: "Completa el contenido de una semana ya scaffoldeada del bootcamp C#: README, rúbrica, teoría, ejercicios uncomment, proyecto con TODOs, recursos y glosario."
argument-hint: "Número de semana (ej: 08). El plan de archivos vive en el README de la semana y en copilot-instructions.md."
mode: "agent"
---

# Completar semana — Bootcamp C#

Todas las semanas ya existen como esqueleto en `bootcamp/week-XX-slug/` con
placeholders marcados `⚠️ Pendiente` y `<!-- TODO -->`. Tu trabajo es
sustituir cada placeholder por contenido real siguiendo
`.github/copilot-instructions.md`.

## Orden de trabajo (una entrega por paso, esperar confirmación)

1. `README.md`: objetivos medibles (uno por archivo de teoría) y descripción real.
2. `1-teoria/`: cada archivo ~150 líneas (máx. 200), con sección "Bajo el capó" cuando aplique, y vínculo a los SVG de `0-assets/`.
3. `0-assets/`: generar cada SVG listado en `0-assets/README.md` (usar prompt `svg-diagrama`).
4. `2-practicas/`: cada ejercicio con README por pasos y `starter/Program.cs` con secciones `PASO N` comentadas. Debe compilar en el paso 0.
5. `3-proyecto/`: README genérico por dominio y `starter/` con TODOs.
6. `rubrica-evaluacion.md`: 10 preguntas reales y criterios concretos.
7. `4-recursos/` y `5-glosario/`.

## Reglas obligatorias

- Documentación en español; código y comentarios técnicos en inglés
- C# 14 / .NET 10, `Nullable` y `TreatWarningsAsErrors` habilitados
- Ejercicios: patrón uncomment, sin TODOs. Proyectos: TODOs genéricos por dominio
- Versiones exactas de NuGet
- NO crear `solution/`

## Semana a completar

$input
