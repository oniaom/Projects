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
timea=[]
timestemp=0

for times in timestamps:
	a=times.split("- ")
	timea.append(a[1])



for times in timestamps: #Make a list of times
    	a=([int(b) for b in times.split() if b.isdigit()])
    	time.append(a)
print(time)
i=0
index=0
while index < (len(time)):
	print("time=",time[index])
	print("len=",len(time[index]))
	while(len(time[index]) >2):
		print("index=",time[index])
		temp = time[index][-1],time[index][-2]
		print("testy too",temp)
		time.remove(time[index])
		print("done")
		time.insert(0,temp)
	index+=1
print(time)
for timeIndexes in range(len(time)): #Make time in proper format ex 3:30
	while i<2:
		hi=str(time[timeIndexes][i])
		cutinhalf = len(hi)//2
		if len(hi) == 4:
			print(hi+" lenght 4")
			hi=hi[:cutinhalf]+":"+hi[-cutinhalf:]
		elif len(hi) <=3:
			print(hi+" lenght 3")
			if hi=="0":
				hi="0:00"
			else:
				hi=hi[:1]+":"+hi[1:]

		elif len(hi) > 6:
			hi=hi+" Try a number below 6 digits."
		
		else:
			newcut=cutinhalf//2
			testcut = (cutinhalf/2) /2
			if testcut > 0.6 < 1:
				print(testcut)
				hi=hi[:newcut+1]+":"+hi[newcut+1:cutinhalf+1]+":"+hi[cutinhalf+1:]
			else:
				hi=hi[:newcut]+":"+hi[newcut:cutinhalf+1]+":"+hi[cutinhalf+1:]
	
		print(hi)
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
control=0

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
		a+= "#"*longest+"#"
		finalfile.write(a)
		control+=2
		text+=1
# Finalize with 20 hashes at the bottom.		
a=("#"*20)
finalfile.write(a)



