# Assets — Semana 04

| Archivo | Muestra | Vinculado desde |
|---------|---------|-----------------|
| `01-objeto-en-heap.svg` | Pila con dos referencias al mismo objeto; encabezado (sync block + method table ptr) y campos en el heap | `1-teoria/01-clases-y-objetos.md` |
| `02-ciclo-vida-objeto.svg` | Orden exacto: `newobj` → campos de la derivada → constructor base → cuerpo derivada → uso → GC; aviso de virtual en constructor | `1-teoria/04-herencia.md` |
| `03-constructor-primario-expandido.svg` | Lo que escribes frente a lo que emite el compilador: campos ocultos por parámetro capturado y dónde validar | `1-teoria/02-propiedades-y-constructores.md` |
| `04-jerarquia-y-vtable.svg` | Jerarquía `object` → `Account` → `Savings`/`Checking` y la method table con el slot redefinido | `1-teoria/04-herencia.md` |
| `05-dispatch-virtual.svg` | Resolución de `s.Describe()` por tipo real; `call` vs `callvirt` vs despacho por interfaz; `new` oculta | `1-teoria/05-polimorfismo-abstract-sealed.md` |
| `06-interfaz-contrato.svg` | Un contrato, tres implementaciones (memoria, JSON, fake); tabla interfaz vs clase abstracta; DIM | `1-teoria/06-interfaces.md` |

Tema dark `#0d1117`, acento `#512BD4`/`#7a5cf0`, sin degradés, sans-serif, `<title>` + `<desc>`.
