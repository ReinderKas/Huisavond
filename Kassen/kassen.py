import os
import sys

module_path = os.path.abspath(os.path.join(os.path.dirname(__file__), 'Games'))
sys.path.insert(0, module_path)

from jackpot import Jackpot



jp = Jackpot()

jp.addName('Reinder')
jp.addName('NJ')
jp.addName('Sofia')
jp.addName('Ingvar')
jp.addName('Julia')
jp.addName('Tjeerd')

for i in range(len(jp.getNamePool())):
    print(jp.draw())

difficulty = 0 # max 3?