import os 


openingPrompt = """
Welcome to the wonderfull game of Kassen.
In this game, Ingvar will get fucked.

How much would you like to drink?
[3] About normal
[2] Barely anything
[1] Basically nothing
[0] Ingvar

"""




def getNumericInput():
    userInput = None
    # TODO between 0 and 3
    while (userInput is None):
        try:
            return int(input())
        except ValueError:
            print("That's not a valid number. Please enter an integer.")


os.system('cls')       
print(openingPrompt)

text = getNumericInput()

print(text)