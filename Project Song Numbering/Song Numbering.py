from appJar import gui
import os


def isInt(string):
    string = string[:2]  # Get the first character of the string
    try:  # if it's an int, return true
        if int(string):
            return True
    except ValueError:  # if not, return false
        return False


def increment(string, increment):
    numberInString = int(string[:2])
    stringWithoutNumber = string[3:]
    if int(numberInString + increment) < 10:
        return "0" + str(numberInString + increment) + " " + stringWithoutNumber
    else:
        return str(numberInString + increment) + " " + stringWithoutNumber


def insertNumber(string, numToInsert):
    if numToInsert < 10:
        return str(0) + str(numToInsert) + f" - {string}"
    else:
        return str(numToInsert) + f" - {string}"


def NumberAction():
    # Get the music files in the selected directory, and number them
    workingDirectory = prog.getEntry("dir")
    allFiles = os.listdir(workingDirectory)  # Gets files in the dir
    filesToIncrement, filesToNumber = [], []
    for files in allFiles:
        if isInt(files) and ".mp3" in files:
            filesToIncrement.append(files)
        elif not isInt(files) and ".mp3" in files:
            filesToNumber.append(files)

    # Count how many times to increment files based on how many are in filesToNumber
    incrementBy = len(filesToNumber)
    # Increment already numbered files
    incrementedFiles = [increment(files, incrementBy) for files in filesToIncrement]
    # Number non numbered files
    newNumberedFiles = [insertNumber(files, filesToNumber.index(files) + 1) for files in filesToNumber]
    # Rename and Apply
    # Cross-Check files and rename accordingly
    for files in range(len(newNumberedFiles)):
        os.rename(workingDirectory + "/" + filesToNumber[files], workingDirectory + "/" + newNumberedFiles[files])
    for files in range(len(incrementedFiles)):
        os.rename(workingDirectory + "/" + filesToIncrement[files], workingDirectory + "/" + incrementedFiles[files])


prog = gui("Song Numbering")
prog.setSize("300x200")
prog.addDirectoryEntry("dir")
prog.setSticky("news")
prog.addButton("Go!", NumberAction)
prog.go()
