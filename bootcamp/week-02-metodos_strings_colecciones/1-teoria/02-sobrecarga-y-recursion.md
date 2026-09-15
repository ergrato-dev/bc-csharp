# Sobrecarga y recursión

## 🎯 Objetivos

Al finalizar este archivo, comprenderás:

- Qué es la sobrecarga de métodos y cómo elige el compilador entre candidatas
- Los conflictos típicos entre sobrecargas, opcionales y `params`
- Cómo escribir recursión correcta: caso base, progreso y profundidad
- Cuándo convertir una recursión en un bucle o en una pila explícita

## 📋 Conceptos clave

### 1. Sobrecarga: mismo nombre, distinta firma

```csharp
static double Area(double radius) => Math.PI * radius * radius;
static double Area(double width, double height) => width * height;
static decimal Area(decimal width, decimal height) => width * height;

Area(2.0);          // círculo
Area(2.0, 3.0);     // rectángulo double
Area(2m, 3m);       // rectángulo decimal
```

La firma es nombre + número y tipos de parámetros. **El tipo de retorno no forma parte**: dos métodos `int Parse(string)` y `long Parse(string)` no compilan juntos (CS0111).

### 2. Resolución de sobrecarga

El compilador elige en compilación, con los tipos estáticos de los argumentos:

1. Candidatas aplicables (los argumentos convierten a los parámetros).
2. Entre ellas, la **mejor**: la que exige conversiones "más específicas" (identidad > ampliación implícita).
3. Empate o ninguna aplicable: error CS0121 / CS1503.

```csharp
static void Show(int n) => Console.WriteLine("int");
static void Show(long n) => Console.WriteLine("long");
static void Show(object o) => Console.WriteLine("object");

Show(1);        // int: identidad gana
Show(1L);       // long
Show(1.5);      // object: double no convierte implícitamente a int ni long; boxing a object sí
Show('a');      // int: char → int es implícita y más específica que char → long
```

Con `var x = 1; Show(x)` el resultado es el mismo: `var` fija el tipo en compilación. La resolución **no** mira el tipo en tiempo de ejecución (eso sería `dynamic`, semana 14).

### 3. Sobrecarga vs parámetros opcionales

```csharp
static void Connect(string host, int port = 5432) { }
static void Connect(string host) { }

Connect("db");   // elige la SIN opcional: una candidata sin defaults aplicados gana
```

Regla del bootcamp: usa **opcionales** cuando las variantes solo añaden datos con valor razonable; usa **sobrecarga** cuando la lógica difiere o los tipos cambian. Nunca mezcles ambas sobre el mismo nombre: la resolución se vuelve difícil de leer.

`params` es la candidata menos preferida: `Sum(1, 2)` elige `Sum(int, int)` antes que `Sum(params int[])` si ambas existen.

### 4. Recursión: un método que se llama a sí mismo

```csharp
static long Factorial(int n)
{
    if (n <= 1) return 1;            // caso base: sin él, StackOverflow
    return n * Factorial(n - 1);     // progreso: n se acerca al caso base
}
```

Toda recursión necesita: un **caso base** que no llama, y un **paso** que reduce el problema hacia el caso base. Cada llamada pendiente ocupa un stack frame; `Factorial(20)` apila 20 frames.

### 5. Recursión estructural: donde brilla

Estructuras anidadas (árboles, directorios, JSON) se recorren naturalmente con recursión:

```csharp
static long DirectorySize(string path)
{
    long total = 0;
    foreach (string file in Directory.GetFiles(path))
        total += new FileInfo(file).Length;
    foreach (string dir in Directory.GetDirectories(path))
        total += DirectorySize(dir);            // subárbol
    return total;
}
```

Aquí la profundidad es la del árbol de carpetas (decenas), no el número de archivos: seguro.

### 6. Cuándo NO usar recursión

```csharp
// Fibonacci recursivo: O(2ⁿ) llamadas, Fib(40) tarda segundos
static long FibSlow(int n) => n < 2 ? n : FibSlow(n - 1) + FibSlow(n - 2);

// Iterativo: O(n), sin stack
static long Fib(int n)
{
    long a = 0, b = 1;
    for (int i = 0; i < n; i++) (a, b) = (b, a + b);
    return a;
}
```

Señales de alarma: el mismo subproblema se calcula muchas veces (usa memoización o iteración), o la profundidad crece con el tamaño de la entrada (una lista de 100 000 elementos recorrida recursivamente desborda el stack).

### 7. Pila explícita: recursión sin límite de stack

```csharp
static long DirectorySizeIterative(string root)
{
    long total = 0;
    var pending = new Stack<string>();
    pending.Push(root);
    while (pending.Count > 0)
    {
        string dir = pending.Pop();
        foreach (string file in Directory.GetFiles(dir)) total += new FileInfo(file).Length;
        foreach (string sub in Directory.GetDirectories(dir)) pending.Push(sub);
    }
    return total;
}
```

Mismo algoritmo, la pila vive en el heap: profundidad limitada solo por memoria. `Stack<T>` se ve en el archivo 06.

## 🔬 Bajo el capó

El stack de cada hilo en .NET es de **1 MB** por defecto en Linux x64 (8 MB en el hilo principal en algunos entornos). Un frame de `Factorial` ocupa ~48–96 bytes (retorno, `n`, registros guardados); ~10 000–20 000 niveles bastan para `StackOverflowException`, que **no se puede capturar**: el proceso muere. El JIT de .NET no garantiza *tail call optimization* en C# (F# sí emite `tail.`), así que una recursión de cola no se convierte en bucle automáticamente. Si necesitas más profundidad, `new Thread(work, maxStackSize: 64 * 1024 * 1024)` crea un hilo con stack mayor; pero casi siempre la respuesta correcta es una pila explícita.

## ⚠️ Errores comunes

- Sobrecargas que solo difieren en el tipo de retorno: no compila.
- `Show(null)` con sobrecargas `string` y `object`: elige `string` (más específica); con `string` y `int[]`, ambigüedad CS0121.
- Recursión sin caso base o con progreso que no converge (`Factorial(n)` en vez de `n - 1`).
- Recursión sobre listas largas: `StackOverflowException` irrecuperable.
- Fibonacci recursivo "porque es elegante": mide antes de elegir.

## 📚 Recursos adicionales

- [Resolución de sobrecarga (especificación C#)](https://learn.microsoft.com/dotnet/csharp/language-reference/language-specification/expressions#1264-overload-resolution)
- [Parámetros opcionales y con nombre](https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments)
- [Recursión en C# (guía)](https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/methods#recursion)

## ✅ Checklist de verificación

- [ ] Predigo qué sobrecarga se elige para `Show(1)`, `Show('a')` y `Show(1.5)`
- [ ] Explico por qué el tipo de retorno no distingue sobrecargas
- [ ] Decido entre opcionales y sobrecarga con un criterio claro
- [ ] Identifico caso base y progreso en cualquier método recursivo
- [ ] Convierto una recursión a bucle o `Stack<T>` cuando la profundidad es un riesgo
