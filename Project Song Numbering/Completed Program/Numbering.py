import library
from appJar import gui
import os


def NumberAction():
    if workingDirectory == "":
        prog.errorBox("Error", "You haven't selected a directory!")
        return
    allFiles = os.listdir(workingDirectory)  # Gets files in the dir
    filesToIncrement, filesToNumber = [], []
    for files in allFiles:
        if library.isInt(files) and ".mp3" in files:
            filesToIncrement.append(files)
        elif not library.isInt(files) and ".mp3" in files:
            filesToNumber.append(files)

    # Count how many times to increment files based on how many are in filesToNumber
    incrementBy = len(filesToNumber)
    # Increment already numbered files
    incrementedFiles = [library.increment(files, incrementBy) for files in filesToIncrement]
    # Number non numbered files
    newNumberedFiles = [library.insertNumber(files, filesToNumber.index(files) + 1) for files in filesToNumber]
    # Rename and Apply
    # Cross-Check files and rename accordingly
    for files in range(len(newNumberedFiles)):
        os.rename(workingDirectory + "/" + filesToNumber[files], workingDirectory + "/" + newNumberedFiles[files])
    for files in range(len(incrementedFiles)):
        os.rename(workingDirectory + "/" + filesToIncrement[files], workingDirectory + "/" + incrementedFiles[files])
    prog.updateListBox("directory",sorted(os.listdir(workingDirectory)))
    prog.infoBox("Success!", "Your music has been numbered successfully!!")


def selectFolder():
    global workingDirectory
    workingDirectory = prog.directoryBox("Select a Directory")
    if workingDirectory is None: return
    prog.updateListBox("directory", sorted(os.listdir(workingDirectory)))


def about():
    prog.infoBox("About", "oni's Song Numbering\nVersion 0.0.1")


workingDirectory = ""
prog = gui("Song Numbering")
prog.setSize("800x600")

menuItems = {"Open Folder": selectFolder, "-": None, "Exit": prog.stop}
for names, funcs in menuItems.items():  # Create the menu items
    prog.addMenuItem("File", names, funcs)
prog.addMenuItem("Help","About",about)

prog.setSticky("news")
prog.addListBox("directory", row=0, column=0)
prog.setSticky("news")
prog.addButton("Number Them!", NumberAction)
prog.go()
