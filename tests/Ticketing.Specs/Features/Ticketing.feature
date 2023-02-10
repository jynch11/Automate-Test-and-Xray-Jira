Feature: Ticketing

	#AS A customer
	#I WANT TO have a page where I can create and submit a ticket about the problems I may encouter
	#SO THAT I wont have to go to their office to file it
	@TEST_ME-3 @TESTSET_ME-4
	Scenario: Create Ticket
		When customer fills all the following datas and submits the form
		| Type       | Name     | AccountNumber | AccountName | MeterNumber | Address | ContactNumber | OtherDetails     | ORNumber | Photos                                                                            | Status       |
		| Complaints | No Water | 1234321       | Nino        | 4321234     | Purok 5 | 09121212121   | Nothing          | 54321    | https://wallpapercave.com/wp/wp10279812.jpg                                       | For Approval |
		| Complaints | Leakage  | 1234532       | Moonshot    | 3456788     | Brgy 3  | 09676181219   | just a test bruh | 32111    | https://www.waterindustryjournal.co.uk/wp-content/uploads/2018/02/burst-pipe.jpeg | For Approval |
		Then a ticket should be succesfully created
	@TEST_ME-7 @TESTSET_ME-4
	Scenario: Display details of a ticket
		Given the following datas are already submitted
		| Id                       | Type             | Name       | AccountNumber | AccountName | MeterNumber | Address        | ContactNumber | OtherDetails | ORNumber   | Photos                                                                                                                                   | Status       |
		| 63c646b0eb34447850246068 | Test Complaint   | No Water   | 12345678      | Jm Albasin  | 87654321    | C.M Recto Ext. | 09676181217   | Just a test  | 0987654321 | https://wallpapercave.com/wp/wp10279812.jpg                                                                                              | For Approval |
		| 63c646b0eb34447850246069 | Test Complaint 2 | Water Leak | 12345678      | Jm Albasin  | 87654321    | C.M Recto Ext. | 09676181217   | Just a test  | 0987654321 | https://imageio.forbes.com/blogs-images/natalieparletta/files/2019/06/AdobeStock_234736184-by-manola72-1200x800.jpg?format=jpg&width=960 | For Approval |
		#Get ticket by ID
		When I view a ticket 
		#Display datas reference to that ID
		Then display all information of the ticket
