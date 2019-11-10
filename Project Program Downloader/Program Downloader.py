#This program needs appJar for the graphical interface, and Wget for the downloading proccess
from appJar import gui
import wget
import urllib.error

app = gui()
CheckedBoxes = []  # Array of which checkboxes were checked

def ButtonClick():
    selectedPrograms = ""  # We check which boxes were checked, append them to CheckedBoxes, and put them in a string with dashes.
    if(app.getCheckBox("cbBrowserFirefox")):
        CheckedBoxes.append("firefox")
    if(app.getCheckBox("cbBrowserChrome")):
        CheckedBoxes.append("chrome")
    if(app.getCheckBox("cbLibreOffice")):
        CheckedBoxes.append("libreoffice")
    if(app.getCheckBox("cb7Zip")):
        CheckedBoxes.append("7zip")
    if(app.getCheckBox("cbSkype")):
        CheckedBoxes.append("skype")
    if(app.getCheckBox("cbDiscord")):
        CheckedBoxes.append("discord")
    if(app.getCheckBox("cbqBittorrent")):
        CheckedBoxes.append("qbittorrent")
    if(app.getCheckBox("cbSteam")):
        CheckedBoxes.append("steam")
    if(app.getCheckBox("cbEverything")):
        CheckedBoxes.append("everything")
    if(app.getCheckBox("cbVSCode")):
        CheckedBoxes.append("vscode")
    if(app.getCheckBox("cbVLC")):
        CheckedBoxes.append("vlc")
    if(app.getCheckBox("cbCodecs")):
        CheckedBoxes.append("klitecodecs")
    if(app.getCheckBox("cbSpotify")):
        CheckedBoxes.append("spotify")
    # And we add dashes to each one (That's how ninite works)
    for programs in CheckedBoxes:
        selectedPrograms += programs + "-"

    # Since the last dash is going to cause us problems, we have to remove it.
    RemoveLastDash = selectedPrograms.rfind("-")
    selectedPrograms = selectedPrograms[:RemoveLastDash]+""+selectedPrograms[RemoveLastDash+1:]
    DownloadProgs(selectedPrograms)

def DownloadProgs(Programs): #This just calls wget to download what we want.
    try:
        wget.download(url="https://www.ninite.com/"+Programs+"/ninite.exe")

    except(urllib.error.HTTPError): # In case the url isn't found (user selects nothing, ninite changes their site)
        print("The url wasn't found.")

if __name__ == "__main__":   
     # These are the selections the user has.
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
    app.go()
    
