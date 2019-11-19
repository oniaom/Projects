import os

timestamps = []
time=[]
timeproper=[]
a=0

stringbeforenum=[]
timefinal =[]
control=0

written=False
text=0

timeFile = open("time.txt","r")

for line in timeFile: #Get everything from file
	timestamps.append(line)

for indexes in range(len(timestamps)): #Remove the \n from string
	if "\n" in timestamps[indexes]:
				 timestamps[indexes]=timestamps[indexes].rstrip('\n')

timestrings = timestamps
for times in timestamps: #Make a list of times
    	a=([int(b) for b in times.split() if b.isdigit()])
    	time.append(a)

i=0

for timeIndexes in range(len(time)): #Make time in proper format ex 3:30
	while i<2:
		hi=str(time[timeIndexes][i])
		if len(hi) == 4:
			hi=hi[:2]+":"+hi[-2:]
		else:
			hi=hi[:1] +":" + hi[-2:]
		timeproper.append(str(hi))
		i+=1
	i=0



for text in timestrings: # Find what was written before numbers
	head,sep,tail = text.partition("-")
	stringbeforenum.append(head)



for stamps in timeproper: # Append all times in one
	timefinal.append(stamps)

longest = 0

finalfile=open('final.txt','w')
text = 0


while text < (len(stringbeforenum)): #This goes through all itterations and finds the longest string
	a=("#"*20+'\n'+stringbeforenum[text]+timefinal[control] + " - " +timefinal[control+1]+'\n')
	if len(a) > longest:
		longest = len(a)
	text+=1
	control+=2
longest-=41
a=""
text=0
control=0
firstTime = True

while text < (len(stringbeforenum)): #Append 'Timestamps' once,then everyting else in the correct order
	if written == False:
		templongest = ((longest+10)//2) - 1
		a= "#"*longest+"#"*21+"\n"+"#"+" "*templongest+'Timestamps:'+" "*templongest+"#"+'\n'
		written=True
		finalfile.write(a)
	else:
		if firstTime == True: #This makes sure that the hashes after Timestamps: are correct
			a=(stringbeforenum[text]+timefinal[control] + " - " +timefinal[control+1]+'\n')
			currentTextLength = len(a)
			finaleHuhu = longest-currentTextLength+20
			a=("#"*longest+"#"*21+'\n'+"#"+stringbeforenum[text]+timefinal[control] + " - " +timefinal[control+1]+" "*finaleHuhu+"#"+'\n')
			firstTime=False
		else:
			a=(stringbeforenum[text]+timefinal[control] + " - " +timefinal[control+1]+'\n')
			currentTextLength = len(a)
			finaleHuhu = longest-currentTextLength+20
			a=("#"*20+'\n'+"#"+stringbeforenum[text]+timefinal[control] + " - " +timefinal[control+1]+" "*finaleHuhu+"#"+'\n')
		if len(a) < longest:
			a+= "#"*longest+"#"
		else:
			a+= "#"*longest+"#"
		finalfile.write(a)
		control+=2
		text+=1
# Finalize with 20 hashes at the bottom.		
a=("#"*20)
finalfile.write(a)



