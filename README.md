# 🏗️ Software Architecture Patterns

Este repositorio explora diversos **patrones de arquitectura de software**, implementados de forma práctica para facilitar el estudio y comparación entre ellos.

Cada rama del repositorio implementa un patrón arquitectónico diferente, mostrando cómo cambia el diseño, la organización del código y el flujo de datos según el enfoque adoptado.

---

## 🎯 Patrones arquitectónicos incluidos

| Rama                      | Patrón arquitectónico    | Descripción breve                                  |
|----------------------------|--------------------------|----------------------------------------------------|
| `layered-pattern`          | Layered (por capas)     | Organización en capas separadas (presentación, lógica, datos). |
| `client-server-pattern`    | Client-Server           | Separación entre cliente que consume servicios y servidor que los provee. |
| `master-slave-pattern`     | Master-Slave            | Un maestro distribuye trabajo a uno o varios esclavos. |
| `event-bus-pattern`        | Event Bus               | Comunicación mediante eventos publicados en un bus. |
| `pipe-filter-pattern`      | Pipe and Filter         | Flujo de procesamiento en etapas independientes encadenadas. |
| `broker-pattern`           | Broker                  | Coordinador que facilita la interacción entre componentes distribuidos. |
| `peer-to-peer-pattern`     | Peer-to-Peer (P2P)      | Todos los nodos actúan como cliente y servidor entre sí. |
| `mvc-pattern`              | Model-View-Controller   | Separación en modelo, vista y controlador para interfaces interactivas. |
| `interpreter-pattern`      | Interpreter             | Define gramáticas e interpreta sentencias en tiempo de ejecución. |
| `blackboard-pattern`       | Blackboard              | Solución colaborativa con múltiples agentes que actualizan un espacio común. |

---

## 🚀 Cómo usar este repositorio

1. Clona el proyecto:
    ```bash
    git clone https://github.com/fernando061/software-architecture-styles.git
    cd software-architecture-styles
    ```

2. Cambia a la rama del patrón que deseas explorar:
    ```bash
    git checkout layered-pattern
    ```

3. Cada rama contiene su propio `README.md` con detalles:
   - 📚 Explicación del patrón
   - ⚙️ Instrucciones de ejecución
   - 📝 Ejemplo de implementación

---

## 🎓 Objetivo del proyecto

✅ Mostrar cómo varían las soluciones arquitectónicas frente a diferentes problemáticas.  
✅ Servir como referencia didáctica para estudiantes y desarrolladores.  
✅ Ayudar a entender en qué contexto aplicar cada patrón.

---

## ✍️ Autor

- **Nombre:** [Fernando Rojo](https://github.com/fernando061)
- **Contacto:** rojofernando296@gmail.com

---

## 📝 Licencia

Este proyecto está licenciado bajo MIT - consulta el archivo [LICENSE](LICENSE) para más detalles.
