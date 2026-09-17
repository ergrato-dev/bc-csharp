# Glosario — Semana 04

Términos técnicos clave introducidos esta semana, ordenados alfabéticamente.

## A

**`abstract` (clase)** — Clase que no se puede instanciar; aporta estado y comportamiento comunes y obliga a las derivadas a completar sus miembros abstractos.

**`abstract` (miembro)** — Declaración sin cuerpo que toda derivada concreta debe implementar. Solo existe dentro de una clase abstracta o de una interfaz.

**Accesibilidad** — `private`, `protected`, `internal`, `protected internal`, `private protected`, `public`: quién puede ver un miembro. Por defecto: miembros `private`, tipos `internal`.

**Accesor** — El `get`, `set` o `init` de una propiedad. Se compila como un método (`get_X`/`set_X`).

## B

**`base`** — Referencia a la parte heredada: `base(...)` invoca el constructor de la clase base, `base.M()` llama a su implementación desde un `override`.

**`beforefieldinit`** — Marca que el compilador pone a un tipo sin constructor estático explícito: permite al runtime inicializar los campos estáticos antes, no exactamente en el primer acceso.

## C

**Campo de respaldo (backing field)** — Campo generado por el compilador para una propiedad autoimplementada (`<Name>k__BackingField`). Desde C# 14 se accede a él con `field`.

**`callvirt`** — Instrucción IL que resuelve el método por la tabla del objeto y comprueba `null`. El compilador la usa incluso para métodos no virtuales de tipos por referencia.

**Clase base frágil** — Problema por el que un cambio interno de la base rompe a las derivadas sin tocar su código, porque dependían de un detalle de implementación.

**Composición** — Reutilizar delegando en colaboradores que se reciben por constructor ("tiene un"), en lugar de heredar ("es un").

**Constructor primario** — Parámetros declarados junto al nombre de la clase, en ámbito en todo su cuerpo; el compilador genera un campo oculto por cada parámetro capturado.

## D

**Decorador** — Tipo que implementa una interfaz y envuelve a otra implementación de la misma interfaz para añadir comportamiento delegando en ella.

**Despacho dinámico** — Elección de la implementación en tiempo de ejecución según el tipo real del objeto, no según el tipo de la variable.

**Desvirtualización** — Optimización del JIT que convierte una llamada virtual en directa (y a menudo la inlinea) cuando puede probar que solo hay una implementación posible: de ahí el valor de `sealed`.

**DIM (default interface member)** — Miembro de interfaz con implementación por defecto. Permite evolucionar una interfaz publicada; solo es visible a través del tipo interfaz.

## E

**Encabezado de objeto** — Sync block index + puntero a la method table: 16 bytes en x64 antes del primer campo.

**`Equals` / `GetHashCode`** — Pareja inseparable: si dos objetos son iguales deben tener el mismo hash, y el hash no puede cambiar mientras el objeto esté en un `Dictionary` o `HashSet`.

## F

**`field` (C# 14)** — Palabra clave contextual que da acceso al campo de respaldo desde el cuerpo de un accesor, sin declararlo a mano.

**`file` (modificador)** — Restringe la visibilidad de un tipo al archivo donde se declara. Pensado para evitar colisiones en código generado.

## H

**Herencia simple** — En C# una clase deriva de **una** sola clase base, pero puede implementar tantas interfaces como quiera.

## I

**`IComparable<T>`** — Contrato del orden natural del tipo (`CompareTo`). Lo usan `Sort`, `SortedSet` y `SortedDictionary`.

**`IEquatable<T>`** — Igualdad tipada sin boxing; la prefieren `Dictionary`, `HashSet` y `List.Contains`.

**Implementación explícita** — `void IFoo.M() { }`: el miembro solo es accesible a través de la interfaz, no desde la clase.

**Interfaz** — Contrato sin estado ni constructor que describe capacidades ("puede hacer esto"). Sus miembros son públicos por definición.

**Inicializador de objeto** — `new X { A = 1 }`: se ejecuta **después** del constructor, por lo que no sirve para garantizar invariantes.

**`init`** — Accesor que solo permite asignar durante la construcción; se emite con el modificador `IsExternalInit`.

**`is` (patrón de tipo)** — `x is Derived d`: comprueba el tipo real y asigna en un paso; no lanza si falla.

## L

**Liskov (principio de sustitución)** — Todo código que funcione con la base debe seguir funcionando al recibir una derivada. Un `override` que lanza `NotSupportedException` lo viola.

## M

**Method table** — Estructura por tipo con sus metadatos y la tabla de métodos virtuales; el encabezado de cada objeto apunta a la de su tipo real.

**Miembro estático** — Pertenece al tipo, no a la instancia: existe una vez por proceso y no tiene `this`.

## N

**`new` (modificador)** — Oculta un miembro heredado en lugar de redefinirlo: con él manda el tipo de la **variable**. Silencia el warning CS0108 sin resolver el problema de diseño.

## O

**`object`** — Raíz de toda la jerarquía. Aporta `ToString`, `Equals`, `GetHashCode` (virtuales) y `GetType` (no virtual).

**`override`** — Redefine un miembro `virtual` o `abstract` de la base; con él manda el tipo del **objeto**.

## P

**`partial`** — Reparte un tipo (o un miembro) entre varios archivos del mismo ensamblado y namespace. Su razón de ser es convivir con código generado.

**Polimorfismo** — Que una misma llamada produzca comportamientos distintos según el tipo real del objeto.

**`protected`** — Visible en el tipo y sus derivadas. Cada miembro protegido es un contrato público con las clases hijas.

**Propiedad** — Par de métodos con sintaxis de campo; permite validar, calcular y evolucionar sin romper a quien la usa.

## R

**`required`** — Obliga a inicializar el miembro al construir el objeto; el compilador lo comprueba (CS9035).

## S

**`sealed` (clase)** — Prohíbe derivar. Valor por defecto del bootcamp: evita sorpresas y permite desvirtualizar.

**`sealed override`** — Redefine y cierra la cadena: nadie más abajo puede volver a redefinir ese miembro.

**Stub de despacho de interfaz** — Mecanismo del CLR con caché por punto de llamada que resuelve las llamadas a través de interfaz.

**`static` (clase)** — No instanciable ni heredable, solo miembros estáticos. Sitio para funciones puras.

## T

**Template Method** — Patrón donde la base fija el esqueleto del algoritmo en un método no virtual y las derivadas rellenan huecos `abstract`/`virtual`.

## U

**Upcast / downcast** — Convertir a la base (implícito y siempre seguro) o a la derivada (`(T)x` lanza, `as` devuelve `null`, `is` comprueba).

## V

**`virtual`** — Miembro con implementación que las derivadas pueden redefinir. Cada `virtual` es una promesa pública de extensibilidad.
