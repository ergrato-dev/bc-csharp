## 🚀 Proyecto Semanal: Modelo de dominio con jerarquía, interfaces y polimorfismo

### 🎯 Objetivo

Modelar **tu dominio asignado** con las herramientas de la POO y con criterio: una base abstracta que aporte estado e invariantes, tres tipos concretos que se diferencien de verdad, capacidades opcionales como interfaces, y las variantes de cálculo resueltas por **composición** (política inyectada + decorador) en vez de por una subclase por combinación.

### 📋 Tu dominio asignado

**Dominio**: [El instructor te asignará tu dominio]

### ✅ Requisitos funcionales (adaptables a tu dominio)

1. **Base abstracta** (`CatalogItem` renombrada) con: constructor que valida con guard clauses, propiedades de solo lectura, una propiedad `abstract` (`Category`), un método `abstract` de negocio (`MonthlyCost()`), un `virtual Describe()` y `Equals`/`GetHashCode` por la clave del dominio.
2. **Tres derivadas `sealed`** que se diferencien en `Category` y en la regla de negocio. Al menos **dos** redefinen `Describe()` llamando a `base.Describe()`. Ninguna lanza `NotSupportedException` en un `override`.
3. **Capacidad opcional como interfaz**: `IReservable` la implementan **solo** los tipos a los que aplica (si la implementaran todos, iría en la base). Incluye el uso del **miembro por defecto** `ReservationLabel()` y añade **una interfaz de capacidad propia** de tu dominio.
4. **Repositorio tras interfaz**: `InMemoryItemRepository` implementa `IItemRepository` con un `Dictionary` sin distinguir mayúsculas. `Find` devuelve `null` (nunca lanza) y `All()` expone `IReadOnlyList<T>`, jamás la colección interna.
5. **Composición sobre herencia**: **dos** políticas `IPricingPolicy` con reglas distintas y **un decorador** que envuelva a cualquiera de ellas (recargo, descuento o mínimo facturable). El menú permite cambiarlas en caliente y `CatalogService` **no cambia** al hacerlo.
6. **Servicio que solo conoce interfaces**: `CatalogService` recibe `IItemRepository` e `IPricingPolicy` por constructor. Añade un método de negocio propio que no mencione ninguna clase concreta.
7. **Polimorfismo real**: listar, agrupar por categoría y totalizar se resuelven con **un bucle** sobre la base. Prohibido decidir comportamiento con `if (item is Book) ... else if (item is Dvd) ...`: si aparece, falta un miembro virtual.
8. **Detección de capacidad con `is`**: reservar/liberar comprueba `item is IReservable r` e informa si el tipo no la ofrece. Eso **no** es lo mismo que el punto 7: aquí se pregunta por una capacidad, no por el tipo concreto.
9. **Disciplina de la semana**: campos privados, `sealed` por defecto, nada de estado estático mutable, ningún método virtual llamado desde un constructor, `required`/`init` donde el estado no deba cambiar.

### 💡 Ejemplos de adaptación por dominio

| Dominio | Base | Tres derivadas | `Category` | Regla que cambia | `IReservable` la implementa |
|---------|------|----------------|------------|------------------|------------------------------|
| **Biblioteca** | `LibraryItem` | `Book` · `Magazine` · `Dvd` | género / periodicidad | coste de reposición mensual | `Book` y `Dvd`, no `Magazine` |
| **Farmacia** | `Product` | `Medicine` · `Cosmetic` · `MedicalDevice` | familia terapéutica | margen y control de receta | solo `MedicalDevice` (alquiler) |
| **Gimnasio** | `Activity` | `Class` · `PersonalSession` · `Court` | tipo de actividad | tarifa por plaza / hora | `Court` y `PersonalSession` |
| **Hotel** | `Bookable` | `Room` · `MeetingRoom` · `ParkingSpot` | categoría | tarifa por noche / hora | las tres |
| **Taller** | `ServiceItem` | `Part` · `Labour` · `Diagnostic` | sistema del vehículo | coste por unidad / hora | solo `Diagnostic` (cita) |
| **Cine** | `Screening` | `Movie2D` · `Movie3D` · `PrivateEvent` | formato | precio de entrada | `PrivateEvent` |

### 🧱 Requisitos técnicos

- Un único proyecto de consola (`Project.csproj` del `starter/`), sin paquetes NuGet
- `dotnet build -warnaserror` sin warnings; `Nullable` habilitado
- Cuatro archivos: `Program.cs` (menú + servicio), `CatalogItem.cs` (jerarquía), `Contracts.cs` (interfaces), `InMemoryItemRepository.cs` (implementación + políticas)
- Un tipo público por archivo salvo los tipos pequeños que acompañan al principal
- Firmas públicas con `IReadOnlyList<T>`/`IEnumerable<T>`; nunca `List<T>` ni el `Dictionary` interno

### 🛠️ Entregables

1. `starter/` completado y adaptado, compilando sin warnings
2. `README.md` propio en `starter/` con:
   - **Diagrama de tu jerarquía** (texto o SVG): base, derivadas e interfaces implementadas por cada una
   - Tabla: por cada derivada, qué devuelve `Category`, qué regla implementa `MonthlyCost()` y por qué merece ser un tipo aparte
   - Justificación de **por qué `IReservable` no está en la base**
   - Sesión de ejemplo pegada mostrando el cambio de política en caliente
3. Respuesta a: *si mañana el precio dependiera de tres ejes (tipo × temporada × canal), ¿cuántas clases harían falta con herencia y cuántas con tu diseño actual?*

### 📊 Evaluación

Ver [rubrica-evaluacion.md](../rubrica-evaluacion.md), sección Producto (30%).
