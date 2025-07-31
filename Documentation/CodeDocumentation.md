# Self commenting code and explicit comments (5%)

Describe how you have documented your code in terms of naming conventions for member variables and member methods, explicit comments (that add value and not clutter) and summary comments.

With a mixture of naminging conventions, single line commenting, summary comments, commits and naming convesntions i  belive i have made it straight forawrd to understand what each class and ench section is designed to do. as i throughout the code i have made it readable without exsesive use of commments. For example:
```cs
public string FirstName { get; set; }
public string MembershipNumber { get; set; }
public bool IsGoldMember { get; set; }

public void ShowGeneralMenu()
public void StartTransaction()
public void UpgradeToGold()
```

Straigh simple and easy to read and understand. As each method and member variables are unique and easy to read.

in terms of summary comments with this allowing users to use multiple lines at a time allwoing for ma much more condenced and easier viewing pleasure. 

```cs
GeneralStaff:
/// <summary>
/// The GeneralStaff class: is responsible for managing the general staff members of the cinema.
/// GeneralStaff members are responsible for handling transactions, adding tickets, concessions, and memberships.
/// </summary>

LoyaltyMember:
/// <summary>
/// The LoyaltyMember class is responsible for managing loyalty members,
/// storing key information such as name, email, phone number, and membership ID.
/// </summary>
now not only do they help me, but anyone who may be looking at the code.

i have also used occasionay inline comments just to mark key areas but i have taken them out as they was either to be potencial features or no longer necassery.

```
