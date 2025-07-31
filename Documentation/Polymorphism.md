# Polymorphism (10%)

Here you should describe how you have used Polymorphism in your solution.
within imy project, i made us of polymorphism to all differnt classes to respond to the same method in different ways depending on the circumstances. For example, the membership class included an abstract method called get discount that is overwritten by lyaty and gold memberships, which then allow for the logic and math for the entire transaction to start and be set in motion. The system simply calls member.GetDiscount() and the correct version runs. I also used override with methods like ToString() to control how objects are displayed when printed.

Pros-
Cleaner Code: You can just call member.GetDiscount() and the correct version (Gold or Loyalty) runs.
Flexible Behavior: You override ToString() in multiple classes to change how objects are printed — making output cleaner.
Easy to Maintain: You don’t need switch statements or type checks when working with different membership types.

Cons- 
Hidden Behavior: It’s not always obvious which version of a method is being executed at runtime.
Debugging Difficulty: If an overridden method has a bug, it may affect the program in ways that aren’t easy to trace.
Performance Cost: Virtual methods and dynamic dispatch may slightly reduce performance (though minimal in your case).


You should use class diagrams and code snippets where appropriate.
```cs
+-------------------+
|      Staff        |
+-------------------+
| - StaffID         |
| - FirstName       |
| - LastName        |
| + ShowOptions()   | <--- virtual
+-------------------+
        ^
        |
+-------------------+      +-------------------+
|  GeneralStaff     |      |  ManagerStaff     |
+-------------------+      +-------------------+
| + ShowOptions()   |      | + ShowOptions()   | <--- override
+-------------------+      +-------------------+
```
Here is an example of a code snippet in Markdown
```cs
public class Staff
{
    public string StaffID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Virtual method for displaying staff info
    public virtual void ShowOptions()
    {
        Console.WriteLine("General staff options.");
    }
}

public class GeneralStaff : Staff
{
    // Override to provide specific options for general staff
    public override void ShowOptions()
    {
        Console.WriteLine("Customer menu for general staff.");
    }
}

public class ManagerStaff : Staff
{
    // Override to provide specific options for managers
    public override void ShowOptions()
    {
        Console.WriteLine("Manager options menu.");
    }
}

// Example usage:
Staff staff = new ManagerStaff("M01", "Alice", "Smith");
staff.ShowOptions(); // Outputs: "Manager options menu."
```

```cs
public interface IValidator
{
    bool Validate(string input);
}

public class EmailValidator : IValidator
{
    public bool Validate(string input) => DataValidation.IsValidEmail(input);
}

public class NameValidator : IValidator
{
    public bool Validate(string input) => DataValidation.IsValidFirstName(input);
}

// Usage
IValidator validator = new EmailValidator();
bool isValid = validator.Validate("test@example.com"); // Uses EmailValidator logic

validator = new NameValidator();
isValid = validator.Validate("Michael"); // Uses NameValidator logic
```

```cs

```





