from appJar import gui
import os


def getNumber(file):
    numberInFile = file[:3]
    return numberInFile


def getAndSwap(name, number):
    name = name[3:]
    name = number + name
    return name


def getDir(listDir):
    directory = "/".join(listDir)
    directory += "/"
    return directory


def numberAction():
    fileToSwap = prog.getEntry("file1")  # Get the first and second files to swap numbers
    fileToGo = prog.getEntry("file2")

    both = [fileToSwap, fileToGo] # This list contains both files with the original directory
    swapper = [getNumber(fileToGo.split('/')[-1]), getNumber(fileToSwap.split('/')[-1])] # this contains the numbers of the files

    for stuff in range(len(both)):  # So now we iterate through the files
        name = both[stuff].split('/')[-1]  # This is the actual name.
        newName = getAndSwap(name, swapper[stuff])  # This swaps the numbers from file1 and file2
        listDirectory = both[stuff].split('/')[:-1]  # Creates a list containing the path
        directory = getDir(listDirectory)  # And makes it a string with "/"
        os.rename(both[stuff], directory + newName)  # Finally, we rename the file!


prog = gui("Song Swapper")
prog.setSize("400x300")
prog.addLabel("Select the file that you want to Change")
prog.addFileEntry("file1")
prog.addLabel("Select the file to change it to")
prog.addFileEntry("file2")
prog.addButton("GO!", numberAction)
prog.go()
