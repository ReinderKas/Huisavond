import time
import os
import random
from playsound import playsound

fuckers = {
    'Sofia'  : 0,
    'NJ'     : 0,
    'Julia'  : 0,
    'Ingvar' : 0,
    'Tjeerd' : 0,
    'Reinder': 0,
}

drinks = [ 'Beer', 'Wine', 'Whiskey', 'Vodka', 'Beerenburg']
timer, waitTime = 0, 15

try:
    while True:
        if (timer <= 0):
            timer = waitTime   # Reset the timer

            fucktard = random.choice(list(fuckers.keys()))  # Draw the fucktard that has to drink
            drink    = random.choice(drinks)                # Draw the drink to consume
            
            fuckers[fucktard] += 1

            os.system('cls')                                                                                        # Clear the console
            print('{0}    has to drink  {1}!\n (Total drinks: {2})\n\n'.format(fucktard, drink, fuckers[fucktard])) # Print
            playsound("C:/Users/Reinder/Source/Huisavond/RandomDrinker/rooster_long.wav")                           # Play sound

        print ("\033[A                             \033[A")             # Clear last line of output and put pointer to beginning
        print('   {0} minutes until the next drink...'.format(timer))   # Print countdown 
        timer -= 1                                                      # Decrement the timer
        time.sleep(60)                                                  # Wait for a minute
except: 
    print(fuckers)