# Semana 17 — EF Core y persistencia

> `DbContext` y modelado, migraciones, relaciones, traducción LINQ a SQL, tracking vs no-tracking, N+1, transacciones, concurrencia optimista, Dapper comparativa, PostgreSQL con Npgsql. PK `Guid`.

**Fase 5: Concurrencia y plataforma** · Dedicación: 10 horas

## 🎯 Objetivos de aprendizaje

Al finalizar esta semana, el estudiante será capaz de:

- <!-- TODO: objetivos medibles derivados de los temas de teoría -->

## 📚 Requisitos previos

- Semana 16 completada
- .NET 10 SDK instalado (`dotnet --version`)

## 🗂️ Estructura de la semana

```
week-17-ef_core_persistencia/
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
| [01-dbcontext-y-modelado.md](1-teoria/01-dbcontext-y-modelado.md) | Dbcontext y modelado | 30 min |
| [02-migraciones.md](1-teoria/02-migraciones.md) | Migraciones | 30 min |
| [03-relaciones.md](1-teoria/03-relaciones.md) | Relaciones | 30 min |
| [04-consultas-y-traduccion.md](1-teoria/04-consultas-y-traduccion.md) | Consultas y traduccion | 30 min |
| [05-tracking-y-rendimiento.md](1-teoria/05-tracking-y-rendimiento.md) | Tracking y rendimiento | 30 min |
| [06-transacciones-y-concurrencia.md](1-teoria/06-transacciones-y-concurrencia.md) | Transacciones y concurrencia | 30 min |

### Prácticas

| Ejercicio | Concepto | Duración |
|-----------|----------|:--------:|
| [ejercicio-01-primer-dbcontext](2-practicas/ejercicio-01-primer-dbcontext/README.md) | Primer dbcontext | 90 min |
| [ejercicio-02-relaciones-migraciones](2-practicas/ejercicio-02-relaciones-migraciones/README.md) | Relaciones migraciones | 90 min |

### Proyecto

[3-proyecto/README.md](3-proyecto/README.md) — API del dominio con PostgreSQL, migraciones y consultas optimizadas.

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
| [← Semana 16: ASP.NET Core Minimal API](../week-16-aspnet_core_minimal_api/README.md) | **Semana 17: EF Core y persistencia** | [Semana 18: Testing y calidad →](../week-18-testing_calidad/README.md) |
