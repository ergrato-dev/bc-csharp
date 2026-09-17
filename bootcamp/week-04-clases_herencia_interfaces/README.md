# Semana 04 — Clases, herencia e interfaces

> Clases, propiedades (`init`, `required`, `field`), constructores primarios, `static`, `partial`, herencia, `virtual`/`override`/`abstract`/`sealed`, `object` (`Equals`/`GetHashCode`/`ToString`), interfaces y miembros por defecto, composición vs herencia.

**Fase 2: POO y diseño** · Dedicación: 10 horas

## 🎯 Objetivos de aprendizaje

Al finalizar esta semana, el estudiante será capaz de:

- Explicar qué guarda una variable de clase, qué copia una asignación y cómo se organiza un objeto en el heap
- Encapsular estado con propiedades `get`/`set`/`init`, `required` y la palabra clave `field` (C# 14), validando en el constructor
- Describir el orden exacto de inicialización de una instancia y por qué no se llama a un método `virtual` desde un constructor
- Elegir entre `const` y `static readonly`, usar `partial` para convivir con código generado y organizar archivos y namespaces
- Construir jerarquías con `base(...)`, `protected` y `sealed`, y distinguir `override` de `new` por sus efectos observables
- Aplicar polimorfismo con `abstract`/`virtual`, y redefinir `ToString`, `Equals` y `GetHashCode` respetando su contrato
- Diseñar interfaces (implícitas, explícitas y con miembros por defecto) e implementar `IEquatable<T>`, `IComparable<T>` e `IDisposable`
- Refactorizar una jerarquía de variantes en colaboradores inyectados, reconociendo la clase base frágil y las violaciones de Liskov

## 📚 Requisitos previos

- Semana 03 completada
- .NET 10 SDK instalado (`dotnet --version`)

## 🗂️ Estructura de la semana

```
week-04-clases_herencia_interfaces/
├── 0-assets/        # 6 diagramas SVG
├── 1-teoria/        # 7 archivos
├── 2-practicas/     # 2 ejercicios guiados (patrón uncomment)
├── 3-proyecto/      # Proyecto semanal (TODOs, dominio único)
├── 4-recursos/      # ebooks-free · videografia · webgrafia
└── 5-glosario/      # Términos clave A-Z
```

## 📝 Contenidos

### Teoría

| Archivo | Tema | Duración |
|---------|------|:--------:|
| [01-clases-y-objetos.md](1-teoria/01-clases-y-objetos.md) | Clase vs objeto, tipos por referencia, heap y encabezado, `null`, accesibilidad, `object` | 30 min |
| [02-propiedades-y-constructores.md](1-teoria/02-propiedades-y-constructores.md) | Propiedades, `init`, `required`, `field` (C# 14), encadenamiento y constructor primario | 30 min |
| [03-static-partial-y-organizacion.md](1-teoria/03-static-partial-y-organizacion.md) | `static`, `const` vs `static readonly`, `.cctor`, `partial`, `file`, namespaces y `global using` | 30 min |
| [04-herencia.md](1-teoria/04-herencia.md) | `base(...)`, orden de inicialización, `protected`, upcast/downcast, `new` vs `override` | 30 min |
| [05-polimorfismo-abstract-sealed.md](1-teoria/05-polimorfismo-abstract-sealed.md) | Despacho dinámico, `abstract`/`virtual`/`sealed`, `Equals`/`GetHashCode`, Template Method | 30 min |
| [06-interfaces.md](1-teoria/06-interfaces.md) | Implícita vs explícita, miembros por defecto, interfaces de la BCL, programar contra el contrato | 30 min |
| [07-composicion-vs-herencia.md](1-teoria/07-composicion-vs-herencia.md) | Clase base frágil, explosión de subclases, Liskov, refactor a estrategia y decorador | 30 min |

### Prácticas

| Ejercicio | Concepto | Duración |
|-----------|----------|:--------:|
| [ejercicio-01-cuentas-bancarias](2-practicas/ejercicio-01-cuentas-bancarias/README.md) | `required`/`init`/`field`, clase `abstract`, `base(...)`, `protected set`, polimorfismo, `Equals`/`GetHashCode`, `new` vs `override` | 90 min |
| [ejercicio-02-figuras-polimorfismo](2-practicas/ejercicio-02-figuras-polimorfismo/README.md) | `abstract`, `IComparable<T>`, miembros por defecto, implementación explícita, estrategia inyectada y decorador | 90 min |

### Proyecto

[3-proyecto/README.md](3-proyecto/README.md) — Modelo de dominio del alumno: base abstracta con invariantes, tres derivadas `sealed` con reglas distintas, capacidades opcionales como interfaces (`IReservable` + una propia), repositorio tras contrato, y dos políticas de precio con decorador intercambiables sin tocar el servicio.

## ⏱️ Distribución del tiempo (10 horas)

| Actividad | Tiempo |
|-----------|-------:|
| Teoría (7 archivos) | 3.5 h |
| Ejercicios (2) | 3.0 h |
| Proyecto semanal | 3.0 h |
| Glosario, recursos y revisión | 0.5 h |
| **Total** | **10 h** |

## 📌 Entregables

1. ✅ Ejercicios descomentados, compilando sin warnings y ejecutando
2. ✅ Proyecto adaptado al dominio asignado
3. ✅ README del proyecto con descripción de la implementación

## 🔗 Navegación

| Anterior | Actual | Siguiente |
|----------|--------|-----------|
| [← Semana 03: Excepciones, I/O, JSON y debugging](../week-03-excepciones_io_json_debugging/README.md) | **Semana 04: Clases, herencia e interfaces** | [Semana 05: Structs, records, enums y genéricos →](../week-05-structs_records_enums_genericos/README.md) |
