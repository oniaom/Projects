import os
import appJar
from appJar import gui

'''
def findExt(ext, filesInDir):    This is what findExt does. For debug purposes.
    desiredPrograms = []
    for Programs in filesInDir:
        for extension in ext:
            if extension in Programs:
                desiredPrograms.append(Programs)
    return desiredPrograms
'''


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


def Sort():  # Main function
    program.setLabel("Success!", "Sorting...")
    try:  # If the user entered a bad directory (ie nothing) stop the program.
        workingDirectory = dirToSort = program.getEntry("directory")
        filesInDir = os.listdir(dirToSort)
    except FileNotFoundError:
        program.errorBox("Error", "Invalid Directory. Please try again.")
        program.setLabel("Success!", "")

    fileNames = ["Programs","Documents","Pictures"]
    fileTypes = [[".exe", ".lnk"],[".txt", ".pdf", ".doc", ".docx", ".rtf", ".odt"],[".jpg", ".png", ".gif", ".pic", ".ico", ".jpeg", ".bmp"]]
    allFiles =[]

    emptyOrNot = lambda array: array if array else False

    for i in range(len(fileNames)):
        allFiles.append(findExt(fileTypes[i],filesInDir))
        emptyOrNot(allFiles[i])

    makeDir = lambda directory: os.mkdir(workingDirectory + "/" + directory) if not os.path.exists(
        workingDirectory + "/" + directory) else False

    dirsToMake = ["Programs", "Documents", "Pictures"]  # Create directories

    for corresponding in range(len(allFiles)):
        if allFiles[corresponding]:
            makeDir(dirsToMake[corresponding])
            moveFiles(allFiles[corresponding], dirsToMake[corresponding])

    program.setLabel("Success!", "Success!")  # Done!


program = gui("Sorter")
program.setSize("300x130")
program.resizable = False
program.setSticky("nesw")
program.setStretch("column")
program.addLabel("Select Directory")
program.addDirectoryEntry("directory")
program.addButton("Sort!", Sort)
program.addLabel("Success!","")
program.go()
