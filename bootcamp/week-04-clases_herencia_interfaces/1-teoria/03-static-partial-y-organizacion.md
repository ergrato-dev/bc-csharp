# `static`, `partial` y organización del código

## 🎯 Objetivos

Al finalizar este archivo, comprenderás:

- Qué significa que un miembro sea `static` y cuándo conviene
- La diferencia entre `const` y `static readonly`, y por qué importa entre ensamblados
- Cuándo se ejecuta un constructor estático y qué peligros tiene
- Para qué existen `partial` y el modificador `file`
- Cómo organizar archivos, namespaces y `using` en un proyecto que va a crecer

## 📋 Conceptos clave

### 1. Miembros estáticos: pertenecen al tipo

```csharp
public sealed class Reservation
{
    private static int _created;                       // UN contador para todo el proceso
    public static int Created => _created;

    public static Reservation Create(string code) => new(code);   // factoría estática

    private Reservation(string code)
    {
        Code = code;
        _created++;
    }

    public string Code { get; }
}
```

Un miembro estático existe una vez por tipo (por proceso), no por objeto, y no puede tocar estado de instancia porque no hay `this`.

Usos legítimos: factorías (`Reservation.Create`), utilidades sin estado (`Math.Max`), constantes y cachés controladas. Uso problemático: **estado mutable global**, que convierte el orden de ejecución en parte del contrato y complica los tests y la concurrencia (semana 15).

### 2. Clases estáticas

```csharp
public static class Money
{
    public static decimal ApplyVat(decimal amount, decimal rate) => amount * (1 + rate);
}
```

Una clase `static` no se puede instanciar ni heredar y solo admite miembros estáticos. Es el sitio correcto para funciones puras. Si empieza a tener estado, deja de ser una utilidad y debería ser un objeto con dependencias explícitas.

### 3. `const` vs `static readonly`

```csharp
public const int MaxNights = 30;                    // literal: se copia en cada sitio que lo usa
public static readonly decimal DefaultRate = 100m;  // se lee del tipo en tiempo de ejecución
public static readonly string[] Tags = ["vip", "web"];  // ¡el contenido del array SÍ es mutable!
```

`const` se **inserta en el código del llamador** al compilar: si cambias el valor en una biblioteca y no recompilas a quien la usa, seguirá con el valor viejo. `static readonly` se resuelve en tiempo de ejecución y no tiene ese problema — por eso las bibliotecas públicas evitan `const` salvo para valores verdaderamente inmutables (números matemáticos, nombres de protocolo).

`readonly` impide reasignar la referencia, no mutar el objeto apuntado: usa `ImmutableArray<T>` o `ReadOnlyCollection<T>` para datos compartidos.

### 4. Constructor estático

```csharp
public static class CatalogDefaults
{
    public static readonly JsonSerializerOptions Options;

    static CatalogDefaults()      // se ejecuta UNA vez, antes del primer uso del tipo
    {
        Options = new JsonSerializerOptions { WriteIndented = true };
    }
}
```

El runtime garantiza que se ejecuta una sola vez y con seguridad entre hilos. Peligros: si lanza, el tipo queda **inutilizable** durante todo el proceso (`TypeInitializationException` en cada acceso posterior), y el momento exacto de ejecución depende de la política `beforefieldinit`. Prefiere inicializadores de campo simples; reserva el constructor estático para lógica que de verdad no cabe en una expresión.

### 5. `partial`: un tipo repartido en varios archivos

```csharp
// Catalog.Core.cs
public sealed partial class Catalog
{
    public int Count => _items.Count;
    private readonly List<Item> _items = [];
}

// Catalog.Reporting.cs
public sealed partial class Catalog
{
    public string BuildReport() => string.Join('\n', _items.Select(i => i.Name));
}
```

Todas las partes deben estar en el **mismo ensamblado y namespace** y llevar `partial`. Para qué sirve de verdad: convivir con **código generado** (source generators, diseñadores, EF Core, `System.Text.Json`, Blazor, MAUI) sin que el generador pise tu código. Partir una clase porque es enorme suele ser señal de que hacen falta dos clases.

También existen los **miembros parciales**: una parte declara la firma y otra la implementa (o nadie, y entonces la llamada se elimina). En C# 13/14 esto se extendió a propiedades e indexadores, que es lo que usan los generadores modernos.

### 6. El modificador `file`

```csharp
file sealed class LineParser { /* ... */ }   // visible SOLO en este archivo
```

Nacido para los source generators: evita colisiones de nombres cuando el generador emite tipos auxiliares. En código de aplicación se usa poco, pero es útil para tipos auxiliares que no deben escapar del archivo.

### 7. Organización: namespaces, archivos y `using`

```csharp
namespace Bootcamp.Hotel.Domain;   // file-scoped: sin llaves, un nivel menos de indentación

using System.Text.Json;            // using dentro o fuera del namespace: da igual salvo colisiones
global using System.Globalization; // una vez en el proyecto, disponible en todos los archivos
using Json = System.Text.Json.JsonSerializer;   // alias para desambiguar
```

Convenciones del bootcamp:

- **Un tipo público por archivo**, con el mismo nombre (`ReservationService.cs`).
- Namespace que refleja la carpeta (`Domain/Reservation.cs` → `Bootcamp.Hotel.Domain`).
- `ImplicitUsings` ya trae `System`, `System.Collections.Generic`, `System.Linq`, `System.IO`… Los `global using` propios van en un único archivo (`GlobalUsings.cs`).
- Nada de clases "cajón de sastre" (`Helpers`, `Utils`, `Manager`): el nombre debe decir qué hace.

## 🔬 Bajo el capó

`partial` es puramente de compilación: las partes se funden en **un solo tipo** en el IL; en el ensamblado no queda rastro de en cuántos archivos estaba. Lo mismo con `file`, que se emite con un nombre interno único por archivo.

Un `const` se emite como literal en los metadatos y el compilador lo copia en cada punto de uso; un `static readonly` se guarda en el tipo y se lee por una instrucción `ldsfld`, aunque el JIT suele convertirlo en constante tras la inicialización.

Los campos estáticos se inicializan por el **class constructor** (`.cctor`). Si la clase solo tiene inicializadores de campo, el compilador marca el tipo como `beforefieldinit` y el runtime puede ejecutarlos antes, en cualquier momento previo al primer acceso a un campo; al escribir un `static Xxx()` explícito, esa marca desaparece y la inicialización pasa a ser exactamente perezosa: justo antes del primer uso. Ese matiz explica bugs de orden de inicialización difíciles de reproducir.

## ⚠️ Errores comunes

- Estado mutable en `static`: tests que se contaminan entre sí y carreras en producción.
- Cambiar el valor de un `const` público de una biblioteca esperando que los consumidores lo vean.
- `static readonly` sobre arrays o listas creyendo que son inmutables.
- Constructor estático que lanza: el tipo queda muerto para todo el proceso.
- Usar `partial` para esconder que una clase hace demasiadas cosas.

## 📚 Recursos adicionales

- [Clases y miembros estáticos](https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members)
- [Constructores estáticos](https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/static-constructors)
- [`partial` (tipos y miembros)](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/partial-type)
- [Namespaces con ámbito de archivo](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/namespace) · [`global using`](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/using-directive#global-modifier)

## ✅ Checklist de verificación

- [ ] Distingo estado de instancia y de tipo, y evito el estado estático mutable
- [ ] Elijo `const` o `static readonly` con criterio de versionado
- [ ] Sé cuándo se ejecuta un `.cctor` y qué pasa si lanza
- [ ] Uso `partial` para convivir con código generado, no para ocultar clases enormes
- [ ] Un tipo público por archivo, namespace acorde a la carpeta
