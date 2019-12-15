from appJar import gui
import os


def calculateNumber(name):
    numberTest = 0
    while True:
        try:
            int(name[numberTest])
            numberTest += 1
        except ValueError:
            return numberTest


def getNumber(name):
    return name[:calculateNumber(name)]


def getAndSwap(name, number):
    return number + name[calculateNumber(name):]


def getDir(listDir):
    directory = "/".join(listDir)
    return directory + "/"


def numberAction():
    firstFile, secondFile = prog.getEntry("file1"), prog.getEntry(
        "file2")  # Get the first and second files to swap numbers
    both = [firstFile, secondFile]  # This list contains both files with the original directory

    for files in both:
        if '.mp3' not in files:
            prog.errorBox(title="Error", message="One or both files are not .mp3!")
            return

    swapper = [getNumber(secondFile.split('/')[-1]),
               getNumber(firstFile.split('/')[-1])]  # this contains the numbers of the files

    for files in range(len(both)):  # So now we iterate through the files
        name = both[files].split('/')[-1]  # This is the actual name. (Splits and returns the first index)
        newName = getAndSwap(name, swapper[files])  # This swaps the numbers from file1 and file2
        listDirectory = both[files].split('/')[
                        :-1]  # Creates a list containing the path (skips the last index  which is the name)
        directory = getDir(listDirectory)  # And makes it a string with "/"
        os.rename(both[files], directory + newName)  # Finally, we rename the current file!


prog = gui("Song Swapper")
prog.setSize("400x300")
prog.addLabel("Select the file that you want to Change")
prog.addFileEntry("file1")
prog.addLabel("Select the file to change it to")
prog.addFileEntry("file2")
prog.addButton("GO!", numberAction)
prog.go()
