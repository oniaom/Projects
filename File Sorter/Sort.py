import appJar
from appJar import gui
import os

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
    desiredFiles = [Programs for Programs in filesInDir for extension in ext if extension in Programs]
    return desiredFiles


def moveFiles(array, name, workingDirectory):  # Move files from their place to the respective folders
    for file in array:
        os.rename(workingDirectory + "\\" + file, workingDirectory + "\\" + name + "\\" + file)


def Sort():  # Main function
    try:  # If a label exists (ie 2nd+ iteration) set the text. Otherwise make a label.
        program.setLabel("Success!", "Sorting...")
    except appJar.appjar.ItemLookupError:
        program.addLabel("Success!", "Sorting...")

    Programs = [".exe", ".lnk"]
    Documents = [".txt", ".pdf", ".doc", ".docx", ".rtf", ".odt"]
    Pictures = [".jpg", ".png", ".gif", ".pic", ".ico", ".jpeg", ".bmp"]

    try:  # If the user entered a bad directory (ie nothing) stop the program.
        workingDirectory = dirToSort = program.getEntry("directory")
        filesInDir = os.listdir(dirToSort)
    except FileNotFoundError:
        program.errorBox("Error", "Invalid Directory. Please try again.")
        program.stop()

    programsInDir = findExt(Programs, filesInDir)  # Populate a list of programs,documents,and pictures from the directory
    documentsInDir = findExt(Documents, filesInDir)
    picturesInDir = findExt(Pictures, filesInDir)

    makeDir = lambda directory: os.mkdir(directory) if not os.path.exists(workingDirectory + "/" + directory) else False

    dirsToMake = ["Applications", "Pictures", "Documents"]  # Create directories
    for directories in dirsToMake:
        makeDir(directories)

    moveFiles(programsInDir, "Applications", workingDirectory)  # Move the files to their respective folders
    moveFiles(documentsInDir, "Documents", workingDirectory)
    moveFiles(picturesInDir, "Pictures", workingDirectory)

    program.setLabel("Success!", "Success!")  # Done!


program = gui("Sorter")
program.setSize("300x100")
program.resizable = False
program.setSticky("nesw")
program.setStretch("column")
program.addLabel("Select Directory")
program.addDirectoryEntry("directory")
program.addButton("Sort!", Sort)
program.go()
