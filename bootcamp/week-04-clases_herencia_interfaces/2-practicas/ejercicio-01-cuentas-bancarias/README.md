# Ejercicio 01 — Cuentas bancarias

> Tutorial guiado. Descomenta paso a paso en `starter/Program.cs` y ejecuta `dotnet run` tras cada paso.

## 🎯 Objetivo

Construir una jerarquía pequeña y honesta: una clase con `required`/`init`/`field`, una base `abstract` con estado compartido y guard clauses, dos derivadas que redefinen reglas de negocio, polimorfismo en una colección, `Equals`/`GetHashCode` con sentido de dominio y la diferencia práctica entre `override` y `new`.

**Duración**: 90 min · **Teoría relacionada**: 01, 02, 04, 05

## 🚀 Preparación

```bash
cd starter
dotnet run
```

Los tipos viven al final del fichero, repartidos en tres bloques (`TIPOS A`, `B` y `C`) que se descomentan junto a los pasos 1, 2 y 3. En top-level statements **toda declaración de tipo va después de la última instrucción** (error CS8803 si no).

## Paso 1: `required`, `init` y `field`

`required` obliga a dar el valor al construir (comprobación en compilación); `init` lo congela después; `field` (C# 14) da acceso al campo de respaldo para validar sin declararlo a mano.

```csharp
public required string Name
{
    get => field;
    set => field = value.Trim();
}
```

Descomenta `PASO 1` y `TIPOS A`. Quita `DocumentId` del inicializador: error CS9035. Fíjate en que `same` y `holder` son **la misma referencia**: asignar no copia el objeto.

## Paso 2: clase abstracta, constructor primario y guard clauses

`Account` es `abstract`: define el estado común (`Number`, `Holder`, `Balance`) y obliga a las derivadas a implementar `MonthlyFee()`. `Balance` tiene `protected set`: solo la jerarquía lo modifica.

```csharp
public abstract class Account(string number, Holder holder)
{
    public decimal Balance { get; protected set; }
    public abstract decimal MonthlyFee();
}
```

Descomenta `PASO 2`, `TIPOS B` y las dos líneas del `using`/cultura del inicio. Prueba `new Account("X", holder)`: no compila, una clase abstracta no se instancia.

## Paso 3: derivar y redefinir una regla de negocio

`CheckingAccount` redefine `Withdraw` para permitir descubierto y lanza su propia excepción de dominio (semana 03) cuando ni con el descubierto llega.

```csharp
public override void Withdraw(decimal amount)
{
    decimal available = Balance + Overdraft;
    if (amount > available) throw new InsufficientFundsException(Number, amount - available);
    Balance -= amount;
}
```

Descomenta `PASO 3` y `TIPOS C`. Observa que el saldo puede quedar **negativo**: es la regla de la cuenta corriente, no un bug.

## Paso 4: polimorfismo en una colección

El array es de `Account`, pero cada elemento responde con **su** `MonthlyFee()`. Ese bucle seguirá funcionando con tipos de cuenta que aún no existen.

```csharp
Account[] accounts = [savings, checking];
foreach (Account account in accounts)
    Console.WriteLine(account.MonthlyFee());
```

Descomenta `PASO 4`. Añade una tercera cuenta derivada y comprueba que el bucle no cambia.

## Paso 5: `override` con `base.X()`

Redefinir no siempre es sustituir: aquí cada derivada **extiende** la descripción de la base.

```csharp
public override string Describe() => $"{base.Describe()} · ahorro al {Rate:P0}";
```

Descomenta `PASO 5`. Quita el `base.Describe()` de una derivada y mira qué información desaparece.

## Paso 6: `Equals`, `GetHashCode` y la identidad del dominio

Dos objetos distintos con el mismo número de cuenta son **el mismo negocio**. Al redefinir `Equals` hay que redefinir `GetHashCode` con el mismo criterio, o el `HashSet` guardará duplicados.

```csharp
public override bool Equals(object? obj) => obj is Account other && Number == other.Number;
public override int GetHashCode() => Number.GetHashCode(StringComparison.Ordinal);
```

Descomenta `PASO 6`. Comenta solo `GetHashCode` y mira cómo el `HashSet` pasa a tener 2 elementos: el contrato roto en acción.

## Paso 7: `is`, `GetType()` y `new` frente a `override`

```csharp
if (account is SavingsAccount s) Console.WriteLine(s.Rate);
Account asBase = checking;
asBase.Label();   // "corriente": override, decide el OBJETO
asBase.Tag();     // "base": new, decide el tipo de la VARIABLE
```

Descomenta `PASO 7`. `Tag()` lleva `new` explícito: escribir esa palabra es exactamente lo que silencia el warning CS0108. Quítala y el compilador vuelve a avisarte de que estás ocultando un miembro heredado.

## ✅ Verificación

```
Ejercicio 01 — cuentas bancarias. Sigue los pasos del README.
titular: [Ada Lovelace] · doc X-1234
misma referencia: True · notas vistas por holder: cliente VIP
ES-001: saldo 1,000.00
depósito rechazado: amount
ES-002: saldo -150.00 (descubierto 200.00)
retirada rechazada: faltan 50.00

ES-001   comisión mensual: 0.00
ES-002   comisión mensual: 3.50

ES-001 de Ada Lovelace: 1,000.00 · ahorro al 2 %
ES-002 de Ada Lovelace: -150.00 · descubierto 200.00

savings == copy (referencia): False
savings.Equals(copy) (por número): True
mismo hash: True
en un HashSet caben 1 (el número de cuenta es la identidad)

ES-001: interés anual 2 %
ES-002: descubierto 200.00
GetType() real: CheckingAccount
override Label (decide el objeto): corriente
new Tag oculto (decide la variable): base=base · derivada=derivada
```

`dotnet build -warnaserror` sin warnings.

## 🧠 Preguntas de reflexión

1. `Balance` tiene `protected set`. ¿Qué se rompería con `public set` y qué invariante protege ahora la clase?
2. Si mañana llega `BusinessAccount` con comisión por movimiento, ¿qué archivos tocas? ¿Y si el cálculo dependiera de tres ejes (tipo × canal × antigüedad)? (teoría 07)
3. Escribir `new` silencia el warning CS0108 sin arreglar nada. ¿Cómo detectarías este caso en una revisión de código y qué propondrías en su lugar?
