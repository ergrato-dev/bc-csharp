# Ejercicio 02 — Figuras y polimorfismo

> Tutorial guiado. Descomenta paso a paso en `starter/Program.cs` y ejecuta `dotnet run` tras cada paso.

## 🎯 Objetivo

Recorrer el otro lado de la POO: una clase `abstract` con despacho dinámico, `IComparable<T>` para el orden natural, miembros de interfaz por defecto, implementación explícita, y el salto de la herencia a la **composición** — una política inyectada y un decorador que la envuelve sin crear una subclase por combinación.

**Duración**: 90 min · **Teoría relacionada**: 03, 05, 06, 07

## 🚀 Preparación

```bash
cd starter
dotnet run
```

Los tipos viven al final en cinco bloques (`TIPOS A` … `E`) que se descomentan junto a los pasos 1, 4, 5 y 6.

## Paso 1: clase abstracta y despacho dinámico

`Shape` declara qué debe saber hacer toda figura; cada derivada lo resuelve a su manera. El bucle es de `Shape` y funcionaría igual con figuras que aún no existen.

```csharp
public abstract class Shape(string name) : IComparable<Shape>, IDescribable
{
    public abstract double Area();
    public abstract double Perimeter();
}
```

Descomenta `PASO 1`, `TIPOS A`, `TIPOS B` y las dos líneas de `using`/cultura. Prueba a crear una derivada sin implementar `Perimeter()`: error CS0534.

## Paso 2: `IComparable<T>` y comparadores puntuales

`Sort()` sin argumentos usa `CompareTo`: el **orden natural** del tipo. Un comparador pasado a `Sort` impone otro criterio sin tocar la clase.

```csharp
public int CompareTo(Shape? other) => other is null ? 1 : Area().CompareTo(other.Area());
ordered.Sort();
ordered.Sort((a, b) => string.CompareOrdinal(a.Name, b.Name));
```

Descomenta `PASO 2`. Invierte el `CompareTo` (`other.Area().CompareTo(Area())`) y observa que **todo** el orden natural del programa cambia: por eso el orden natural debe ser el evidente.

## Paso 3: miembros de interfaz por defecto

`ShortLabel()` tiene cuerpo dentro de la interfaz. Como ninguna clase lo implementa, **solo se ve a través del tipo interfaz**.

```csharp
public interface IDescribable
{
    string Describe();
    string ShortLabel() => Describe().Split(':')[0];
}
```

Descomenta `PASO 3`. Prueba `shapes[0].ShortLabel()` sin el cast: no compila. Esa es la diferencia entre un DIM y un método heredado de una clase base.

## Paso 4: implementación explícita

`Canvas` implementa `IDisposable` de forma explícita: `Dispose` **no** forma parte de su API pública y solo se llega a él a través de la interfaz (lo que hace `using` internamente).

```csharp
void IDisposable.Dispose() => _shapes.Clear();
```

Descomenta `PASO 4` y `TIPOS C`. Prueba `canvas.Dispose()` directo: no compila. Cámbialo a `using (var c = new Canvas()) { }` y verás que sí funciona.

## Paso 5: composición — la política se inyecta

`Quote` no sabe calcular precios: delega en el `IPricing` que reciba. Añadir una tarifa nueva no toca `Quote` ni obliga a derivar de nada.

```csharp
public sealed class Quote(Shape shape, IPricing pricing)
{
    public decimal Total() => pricing.Compute(shape);
}
```

Descomenta `PASO 5` y `TIPOS D`. Escribe una tercera política (`PerimeterPricing`) y úsala sin modificar `Quote`.

## Paso 6: decorador

`DiscountDecorator` **es un** `IPricing` y **tiene un** `IPricing`: cumple el contrato y delega en el envuelto ajustando el resultado. Se encadenan sin crear una clase por combinación.

```csharp
public sealed class DiscountDecorator(IPricing inner, decimal percent) : IPricing
{
    public decimal Compute(Shape shape) => inner.Compute(shape) * (1 - percent);
}
```

Descomenta `PASO 6` y `TIPOS E`. Con herencia, "por área + descuento + mínimo facturable" serían 8 subclases; aquí son 3 piezas combinables.

## Paso 7: comparar, `is` y estado del tipo

```csharp
if (shape.CompareTo(biggest) > 0) biggest = shape;
Console.WriteLine(biggest is Rectangle);
Console.WriteLine(Shape.Created);     // estado del TIPO, no de cada objeto
```

Descomenta `PASO 7`. `Created` cuenta todas las figuras del proceso: es exactamente el estado estático mutable del que advierte la teoría 03 — aquí es inofensivo, en un servidor con varios hilos no lo sería (semana 15).

## ✅ Verificación

```
Ejercicio 02 — figuras y polimorfismo. Sigue los pasos del README.
círculo    área     7.07 perímetro     9.42
cuadrado   área     4.00 perímetro     8.00
rectángulo área     4.50 perímetro     9.00

orden natural por área: cuadrado < rectángulo < círculo
orden alfabético: cuadrado < círculo < rectángulo

círculo: área 7.07, perímetro 9.42
cuadrado: área 4.00, perímetro 8.00
rectángulo: área 4.50, perímetro 9.00
círculo

figuras en el lienzo: 2
tras Dispose: 0

presupuesto por área:  45.00
presupuesto plano:     25.00

por área con 10 % dto: 40.50
dos descuentos encadenados: 36.45

la mayor es círculo (7.07)
¿es un rectángulo?: False
total de figuras creadas: 3
```

`dotnet build -warnaserror` sin warnings.

## 🧠 Preguntas de reflexión

1. `Shape` es una clase abstracta e `IDescribable` una interfaz. ¿Por qué cada uno es lo que es, y qué pasaría si `Shape` fuera solo una interfaz?
2. En el paso 6 encadenas dos descuentos del 10 % y el resultado no es un 20 %. ¿Por qué, y qué dice eso sobre el orden de los decoradores?
3. `Shape.Created` es un contador estático. Escribe en una frase el problema que tendría con 100 peticiones concurrentes y cómo lo resolverías.
