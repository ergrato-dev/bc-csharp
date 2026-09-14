# Dominios únicos por aprendiz (política anticopia)

Cada aprendiz recibe al inicio del bootcamp un dominio de negocio distinto y
adapta todos los proyectos semanales a ese dominio. Los ejercicios guiados son
comunes; los proyectos no.

## Dominios sugeridos

| # | Dominio | Entidad principal | Entidades secundarias |
|---|---------|-------------------|-----------------------|
| 1 | Biblioteca | Libro | Autor, Préstamo, Socio |
| 2 | Farmacia | Medicamento | Venta, Proveedor, Lote |
| 3 | Gimnasio | Miembro | Rutina, Asistencia, Entrenador |
| 4 | Escuela | Estudiante | Curso, Matrícula, Docente |
| 5 | Tienda de mascotas | Mascota | Producto, Venta, Cliente |
| 6 | Restaurante | Platillo | Mesa, Pedido, Reserva |
| 7 | Banco | Cuenta | Movimiento, Cliente, Tarjeta |
| 8 | Agencia de taxis | Viaje | Conductor, Vehículo, Pasajero |
| 9 | Hospital | Paciente | Cita, Médico, Historia clínica |
| 10 | Cine | Función | Película, Sala, Entrada |
| 11 | Hotel | Reserva | Habitación, Huésped, Servicio |
| 12 | Agencia de viajes | Paquete | Destino, Reserva, Cliente |
| 13 | Concesionario | Vehículo | Venta, Cliente, Prueba de manejo |
| 14 | Tienda de ropa | Prenda | Talla, Pedido, Cliente |
| 15 | Taller mecánico | Orden de trabajo | Vehículo, Repuesto, Mecánico |
| 16 | Veterinaria | Consulta | Mascota, Veterinario, Vacuna |
| 17 | Coworking | Reserva de espacio | Espacio, Miembro, Plan |
| 18 | Ferretería | Producto | Inventario, Venta, Proveedor |
| 19 | Editorial | Publicación | Autor, Edición, Distribuidor |
| 20 | Club deportivo | Partido | Equipo, Jugador, Torneo |

## Reglas para el instructor

1. Asignar y registrar un dominio por aprendiz; no repetir en el mismo grupo.
2. Validar cada semana que el proyecto es coherente con el dominio.
3. Las entidades del dominio aparecen desde la semana 03 (persistencia JSON) y
   evolucionan hasta el proyecto final (API + worker + UI).

## Reglas para el aprendiz

- Nombres de tipos en inglés aunque el dominio se describa en español
  (`Book`, `Loan`, `Member`).
- La PK de toda entidad es `Guid`.
- El mismo dominio se mantiene las 26 semanas.
