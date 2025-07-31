# Inheritance for Code Reuse (10%)

Here you should describe how you have used Inheritance for Code Reuse in your solution.

Within my program, I used Encapsulation to protect class data and ensure that each object can only be used in valid ways, for example, in the Concession, Membership, Transaction and private classes. I used inheritance to avoid code duplication and created base classes like staf and membership to types like membership and gold membership that inherit form shared behevior from their basease classes. which allows for flexibility and working with different categories and types of data. 

Pros- 
Code Reuse: The Staff and Membership base classes reduce duplication between GeneralStaff, ManagerStaff, LoyaltyMembership, and GoldMembership.
Organized Structure: Inherited relationships keep your class hierarchy clean and predictable.
Easier Expansion: You can easily create new staff or membership types without rewriting shared logic.

Cons-
Tight Coupling: Subclasses depend on their base classes — changes to Staff might break ManagerStaff and GeneralStaff.
Limited Flexibility: A class can only inherit from one base class (C# doesn’t support multiple inheritance).
Can Be Misused: It’s tempting to overuse inheritance where composition might be better (e.g., nesting features instead of extending).

You should use class diagrams and code snippets where appropriate.

```cs
+-------------------+
|      Staff        |
+-------------------+
| - StaffID         |
| - FirstName       |
| - LastName        |
| + ShowInfo()      |
+-------------------+
        ^
        |
+-------------------+      +-------------------+
|  GeneralStaff     |      |  ManagerStaff     |
+-------------------+      +-------------------+
| + CustomerMenu()  |      | + ShowManagerOptions() |
+-------------------+      +-------------------+
```

Here is an example of a code snippet in markdown
```cs
// Base class for all staff members
public class Staff
{
    public string StaffID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Staff(string staffID, string firstName, string lastName)
    {
        StaffID = staffID;
        FirstName = firstName;
        LastName = lastName;
    }

    // Common method for all staff
    public virtual void ShowInfo()
    {
        Console.WriteLine($"{StaffID}: {FirstName} {LastName}");
    }
}

// Derived class for general staff
public class GeneralStaff : Staff
{
    public GeneralStaff(string staffID, string firstName, string lastName)
        : base(staffID, firstName, lastName) { }

    // Additional methods specific to general staff
    public void CustomerMenu() { /* ... */ }
}

// Derived class for manager staff
public class ManagerStaff : Staff
{
    public ManagerStaff(string staffID, string firstName, string lastName)
        : base(staffID, firstName, lastName) { }

    // Additional methods specific to managers
    public void ShowManagerOptions() { /* ... */ }
}
```
```cs
public class Ticket
{
    public string Type { get; set; }
    public decimal Price { get; set; }
}

public class GoldTicket : Ticket
{
    public decimal Discount { get; set; }
}
```
```cs
public class ValidationException : Exception
{
    public ValidationException(string message) : base(message) { }
}

public class EmailValidationException : ValidationException
{
    public EmailValidationException(string message) : base(message) { }
}
```

