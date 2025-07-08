# Patrón de Diseño: Blackboard Pattern

## Descripción

El **Blackboard Pattern** es un patrón de diseño arquitectónico que permite resolver problemas complejos mediante la colaboración de múltiples fuentes de conocimiento especializadas. En este patrón, las fuentes de conocimiento trabajan de forma independiente sobre una "pizarra" (blackboard) compartida, contribuyendo con su experiencia específica para resolver el problema paso a paso.

## Características Principales

- **Pizarra compartida**: Área de memoria común donde se almacena el estado del problema
- **Fuentes de conocimiento**: Módulos especializados que contribuyen con su experiencia
- **Controlador**: Coordina el flujo de trabajo entre las fuentes de conocimiento
- **Resolución incremental**: El problema se resuelve paso a paso mediante contribuciones

## Componentes de la Implementación

### 1. Blackboard (Pizarra)
```python
class Blackboard:
    def __init__(self):
        self.data = {}        # Almacena datos del problema
        self.status = "incomplete"  # Estado de resolución
```

**Responsabilidades:**
- Almacenar datos compartidos entre fuentes de conocimiento
- Mantener el estado de resolución del problema
- Servir como punto central de comunicación

### 2. KnowledgeSource (Fuente de Conocimiento)
```python
class KnowledgeSource:
    def __init__(self, name):
        self.name = name

    def can_contribute(self, blackboard):
        """Decidir si puede contribuir en base a la pizarra"""
        raise NotImplementedError

    def contribute(self, blackboard):
        """Hacer su contribución"""
        raise NotImplementedError
```

**Responsabilidades:**
- Evaluar si puede contribuir al estado actual
- Realizar contribuciones específicas al problema
- Mantener su área de especialización

### 3. Fuentes de Conocimiento Específicas

#### InputSource
- **Propósito**: Proporcionar datos de entrada
- **Condición**: Solo contribuye si no hay datos de entrada
- **Contribución**: Agrega pares de números para procesar

#### SumSource
- **Propósito**: Realizar operaciones matemáticas
- **Condición**: Solo contribuye si hay datos de entrada pero no hay resultado
- **Contribución**: Calcula la suma de los números

#### OutputSource
- **Propósito**: Mostrar resultados finales
- **Condición**: Solo contribuye si hay resultado pero el problema no está completo
- **Contribución**: Muestra el resultado y marca el problema como resuelto

### 4. Controller (Controlador)
```python
class Controller:
    def __init__(self, blackboard, sources):
        self.blackboard = blackboard
        self.sources = sources

    def run(self):
        while self.blackboard.status != 'complete':
            for source in self.sources:
                if source.can_contribute(self.blackboard):
                    source.contribute(self.blackboard)
```

**Responsabilidades:**
- Coordinar el flujo de trabajo
- Iterar sobre las fuentes de conocimiento
- Detener el proceso cuando el problema esté resuelto

## Diagrama de Arquitectura

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   InputSource   │    │   SumSource     │    │  OutputSource   │
│                 │    │                 │    │                 │
│ - Proporciona   │    │ - Calcula       │    │ - Muestra       │
│   datos         │    │   sumas         │    │   resultados    │
└─────────────────┘    └─────────────────┘    └─────────────────┘
         │                       │                       │
         └───────────────────────┼───────────────────────┘
                                 │
                    ┌─────────────────┐
                    │   Controller    │
                    │                 │
                    │ - Coordina      │
                    │   flujo         │
                    └─────────────────┘
                                 │
                    ┌─────────────────┐
                    │   Blackboard    │
                    │                 │
                    │ - data: {}      │
                    │ - status: str   │
                    └─────────────────┘
```

## Flujo de Ejecución

1. **Inicialización**: Se crea la pizarra y las fuentes de conocimiento
2. **InputSource**: Agrega datos de entrada (9, 6)
3. **SumSource**: Calcula la suma (9 + 6 = 15)
4. **OutputSource**: Muestra el resultado y marca como completo
5. **Finalización**: El controlador detecta que el problema está resuelto

## Ejemplo de Uso

```python
# Crear componentes
blackboard = Blackboard()
sources = [
    InputSource("Entrada"),
    SumSource("Suma"),
    OutputSource("Salida")
]

controller = Controller(blackboard, sources)
controller.run()
```

### Salida Esperada
```
[Entrada] puso entrada: (9, 6)
[Suma] calculó la suma: 15
[Salida] Resultado final: 15
```

## Ventajas del Patrón

1. **Modularidad**: Cada fuente de conocimiento es independiente
2. **Extensibilidad**: Fácil agregar nuevas fuentes de conocimiento
3. **Flexibilidad**: Las fuentes deciden cuándo contribuir
4. **Reutilización**: Las fuentes pueden reutilizarse en diferentes contextos
5. **Mantenibilidad**: Cambios en una fuente no afectan a las demás

## Casos de Uso Apropiados

- **Sistemas de reconocimiento de voz**: Diferentes algoritmos contribuyen al reconocimiento
- **Diagnóstico médico**: Múltiples especialistas evalúan síntomas
- **Análisis de datos**: Diferentes técnicas procesan información
- **Sistemas expertos**: Múltiples reglas contribuyen a la decisión
- **Procesamiento de lenguaje natural**: Diferentes módulos analizan texto

## Consideraciones de Implementación

### Cuándo Usar Blackboard Pattern
- ✅ Problemas complejos que requieren múltiples perspectivas
- ✅ Sistemas donde las contribuciones son independientes
- ✅ Cuando se necesita flexibilidad en el orden de procesamiento

### Cuándo NO Usar
- ❌ Problemas simples con flujo lineal
- ❌ Sistemas con dependencias estrictas entre componentes
- ❌ Cuando se necesita control total sobre el flujo de ejecución

## Extensiones Posibles

1. **Prioridades**: Asignar prioridades a las fuentes de conocimiento
2. **Paralelismo**: Permitir contribuciones concurrentes
3. **Persistencia**: Guardar el estado de la pizarra
4. **Logging**: Registrar todas las contribuciones
5. **Validación**: Verificar la calidad de las contribuciones

## Conclusión

Esta implementación demuestra los conceptos fundamentales del Blackboard Pattern de manera clara y educativa. El patrón es especialmente útil para problemas que requieren la colaboración de múltiples especialistas o algoritmos, proporcionando una arquitectura flexible y extensible.

## 📚 Referencias

- [Medium - Blackboard Architecture](https://justgokus.medium.com/what-is-the-blackboard-design-pattern-c834227dc617)