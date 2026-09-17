# Glosario — Semana 05

Términos técnicos clave introducidos esta semana, ordenados alfabéticamente.

## B

**Boxing** — Convertir un tipo por valor en objeto del heap (al pasarlo a `object`, a `dynamic` o a una interfaz): asigna memoria y copia el valor. `Unboxing` es el camino inverso.

**`beforefieldinit`** — (semana 04) Sigue importando aquí: cada tipo genérico **cerrado** tiene su propio constructor estático y su propio almacenamiento estático.

## C

**Contravarianza (`in`)** — Un parámetro de tipo que solo **entra** permite usar una implementación más general donde se pide una más específica: `IComparer<object>` vale como `IComparer<string>`.

**Copia defensiva** — Copia que el compilador inserta al llamar a un miembro de un `struct` no `readonly` almacenado en un campo de solo lectura. `readonly struct` la elimina.

**Copia superficial** — La que hace `with` (y el constructor de copia de un `record`): copia los campos, no lo que apuntan las referencias.

**Covarianza (`out`)** — Un parámetro de tipo que solo **sale** permite usar una implementación más específica donde se pide una más general: `IEnumerable<string>` vale como `IEnumerable<object>`.

## D

**`default(T)`** — Valor cero del tipo: `null` para referencias, `0`/`false` para numéricos, `struct` con todos los campos a cero. Existe siempre, aunque el constructor valide.

**Deconstrucción** — `var (a, b) = record;` gracias al método `Deconstruct` que genera el compilador.

## E

**`EqualityComparer<T>.Default`** — Comparador que el runtime elige por tipo (usa `IEquatable<T>` si existe) sin boxing y **sin exigir restricciones**.

**`EqualityContract`** — Propiedad protegida generada en cada `record` que devuelve su `Type`; `Equals` la compara primero, por eso un derivado nunca es igual a su base.

## F

**`[Flags]`** — Atributo que marca un `enum` como conjunto de bits: cambia `ToString()` para listar los nombres combinados. Requiere valores potencia de dos y un miembro 0.

## I

**Instanciación (de un genérico)** — Cada tipo cerrado (`List<int>`, `List<string>`) es un tipo real con su propia identidad, sus estáticos y, para tipos por valor, su propio código nativo.

**`INumber<T>`** — Interfaz de las matemáticas genéricas: exige `T.Zero`, `T.One` y los operadores con miembros `static abstract`, para escribir un algoritmo numérico una sola vez.

**Invarianza** — Cuando el parámetro de tipo entra y sale (`List<T>`, `IList<T>`): ninguna conversión de varianza es segura.

## N

**`notnull`** — Restricción que admite cualquier tipo salvo los nullable; es la que exige `Dictionary<TKey, TValue>` para la clave.

**`Nullable<T>`** — `readonly struct` genérico detrás de `int?`: `HasValue`, `Value`, `GetValueOrDefault()`.

## R

**`record` (class)** — Clase orientada a datos con igualdad por valor, `ToString`, `with` y `Deconstruct` generados por el compilador.

**`record struct`** — Versión por valor del `record`. Sin `readonly`, sus propiedades posicionales se generan mutables.

**`readonly record struct`** — La combinación recomendada para valores pequeños e inmutables: igualdad generada, cero asignaciones en el heap, sin copias defensivas.

**`readonly struct`** — `struct` que promete no mutar su estado; evita las copias defensivas del compilador.

**Restricción (`where`)** — Cada cláusula concede una capacidad al parámetro de tipo (`new()`, `class`, `struct`, `notnull`, `unmanaged`, interfaz, clase base, otro parámetro).

## S

**`static abstract` (miembro de interfaz)** — Permite exigir miembros estáticos y operadores a un parámetro de tipo (C# 11). Base de `INumber<T>` e `IParsable<T>`.

**`struct`** — Tipo por valor: la variable contiene los datos, la asignación copia y no hay encabezado de objeto.

## T

**Tipo abierto / tipo cerrado** — `List<T>` es la plantilla (abierto); `List<int>` es un tipo real (cerrado) con su propia identidad en el runtime.

**Tipo por valor / por referencia** — Qué guarda la variable: el dato o una dirección. Determina qué copia una asignación y quién libera la memoria.

## U

**`unmanaged`** — Restricción que exige un `struct` sin campos por referencia: permite `sizeof`, `stackalloc` e interop.

## V

**Value object** — Tipo definido por sus datos, no por su identidad (`Money`, `RoomId`, `DateOnly`). En C# moderno: `readonly record struct`.

**Varianza** — Capacidad de sustituir un argumento de tipo por una base o una derivada; solo en interfaces y delegados genéricos y solo con tipos por referencia.

## W

**`with`** — Expresión que crea una copia de un `record` cambiando los miembros indicados; usa el constructor de copia generado y es superficial.
