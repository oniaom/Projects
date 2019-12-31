import os
import appJar
from appJar import gui

# The difference between this and Version 1 is that this uses dictionaries instead of lists.

def findExt(ext, filesInDir):  # Find the extension of choice inside the directory
    desiredFiles = [Files for Files in filesInDir for extension in ext if extension in Files]
    return desiredFiles


def moveFiles(array, name):  # Move files from their place to the respective folders
    workingDirectory = program.getEntry("directory")
    for file in array:
        try:
            os.rename(workingDirectory + "/" + file, workingDirectory + "/" + name + "/" + file)
        except FileNotFoundError:
            continue

def isEmpty(array):
    if array:
        return array
    else:
        return True


def Sort():  # Main function
    program.setLabel("Success!", "Sorting...")
    try:  # If the user entered a bad directory (ie nothing) stop the program.
        workingDirectory = program.getEntry("directory")
        filesInDir = os.listdir(workingDirectory)
    except FileNotFoundError:
        program.errorBox("Error", "Invalid Directory. Please try again.")
        program.setLabel("Success!", "")
        return

    filesWithExt = {"Programs": (".exe", ".lnk"), "Documents": (".txt", ".pdf", ".doc", ".docx", ".rtf", ".odt"),
                    "Pictures": (".jpg", ".png", ".gif", ".pic", ".ico", ".jpeg", ".bmp"), "Music": (".mp3", ".ogg")}
    allFiles = []
    dirsToMake = []
    index = 0

    for extensions in filesWithExt.values():
        allFiles.append(findExt(extensions, filesInDir))
        if not allFiles[index]:
            allFiles[index] = False
        index += 1

    for names in filesWithExt.keys():
        a = tuple(filesWithExt.keys()).index(names)
        if allFiles[a]:
            dirsToMake.append(names)

    for stuff in allFiles:
        if not stuff:
            del (allFiles[stuff])

    everything = dict(zip(dirsToMake, allFiles))
    for dirs, contents in everything.items():
        if not os.path.exists(workingDirectory + "/" + dirs):
            os.mkdir(workingDirectory + "/" + dirs)
        moveFiles(contents, dirs)

    program.setLabel("Success!", "Success!")  # Done!


program = gui("Sorter")
program.setSize("300x130")
program.resizable = False
program.setSticky("nesw")
program.setStretch("column")
program.addLabel("Select Directory")
program.addDirectoryEntry("directory")
program.addButton("Sort!", Sort)
program.addLabel("Success!", "")
program.go()
