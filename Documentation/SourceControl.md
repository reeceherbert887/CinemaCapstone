# User Interaction (10%)

You should use a reusable, object oriented menu system to manage user interaction. It should not be possible to crash the program with invalid or unexpected user input.

to manage the user interaction side of the capstone project, implemented a modular OOP (Object Oriented Programming) Menus System. With each major function of the system's ticket sales, concessions, scheduling and staff management all being accessible through clearly identifiable and labelled menus. I designed it by imagining the interface in the console to begin with, for example, i envisaged how the program would flow. 

To Simulate follow the console:

PM member gold member and GS staff
```cs
Welcome To Hullywood Cinema
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
Select An Option: 1
Enter Your Membership ID: pm01
Weclome Back Reece Herbert - Status Gold Member
--- Today's Screening Schedule ---
--- Movie Selection Menu ---
Staff Serving: GS01 - John
1. Holiday - 120 mins - Rated: 13 | Screen: S01 | Start Time: 10:00 AM
2. Iron Man - 150 mins - Rated: 12 | Screen: S01 | Start Time: 12:50 PM
3. Mufasa - 150 mins - Rated: PG | Screen: S01 | Start Time: 04:10 PM
4. Gladiator - 120 mins - Rated: 15 | Screen: S01 | Start Time: 07:30 PM
5. Maze Runner - 130 mins - Rated: 12 | Screen: S01 | Start Time: 10:20 PM
6. Holiday - 120 mins - Rated: 13 | Screen: S02 | Start Time: 10:00 AM
7. Maze Runner - 130 mins - Rated: 12 | Screen: S02 | Start Time: 12:50 PM
8. Mufasa - 150 mins - Rated: PG | Screen: S02 | Start Time: 03:50 PM
9. Gladiator - 120 mins - Rated: 15 | Screen: S02 | Start Time: 07:10 PM
10. Iron Man - 150 mins - Rated: 12 | Screen: S02 | Start Time: 10:00 PM
Select a movie screening: 1
Selected: Holiday at 10:00 AM on screen S01
Select Type:
1. Standard Ticket: £8
2. Premium Ticket: £12
2
Select Seat:
1. Regular Seat (No Cost)
2. VIP Seat (£3)
2
Enter Number Of Customers (max 5): 1
Enter Age For Customer 1: 18
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
How Many Popcorn Would You Like?: 5
5x Popcorn (£20.00)

Would You Like To Add More Concessions? (y/n): y
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
Which Item Would You Like? 2
How Many Soda Would You Like?: 1
1x Soda (£1.00)

Would You Like To Add More Concessions? (y/n): n
You Are Already A Gold Member.
Gold Member Discount Applied: 25%
--- Concession Summary ---
5 x Popcorn - £4.00 each
1 x Soda - £1.00 each
Total Concession Cost: £15.75
--- Ticket Summary ---
1 x Premium Ticket - VIP Seat - £12.00 each
Total Ticket Cost: £12.00
Grand Total: £27.75
Finalize Transaction? (y/n): y
Print Receipt? (y/n): n
Transaction Complete.

```
GS Pm Non gold memmber
```cs
Welcome To Hullywood Cinema
--- Main Menu ---
1. Sign In
2. View Transactions
3. Exit Program
Select An Option: 1
--- Staff Sign In ---
Enter Staff ID: gs02
Staff Number: GS02 - Jack
--- Customer Menu ---
1. Sign In
2. Sign Up
3. Sign In As Guest
Select An Option: 1
Enter Your Membership ID: pm02
Weclome Back Alan Turing - Status Non Member
--- Today's Screening Schedule ---
--- Movie Selection Menu ---
Staff Serving: GS02 - Jack
1. Maze Runner - 130 mins - Rated: 12 | Screen: S01 | Start Time: 10:00 AM
2. Holiday - 120 mins - Rated: 13 | Screen: S01 | Start Time: 01:00 PM
3. Gladiator - 120 mins - Rated: 15 | Screen: S01 | Start Time: 03:50 PM
4. Mufasa - 150 mins - Rated: PG | Screen: S01 | Start Time: 06:40 PM
5. Iron Man - 150 mins - Rated: 12 | Screen: S01 | Start Time: 10:00 PM
6. Gladiator - 120 mins - Rated: 15 | Screen: S02 | Start Time: 10:00 AM
7. Maze Runner - 130 mins - Rated: 12 | Screen: S02 | Start Time: 12:50 PM
8. Mufasa - 150 mins - Rated: PG | Screen: S02 | Start Time: 03:50 PM
9. Holiday - 120 mins - Rated: 13 | Screen: S02 | Start Time: 07:10 PM
10. Iron Man - 150 mins - Rated: 12 | Screen: S02 | Start Time: 10:00 PM
Select a movie screening: 2
Selected: Holiday at 01:00 PM on screen S01
Select Type:
1. Standard Ticket: £8
2. Premium Ticket: £12
1
Select Seat:
1. Regular Seat (No Cost)
2. VIP Seat (£3)
1
Enter Number Of Customers (max 5): 1
Enter Age For Customer 1: 18
Add Concessions? (y/n): n
Would You Like To Upgrade To Gold Member Status? (y/n)
n
You Chose Not To Upgrade To Gold Member Status.
--- Concession Summary ---
Total Concession Cost: £0.00
--- Ticket Summary ---
1 x Standard Ticket - Regular Seat - £8.00 each
Total Ticket Cost: £8.00
Grand Total: £8.00
Finalize Transaction? (y/n):
```
GS Pm becomes Non gold memmber
```cs
Welcome To Hullywood Cinema
--- Main Menu ---
1. Sign In
2. View Transactions
3. Exit Program
Select An Option: 1
--- Staff Sign In ---
Enter Staff ID: gs03
Staff Number: GS03 - Adam
--- Customer Menu ---
1. Sign In
2. Sign Up
3. Sign In As Guest
Select An Option: 1
Enter Your Membership ID: pm02
Weclome Back Alan Turing - Status Non Member
--- Today's Screening Schedule ---
--- Movie Selection Menu ---
Staff Serving: GS03 - Adam
1. Iron Man - 150 mins - Rated: 12 | Screen: S01 | Start Time: 10:00 AM
2. Maze Runner - 130 mins - Rated: 12 | Screen: S01 | Start Time: 01:20 PM
3. Mufasa - 150 mins - Rated: PG | Screen: S01 | Start Time: 04:20 PM
4. Holiday - 120 mins - Rated: 13 | Screen: S01 | Start Time: 07:40 PM
5. Gladiator - 120 mins - Rated: 15 | Screen: S01 | Start Time: 10:30 PM
6. Maze Runner - 130 mins - Rated: 12 | Screen: S02 | Start Time: 10:00 AM
7. Holiday - 120 mins - Rated: 13 | Screen: S02 | Start Time: 01:00 PM
8. Mufasa - 150 mins - Rated: PG | Screen: S02 | Start Time: 03:50 PM
9. Iron Man - 150 mins - Rated: 12 | Screen: S02 | Start Time: 07:10 PM
10. Gladiator - 120 mins - Rated: 15 | Screen: S02 | Start Time: 10:30 PM
Select a movie screening: 1
Selected: Iron Man at 10:00 AM on screen S01
Select Type:
1. Standard Ticket: £8
2. Premium Ticket: £12
1
Select Seat:
1. Regular Seat (No Cost)
2. VIP Seat (£3)
1
Enter Number Of Customers (max 5): 1
Enter Age For Customer 1: 20
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
Which Item Would You Like? 5
How Many HotDog Would You Like?: 1
1x HotDog (£5.00)

Would You Like To Add More Concessions? (y/n): n
Would You Like To Upgrade To Gold Member Status? (y/n)
y
You Have Been Upgraded To Gold Member Status.
Gold Member Discount Applied: 25%
--- Concession Summary ---
1 x HotDog - £5.00 each
Total Concession Cost: £3.75
--- Ticket Summary ---
1 x Standard Ticket - Regular Seat - £8.00 each
Total Ticket Cost: £8.00
Grand Total: £11.75
```
Guest becomes gold 
```cs
--- Customer Menu ---
1. Sign In
2. Sign Up
3. Sign In As Guest
Select An Option: 2
Enter First Name (6-20 Letters): amy
Enter Last Name (12-25 Letters): lee
Enter Email (Must Contain Number And Special Char): amyleet12@gmail.com
Enter UK Phone Number (##### ######): 07700 900123
New Member: Amy Lee NM06 - Status Non Member

Would You Like To Upgrade To Gold Member Status? (y/n)
y
You Have Been Upgraded To Gold Member Status.
Gold Member Discount Applied: 25%
--- Concession Summary ---
Total Concession Cost: £0.00
--- Ticket Summary ---
1 x Standard Ticket - Regular Seat - £8.00 each
Total Ticket Cost: £8.00
Grand Total: £8.00
Finalize Transaction? (y/n):
Would You Like To Upgrade To Gold Member Status? (y/n)
n
--- Concession Summary ---
Total Concession Cost: £0.00
--- Ticket Summary ---
1 x Standard Ticket - Regular Seat - £8.00 each
Total Ticket Cost: £8.00
Grand Total: £8.00
Finalize Transaction? (y/n):
```
Guest No members
```cs
--- Customer Menu ---
1. Sign In
2. Sign Up
3. Sign In As Guest
Select An Option: 2
Enter First Name (6-20 Letters): amy
Enter Last Name (12-25 Letters): lee
Enter Email (Must Contain Number And Special Char): amyleet12@gmail.com
Enter UK Phone Number (##### ######): 07700 900123
New Member: Amy Lee NM06 - Status Non Member

Would You Like To Upgrade To Gold Member Status? (y/n)

--- Concession Summary ---
Total Concession Cost: £0.00
--- Ticket Summary ---
1 x Standard Ticket - Regular Seat - £8.00 each
Total Ticket Cost: £8.00
Grand Total: £8.00
Finalize Transaction? (y/n):
y
Would You Like To Upgrade To Gold Member Status? (y/n)
n
--- Concession Summary ---
Total Concession Cost: £0.00
--- Ticket Summary ---
1 x Standard Ticket - Regular Seat - £8.00 each
Total Ticket Cost: £8.00
Grand Total: £8.00
Finalize Transaction? (y/n):
```
manager non member
```cs
--- Staff Sign In ---
Enter Staff ID: ms01
Staff Number: MS01 - Reece
--- Customer Menu ---
1. Sign In
2. Sign Up
3. Sign In As Guest
Select An Option: 1
Enter Your Membership ID: pm02
Weclome Back Alan Turing - Status Non Member
--- Today's Screening Schedule ---
--- Movie Selection Menu ---
Staff Serving: GS03 - Adam
1. Iron Man - 150 mins - Rated: 12 | Screen: S01 | Start Time: 10:00 AM
2. Maze Runner - 130 mins - Rated: 12 | Screen: S01 | Start Time: 01:20 PM
3. Mufasa - 150 mins - Rated: PG | Screen: S01 | Start Time: 04:20 PM
4. Holiday - 120 mins - Rated: 13 | Screen: S01 | Start Time: 07:40 PM
5. Gladiator - 120 mins - Rated: 15 | Screen: S01 | Start Time: 10:30 PM
6. Maze Runner - 130 mins - Rated: 12 | Screen: S02 | Start Time: 10:00 AM
7. Holiday - 120 mins - Rated: 13 | Screen: S02 | Start Time: 01:00 PM
8. Mufasa - 150 mins - Rated: PG | Screen: S02 | Start Time: 03:50 PM
9. Iron Man - 150 mins - Rated: 12 | Screen: S02 | Start Time: 07:10 PM
10. Gladiator - 120 mins - Rated: 15 | Screen: S02 | Start Time: 10:30 PM
Select a movie screening: 1
Selected: Iron Man at 10:00 AM on screen S01
Select Type:
1. Standard Ticket: £8
2. Premium Ticket: £12
1
Select Seat:
1. Regular Seat (No Cost)
2. VIP Seat (£3)
1
Enter Number Of Customers (max 5): 1
Enter Age For Customer 1: 20
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
Which Item Would You Like? 5
How Many HotDog Would You Like?: 1
1x HotDog (£5.00)

Would You Like To Add More Concessions? (y/n): n
Would You Like To Upgrade To Gold Member Status? (y/n)
y
You Have Been Upgraded To Gold Member Status.
Gold Member Discount Applied: 25%
--- Concession Summary ---
1 x HotDog - £5.00 each
Total Concession Cost: £3.75
--- Ticket Summary ---
1 x Standard Ticket - Regular Seat - £8.00 each
Total Ticket Cost: £8.00
Grand Total: £11.75
```
Manager Member
```cs
--- Staff Sign In ---
Enter Staff ID: ms01
Staff Number: MS01 - Reece
--- Customer Menu ---
1. Sign In
2. Sign Up
3. Sign In As Guest
Select An Option: 1
Enter Your Membership ID: pm01
Weclome Back Reece Herbert - Status Gold
--- Today's Screening Schedule ---
--- Movie Selection Menu ---
Staff Serving: GS03 - Adam
1. Iron Man - 150 mins - Rated: 12 | Screen: S01 | Start Time: 10:00 AM
2. Maze Runner - 130 mins - Rated: 12 | Screen: S01 | Start Time: 01:20 PM
3. Mufasa - 150 mins - Rated: PG | Screen: S01 | Start Time: 04:20 PM
4. Holiday - 120 mins - Rated: 13 | Screen: S01 | Start Time: 07:40 PM
5. Gladiator - 120 mins - Rated: 15 | Screen: S01 | Start Time: 10:30 PM
6. Maze Runner - 130 mins - Rated: 12 | Screen: S02 | Start Time: 10:00 AM
7. Holiday - 120 mins - Rated: 13 | Screen: S02 | Start Time: 01:00 PM
8. Mufasa - 150 mins - Rated: PG | Screen: S02 | Start Time: 03:50 PM
9. Iron Man - 150 mins - Rated: 12 | Screen: S02 | Start Time: 07:10 PM
10. Gladiator - 120 mins - Rated: 15 | Screen: S02 | Start Time: 10:30 PM
Select a movie screening: 1
Selected: Iron Man at 10:00 AM on screen S01
Select Type:
1. Standard Ticket: £8
2. Premium Ticket: £12
1
Select Seat:
1. Regular Seat (No Cost)
2. VIP Seat (£3)
1
Enter Number Of Customers (max 5): 1
Enter Age For Customer 1: 20
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
Which Item Would You Like? 5
How Many HotDog Would You Like?: 1
1x HotDog (£5.00)

Would You Like To Add More Concessions? (y/n): n
You Have Been Upgraded To Gold Member Status.
Gold Member Discount Applied: 25%
--- Concession Summary ---
1 x HotDog - £5.00 each
Total Concession Cost: £3.75
--- Ticket Summary ---
1 x Standard Ticket - Regular Seat - £8.00 each
Total Ticket Cost: £8.00
Grand Total: £11.75
```
Manager SCreens
```cs
--- Main Menu ---
1. Sign In
2. View Transactions
3. Exit Program
Select An Option: 1
--- Staff Sign In ---
Enter Staff ID: ms01
Staff Number: MS01 - Reece
--- Manager Options ---
1. Add Staff
2. View Staff
3. Remove Staff
4. Set Sechedule
5. Manage Concessions
6. Start Transaction
7. Exit Program
Select an option:

```
Manager SCreens
```cs
--- Staff Sign In ---
Enter Staff ID: ms01
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
```
Manager screen
```cs
--- Schedule Menu ---
1. View Today's Schedule
2. Add New Screening
3. Save Schedule
4. Exit Schedule Menu
Select An Option: 1
--- Today's Schedule ---
10:00 AM - Iron Man - 150 Mins - Rated: 12
01:20 PM - Mufasa - 150 Mins - Rated: PG
04:40 PM - Holiday - 120 Mins - Rated: 13
07:30 PM - Maze Runner - 130 Mins - Rated: 12
10:30 PM - Gladiator - 120 Mins - Rated: 15
10:00 AM - Mufasa - 150 Mins - Rated: PG
01:20 PM - Holiday - 120 Mins - Rated: 13
04:10 PM - Maze Runner - 130 Mins - Rated: 12
07:10 PM - Iron Man - 150 Mins - Rated: 12
10:30 PM - Gladiator - 120 Mins - Rated: 15
```
add it but Broken??
```cs
-- Schedule Menu ---
1. View Today's Schedule
2. Add New Screening
3. Save Schedule
4. Exit Schedule Menu
Select An Option: 2
Loaded 5 movies and 2 screens.
Enter your age: 20
Select a Movie:
1. Gladiator (Rating: 15)
2. Iron Man (Rating: 12)
3. Mufasa (Rating: PG)
4. Maze Runner (Rating: 12)
5. Holiday (Rating: 13)
1
Select a Screen:
1. S01
2. S02
1
Select a Time:
1. 10:00 AM
2. 12:00 PM
3. 2:00 PM
4. 4:00 PM
5. 6:00 PM
6. 8:00 PM
1
Screening added: Gladiator at 31/07/2025 10:00:00 AM on Screen S01
```

```cs
Select An Option: 1
--- Staff Sign In ---
Enter Staff ID: ms01
Staff Number: MS01 - Reece
--- Manager Options ---
1. Add Staff
2. View Staff
3. Remove Staff
4. Set Sechedule
5. Manage Concessions
6. Start Transaction
7. Exit Program
Select an option: 4
--- Schedule Menu ---
1. View Today's Schedule
2. Add New Screening
3. Save Schedule
4. Exit Schedule Menu
Select An Option: 1
--- Today's Schedule ---
10:00 AM - Gladiator - 120 Mins - Rated: 15
12:50 PM - Iron Man - 150 Mins - Rated: 12
04:10 PM - Holiday - 120 Mins - Rated: 13
07:00 PM - Mufasa - 150 Mins - Rated: PG
10:20 PM - Maze Runner - 130 Mins - Rated: 12
10:00 AM - Holiday - 120 Mins - Rated: 13
12:50 PM - Mufasa - 150 Mins - Rated: PG
04:10 PM - Gladiator - 120 Mins - Rated: 15
07:00 PM - Iron Man - 150 Mins - Rated: 12
10:20 PM - Maze Runner - 130 Mins - Rated: 12
--- Schedule Menu ---
1. View Today's Schedule
2. Add New Screening
3. Save Schedule
4. Exit Schedule Menu
Select An Option:
```
concessions
```cs
-- Manager Options ---
1. Add Staff
2. View Staff
3. Remove Staff
4. Set Sechedule
5. Manage Concessions
6. Start Transaction
7. Exit Program
Select an option: 5
--- Concession Management ---
1. Add Concession
2. Remove Concession
3. View All Concessions
4. Exit
Select An Option:
```
Concessions Broken
```cs
-- Concession Management ---
1. Add Concession
2. Remove Concession
3. View All Concessions
4. Exit
Select An Option: 3
--- Concessions ---
ID: CI01 | Item: Popcorn | Price £4
ID: CI02 | Item: Soda | Price £1
ID: CI03 | Item: Chocolate | Price £3
ID: CI04 | Item: Natchos | Price £6
ID: CI05 | Item: HotDog | Price £5
ID: CI06 | Item: Candy | Price £3
ID: CI01 | Item: Reese's | Price £2
ID: CI01 | Item: 0 | Price £0
ID: CI01 | Item: d | Price £2
```
Broken
```cs
--- Manager Options ---
1. Add Staff
2. View Staff
3. Remove Staff
4. Set Sechedule
5. Manage Concessions
6. Start Transaction
7. Exit Program
Select an option: 5
--- Concession Management ---
1. Add Concession
2. Remove Concession
3. View All Concessions
4. Exit
Select An Option: 1
Enter Concession Name: Jelly Bean
Enter Price (in pence): 2
Enter a new Concession ID (e.g., C01): 9
Invalid ID. Must Start with 'C' Followed By Digits.
Enter a new Concession ID (e.g., C01): C10
```
```cs

```
```cs

```
```cs

```

