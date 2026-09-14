---
name: "Commit message"
description: "Genera un mensaje de commit Conventional Commits para cambios del bootcamp C#."
argument-hint: "Resumen de los cambios o salida de git diff --stat"
mode: "agent"
---

# Commit message — Bootcamp C#

Formato: `tipo(alcance): descripción` en español, imperativo, ≤ 72 caracteres.

Tipos: `feat` (contenido nuevo), `fix` (corrección), `docs` (README/docs raíz), `refactor`, `chore`, `style`.
Alcance: `week-XX`, `docs`, `assets`, `repo`.

Ejemplos:

- `feat(week-08): agregar teoría de ejecución diferida en LINQ`
- `fix(week-12): corregir ejemplo de stackalloc que no compilaba`
- `docs(repo): actualizar tabla de semanas`

Cuerpo opcional con viñetas de qué cambió y por qué. Sin emojis.

## Cambios

$input
