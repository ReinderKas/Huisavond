import time
import os
from random import randrange
from playsound import playsound


people = [
    'Sofia',
    'NJ',
    'Julia',
    'Ingvar',
    'Tjeerd',
    'Reinder',
]

drinks = [
    'Beer',
    'Wine',
    'Whiskey',
    'Vodka',
    'Beerenburg',
]

drinkCounter = {
    'Sofia'  : 0,
    'NJ'  : 0,
    'Julia'  : 0,
    'Ingvar' : 0,
    'Tjeerd' : 0,
    'Reinder': 0,
}

totalDrinks = 0
timer = 0

try:
    while True:
        timer -= 1  # Decrement the timer
        if (timer <= 0):
            os.system('cls')    # Clear the console
            timer = 15          # Reset the timer
            totalDrinks += 1    # Increment the drink counter

            fucktard = people[randrange(len(people))]  # Draw the person that has to drink
            drink    = drinks[randrange(len(drinks))]  # Draw the drink to consume

            drinkCounter[fucktard] += 1

            print('{0}    has to drink  {1}!\n (Total drinks: {2})\n'.format(fucktard, drink, drinkCounter[fucktard]))  # Print

            # Somehow breaks if I don't put full string here...
            playsound("C:/Users/Reinder/Source/Huisavond/RandomDrinker/rooster_long.wav")      # Play sound
        else : 
            print ("\033[A                             \033[A")             # Clear last line of output and put pointer to begin
            print('   {0} minutes until the next drink...'.format(timer))   # Print countdown 
            
        time.sleep(1)  # Wait for a minute
except:
    print(drinkCounter)