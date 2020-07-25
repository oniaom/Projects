

'''
ok so the aim of this program is to get monthly salary, and needs of user (debt,ongoing rent etc) and make a financial aim for things
such as money goals, wanted items etc.

'''

try: 
    from appJar import gui
except ModuleNotFoundError:
    print("Missing module: appJar")


def Calculation():
    # We need to get each entry seperately, and calculate the expenses
    # But first, we need to check if the most important entries are populated. Those are: Salary, Necessary payments
    if prog.getEntry("Monthly Salary     €") is None or prog.getEntry("Necessary monthly expenses (Gas, food, etc.)     €") is None:
        prog.errorBox("Missing entries","Missing Salary, or Necessary Expenses.")
        return

    # Now lets add the values in a dictionary for easy access    
    toCheck = ["Salary","Debt","Debt_Payments","Ongoing_Payments","Monthly_Expenses"]
    Everything = {}

    for entries, values in zip(LabelEntries,toCheck):
        # In case the user left blank entries, we'll turn em to 0s
        Everything[values] = 0 if prog.getEntry(entries) is None else prog.getEntry(entries)
    
    # I want to see how much money there's left after expenses, IGNORING DEBT (debt = borrowed more than you have anyway)
    
    Remaining_Salary = Everything["Salary"] - Everything["Ongoing_Payments"] - Everything["Monthly_Expenses"] - Everything["Debt_Payments"]

    # Sanity check that you can ACTUALLY save anything at all:
    if Remaining_Salary <= 0:
        prog.errorBox("Not Enough Money","Your remaining salary is not enough to cover everything. Please cut expenses and try again.")

    # So after we've sorted out the remaining salary, let's do some mathy moo to check how much salary can be saved (extreme edition) (gone wrong)
    prog.setLabel("Calculated budget will be shown here","This is as much as you can save: " + "€" +str(Remaining_Salary))
    

LabelEntries = ["Monthly Salary     €","Debt    €","Debt Payments   €","Ongoing Payments (Monthly)  €", "Necessary monthly expenses (Gas, food, etc.)     €"]

prog = gui("Financial Advisor")
prog.setResizable(False)
# add each label entry while saving lines huhu
for entries in LabelEntries:
    prog.addLabelNumericEntry(entries)
prog.addButton("Calculate Budget",func=Calculation)
prog.addLabel("Calculated budget will be shown here")

prog.go()