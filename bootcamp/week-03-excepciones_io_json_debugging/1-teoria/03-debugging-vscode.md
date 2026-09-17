# Depuración en VS Code

## 🎯 Objetivos

Al finalizar este archivo, comprenderás:

- Cómo configurar `launch.json` para depurar un proyecto de consola .NET
- Los tipos de breakpoint que existen y cuándo cada uno ahorra horas
- Cómo leer la pila de llamadas, inspeccionar variables y usar la ventana de Watch
- Cómo detener el depurador en el punto exacto donde se lanza una excepción
- Qué aportan `Debug.Assert`, `Debugger.Break()` y los logs frente al depurador

## 📋 Conceptos clave

### 1. Requisitos

Extensión **C# Dev Kit** (o **C#** de Microsoft, que trae el depurador `coreclr`). Con el proyecto abierto, `F5` propone generar la configuración; si prefieres escribirla a mano, `.vscode/launch.json`:

```jsonc
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": ".NET Console",
      "type": "coreclr",
      "request": "launch",
      "preLaunchTask": "build",
      "program": "${workspaceFolder}/bin/Debug/net10.0/Exercise.dll",
      "args": [],
      "cwd": "${workspaceFolder}",
      "console": "integratedTerminal",   // obligatorio si el programa usa Console.ReadLine
      "stopAtEntry": false
    }
  ]
}
```

`console: "integratedTerminal"` es el detalle que más tiempo hace perder: con el valor por defecto (`internalConsole`) la entrada por teclado no funciona y el programa parece colgado.

> `launch.json` está en `.gitignore` del bootcamp (salvo `Properties/launchSettings.json.example`): es configuración de tu máquina.

### 2. Breakpoints

| Tipo | Cómo | Para qué |
|------|------|----------|
| Normal | clic en el margen / `F9` | detener siempre en esa línea |
| **Condicional** | clic derecho → *Expression* | `i == 9997` o `item.Key == "KB-01"`: detiene solo en el caso malo |
| **Hit count** | clic derecho → *Hit Count* | `>500`: detener a partir de la iteración 500 |
| **Logpoint** | clic derecho → *Log Message* | imprime `{quantity}` sin detener ni tocar el código |
| **Function** | panel Breakpoints → `+` | detener en un método por nombre, sin abrir el fichero |

Un breakpoint condicional dentro de un bucle de 10 000 iteraciones sustituye a 10 000 pulsaciones de `F5`.

### 3. Controlar la ejecución

| Tecla | Acción | Significado |
|-------|--------|-------------|
| `F5` | Continue | hasta el siguiente breakpoint |
| `F10` | Step Over | ejecuta la línea, sin entrar en los métodos |
| `F11` | Step Into | entra en el método llamado |
| `Shift+F11` | Step Out | termina el método actual y vuelve al llamador |
| `Ctrl+Shift+F5` | Restart | reinicia la sesión |

### 4. Inspeccionar el estado

- **Variables**: locals, parámetros y `this`. Editables en caliente: cambia un valor y sigue ejecutando para probar el otro camino.
- **Watch**: expresiones fijas (`catalog.Count`, `words[^1]`, `File.Exists(path)`). Se reevalúan en cada parada; cuidado con expresiones con efectos secundarios.
- **Call Stack**: la pila viva. Al hacer clic en un frame anterior ves **sus** variables locales — la forma más rápida de saber quién pasó el argumento malo.
- **Debug Console**: evalúa cualquier expresión C# en el contexto de la parada, incluso llamadas a métodos.

### 5. Detenerse donde se lanza la excepción

En el panel **Breakpoints**, casillas *All Exceptions* y *User-Unhandled Exceptions*. Marcar **User-Unhandled** es lo razonable por defecto: el depurador se detiene en la línea del `throw` y ves los locales que causaron el problema, no el `catch` tres frames más arriba donde ya se perdió todo.

Si la excepción está siendo capturada por un `catch (Exception) { }` ajeno, marca *All Exceptions* temporalmente y filtra por tipo.

### 6. Ayudas desde el código

```csharp
using System.Diagnostics;

Debug.Assert(quantity >= 0, $"Cantidad negativa: {quantity}");  // solo en Debug; aborta si falla
Debug.WriteLine($"Procesando {item.Key}");                      // solo en Debug; a la Debug Console
Trace.WriteLine("Esto sí sale en Release");                     // Trace se conserva en Release
if (Debugger.IsAttached) Debugger.Break();                      // parada programática
```

`Debug.Assert` y `Debug.WriteLine` llevan `[Conditional("DEBUG")]`: **el compilador elimina la llamada completa en Release**, argumentos incluidos. Cero coste en producción, cero necesidad de comentarlos luego.

### 7. Cuando el depurador no basta

El depurador paraliza el tiempo, y a veces el bug vive en el tiempo (condiciones de carrera, timeouts, procesos remotos). Ahí se usan logs estructurados, `dotnet-trace`, `dotnet-counters` y `dotnet-dump` — herramientas de las semanas 13 y 25. Para esta semana: breakpoint condicional + Call Stack resuelve casi todo.

## 🔬 Bajo el capó

El depurador se comunica con VS Code por el **Debug Adapter Protocol**; al otro lado, `vsdbg` se engancha al proceso .NET usando la API de depuración del CLR (ICorDebug). En **Debug** el compilador emite IL sin optimizar y un mapa de secuencias en el **portable PDB** que relaciona cada offset IL con fichero y línea: por eso puedes poner un breakpoint en una línea concreta y ver nombres de variables locales.

En **Release** el JIT inlinea métodos, reordena instrucciones y elimina locales, así que los pasos "saltan" y algunas variables aparecen como *optimized away*. Por eso se depura en Debug y se mide rendimiento en Release (semana 13): son configuraciones con propósitos opuestos. `<DebugType>portable</DebugType>` es el valor por defecto de .NET y genera el `.pdb` junto al `.dll`.

## ⚠️ Errores comunes

- `console: "internalConsole"` con `Console.ReadLine()`: el programa parece congelado.
- Depurar la build equivocada (`program` apuntando a `Release/` o a otro `net`).
- Poner el breakpoint en el `catch` en vez de activar *User-Unhandled Exceptions*.
- Llenar el código de `Console.WriteLine` de depuración y comitearlos: usa logpoints o `Debug.WriteLine`.
- Concluir "el bug desapareció" al cambiar a Release: normalmente es un problema de tiempos o de inicialización.

## 📚 Recursos adicionales

- [Depurar .NET en VS Code](https://code.visualstudio.com/docs/csharp/debugging)
- [Configuración de `launch.json` para .NET](https://github.com/dotnet/vscode-csharp/blob/main/debugger-launchjson.md)
- [`Debug` y `Trace`](https://learn.microsoft.com/dotnet/api/system.diagnostics.debug)
- [Atributo `Conditional`](https://learn.microsoft.com/dotnet/csharp/language-reference/attributes/general#conditional-attribute)

## ✅ Checklist de verificación

- [ ] Depuro un proyecto de consola con entrada por teclado desde VS Code
- [ ] Uso breakpoints condicionales y logpoints en vez de `F5` repetido
- [ ] Leo la Call Stack y cambio de frame para ver los locales del llamador
- [ ] Detengo la ejecución en el `throw` con *User-Unhandled Exceptions*
- [ ] Sé por qué `Debug.Assert` no cuesta nada en Release
