# Creating a Loyalty Scheme (10%)

In the workflow sections you must give clear instructions as to how to perform this workflow in your applcation. Use images and diagrams where necessary. Failure to give adequate instructions here may result in loss of marks.

- Load information about members
```cs
Welcome To Hullywood Cinema
--- Main Menu ---
1. Sign In
2. View Transactions
3. Exit Program
Select An Option: 1
--- Staff Sign In ---
Enter Staff ID: gs01 // Goes up to 5 base staff
Staff Number: GS01 - John

--- Main Menu ---
1. Sign In
2. View Transactions
3. Exit Program
Select An Option: 1
--- Staff Sign In ---
Enter Staff ID: ms01 //2 base managers
Staff Number: MS01 - Reece

--- Manager Options ---
1. Add Staff
2. View Staff
3. Remove Staff
4. Set Sechedule
5. Manage Concessions
6. Start Transaction
7. Exit Program
Select an option: 2
--- Staff List ---
ID: GS01 | Name: John Smith | Role: general staff
ID: GS02 | Name: Jack Sparrow | Role: general staff
ID: GS03 | Name: Adam West | Role: general staff
ID: GS04 | Name: Donald Rump | Role: general staff
ID: GS05 | Name: Jacob Scott | Role: general staff
ID: MS01 | Name: Reece Herbert | Role: manager
ID: MS02 | Name: Ron Swanson | Role: manager


Select Role:
1. General Staff
2. Manager Staff
1
New Staff Member Added: ID:GS06, Name: Will Cocks
--- Manager Options ---
1. Add Staff
2. View Staff
3. Remove Staff
4. Set Sechedule
5. Manage Concessions
6. Start Transaction
7. Exit Program
Select an option: 2
--- Staff List ---
ID: GS01 | Name: John Smith | Role: general staff
ID: GS02 | Name: Jack Sparrow | Role: general staff
ID: GS03 | Name: Adam West | Role: general staff
ID: GS04 | Name: Donald Rump | Role: general staff
ID: GS05 | Name: Jacob Scott | Role: general staff
ID: GS06 | Name: Will Cocks | Role: general staff //Same process as manager


Select an option: 3
Enter Staff ID To Remove: gs06
Staff Removed Successfully.
--- Manager Options ---
1. Add Staff
2. View Staff
3. Remove Staff
4. Set Sechedule
5. Manage Concessions
6. Start Transaction
7. Exit Program
Select an option: 2
--- Staff List ---
ID: GS01 | Name: John Smith | Role: general staff
ID: GS02 | Name: Jack Sparrow | Role: general staff
ID: GS03 | Name: Adam West | Role: general staff
ID: GS04 | Name: Donald Rump | Role: general staff
ID: GS05 | Name: Jacob Scott | Role: general staff
ID: MS01 | Name: Reece Herbert | Role: manager
ID: MS02 | Name: Ron Swanson | Role: manager
```
This workflow should do the following things:
- Any worker can add a member by providing a first name, surname and email address
```cs
-- Manager Options ---
1. Add Staff
2. View Staff
3. Remove Staff
4. Set Sechedule
5. Manage Concessions
6. Start Transaction
7. Exit Program
Select an option: 6
--- Customer Menu ---
1. Sign In
2. Sign Up
3. Sign In As Guest
Select An Option: 2
Enter First Name : jack
Enter Last Name: black
Enter Email (Must Contain Number And Special Char): jack.black@jb.com
Enter UK Phone Number (##### ######): 11111111111
New Member: Jack Black NM06 - Status Non Member
1. Holiday - 120 mins - Rated: 13 | Screen: S01 | Start Time: 10:00 AM
2. Gladiator - 120 mins - Rated: 15 | Screen: S01 | Start Time: 12:50 PM
3. Iron Man - 150 mins - Rated: 12 | Screen: S01 | Start Time: 03:40 PM
4. Mufasa - 150 mins - Rated: PG | Screen: S01 | Start Time: 07:00 PM
5. Maze Runner - 130 mins - Rated: 12 | Screen: S01 | Start Time: 10:20 PM
6. Mufasa - 150 mins - Rated: PG | Screen: S02 | Start Time: 10:00 AM
7. Iron Man - 150 mins - Rated: 12 | Screen: S02 | Start Time: 01:20 PM
8. Gladiator - 120 mins - Rated: 15 | Screen: S02 | Start Time: 04:40 PM
9. Maze Runner - 130 mins - Rated: 12 | Screen: S02 | Start Time: 07:30 PM
10. Holiday - 120 mins - Rated: 13 | Screen: S02 | Start Time: 10:30 PM
Select a movie screening: 1
Select a movie screening: 1
Selected: Holiday at 10:00 AM on screen S01
Select Type:
1. Standard Ticket: £8
2. Premium Ticket: £12
1
Select Seat:
1. Regular Seat (No Cost)
2. VIP Seat (£3)
1
Enter Number Of Customers (max 5): 1
Enter Age For Customer 1: 1
Add Concessions? (y/n): y
--- Concessions ---
1. Popcorn - £4.00
2. Soda - £1.00
3. Chocolate - £3.00
4. Natchos - £6.00
5. HotDog - £5.00
6. Candy - £3.00
7. Reese's - £2.00
8. 0 - £0.00
9. d - £2.00
Which Item Would You Like? 1
How Many Popcorn Would You Like?: 1
1x Popcorn (£4.00)

Would You Like To Add More Concessions? (y/n): n
Would You Like To Upgrade To Gold Member Status? (y/n)
y
You Have Been Upgraded To Gold Member Status.
Gold Member Discount Applied: 25%
--- Concession Summary ---
1 x Popcorn - £4.00 each
Total Concession Cost: £3.00
--- Ticket Summary ---
1 x Standard Ticket - Regular Seat - £8.00 each
Total Ticket Cost: £8.00
Grand Total: £11.00


--- Main Menu ---
1. Sign In
2. View Transactions
3. Exit Program
Select An Option: 1
--- Staff Sign In ---
Enter Staff ID: gs01
Staff Number: GS01 - John
--- Customer Menu ---
1. Sign In
2. Sign Up
3. Sign In As Guest
Select An Option: 2
Enter First Name : don
Enter Last Name: connel
Enter Email (Must Contain Number And Special Char): don.connel12@DC.com
Enter UK Phone Number (##### ######): 11111111111
New Member: Don Connel NM06 - Status Non Member


```
- 
- When a member visits 10 times their next standard ticket is free
```cs

```
- 

