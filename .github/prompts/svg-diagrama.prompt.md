---
name: "Diagrama SVG"
description: "Crea un diagrama SVG para 0-assets/ con tema dark, paleta .NET púrpura (#512BD4), sin degradés, sans-serif y accesible."
argument-hint: "Semana destino, nombre de archivo (ej: 04-generaciones-gc) y qué debe mostrar"
mode: "agent"
---

# Diagrama SVG — Bootcamp C#

## Estándares

| Propiedad | Valor |
|-----------|-------|
| Fondo | `#0d1117`, `rx="12"` |
| Superficies | `#161b22` (cajas) · `#21262d` (destacado) |
| Texto | `#f0f6fc` principal · `#8b949e` secundario · `#484f58` notas |
| Acento | `#512BD4` · claro `#7a5cf0` · oscuro `#3f21a6` |
| Estado | success `#3fb950` · warning `#d29922` · error `#f85149` · info `#58a6ff` |
| Bordes | `#30363d` · énfasis `#6e7681` |
| Fuente | `system-ui, -apple-system, sans-serif` |
| Degradés | prohibidos |
| Tamaño | `viewBox="0 0 800 500"` (ajustar alto si hace falta) |

## Esqueleto

```xml
<svg xmlns="http://www.w3.org/2000/svg" width="800" height="500" viewBox="0 0 800 500"
     role="img" aria-labelledby="title desc">
  <title id="title">Nombre</title>
  <desc id="desc">Descripción completa para lectores de pantalla</desc>
  <rect width="800" height="500" fill="#0d1117" rx="12"/>
  <defs>
    <marker id="arrow" markerWidth="10" markerHeight="7" refX="9" refY="3.5" orient="auto">
      <polygon points="0 0, 10 3.5, 0 7" fill="#7a5cf0"/>
    </marker>
  </defs>
  <!-- contenido -->
</svg>
```

## Reglas

- Labels de código en inglés (`Gen0`, `ThreadPool`, `DbContext`); conceptos pedagógicos en español
- Máximo ~12 nodos; un concepto por diagrama
- Vincular desde teoría: `![Descripción](../0-assets/NN-nombre.svg)`
- Actualizar `0-assets/README.md` marcando el SVG como generado

## Datos

$input
