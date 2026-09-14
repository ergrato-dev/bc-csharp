## 🚀 Proyecto Semanal: Calculadora de dominio en consola

### 🎯 Objetivo

Construir una aplicación de consola con menú que resuelva **cuatro cálculos propios de tu dominio asignado**, aplicando todo lo visto en la semana 01: tipos correctos (`decimal` para dinero, `int`/`long` para conteos, `double` para medidas), conversiones seguras con `TryParse`, `checked` donde un desbordamiento sería un bug, control de flujo con `do-while`/`while (true)` y decisiones con `switch` expression.

### 📋 Tu dominio asignado

**Dominio**: [El instructor te asignará tu dominio]

### ✅ Requisitos funcionales (adaptables a tu dominio)

1. **Menú en bucle**: muestra las opciones, lee la elección, ejecuta, vuelve al menú. Opción `0` sale. Entrada inválida no rompe el programa.
2. **Cuatro cálculos del dominio**, cada uno con al menos dos datos de entrada validados con `TryParse`:
   - uno **monetario** (usa `decimal`, muestra 2 decimales)
   - uno con **medidas o proporciones** (usa `double`)
   - uno con **conteos o fechas** (usa `int`/`long`; usa `checked` si multiplica)
   - uno que **clasifique** el resultado con `switch` expression y patrones relacionales (`< 0`, `>= 18 and < 65`, …)
3. **Validación**: valores negativos donde no tengan sentido y divisiones por cero se rechazan con mensaje claro, sin excepción visible.
4. **Formato de salida**: usa interpolación y `CultureInfo.InvariantCulture` o la cultura del sistema de forma consciente (documenta cuál y por qué).

### 💡 Ejemplos de adaptación por dominio

| Dominio | Monetario (`decimal`) | Medida (`double`) | Conteo (`int`/`long`) | Clasificación (`switch`) |
|---------|----------------------|-------------------|-----------------------|--------------------------|
| **Biblioteca** | multa por días de retraso | ocupación de estanterías en % | libros prestados por socio al año | socio: nuevo / habitual / VIP |
| **Farmacia** | precio con IVA y descuento | dosis en mg por kg | unidades para N días de tratamiento | stock: crítico / bajo / normal |
| **Gimnasio** | cuota con promoción | IMC | sesiones por mes | IMC: bajo / normal / sobrepeso |
| **Restaurante** | cuenta con propina dividida | calorías por ración | mesas para N comensales | tiempo de espera: corto / medio / largo |
| **Taller mecánico** | mano de obra + repuestos | consumo l/100 km | km hasta próxima revisión | urgencia: baja / media / alta |

### 🧱 Requisitos técnicos

- Un único proyecto de consola (`Project.csproj` del `starter/`), sin paquetes NuGet
- `dotnet build -warnaserror` sin warnings; `Nullable` habilitado
- Código en inglés (nombres de métodos y variables), mensajes al usuario en español
- Cada cálculo en su propio método `static` dentro de `DomainCalculator.cs`
- Nada de `int.Parse`/`Convert.ToInt32` sobre entrada de usuario
- Sin `goto`; sin más de 3 niveles de anidamiento (usa early return o `continue`)

### 🛠️ Entregables

1. `starter/` completado y adaptado, compilando sin warnings
2. `README.md` propio en `starter/` con: dominio, descripción de los 4 cálculos, captura de una sesión de ejemplo (texto pegado vale) y la decisión sobre cultura
3. Respuesta a: *¿en qué cálculo usaste `checked` y qué pasaría sin él?*

### 📊 Evaluación

Ver [rubrica-evaluacion.md](../rubrica-evaluacion.md), sección Producto (30%).
