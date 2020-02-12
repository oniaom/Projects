import time
import threading
from appJar import gui

def timer_Start():
    global stop # This mitigates a problem where the user can't start the timer again...
    stop = False # ...If they stopped it once.
    # We check if the user accidentally started the timer (minutes and seconds = 0)
    if (int(prog.getSpinBox('Minutes')) == 0 and int(prog.getSpinBox('Seconds'))) == 0:
        prog.errorBox("No time selected!","You haven't selected a time!")
        return
    try: # Since there's a posibility of the user leaving one of the boxes empty by accident, we use try/catch
        minutesList = [i for i in range(int(prog.getSpinBox('Minutes'))+1)] # Specify minutes
        secondsList = [i for i in range(int(prog.getSpinBox('Seconds')))] # Specify seconds
    except ValueError:
        prog.errorBox("Error","One or both of your entries are blank!")
        return
        

    if not secondsList:
        secondsList = [i for i in range(60)] # This prevents the program not running if seconds = 0
        del(minutesList[-1])

    if not minutesList or minutesList == 0:
        minutesList=['0'] # This prevents the main loop from not running if minutesList is empty

    for second in range(len(secondsList)):
        if secondsList[second] <10:
            secondsList[second] = "0"+str(secondsList[second]) # Adding a 0 to values below 10. eg. 09 instead of 9

    backgroundStart = threading.Thread(target=ThreadedTimer_Start,args=(minutesList,secondsList),daemon=True) # Making sure the program doesn't hang
    backgroundStart.start()

def ThreadedTimer_Start(minutesList,secondsList):
    global stop
    textFile = open("time.txt","w+") # open time.txt, or create if it doesn't exist
    # TODO: DON"T CREATE TEXT FILE UNTIL USER WANTS TO LOG TO FILE!!!
    for minute in reversed(minutesList):
        # Check if the user said stop
        if stop:
            break
        for second in reversed(secondsList):
            # Check if the user said stop
            if stop:
                break
            # This section is about writing the time to a text file and displaying it on screen:
            if prog.getCheckBox('Log to file'):
                textFile.close()  # Closing the text file resets its contents when re-opened
                textFile = open("time.txt","w")
                textFile.write(str(minute)+":"+str(second))
                prog.setLabel('labelCurrentTime',str(minute)+":"+str(second))
                textFile.flush() # Flushing updates the contents in real-time
                time.sleep(1)
                secondsList = [i for i in range(60)] # Making sure it won't start the next cycle with the user selected seconds but start from 59 instead.
            # This section is about not writing to a text file, but instead just displaying it on screen:
            else:
                prog.setLabel('labelCurrentTime',str(minute)+":"+str(second))
                time.sleep(1)
                secondsList = [i for i in range(60)] # Making sure it won't start the next cycle with the user selected seconds but start from 59 instead.


def Timer_Stop():
    global stop # using this global var, we're able to check it in the other function
    stop = True # That creates a problem where you can't start again after this //fixed
    

# This is the same as void main().
# We initiate the user interface
stop=False
prog = gui('Timer')
prog.setSize('500x200')
prog.setSticky('nw')
prog.addLabelSpinBox('Minutes',[i for i in range(200)],row=0,column=0)
prog.setSticky('nw')
prog.addLabelSpinBox('Seconds',[i for i in range(60)],row=0,column=1)
prog.setSticky('news')
prog.addButton("Start",timer_Start,row=1,column=0)
prog.addButton('Stop',Timer_Stop,row=1,column=1)
prog.addLabel('labelCurrentTime',text='Timer will be shown here as well.',row=2,column=1)
prog.addCheckBox('Log to file',row=2,column=0)
prog.setCheckBox('Log to file')
prog.go()
