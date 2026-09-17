// Ejercicio 02 — Figuras y polimorfismo
// El programa compila y ejecuta desde el paso 0. Descomenta cada PASO en orden.
// Los TIPOS van al final: en top-level statements toda declaración de tipo se escribe
// DESPUÉS de la última instrucción (error CS8803 si no).

// Desde el paso 1 hacen falta estas dos líneas (cultura fija = misma salida en cualquier máquina):
// using System.Globalization;
// CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

Console.WriteLine("Ejercicio 02 — figuras y polimorfismo. Sigue los pasos del README.");

// ============================================
// PASO 1: Clase abstracta y despacho dinámico
// ============================================
// Shape declara Area() y Perimeter() abstractos: cada figura los resuelve a su manera.
// El array es de Shape, pero decide el objeto.
// Descomenta también TIPOS A, TIPOS B y las dos líneas del using/cultura.
// Descomenta las siguientes líneas:
// Shape[] shapes = [new Circle(1.5), new Square(2), new Rectangle(3, 1.5)];
// foreach (Shape shape in shapes)
//     Console.WriteLine($"{shape.Name,-10} área {shape.Area(),8:F2} perímetro {shape.Perimeter(),8:F2}");

// ============================================
// PASO 2: IComparable<T>: orden natural y comparador puntual
// ============================================
// Sort() sin argumentos usa CompareTo (orden por área).
// Sort(comparación) impone otro criterio sin tocar la clase.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// List<Shape> ordered = [.. shapes];
// ordered.Sort();                                     // usa IComparable<Shape>: orden natural por área
// Console.WriteLine($"orden natural por área: {string.Join(" < ", ordered.Select(s => s.Name))}");
// ordered.Sort((a, b) => string.CompareOrdinal(a.Name, b.Name));   // comparador puntual
// Console.WriteLine($"orden alfabético: {string.Join(" < ", ordered.Select(s => s.Name))}");

// ============================================
// PASO 3: Miembros de interfaz por defecto (DIM)
// ============================================
// ShortLabel() tiene cuerpo en la interfaz: solo se ve a través del tipo interfaz.
// Por eso hay que escribir ((IDescribable)shape).ShortLabel().
// Descomenta las siguientes líneas:
// Console.WriteLine();
// foreach (Shape shape in shapes)
//     Console.WriteLine(((IDescribable)shape).Describe());        // miembro por defecto de la interfaz
// Console.WriteLine(((IDescribable)shapes[0]).ShortLabel());      // implementación por defecto no redefinida

// ============================================
// PASO 4: Implementación explícita de una interfaz
// ============================================
// Canvas implementa IDisposable de forma explícita: Dispose no aparece en su API pública.
// Descomenta también TIPOS C.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// var canvas = new Canvas();
// canvas.Add(shapes[0]);
// canvas.Add(shapes[1]);
// Console.WriteLine($"figuras en el lienzo: {canvas.Count}");
// ((IDisposable)canvas).Dispose();                                // implementación explícita
// Console.WriteLine($"tras Dispose: {canvas.Count}");

// ============================================
// PASO 5: Composición: la política de precio se inyecta
// ============================================
// Quote no sabe calcular precios: delega en el IPricing que reciba.
// Cambiar de política no toca ni una línea de Quote.
// Descomenta también TIPOS D.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// IPricing perArea = new AreaPricing(pricePerUnit: 10m);
// IPricing flat = new FlatPricing(price: 25m);
// var quoteByArea = new Quote(shapes[2], perArea);
// var quoteFlat = new Quote(shapes[2], flat);
// Console.WriteLine($"presupuesto por área:  {quoteByArea.Total():N2}");
// Console.WriteLine($"presupuesto plano:     {quoteFlat.Total():N2}");

// ============================================
// PASO 6: Decorador: envolver un colaborador
// ============================================
// DiscountDecorator ES un IPricing y TIENE un IPricing: delega y ajusta el resultado.
// Se pueden encadenar sin crear una subclase por combinación.
// Descomenta también TIPOS E.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// IPricing discounted = new DiscountDecorator(perArea, percent: 0.10m);
// var quoteDiscounted = new Quote(shapes[2], discounted);
// Console.WriteLine($"por área con 10 % dto: {quoteDiscounted.Total():N2}");
// IPricing twice = new DiscountDecorator(new DiscountDecorator(perArea, 0.10m), 0.10m);
// Console.WriteLine($"dos descuentos encadenados: {new Quote(shapes[2], twice).Total():N2}");

// ============================================
// PASO 7: Comparar, is y estado estático del tipo
// ============================================
// CompareTo ordena; is comprueba el tipo real; Created es estado del TIPO, no del objeto.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// Shape biggest = shapes[0];
// foreach (Shape shape in shapes)
//     if (shape.CompareTo(biggest) > 0) biggest = shape;
// Console.WriteLine($"la mayor es {biggest.Name} ({biggest.Area():F2})");
// Console.WriteLine($"¿es un rectángulo?: {biggest is Rectangle}");
// Console.WriteLine($"total de figuras creadas: {Shape.Created}");

// ============================================
// TIPOS A: Shape y sus tres derivadas (paso 1)
// ============================================
// Clase abstracta con miembros abstractos, IComparable<Shape> y un contador estático.
// Descomenta las siguientes líneas:
// public abstract class Shape(string name) : IComparable<Shape>, IDescribable
// {
//     private static int _created;
//
//     public static int Created => _created;
//
//     public string Name { get; } = Register(name);
//
//     public abstract double Area();
//     public abstract double Perimeter();
//
//     public int CompareTo(Shape? other) => other is null ? 1 : Area().CompareTo(other.Area());
//
//     public string Describe() => $"{Name}: área {Area():F2}, perímetro {Perimeter():F2}";
//
//     public override string ToString() => Describe();
//
//     private static string Register(string name)
//     {
//         _created++;
//         return name;
//     }
// }
//
// public sealed class Circle(double radius) : Shape("círculo")
// {
//     public override double Area() => Math.PI * radius * radius;
//     public override double Perimeter() => 2 * Math.PI * radius;
// }
//
// public sealed class Square(double side) : Shape("cuadrado")
// {
//     public override double Area() => side * side;
//     public override double Perimeter() => 4 * side;
// }
//
// public sealed class Rectangle(double width, double height) : Shape("rectángulo")
// {
//     public override double Area() => width * height;
//     public override double Perimeter() => 2 * (width + height);
// }

// ============================================
// TIPOS B: IDescribable con miembro por defecto (paso 1)
// ============================================
// Describe() es obligatorio; ShortLabel() trae implementación por defecto.
// Descomenta las siguientes líneas:
// public interface IDescribable
// {
//     string Describe();
//
//     string ShortLabel() => Describe().Split(':')[0];   // miembro por defecto (DIM)
// }

// ============================================
// TIPOS C: Canvas con IDisposable explícito (paso 4)
// ============================================
// Dispose solo accesible a través de la interfaz.
// Descomenta las siguientes líneas:
// public sealed class Canvas : IDisposable
// {
//     private readonly List<Shape> _shapes = [];
//
//     public int Count => _shapes.Count;
//
//     public void Add(Shape shape) => _shapes.Add(shape);
//
//     void IDisposable.Dispose() => _shapes.Clear();     // explícita: no ensucia la API pública
// }

// ============================================
// TIPOS D: IPricing, sus implementaciones y Quote (paso 5)
// ============================================
// Estrategia inyectada por constructor primario.
// Descomenta las siguientes líneas:
// public interface IPricing
// {
//     decimal Compute(Shape shape);
// }
//
// public sealed class AreaPricing(decimal pricePerUnit) : IPricing
// {
//     public decimal Compute(Shape shape) => (decimal)shape.Area() * pricePerUnit;
// }
//
// public sealed class FlatPricing(decimal price) : IPricing
// {
//     public decimal Compute(Shape shape) => price;
// }
//
// public sealed class Quote(Shape shape, IPricing pricing)
// {
//     public decimal Total() => pricing.Compute(shape);   // composición: la política se inyecta
// }

// ============================================
// TIPOS E: DiscountDecorator (paso 6)
// ============================================
// Decorador que implementa la interfaz y delega en otro IPricing.
// Descomenta las siguientes líneas:
// public sealed class DiscountDecorator(IPricing inner, decimal percent) : IPricing
// {
//     public decimal Compute(Shape shape) => inner.Compute(shape) * (1 - percent);   // delega y ajusta
// }
