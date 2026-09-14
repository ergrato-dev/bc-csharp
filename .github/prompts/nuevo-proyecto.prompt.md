---
name: "Nuevo proyecto"
description: "Crea el proyecto semanal de 3-proyecto/ del bootcamp C#: README genérico adaptable a dominios únicos y starter/ con TODOs."
argument-hint: "Semana, título del proyecto, conceptos que debe integrar"
mode: "agent"
---

# Nuevo proyecto semanal — Bootcamp C#

## Estructura

```
3-proyecto/
├── README.md
└── starter/
    ├── Project.csproj
    ├── Program.cs
    └── ... (tipos con TODOs según la semana)
```

`solution/` NO se crea (política anticopia, `.gitignore`).

## README.md

```markdown
## 🚀 Proyecto Semanal: [Título genérico]

### 🎯 Objetivo
### 📋 Tu dominio asignado
**Dominio**: [El instructor te asignará tu dominio]
### ✅ Requisitos funcionales (adaptables a tu dominio)
1. ...
### 💡 Ejemplos de adaptación por dominio
- **Biblioteca**: ...  - **Farmacia**: ...  - **Gimnasio**: ...  - **Restaurante**: ...
### 🧱 Requisitos técnicos
- conceptos de la semana que deben aparecer (lista verificable)
### 🛠️ Entregables
### 📊 Criterios de evaluación (enlace a rubrica-evaluacion.md)
```

## starter/

- Nombres genéricos (`Item`, `ItemService`, `IItemRepository`) con nota "adapta a tu dominio"
- Cada TODO indica QUÉ y con qué concepto de la semana, no CÓMO
- Compila tal cual (`throw new NotImplementedException()` donde haga falta)

## Datos

$input
