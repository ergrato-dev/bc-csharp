# Formateo y cultura

## 🎯 Objetivos

Al finalizar este archivo, comprenderás:

- Los formatos estándar (`N2`, `C`, `P`, `F`, `X`, `D`) y personalizados (`0.00`, `#,##0`)
- Cómo interpolar con alineación y formato: `{value,10:N2}`
- Qué es `CultureInfo`, cómo afecta a números y fechas, y cuándo usar `InvariantCulture`
- Cómo formatear y parsear fechas de forma reproducible

## 📋 Conceptos clave

### 1. Formatos numéricos estándar

```csharp
double n = 1234567.891;
n.ToString("N2");     // "1,234,567.89"  número con separadores, 2 decimales
n.ToString("F0");     // "1234568"        fijo, sin separadores
n.ToString("E2");     // "1.23E+006"      científico
(0.256).ToString("P1"); // "25.6 %"       porcentaje (multiplica por 100)
(255).ToString("X");  // "FF"             hexadecimal; "x2" → "ff" con 2 dígitos mínimo
(7).ToString("D3");   // "007"            entero con ceros a la izquierda
19.99m.ToString("C"); // "$19.99" o "19,99 €": depende de la cultura
```

El resultado exacto (coma o punto, símbolo de moneda) **depende de la cultura actual**. Los ejemplos de arriba asumen `en-US`.

### 2. Formatos personalizados

```csharp
1234.5.ToString("#,##0.00");     // "1,234.50"  # dígito opcional, 0 obligatorio
0.5.ToString("0.###");           // "0.5"       hasta 3 decimales sin ceros de relleno
(-5).ToString("+0;-0;zero");     // "-5"        secciones: positivo;negativo;cero
42.ToString("000000");           // "000042"
```

### 3. Interpolación con alineación y formato

```csharp
string name = "Teclado"; decimal price = 49.9m; int qty = 3;
Console.WriteLine($"{name,-12}|{qty,4}|{price,10:N2}|");
// "Teclado     |   3|     49.90|"
//  ,-12 alinea a la izquierda en 12; ,10 a la derecha en 10; :N2 formato
```

Sintaxis: `{expresión, alineación : formato}`. Negativo = izquierda. Ideal para tablas en consola. `string.Format("{0,-12}", name)` es la forma antigua equivalente.

### 4. `CultureInfo`: quién decide la coma

```csharp
using System.Globalization;

var es = new CultureInfo("es-ES");
var us = new CultureInfo("en-US");
1234.5.ToString("N1", es);       // "1.234,5"
1234.5.ToString("N1", us);       // "1,234.5"
1234.5.ToString("N1", CultureInfo.InvariantCulture);  // "1,234.5" (fija, similar a en-US)

CultureInfo.CurrentCulture;      // la del proceso: viene de LANG en Linux, del SO en Windows
```

Dos culturas importan: `CurrentCulture` (formatos, comparaciones) y `CurrentUICulture` (idioma de recursos). Cambiarlas en un hilo: `CultureInfo.CurrentCulture = us;`. En contenedores Docker sin `LANG` la cultura es **invariante** por defecto: tu app puede formatear distinto en local que en producción.

### 5. Regla de oro: Invariant para máquinas, Current para humanos

| Destino del texto | Cultura |
|-------------------|---------|
| Archivos, JSON, CSV, URLs, logs, base de datos | `InvariantCulture` |
| Pantalla, informes para personas | `CurrentCulture` (o la del usuario) |
| Parsear entrada del usuario | la misma que usaste para mostrarla |

```csharp
// escribir a fichero: siempre invariante
string line = string.Create(CultureInfo.InvariantCulture, $"{id},{amount:F2},{date:O}");

// leer de fichero: siempre invariante
decimal amount = decimal.Parse(parts[1], CultureInfo.InvariantCulture);
```

`string.Create(culture, $"...")` interpola con una cultura concreta sin `ToString` en cada hueco.

### 6. Fechas: `DateTime`, `DateOnly`, `DateTimeOffset`

```csharp
var now = DateTime.Now;                       // hora local, sin zona: ambigua
var utc = DateTime.UtcNow;                    // preferida para almacenar
var stamped = DateTimeOffset.Now;             // hora + desfase: sin ambigüedad
var day = DateOnly.FromDateTime(now);         // solo fecha; también TimeOnly

utc.ToString("O");                            // "2026-09-13T10:30:00.0000000Z" ISO 8601 round-trip
utc.ToString("yyyy-MM-dd HH:mm");             // "2026-09-13 10:30"  (MM mes, mm minutos, HH 24 h)
now.ToString("d", es);                        // "13/09/2026"; con us: "9/13/2026"
DateTime.ParseExact("13/09/2026", "dd/MM/yyyy", CultureInfo.InvariantCulture);
DateTime.TryParse("2026-09-13", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var parsed);
```

Regla: almacena y transmite en UTC con formato `"O"`; convierte a local solo al mostrar. `TimeSpan` para duraciones: `(end - start).TotalSeconds`.

### 7. `IFormattable` y tus propios tipos

Cualquier tipo puede participar en `{x:formato}` implementando `IFormattable` (o `ISpanFormattable` para evitar asignaciones). Lo verás al crear value objects en la semana 05.

## 🔬 Bajo el capó

`ToString("N2")` es `Number.FormatDouble` en la BCL: convierte el `double` a dígitos decimales con el algoritmo Ryu/Grisu (exacto y rápido), luego aplica `NumberFormatInfo` de la cultura (separadores, símbolos). Cada cultura carga sus datos de **ICU** (International Components for Unicode) en Linux; si `libicu` no está instalada, .NET arranca en modo invariante (`DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1`), lo que explica diferencias entre tu máquina y un contenedor `alpine`. La interpolación con `{price,10:N2}` llama a `TryFormat` sobre un `Span<char>` del handler: cero strings intermedios. `DateTime` guarda un `ulong` con ticks (100 ns) y 2 bits de `Kind` (Utc/Local/Unspecified); `DateTimeOffset` añade un `short` con los minutos de desfase.

## ⚠️ Errores comunes

- Escribir `amount.ToString()` a un CSV y leerlo en otra máquina con otra cultura.
- `"MM"` vs `"mm"`: mes vs minutos. `"hh"` es 12 h; `"HH"` es 24 h.
- `DateTime.Now` para timestamps que se comparan entre servidores: usa `UtcNow`.
- Asumir que `"C"` muestra `$`: depende de la cultura.
- Comparar fechas parseadas con `Kind` distinto (`Local` vs `Utc`): resultados inesperados.

## 📚 Recursos adicionales

- [Cadenas de formato numérico estándar](https://learn.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings)
- [Cadenas de formato numérico personalizado](https://learn.microsoft.com/dotnet/standard/base-types/custom-numeric-format-strings)
- [Cadenas de formato de fecha y hora](https://learn.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings)
- [Globalización y ICU en .NET](https://learn.microsoft.com/dotnet/core/extensions/globalization-icu)

## ✅ Checklist de verificación

- [ ] Formateo un `decimal` con 2 decimales y separadores de miles en cualquier cultura
- [ ] Alineo columnas en consola con `{x,-12}` y `{x,10:N2}`
- [ ] Explico la regla "Invariant para máquinas, Current para humanos" con un ejemplo
- [ ] Serializo una fecha en UTC con `"O"` y la parseo de vuelta
- [ ] Sé por qué un contenedor puede formatear distinto que mi máquina
