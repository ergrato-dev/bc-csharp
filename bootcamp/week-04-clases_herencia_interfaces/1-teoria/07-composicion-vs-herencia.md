# Composición vs herencia

## 🎯 Objetivos

Al finalizar este archivo, comprenderás:

- Por qué "favorece la composición sobre la herencia" no es una moda
- Qué es el problema de la clase base frágil y la explosión de subclases
- El principio de sustitución de Liskov en términos prácticos
- Cómo refactorizar una jerarquía en colaboradores inyectados
- Cuándo la herencia sigue siendo la respuesta correcta

## 📋 Conceptos clave

### 1. Dos formas de reutilizar

```csharp
// Herencia: "es un". La derivada hereda TODO, quiera o no.
public sealed class PremiumAccount : Account { }

// Composición: "tiene un". El objeto delega en colaboradores que puede elegir.
public sealed class Account(IFeePolicy fees, IAuditLog audit)
{
    public decimal Fee(decimal balance) => fees.Compute(balance);
}
```

La herencia se decide **en compilación** y es para siempre; la composición se decide **en ejecución** y se puede cambiar, envolver o sustituir en un test.

### 2. La clase base frágil

Un cambio en la base rompe a las derivadas sin que nadie tocara su código:

```csharp
public class CountingList
{
    private readonly List<string> _items = [];
    public int AddedCount { get; private set; }

    public virtual void Add(string item) { _items.Add(item); AddedCount++; }
    public virtual void AddRange(IEnumerable<string> items) { foreach (var i in items) Add(i); }
}

public sealed class LoggingList : CountingList
{
    public override void Add(string item) { Console.WriteLine(item); base.Add(item); }
}
```

Hoy `AddRange` llama a `Add`, así que `LoggingList` registra todo. Si mañana alguien "optimiza" `AddRange` para insertar directamente en `_items`, `LoggingList` deja de registrar — sin ningún cambio en su código. La derivada dependía de un **detalle interno** de la base, no de su contrato.

### 3. La explosión de subclases

Tres ejes de variación (tipo de cliente × canal × forma de pago) por herencia son 2×3×3 = 18 clases. Por composición, tres colaboradores y una clase:

```csharp
public sealed class Order(IDiscountPolicy discount, IShippingPolicy shipping, IPaymentMethod payment);
```

Combinar en ejecución lo que la herencia obliga a enumerar en compilación es la diferencia entre 18 clases y 8 piezas.

### 4. Liskov, sin teoría

Si `Derived` es un `Base`, todo el código que funcione con `Base` debe seguir funcionando al recibir un `Derived`. Señales de que se viola:

```csharp
public override void Withdraw(decimal amount) => throw new NotSupportedException();  // ⚠️
public override decimal Fee() => base.Fee() * -1;             // ⚠️ invierte el significado
public override void Save() { /* no hace nada */ }            // ⚠️ silencio inesperado
```

Un `override` que lanza `NotSupportedException`, endurece las precondiciones o relaja las postcondiciones dice que la relación "es un" era mentira. El caso clásico: `Square : Rectangle` (cambiar el ancho de un cuadrado cambia también su alto, y el código que esperaba un rectángulo falla).

### 5. Refactor: de jerarquía a colaboradores

```csharp
// Antes: una subclase por variante de cálculo
public abstract class Invoice { public abstract decimal Total(); }
public sealed class SpanishInvoice : Invoice { public override decimal Total() => Net * 1.21m; }
public sealed class ExemptInvoice : Invoice { public override decimal Total() => Net; }

// Después: una clase y una estrategia inyectada
public interface ITaxPolicy { decimal Apply(decimal net); }
public sealed class VatPolicy(decimal rate) : ITaxPolicy { public decimal Apply(decimal net) => net * (1 + rate); }
public sealed class ExemptPolicy : ITaxPolicy { public decimal Apply(decimal net) => net; }

public sealed class Invoice(ITaxPolicy tax)
{
    public decimal Net { get; init; }
    public decimal Total() => tax.Apply(Net);
}
```

Ganancias: añadir una política nueva no toca `Invoice`; se puede probar cada política aislada; se combinan políticas (decorador) sin nuevas subclases. Esto es Strategy, y se formaliza en la semana 06.

### 6. Delegación explícita

```csharp
public sealed class AuditedRepository(IRoomRepository inner, IAuditLog log) : IRoomRepository
{
    public Room? Find(string number) => inner.Find(number);

    public void Save(Room room)
    {
        log.Write($"save {room.Number}");
        inner.Save(room);       // delega en el envuelto: decorador
    }

    public IReadOnlyList<Room> All() => inner.All();
}
```

El precio de la composición: métodos que solo reenvían. Es código aburrido y visible — preferible a una herencia que acopla en silencio.

### 7. Cuándo SÍ heredar

- Template Method: la base fija el algoritmo y las derivadas rellenan huecos (archivo 05).
- Jerarquías cerradas y estables del dominio, de uno o dos niveles.
- Extender un tipo de un framework que lo pide (`Exception`, `Controller`, `ComponentBase`, `DbContext`).
- Compartir estado e invariantes que todas las derivadas deben respetar.

En los tres primeros casos la base se diseñó para ello. Esa es la prueba: **¿alguien diseñó esta clase para que se derive?** Si no, composición.

## 🔬 Bajo el capó

La herencia es despacho por tabla de métodos: un salto indirecto ya resuelto en el layout del tipo. La composición añade un salto más (el campo del colaborador) y una llamada por interfaz, que usa el stub con caché del archivo 06. En un bucle caliente eso se nota; en la inmensa mayoría del código, no — y sellar las implementaciones deja que el JIT desvirtualice y vuelva a inlinar.

La diferencia cara no es de CPU: es que la herencia fija el grafo de objetos en compilación y la composición lo construye en ejecución, que es exactamente lo que permite a un contenedor de DI (semana 16) armar el objeto real en producción y uno falso en el test.

## ⚠️ Errores comunes

- Heredar para reutilizar tres líneas: acoplas todo el contrato.
- Jerarquías profundas donde el comportamiento real está repartido en cuatro niveles.
- `override` que lanza `NotSupportedException`.
- Composición con un colaborador creado dentro con `new`: vuelves a acoplarte a la implementación.
- Envolver todo en interfaces con un solo implementador "por si acaso" (la otra cara del exceso).

## 📚 Recursos adicionales

- [Herencia frente a composición (guía de .NET)](https://learn.microsoft.com/dotnet/standard/design-guidelines/choosing-between-class-and-struct)
- [Principio de sustitución de Liskov](https://learn.microsoft.com/dotnet/architecture/modern-web-apps-azure/architectural-principles)
- [Patrón Strategy en .NET](https://learn.microsoft.com/dotnet/architecture/microservices/) (capítulo de diseño de dominio)
- [Composition over inheritance — discusión clásica](https://en.wikipedia.org/wiki/Composition_over_inheritance)

## ✅ Checklist de verificación

- [ ] Explico el problema de la clase base frágil con un ejemplo propio
- [ ] Detecto violaciones de Liskov en un `override`
- [ ] Convierto una jerarquía de variantes en una estrategia inyectada
- [ ] Justifico cada herencia respondiendo "¿se diseñó para derivarse?"
- [ ] Acepto el coste de la delegación explícita a cambio de acoplamiento visible
