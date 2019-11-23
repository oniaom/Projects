from appJar import gui


def Open_or_Save_File(open_or_save):  # This is the open file dialog
    if open_or_save == 'Open':
        try:  # Opens an open file dialog and gets the text from the text document that was chosen,then sets it on the textArea
            SelectedFile = Program.openBox("Select a text file", fileTypes=[('Text Documents', '*.txt')], asFile=True,
                                           mode='r')
            FileText = SelectedFile.read()
            Program.setTextArea("textNotepad", FileText)
        except AttributeError:
            pass
    elif open_or_save == 'Save':
        try:  # Gets the text from textArea and saves it in a text document in the directory the user chooses.
            textToSave = Program.getTextArea("textNotepad")
            fileToSave = Program.saveBox("Save your Document", fileTypes=[('Text Documents', '*.txt')], asFile=True)
            fileToSave.write(textToSave)
        except AttributeError:
            pass
    else:  # Since there's only three options, open save or exit, then user selected exit.
        Program.stop()


# Sets the GUI

Program = gui()
Program.setSize("500x500")

Program.addScrolledTextArea("textNotepad")
FileMenuOptions = ["Open", "Save", "Exit"]
Program.addMenuList("File", FileMenuOptions, Open_or_Save_File)

Program.go()
