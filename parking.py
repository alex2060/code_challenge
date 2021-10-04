
#garage
"""
used to add and remove cars form spots in a parking garage
depends on and uses floors and spots
"""
class garage:
	def __init__(self, floor):
		self.floors = [""]*floor

	#makes a database sting for use for the hyperwiki
	def make_sting_for_database(self):
		outsting=""
		if isinstance(self.floors, list)!=True:
			return "Invalid_garage_floor_"+x
		for x in range( len(self.floors) ):
			if isinstance(self.floors[x], floor)!=True:
				return "Invalid_garage"

			for y in range(len( self.floors[x].rows ) ):
				if isinstance(self.floors[x].rows[y], list)!=True:
					return "Invalid_garage"

				for z in range( len(self.floors[x].rows[y]) ):
					if isinstance(self.floors[x].rows[y][z], spot)!=True:
						return "Invalid_garage"
					outsting=outsting+self.floors[x].rows[y][z].occupiedby+"*"+self.floors[x].rows[y][z].type_of_space+"?"
				outsting=outsting+"@"
			outsting=outsting+","
		return outsting

	#removes a parking form form the garage
	def remove_spot(self,floor_number,row_number,spot_number):
		if isinstance(self.floors, list)!=True:
			return "Invalid_floor"
		if isinstance(self.floors, list)!=True:
			return "Invalid_spot"
		if floor_number>=len(self.floors):
			return "Invalid_spot"
		if isinstance(self.floors[floor_number], floor)!=True:
			return "Invalid_spot"
		if row_number>=len(self.floors[floor_number].rows):
			return "Invalid_spot"
		if isinstance(self.floors[floor_number].rows[row_number], list)!=True:
			return "Invalid_Row"
		if spot_number>=len(self.floors[floor_number].rows[row_number]):
			return "Invalid_spot"
		if isinstance(self.floors[floor_number].rows[row_number][spot_number], spot)!=True:
			return "Invalid_spot"
		if (self.floors[floor_number].rows[row_number][spot_number].occupiedby!="NONE"):
			if self.floors[floor_number].rows[row_number][spot_number].occupiedby in ["B2","B3","B4","B5"]:
				return "Cant_be_removed"
			if self.floors[floor_number].rows[row_number][spot_number].occupiedby =="B1":
				if spot_number+5>=len(self.floors[floor_number].rows[row_number]):
					return "Not_Enough_spots_for_buss_parking_invlaid"
				if isinstance(self.floors[floor_number].rows[row_number][spot_number+1], spot)!=True:
					return "Invalid_spot"
				if isinstance(self.floors[floor_number].rows[row_number][spot_number+2], spot)!=True:
					return "Invalid_spot"
				if isinstance(self.floors[floor_number].rows[row_number][spot_number+3], spot)!=True:
					return "Invalid_spot"
				if isinstance(self.floors[floor_number].rows[row_number][spot_number+4], spot)!=True:
					return "Invalid_spot"
				self.floors[floor_number].rows[row_number][spot_number+0].occupiedby = "NONE"
				self.floors[floor_number].rows[row_number][spot_number+1].occupiedby = "NONE"
				self.floors[floor_number].rows[row_number][spot_number+2].occupiedby = "NONE"
				self.floors[floor_number].rows[row_number][spot_number+3].occupiedby = "NONE"
				self.floors[floor_number].rows[row_number][spot_number+4].occupiedby = "NONE"
				return "Removed_bus"
			self.floors[floor_number].rows[row_number][spot_number+0].occupiedby = "NONE"
			return "Removed"
		else:
			return "Spot_empty"

	#adds a parking spot to the garage
	def add_parking(self,floor_number,row_number,spot_number,park_type):
		if isinstance(self.floors, list)!=True:
			return "Invalid_floor"
		if floor_number>=len(self.floors):
			return "Not_Enough_floors"
		if isinstance(self.floors[floor_number], floor)!=True:
			return "NO_floor"
		if row_number>=len(self.floors[floor_number].rows):
			return "Not_Enough_rows"
		if isinstance(self.floors[floor_number].rows[row_number], list)!=True:
			return "Invalid_Row"
		if spot_number>=len(self.floors[floor_number].rows[row_number]):
			return "Not_Enough_spots"
		if park_type=="B":
			if spot_number+5>=len(self.floors[floor_number].rows[row_number]):
				return "Not_Enough_spots_for_buss"
		if isinstance(self.floors[floor_number].rows[row_number][spot_number], spot)!=True:
			return "Invalid_spot"
		if park_type=="M":
			if (self.floors[floor_number].rows[row_number][spot_number].occupiedby=="NONE"):
				if self.floors[floor_number].rows[row_number][spot_number].type_of_space in "MCL":
					self.floors[floor_number].rows[row_number][spot_number].occupiedby="M"
					return "ADDED"
				else:
					return "Spot_not_valid"
			else:
				return "Spot_taken"
		if park_type=="C":
			if (self.floors[floor_number].rows[row_number][spot_number].occupiedby=="NONE"):
				if self.floors[floor_number].rows[row_number][spot_number].type_of_space in "CL":
					self.floors[floor_number].rows[row_number][spot_number].occupiedby="C"
					return "ADDED"
				else:
					return "Spot_not_valid"
			else:
				return "Spot_taken"
		if park_type=="B":
			check1 = self.floors[floor_number].rows[row_number][spot_number+0].occupiedby=="NONE"
			check2 = self.floors[floor_number].rows[row_number][spot_number+1].occupiedby=="NONE"
			check3 = self.floors[floor_number].rows[row_number][spot_number+2].occupiedby=="NONE"
			check4 = self.floors[floor_number].rows[row_number][spot_number+3].occupiedby=="NONE"
			check5 = self.floors[floor_number].rows[row_number][spot_number+4].occupiedby=="NONE"
			if (check1 and check2 and check3 and check4 and check5):

				check1_spot = self.floors[floor_number].rows[row_number][spot_number+0].type_of_space in "L"
				check2_spot = self.floors[floor_number].rows[row_number][spot_number+1].type_of_space in "L"
				check3_spot = self.floors[floor_number].rows[row_number][spot_number+2].type_of_space in "L"
				check4_spot = self.floors[floor_number].rows[row_number][spot_number+3].type_of_space in "L"
				check5_spot = self.floors[floor_number].rows[row_number][spot_number+4].type_of_space in "L"

				if (check1_spot and check2_spot and check3_spot and check4_spot and check5_spot):
					if isinstance(self.floors[floor_number].rows[row_number][spot_number+1], spot)!=True:
						return "Invalid_row"
					if isinstance(self.floors[floor_number].rows[row_number][spot_number+2], spot)!=True:
						return "Invalid_row"
					if isinstance(self.floors[floor_number].rows[row_number][spot_number+3], spot)!=True:
						return "Invalid_row"
					if isinstance(self.floors[floor_number].rows[row_number][spot_number+4], spot)!=True:
						return "Invalid_row"
					self.floors[floor_number].rows[row_number][spot_number+0].occupiedby="B1"
					self.floors[floor_number].rows[row_number][spot_number+1].occupiedby="B2"
					self.floors[floor_number].rows[row_number][spot_number+2].occupiedby="B3"
					self.floors[floor_number].rows[row_number][spot_number+3].occupiedby="B4"
					self.floors[floor_number].rows[row_number][spot_number+4].occupiedby="B5"
					return "ADDED"
				else:
					return "A_spots_not_valid"
			else:
				return "A_spot_taken"


#floor class
"""
used to make a floor for the garage
"""
class floor:
	def __init__(self, row):
		self.rows = [""]*row
	#adds a row to the parking lot
	def add_row(self , row_sting,row_number):
		if row_number>=len(self.rows):
			return "Not_Enough_Rows"
		parking_row = [0]*len(row_sting)
		for x in range(len(row_sting)):
			if row_sting[x] in "MCL":
				parking_row[x]=spot(row_sting[x])
			else:
				return "NO_ROW_ADDED"
		self.rows[row_number] = parking_row
		return "ROW_ADDED" 
#spot
"""
a spot in the garage used in floor
"""
class spot:
	#type_of_space - > the tpye of space it is
	#occupiedby -> whats ocuping the space
	def __init__(self, type_of_space,occupiedby="NONE"):
		self.type_of_space = type_of_space
		self.occupiedby  = occupiedby

#set up


#outputs and testing
def test():
	import pytest
	parking=garage(2)
	#making floor 1
	p1 = floor(3)
	p1.add_row("MC",0)
	p1.add_row("MCLLLLLLLLM",1)
	p1.add_row("MCLLLLLLLLM",2)

	#makeing floor 2
	p2 = floor(1)
	p2.add_row("CCCCC",0)

	#adding floors to parking
	parking.floors[0]=p2
	parking.floors[1]=p1


	output = [""]*13
	#adding m to floor
	output[0]= parking.add_parking(1,2,0,"M")
	output[1]= parking.remove_spot(1,2,0)
	#removing cycale
	output[2]= parking.add_parking(1,2,0,"M")
	output[3]= parking.add_parking(1,2,0,"M")
	output[4]= parking.add_parking(1,2,2,"C")
	output[5]= parking.add_parking(1,2,3,"B")
	output[6]= parking.add_parking(1,2,4,"C")
	output[7]= parking.add_parking(0,0,4,"C")
	output[8]= parking.remove_spot(1,2,4)
	output[9]= parking.remove_spot(1,2,3)
	output[10]=parking.add_parking(1,2,4,"C") 
	output[11]=parking.add_parking(1,1,3,"B") 
	cartest    = parking.add_parking(0,0,0,"C")
	output[12]=parking.make_sting_for_database()

 
	cycal_test = parking.add_parking(0,0,0,"M") 
	assert output[0 ]=="ADDED"
	assert output[1 ]=="Removed"
	assert output[2 ]=="ADDED"
	assert output[3 ]=="Spot_taken"
	assert output[4 ]=="ADDED"
	assert output[5 ]=="ADDED"
	assert output[6 ]=="Spot_taken"
	assert output[7 ]=="ADDED"
	assert output[8 ]=="Cant_be_removed"
	assert output[9 ]=="Removed_bus"
	assert output[10]=="ADDED"
	print("All Tests passed")
	#for intigration test use the atached 
	import requests
	x = requests.get("http://alexhaussmann.com/adhaussmann/a_final/change_post.php?uname=&hashword=&change_text="+output[12]+"&post=54ed0eaabc535520bef6caaa8e8959af0ce321d48c007b2751768100ead64020")
	print(x)
	print("head to http://alexhaussmann.com/adhaussmann/a_final/make_newpage.php?usertemplate_name=example_mygamePIJLYBTPPMQRRPGKXMRLDHKJHOBFJP to see the parking garage")


test()





