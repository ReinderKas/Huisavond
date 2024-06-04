import random 

class Jackpot:
    def __init__(self):
        self.namePool = []

    def addName(self, name):
        self.namePool.append(name)

    def printPool(self):
        for name in self.namePool:
            print(name)

    def getNamePool(self):
        return self.namePool

    def draw(self):
        if not self.namePool:
            raise ValueError("The list is empty")
        return random.choice(self.namePool)