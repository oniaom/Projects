#This program needs appJar for the graphical interface, and Wget for the downloading proccess
from appJar import gui
import wget
import urllib.error


app = gui()
CheckedBoxes = []  # Array of which checkboxes were checked
success = False
firstItteration = True


def ButtonClick():
    global firstItteration
    firstItteration = False
    selectedPrograms = ""  # We check which boxes were checked, append them to CheckedBoxes, and put them in a string with dashes.
    selectionCheckBoxes = ["cbBrowserFirefox","cbBrowserChrome","cbLibreOffice","cb7Zip","cbSkype","cbDiscord","cbqBittorrent","cbSteam","cbEverything","cbVSCode","cbVLC","cbCodecs","cbSpotify"]
    selectionCorrespondingPrograms = ["firefox","chrome","libreoffice","7zip","skype","discord","qbittorrent","steam","everything","vscode","vlc","klitecodecs","spotify"]
    for i in range(len(selectionCheckBoxes)):
     if app.getCheckBox(selectionCheckBoxes[i]):
        CheckedBoxes.append(selectionCorrespondingPrograms[i])
    # And we add dashes to each one (That's how ninite works)
    for programs in CheckedBoxes:
        selectedPrograms += programs + "-"
    # Since the last dash is going to cause us problems, we have to remove it.
    RemoveLastDash = selectedPrograms.rfind("-")
    selectedPrograms = selectedPrograms[:RemoveLastDash]+""+selectedPrograms[RemoveLastDash+1:]
    
    DownloadProgs(selectedPrograms)    
    
    app.removeAllWidgets()  #  These 2 lines are essential for appJar, because it tries to re-add the widgets causing errors
    
    mainFunction()          #  even without calling mainFunction()
def DownloadProgs(Programs): #This just calls wget to download what we want.
    global success
    try:
        wget.download(url="https://www.ninite.com/"+Programs+"/ninite.exe")       
        success = True
    except(urllib.error.HTTPError): # In case the url isn't found (user selects nothing, ninite changes their site)
        success = False

def mainFunction():
     # These are the selections the user has.
    CheckedBoxes.clear()
    app.addCheckBox("cbBrowserFirefox",row=0,column=0,name="Firefox")
    app.addCheckBox("cbBrowserChrome",row=0,column=1,name="Chrome")
    app.addCheckBox("cbLibreOffice",row=1,column=0,name="LibreOffice")
    app.addCheckBox("cb7Zip",row=1,column=1,name="7-Zip")
    app.addCheckBox("cbSkype",row=2,column=0,name="Skype")
    app.addCheckBox("cbDiscord",row=2,column=1,name="Discord")
    app.addCheckBox("cbqBittorrent",row=2,column=2,name="qBittorrent")
    app.addCheckBox("cbSteam",row=3,column=0,name="Steam")
    app.addCheckBox("cbEverything",row=3,column=1,name="Everything")
    app.addCheckBox("cbVSCode",row=4,column=0,name="VSCode")
    app.addCheckBox("cbVLC",row=4,column=1,name="VLC")
    app.addCheckBox("cbCodecs",row=4,column=2,name="K-Lite Codecs")
    app.addCheckBox("cbSpotify",row=4,column=3,name="Spotify")    
    # We link our Button to the function ButtonClick so when the user clicks the button, the function starts.
    app.addButton("Download",ButtonClick)
    global success
    global firstItteration
    if (success == True):
        app.addLabel("lSuccess",text="Success!\nYour programs have\ndownloaded!",row=6,column=0)
    elif success == False and firstItteration == True:
        pass
    elif success == False and firstItteration == False:
        app.addLabel("lFailure","The url wasn't found!\nPlease check your\ninternet connection and\ntry again!")
    app.go()

if __name__ == "__main__":   
    mainFunction()
    
    
