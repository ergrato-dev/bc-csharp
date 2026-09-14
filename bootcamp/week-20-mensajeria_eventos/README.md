# Semana 20 — Mensajería y arquitectura orientada a eventos

> RabbitMQ con MassTransit, publish/subscribe, consumidores, reintentos y dead-letter, outbox, idempotencia, sagas intro, workers desacoplados, Kafka comparativa.

**Fase 6: Comunicación y eventos** · Dedicación: 10 horas

## 🎯 Objetivos de aprendizaje

Al finalizar esta semana, el estudiante será capaz de:

- <!-- TODO: objetivos medibles derivados de los temas de teoría -->

## 📚 Requisitos previos

- Semana 19 completada
- .NET 10 SDK instalado (`dotnet --version`)

## 🗂️ Estructura de la semana

```
week-20-mensajeria_eventos/
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
| [01-fundamentos-mensajeria.md](1-teoria/01-fundamentos-mensajeria.md) | Fundamentos mensajeria | 30 min |
| [02-rabbitmq-y-masstransit.md](1-teoria/02-rabbitmq-y-masstransit.md) | Rabbitmq y masstransit | 30 min |
| [03-consumidores-reintentos-dlq.md](1-teoria/03-consumidores-reintentos-dlq.md) | Consumidores reintentos dlq | 30 min |
| [04-outbox-e-idempotencia.md](1-teoria/04-outbox-e-idempotencia.md) | Outbox e idempotencia | 30 min |
| [05-sagas-intro.md](1-teoria/05-sagas-intro.md) | Sagas intro | 30 min |
| [06-kafka-comparativa.md](1-teoria/06-kafka-comparativa.md) | Kafka comparativa | 30 min |

### Prácticas

| Ejercicio | Concepto | Duración |
|-----------|----------|:--------:|
| [ejercicio-01-publish-subscribe](2-practicas/ejercicio-01-publish-subscribe/README.md) | Publish subscribe | 90 min |
| [ejercicio-02-outbox-idempotente](2-practicas/ejercicio-02-outbox-idempotente/README.md) | Outbox idempotente | 90 min |

### Proyecto

[3-proyecto/README.md](3-proyecto/README.md) — Worker de procesamiento de eventos del dominio con outbox e idempotencia.

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
| [← Semana 19: gRPC y SignalR](../week-19-grpc_signalr/README.md) | **Semana 20: Mensajería y arquitectura orientada a eventos** | [Semana 21: Blazor fundamentos →](../week-21-blazor_fundamentos/README.md) |
