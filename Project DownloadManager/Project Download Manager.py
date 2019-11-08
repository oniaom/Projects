import wget
from appJar import gui
import threading

def ButtonClick(): # STart a separate thread to not lag the UI
    labelProgress = program.addLabel("message",text="Your program is Downloading...")
    otherThread = threading.Thread(target=thread, args=(1,))
    otherThread.start()

def thread(test): # Get the text in the label called 'WrittenURL' and use WGET to download it 
    url = str(program.getTextArea("writtenURL"))    
    name = wget.download(url)
    program.setLabel("message","Download of '"+str(name)+"' is done!")

program = gui("Program")
program.setSize("500x600")
program.addTextArea("writtenURL",row=0,column=0)
program.addButton("Download!",ButtonClick,row=1,column=0)

program.go()
