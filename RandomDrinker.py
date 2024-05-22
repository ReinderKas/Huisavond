import time
from random import randrange


people = [
    'Sofia',
    'NJ   ',
    'Julia',
    'Ingvar',
    'Tjeerd',
    'Reinder',
]

drinks = [
    'beer',
    'wine',
    'whiskey',
    'vodka',
    'beerenburg',
]


sleepTime = 60      # in seconds
iteration = 0       # counter to keep track

while True:
    iteration += 1

    fucktard = people[randrange(len(people))]
    drink    = drinks[randrange(len(drinks))]

    print('{0}:  {1} \thas to drink  {2}!'.format(iteration, fucktard, drink.capitalize()))
    time.sleep(sleepTime)
