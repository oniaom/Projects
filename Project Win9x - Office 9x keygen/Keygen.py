# For windows 95, we have 3 concrete rules

# The first 3 numbers must be anywhere between 000 and 999.
#   However 333,444,555,666,777,888,999 are invalid

# Add a dash

# The second segment numbers, 7 in total, must have a sum divisible by 7.
#   However, the last digit must never be 0 or >=8


# For Win 97+ OEM keys, there are other rules

# The first segment, has 5 numbers.
#   The first 3 represent a day so anything between 001 and 366
#   The last 2 must always be >95 and <03

# Add a dash

# Next, it's always OEM (already pre written)

# Dash

# 7 Numbers, same divide by 7 check
#   First number must always be 0

# Dash

# Last 5 numbers are irrelevant. Anything will do

import random

def Check95(number):
    dissallowedNumbers = [333,444,555,666,777,888,999]
    for num in dissallowedNumbers:
        if number == num:
            return False
    return True

def Gen95():
    # Let's start by generating any random number
    valid = False
    while not valid: # enclosing in a loop to check if said number is valid
        segmentOne = random.randrange(0,999)
        if Check95(segmentOne):
            valid = True
       
    # This can cause problems if number < lenght of 3
    segmentOne = str(segmentOne)
    while (len(segmentOne) < 3):     
        segmentOne += "0"
    segmentOne = int(segmentOne)


    # At this point, the first segment is done. Now to generate the second segment
    # 7 numbers, divisible by 7, last never 0 or > 8(duh)
    # It would probably be easier to generate in chunks

    complete = False
    segmentTwo = ""
    
    while not complete:
        num = random.randint(111111,999999) # Make a random 6 character number
        num = str(num)
        num+="0" # and add the mandatory 0 at the end
        
        final = 0

        for chars in num:
            final+=int(chars)

        if final % 7 == 0:

            segmentTwo = num
            complete = True

    return str(segmentOne) + "-" + str(segmentTwo)
    

def Gen98Plus():
    # Segment one is just a date. simple 0-366, >03 and <95 
    SegmentOneP1 = random.randint(0,366) # Generate date
    SegmentOneP1 = str(SegmentOneP1)

    while len(SegmentOneP1) < 3:           
        SegmentOneP1 = SegmentOneP1.zfill(3)


    SegmentOneP2 = random.randint(3,95) # Generate year
    SegmentOneP2 = str(SegmentOneP2)

    while len(SegmentOneP2) < 2:     
        SegmentOneP2 = SegmentOneP2.zfill(2)

    # Segment 1 done!

    SegmentTwo = "OEM"
    # Segment 2 done!

    # ONTO SEGMENT 3!
    SegmentThree = 0
    complete = False
    while not complete:
        num = random.randint(111111,999999) # Make a random 6 character number
        num = str(num)
        num = num.zfill(7) # insert a 0 at the beginning

        final = 0
        for chars in num:
            final+=int(chars)

        if final % 7 == 0:
            SegmentThree = num
            complete = True
    
    # Segment 3 DONE!

    # Since segment 4 is just a normal 5 digit random number, let's do that!

    SegmentFour = random.randint(0,99999)
    SegmentFour = str(SegmentFour)
    while len(SegmentFour) < 5:
        SegmentFour.zfill(5)
    
    # DONE!
    
    return (SegmentOneP1+SegmentOneP2+"-"+SegmentTwo+"-"+SegmentThree+"-"+SegmentFour)


    

print(Gen95())
print(Gen98Plus())
