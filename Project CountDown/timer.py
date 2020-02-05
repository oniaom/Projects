import time
import threading
from appJar import gui
def timer_Start():
    global stop # This mitigates a problem where the user can't start the timer again
    stop = False # If they stopped it once.

    #textFile = open("time.txt","w+") # open time.txt, or create if it doesn't exist

    minutesList = [i for i in range(int(prog.getSpinBox('minutes')))] # Specify minutes
    secondsList = [i for i in range(int(prog.getSpinBox('seconds')))] # Specify seconds

    if not secondsList:
        secondsList = [i for i in range(59)] # This prevents the program not running if seconds = 0

    if not minutesList:
        minutesList=['0']

    for second in range(len(secondsList)):
        if secondsList[second] <10:
            secondsList[second] = "0"+str(secondsList[second]) # Adding a 0 to values below 10. eg. 09 instead of 9

    backgroundStart = threading.Thread(target=ThreadedTimer_Start,args=(minutesList,secondsList),daemon=True) # Making sure the program doesn't hang
    backgroundStart.start()

def ThreadedTimer_Start(minutesList,secondsList):
    global stop
    textFile = open("time.txt","w+") # open time.txt, or create if it doesn't exist
    for minute in reversed(minutesList):
        time.sleep(1)
        # Check if the user said stop
        if stop:
            break
        for second in reversed(secondsList):
            # Check if the user said stop
            if stop:
                break

            textFile.close()  # Closing the text file resets its contents when re-opened
            textFile = open("time.txt","w")
            textFile.write(str(minute)+":"+str(second))
            prog.setLabel('labelCurrentTime',str(minute)+":"+str(second))
            textFile.flush() # Flushing updates the contents in real-time
            time.sleep(1)
            secondsList = [i for i in range(59)] # Making sure it won't start the next cycle with the user selected seconds but start from 59 instead.

def Timer_Stop():
    global stop # using this global var, we're able to check it in the other function
    stop = True # That creates a problem where you can't start again after this //fixed
    
stop=False
prog = gui('OBS Timer')
prog.setSize('500x200')
prog.setSticky('nw')
prog.addLabelSpinBox('minutes',[i for i in range(200)],row=0,column=0)
prog.setSticky('nw')
prog.addLabelSpinBox('seconds',[i for i in range(60)],row=0,column=1)
prog.setSticky('news')
prog.addButton("Start",timer_Start,row=1,column=0)
prog.addButton('Stop',Timer_Stop,row=1,column=1)
prog.addLabel('labelCurrentTime',text='The timer will be shown here.')
prog.go()
