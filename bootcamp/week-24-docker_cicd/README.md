# Semana 24 — Docker y CI/CD

> `dotnet publish` (trimming, AOT, single-file), Dockerfile multi-stage, docker-compose con PostgreSQL y RabbitMQ, secretos, GitHub Actions, versionado y NuGet propio.

**Fase 8: Producción y proyecto final** · Dedicación: 10 horas

## 🎯 Objetivos de aprendizaje

Al finalizar esta semana, el estudiante será capaz de:

- <!-- TODO: objetivos medibles derivados de los temas de teoría -->

## 📚 Requisitos previos

- Semana 23 completada
- .NET 10 SDK instalado (`dotnet --version`)

## 🗂️ Estructura de la semana

```
week-24-docker_cicd/
├── 0-assets/        # 4 diagramas SVG
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
| [01-publish-y-modos.md](1-teoria/01-publish-y-modos.md) | Publish y modos | 30 min |
| [02-dockerfile-multistage.md](1-teoria/02-dockerfile-multistage.md) | Dockerfile multistage | 30 min |
| [03-compose.md](1-teoria/03-compose.md) | Compose | 30 min |
| [04-github-actions.md](1-teoria/04-github-actions.md) | Github actions | 30 min |
| [05-paquetes-nuget.md](1-teoria/05-paquetes-nuget.md) | Paquetes nuget | 30 min |

### Prácticas

| Ejercicio | Concepto | Duración |
|-----------|----------|:--------:|
| [ejercicio-01-dockerizar-api](2-practicas/ejercicio-01-dockerizar-api/README.md) | Dockerizar api | 90 min |
| [ejercicio-02-pipeline-actions](2-practicas/ejercicio-02-pipeline-actions/README.md) | Pipeline actions | 90 min |

### Proyecto

[3-proyecto/README.md](3-proyecto/README.md) — Solución del dominio contenedorizada con CI verde.

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
| [← Semana 23: .NET MAUI multiplataforma](../week-23-maui_multiplataforma/README.md) | **Semana 24: Docker y CI/CD** | [Semana 25: Observabilidad, resiliencia y seguridad →](../week-25-observabilidad_resiliencia_seguridad/README.md) |
