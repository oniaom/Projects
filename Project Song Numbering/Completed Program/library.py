def isInt(string):
    string = string[:2]  # Get the first character of the string
    try:  # if it's an int, return true
        int(string)
        return True
    except ValueError:  # if not, return false
        return False


def calculateNumber(name):
    numberTest = 0
    while True:
        try:
            int(name[numberTest])
            numberTest += 1
        except ValueError:
            return numberTest


def increment(string, number):
    numberInString = int(string[:calculateNumber(string)])
    stringWithoutNumber = string[calculateNumber(string):]
    if int(numberInString + number) < 10:
        return "0" + str(numberInString + number) + " " + stringWithoutNumber
    else:
        return str(numberInString + number) + stringWithoutNumber


def insertNumber(string, numToInsert):
    if numToInsert < 10:
        return "0" + str(numToInsert) + f" - {string}"
    else:
        return str(numToInsert) + f" - {string}"
