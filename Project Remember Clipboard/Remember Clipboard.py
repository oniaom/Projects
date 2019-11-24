import pyperclip
import time
import sys
import threading
from appJar import gui


def ContentUpdater():
    start = threading.Thread(target=threadFunction)
    start.start()


def threadFunction():
    clipboard = pyperclip.paste() # Get contents of clipboard
    program.setTextArea("contents", clipboard) # Put them in the text area
    compareClipboard = ""
    while True:  # Run until program closes. Compare the old clipboard with the potential new one. If there's new content, put them in the text area.
        compareClipboard = pyperclip.paste()
        if compareClipboard != clipboard:
            clipboard = compareClipboard
            program.setTextArea("contents", "\n" + clipboard)
        time.sleep(1)


program = gui()
program.setSize("300x300")
program.addLabel("clip", text="Your past clipboard content", )
program.addTextArea("contents")
program.setStartFunction(ContentUpdater) # This makes the program start with my contentupdater function 
program.go()
