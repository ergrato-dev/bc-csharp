// Ejercicio 01 — Cuentas bancarias
// El programa compila y ejecuta desde el paso 0. Descomenta cada PASO en orden.
// Los TIPOS van al final del fichero: en top-level statements toda declaración de tipo
// se escribe DESPUÉS de la última instrucción (error CS8803 si no).

// Desde el paso 2 hace falta este using y fijar la cultura para que la salida no dependa de tu máquina:
// using System.Globalization;
// CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

Console.WriteLine("Ejercicio 01 — cuentas bancarias. Sigue los pasos del README.");

// ============================================
// PASO 1: Clase, required, init y la palabra clave field
// ============================================
// required obliga a dar el valor al construir; init lo congela después.
// field (C# 14) da acceso al campo de respaldo para validar sin declararlo a mano.
// Asignar una variable de clase copia la REFERENCIA: las dos ven el mismo objeto.
// Descomenta también el bloque TIPOS A del final.
// Descomenta las siguientes líneas:
// var holder = new Holder { Name = "  Ada Lovelace  ", DocumentId = "X-1234" };
// Console.WriteLine($"titular: [{holder.Name}] · doc {holder.DocumentId}");
// Holder same = holder;
// same.Notes = "cliente VIP";
// Console.WriteLine($"misma referencia: {ReferenceEquals(holder, same)} · notas vistas por holder: {holder.Notes}");

// ============================================
// PASO 2: Clase abstracta, constructor primario y guard clauses
// ============================================
// Account es abstract: no se instancia. SavingsAccount pasa sus datos con : Account(...).
// Balance tiene protected set: solo la jerarquía lo cambia.
// Descomenta también el bloque TIPOS B y el using del inicio.
// Descomenta las siguientes líneas:
// var savings = new SavingsAccount("ES-001", holder, rate: 0.02m);
// savings.Deposit(1000m);
// Console.WriteLine($"{savings.Number}: saldo {savings.Balance:N2}");
// try
// {
//     savings.Deposit(-5m);
// }
// catch (ArgumentOutOfRangeException ex)
// {
//     Console.WriteLine($"depósito rechazado: {ex.ParamName}");
// }

// ============================================
// PASO 3: Derivar y redefinir una regla de negocio
// ============================================
// CheckingAccount redefine Withdraw para admitir descubierto y lanza su propia excepción.
// Descomenta también el bloque TIPOS C.
// Descomenta las siguientes líneas:
// var checking = new CheckingAccount("ES-002", holder, overdraft: 200m);
// checking.Deposit(100m);
// checking.Withdraw(250m);                       // permitido: usa el descubierto
// Console.WriteLine($"{checking.Number}: saldo {checking.Balance:N2} (descubierto {checking.Overdraft:N2})");
// try
// {
//     checking.Withdraw(100m);
// }
// catch (InsufficientFundsException ex)
// {
//     Console.WriteLine($"retirada rechazada: faltan {ex.Missing:N2}");
// }

// ============================================
// PASO 4: Polimorfismo: un bucle, dos comportamientos
// ============================================
// El array es de Account, pero cada objeto responde con SU MonthlyFee(): despacho dinámico.
// Descomenta las siguientes líneas:
// Account[] accounts = [savings, checking];
// Console.WriteLine();
// foreach (Account account in accounts)
//     Console.WriteLine($"{account.Number,-8} comisión mensual: {account.MonthlyFee():N2}");

// ============================================
// PASO 5: override con base.X(): extender en vez de sustituir
// ============================================
// Describe() de cada derivada llama a base.Describe() y le añade lo suyo.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// foreach (Account account in accounts)
//     Console.WriteLine(account.Describe());

// ============================================
// PASO 6: Equals, GetHashCode y la identidad del objeto
// ============================================
// Dos objetos distintos con el mismo número de cuenta son iguales para el negocio.
// Equals y GetHashCode van SIEMPRE juntos: el HashSet lo demuestra.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// var copy = new SavingsAccount("ES-001", holder, rate: 0.05m);
// Console.WriteLine($"savings == copy (referencia): {ReferenceEquals(savings, copy)}");
// Console.WriteLine($"savings.Equals(copy) (por número): {savings.Equals(copy)}");
// Console.WriteLine($"mismo hash: {savings.GetHashCode() == copy.GetHashCode()}");
// var registry = new HashSet<Account> { savings, copy };
// Console.WriteLine($"en un HashSet caben {registry.Count} (el número de cuenta es la identidad)");

// ============================================
// PASO 7: is con patrón, GetType() y new frente a override
// ============================================
// is comprueba y asigna en un paso. GetType() devuelve siempre el tipo real.
// Label() es override: decide el objeto. Tag() usa new: decide el tipo de la variable.
// Descomenta las siguientes líneas:
// Console.WriteLine();
// foreach (Account account in accounts)
// {
//     if (account is SavingsAccount s)
//         Console.WriteLine($"{s.Number}: interés anual {s.Rate:P0}");
//     else if (account is CheckingAccount c)
//         Console.WriteLine($"{c.Number}: descubierto {c.Overdraft:N2}");
// }
//
// Account asBase = checking;
// Console.WriteLine($"GetType() real: {asBase.GetType().Name}");
// Console.WriteLine($"override Label (decide el objeto): {asBase.Label()}");
// Console.WriteLine($"new Tag oculto (decide la variable): base={asBase.Tag()} · derivada={checking.Tag()}");

// ============================================
// TIPOS A: Holder (paso 1)
// ============================================
// Propiedades required/init y un accesor con field.
// Descomenta las siguientes líneas:
// public sealed class Holder
// {
//     public required string Name
//     {
//         get => field;
//         set => field = value.Trim();          // C# 14: campo de respaldo sin declararlo
//     }
//
//     public required string DocumentId { get; init; }
//     public string Notes { get; set; } = "";
// }

// ============================================
// TIPOS B: Account, InsufficientFundsException y SavingsAccount (paso 2)
// ============================================
// Clase base abstracta con estado común, un método abstracto y dos virtuales.
// Descomenta las siguientes líneas:
// public abstract class Account(string number, Holder holder)
// {
//     public string Number { get; } = number;
//     public Holder Holder { get; } = holder;
//     public decimal Balance { get; protected set; }
//
//     public void Deposit(decimal amount)
//     {
//         ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
//         Balance += amount;
//     }
//
//     public virtual void Withdraw(decimal amount)
//     {
//         ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
//         if (amount > Balance) throw new InsufficientFundsException(Number, amount - Balance);
//         Balance -= amount;
//     }
//
//     public abstract decimal MonthlyFee();                     // cada tipo la calcula a su manera
//
//     public virtual string Describe() => $"{Number} de {Holder.Name}: {Balance:N2}";
//
//     public virtual string Label() => "cuenta";
//     public string Tag() => "base";
//
//     public override string ToString() => Describe();
//     public override bool Equals(object? obj) => obj is Account other && Number == other.Number;
//     public override int GetHashCode() => Number.GetHashCode(StringComparison.Ordinal);
// }
//
// public sealed class SavingsAccount(string number, Holder holder, decimal rate) : Account(number, holder)
// {
//     public decimal Rate { get; } = rate;
//
//     public override decimal MonthlyFee() => 0m;               // sin comisión
//
//     public override string Describe() => $"{base.Describe()} · ahorro al {Rate:P0}";
//
//     public override string Label() => "ahorro";
// }
//
// public sealed class InsufficientFundsException(string number, decimal missing)
//     : InvalidOperationException($"Saldo insuficiente en {number}: faltan {missing:N2}.")
// {
//     public decimal Missing { get; } = missing;
// }

// ============================================
// TIPOS C: CheckingAccount (paso 3)
// ============================================
// Derivada que redefine Withdraw, MonthlyFee, Describe y Label; Tag() usa new a propósito.
// Descomenta las siguientes líneas:
// public sealed class CheckingAccount(string number, Holder holder, decimal overdraft) : Account(number, holder)
// {
//     public decimal Overdraft { get; } = overdraft;
//
//     public override void Withdraw(decimal amount)
//     {
//         ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
//         decimal available = Balance + Overdraft;
//         if (amount > available) throw new InsufficientFundsException(Number, amount - available);
//         Balance -= amount;
//     }
//
//     public override decimal MonthlyFee() => 3.50m;
//
//     public override string Describe() => $"{base.Describe()} · descubierto {Overdraft:N2}";
//
//     public override string Label() => "corriente";
//
//     public new string Tag() => "derivada";                    // ⚠️ oculta, no redefine
// }
