class Blackboard:
    def __init__(self):
        self.data = {}
        self.status = "incomplete"

class KnowledgeSource:
    def __init__(self, name):
        self.name = name

    def can_contribute(self, blackboard):
        """Decidir si puede contribuir en base a la pizarra"""
        raise NotImplementedError

    def contribute(self, blackboard):
        """Hacer su contribución"""
        raise NotImplementedError

class InputSource(KnowledgeSource):
    def can_contribute(self, blackboard):
        return 'input' not in blackboard.data

    def contribute(self, blackboard):
        blackboard.data['input'] = (9, 6)
        print(f"[{self.name}] puso entrada: (9, 6)")

class SumSource(KnowledgeSource):
    def can_contribute(self, blackboard):
        return 'input' in blackboard.data and 'sum' not in blackboard.data

    def contribute(self, blackboard):
        a, b = blackboard.data['input']
        blackboard.data['sum'] = a + b
        print(f"[{self.name}] calculó la suma: {a + b}")

class OutputSource(KnowledgeSource):
    def can_contribute(self, blackboard):
        return 'sum' in blackboard.data and blackboard.status != 'complete'

    def contribute(self, blackboard):
        result = blackboard.data['sum']
        print(f"[{self.name}] Resultado final: {result}")
        blackboard.status = 'complete'

class Controller:
    def __init__(self, blackboard, sources):
        self.blackboard = blackboard
        self.sources = sources

    def run(self):
        while self.blackboard.status != 'complete':
            for source in self.sources:
                if source.can_contribute(self.blackboard):
                    source.contribute(self.blackboard)

# Crear componentes
blackboard = Blackboard()
sources = [
    InputSource("Entrada"),
    SumSource("Suma"),
    OutputSource("Salida")
]

controller = Controller(blackboard, sources)
controller.run()