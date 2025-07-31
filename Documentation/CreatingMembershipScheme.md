# Expanding the Loyalty Scheme to Include Gold Membership (10%)
In the workflow sections you must give clear instructions as to how to perform this workflow in your applcation. Use images and diagrams where necessary. Failure to give adequate instructions here may result in loss of marks.
To Simulate: Select the member from "PreMembers.txt"
This workflow should do the following things:
- Load information about members
 ```cs
--- Customer Menu ---
1. Sign In
2. Sign Up
3. Sign In As Guest
Select An Option: 1
Select An Option: 1
Enter Your Membership ID: pm02
Weclome Back Alan Turing - Status Non Member

```

 ```cs
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

```
To Simulate: Either during the transaction or before the transaction, the customer can choose Y/N to sign up for a gold membership
- Sell an annual membership to turn a loyalty scheme member into a gold member
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
--- Today's Screening Schedule ---
```

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
10:00 AM - Maze Runner - 130 mins - Rated: 12 | Screen: S01
01:00 PM - Holiday - 120 mins - Rated: 13 | Screen: S01
03:50 PM - Gladiator - 120 mins - Rated: 15 | Screen: S01
06:40 PM - Iron Man - 150 mins - Rated: 12 | Screen: S01
10:00 PM - Mufasa - 150 mins - Rated: PG | Screen: S01
10:00 AM - Maze Runner - 130 mins - Rated: 12 | Screen: S02
01:00 PM - Mufasa - 150 mins - Rated: PG | Screen: S02
04:20 PM - Gladiator - 120 mins - Rated: 15 | Screen: S02
07:10 PM - Iron Man - 150 mins - Rated: 12 | Screen: S02
10:30 PM - Holiday - 120 mins - Rated: 13 | Screen: S02

Select a movie screening: 1
Selected: Maze Runner at 10:00 AM on screen S01
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
How Many Popcorn Would You Like?: 4
4x Popcorn (£16.00)

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
How Many Soda Would You Like?: 2
2x Soda (£2.00)

Would You Like To Add More Concessions? (y/n): n
You Are Already A Gold Member.
Gold Member Discount Applied: 25%
--- Concession Summary ---
4 x Popcorn - £4.00 each
2 x Soda - £1.00 each
Total Concession Cost: £13.50
--- Ticket Summary ---
1 x Standard Ticket - Regular Seat - £8.00 each
Total Ticket Cost: £8.00
Grand Total: £21.50
Finalize Transaction? (y/n):
```

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
Select An Option: 3
--- Today's Screening Schedule ---
10:00 AM - Holiday - 120 mins - Rated: 13 | Screen: S01
12:50 PM - Iron Man - 150 mins - Rated: 12 | Screen: S01
04:10 PM - Mufasa - 150 mins - Rated: PG | Screen: S01
07:30 PM - Gladiator - 120 mins - Rated: 15 | Screen: S01
10:20 PM - Maze Runner - 130 mins - Rated: 12 | Screen: S01
10:00 AM - Iron Man - 150 mins - Rated: 12 | Screen: S02
01:20 PM - Maze Runner - 130 mins - Rated: 12 | Screen: S02
04:20 PM - Mufasa - 150 mins - Rated: PG | Screen: S02
07:40 PM - Gladiator - 120 mins - Rated: 15 | Screen: S02
10:30 PM - Holiday - 120 mins - Rated: 13 | Screen: S02
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
Enter Age For Customer 1: 18
Add Concessions? (y/n): n
You Are Currently Signed In As A Guest.
Would You Like To Sign Up For A Membership? (y/n)
n
Continuing as Guest.
--- Concession Summary ---
Total Concession Cost: £0.00
--- Ticket Summary ---
1 x Standard Ticket - Regular Seat - £8.00 each
Total Ticket Cost: £8.00
Grand Total: £8.00
Finalize Transaction? (y/n): y
Print Receipt? (y/n): n
Transaction Complete.
```

```cs
Would You Like To Add More Concessions? (y/n): n
You Are Already A Gold Member.
Gold Member Discount Applied: 25%
--- Concession Summary ---
4 x Popcorn - £4.00 each
2 x Soda - £1.00 each
Total Concession Cost: £13.50
--- Ticket Summary ---
1 x Standard Ticket - Regular Seat - £8.00 each
Total Ticket Cost: £8.00
Grand Total: £21.50
Finalize Transaction? (y/n):
```

Membership class now includes Gold status and expiry date. This allows the system to distinguish between regular and Gold members.
```cs
public class Membership
{
    public string ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Visits { get; set; }
    public bool IsGold { get; set; } // Indicates Gold membership status
    public DateTime? GoldExpiryDate { get; set; } // Expiry date for Gold membership

    // Constructor and other logic...
}
```

DataValidation provides a method to check if the Gold membership is expired. This abstracts the logic for determining Gold status validity.

```cs
public static bool IsGoldMembershipExpired(DateTime expiryDate)
{
    return DateTime.Now.Date > expiryDate.Date;
}
```



When loading members, ensure Gold status and expiry are read from the file. This enables the system to recognise and process Gold members.

```cs
if (part.StartsWith("[Gold:"))
    bool.TryParse(part.Replace("[Gold:", "").Replace("]", "").Trim(), out isGold);

if (part.StartsWith("[Expiry:"))
{
    string expiryText = part.Replace("[Expiry:", "").Replace("]", "").Trim();
    if (!string.IsNullOrEmpty(expiryText) && expiryText != "N/A")
    {
        if (DateTime.TryParse(expiryText, out var parsedDate))
            expiryDate = parsedDate;
    }
}
```
