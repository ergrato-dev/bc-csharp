---
name: "Nuevo archivo de teoría"
description: "Redacta un archivo de 1-teoria/ del bootcamp C#: ~150 líneas, español, código C# en inglés, sección 'Bajo el capó' y referencias a learn.microsoft.com."
argument-hint: "Semana (ej: week-12), archivo (ej: 03-ref-semantics), conceptos a cubrir"
mode: "agent"
---

# Nuevo archivo de teoría — Bootcamp C#

## Extensión

- Objetivo ~150 líneas, máximo 200, mínimo 80. Si sobra, dividir en archivos numerados.

## Estructura

```markdown
# Título

## 🎯 Objetivos
- ...

## 📋 Conceptos clave
### 1. Concepto
Explicación en español + ejemplo:

\`\`\`csharp
// nombres en inglés, comentarios pedagógicos en español
\`\`\`

> 💡 **Comparado con otros lenguajes**: (Java/TypeScript/Python/C++ cuando ayude al aprendiz que viene de otro lenguaje)

## 🔬 Bajo el capó
Qué genera el compilador (lowering, IL) o qué hace el runtime. Obligatorio en fases 3–5.

## ⚠️ Errores comunes

## 📚 Recursos adicionales
- enlaces a learn.microsoft.com/dotnet y a la especificación de C#

## ✅ Checklist de verificación
```

## Reglas

- Nada de ASCII art: diagramas como `![Descripción](../0-assets/NN-nombre.svg)`
- Código compilable en .NET 10 con nullable habilitado
- Cada ejemplo aporta algo nuevo; sin relleno

## Datos

$input
