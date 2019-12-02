from appJar import gui
import random
import os
######################################### TO DO: ADD COMMENTS.
program = gui("Tick Tack Toe")

Combo = 0
possibleCombo = False
randomCombo = random.randint(0, 7)


def playGame(buttonName):
    global Combo
    global possibleCombo
    global randomCombo
    alotoftries = 0
    allButtons = ['1', '2', '3', '4', '5', '6', '7', '8', '9']
    conditionsToWin = [['1', '2', '3'], ['4', '5', '6'], ['7', '8', '9'], ['1', '4', '7'], ['2', '5', '8'],
                       ['3', '6', '9'], ['1', '5', '9'], ['3', '5', '7']]

    if program.getButton(buttonName) != 'X' and program.getButton(buttonName) != "O":
        program.setButton(buttonName, "X")
    # choose a random index of the conditions that the user has yet to click on
    # next iteration of the user clicked on one of the required buttons find an other one that contains the last button clicked
    # and check if there's possible moves

    tries = 0
    loosingtries = 0
    while not possibleCombo:
        for conditions in conditionsToWin[randomCombo]:
            if program.getButton(conditions) == "X":
                randomCombo = random.randint(0, 7)
                tries = 0
                loosingtries += 1
            elif program.getButton(conditions) == buttonName:
                randomCombo = random.randint(0, 7)
                tries = 0
                loosingtries += 1
            else:
                tries += 1
                if tries == 3:
                    Combo = conditionsToWin[randomCombo]
                    possibleCombo = True
                elif tries > 100:
                    randomCombo = random.randint(0, 7)
                    continue
        if tries == 3:
            Combo = conditionsToWin[randomCombo]
            possibleCombo = True
        elif tries > 100:
            randomCombo = random.randint(0, 7)
            continue
    if possibleCombo:
        for check in Combo:
            if program.getButton(check) == "X":
                possibleCombo = False
            while not possibleCombo:
                for conditions in conditionsToWin[randomCombo]:
                    if program.getButton(conditions) == "X":
                        randomCombo = random.randint(0, 7)
                        tries = 0
                        loosingtries += 1
                    elif program.getButton(conditions) == buttonName:
                        randomCombo = random.randint(0, 7)
                        tries = 0
                        loosingtries += 1
                    else:
                        tries += 1
                if tries == 3:
                    Combo = conditionsToWin[randomCombo]
                    possibleCombo = True
                elif loosingtries > 100 or tries > 100:
                    print("No possible moves")
                    randomCombo = random.randint(0, 7)
                    tries = 0
                    alotoftries += 1
                if alotoftries > 100:
                    humanwin = 0
                    aiwin = 0
                    for surface in range(len(conditionsToWin)):
                        for a in conditionsToWin[surface]:
                            if program.getButton(a) == 'X':
                                humanwin += 1
                            elif program.getButton(a) == 'O':
                                aiwin += 1
                        if humanwin == 3:
                            program.infoBox("You Won!", "Congratulations! You Won!!!")
                            program.stop()
                        elif aiwin == 3:
                            program.infoBox("AI Won!", "The AI has won this game")
                        else:
                            humanwin = 0
                            aiwin = 0
                    program.infoBox("Stalemate!", "The AI Is dumb and can't win in this situation!")
                    program.stop()

        program.setButton(Combo[0], "O")
        print(Combo, Combo[0])
        del Combo[0]

    humanwin = 0
    aiwin = 0
    for surface in range(len(conditionsToWin)):
        for a in conditionsToWin[surface]:
            if program.getButton(a) == 'X':
                humanwin += 1
            elif program.getButton(a) == 'O':
                aiwin += 1
        if humanwin == 3:
            program.infoBox("You Won!", "Congratulations! You Won!!!")
            program.stop()
        elif aiwin == 3:
            program.infoBox("AI Won!", "The AI has won this game")
        else:
            humanwin = 0
            aiwin = 0


program.setSize("500x500")
r, c = 0, 0
buttonsToAdd = ('1', '2', '3', '4', '5', '6', '7', '8', '9')
for buttons in buttonsToAdd:
    program.addButton(buttons, playGame, r, c)
    c += 1
    if c % 3 == 0:
        r += 1
        c = 0

program.go()
