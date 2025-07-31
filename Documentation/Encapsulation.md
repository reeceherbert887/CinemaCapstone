# Encapsulation and Cohesion (10%)

Here you should describe how you have used Encapsulation and Cohesion in your solution.
Encapsulation protects the internal state of a class by restricting its data; instead, data is accessed and modified through public methods or propertied. This can help keep the code and program in tact and safe from updates or flase modifications.
Pros-
Data Safety: By using private fields in classes like Concession, Transaction, and Membership, you prevent unwanted or invalid access.
Controlled Access: Setters and getters ensure data is validated before it's changed (e.g., only allowing valid ticket prices or member types).
Simplified Debugging: Changes in one class don’t break others because the internal logic is self-contained.

Cons-
Extra Boilerplate: You need to write a lot of getters/setters, which increases code size.
Too Much Hiding: Over-encapsulation can hide logic that might be useful elsewhere (e.g., when debugging or testing).
Learning Curve: New developers may not understand how to interact with your class without digging through documentation.

cohesion, however, is more focused and related to the responsibilities of a class. a high-chesive class only performs one clear task (method field, etc)
pros-
Classes are easier to understand and maintain
Encourages reuse of well-defined components
Reduces unintended side effects and bugs

cons-
Too much fragmentation can lead to overly small or scattered classes
Developers may over-split logic into too many files
Some tasks may require coordination between multiple classes

You should use class diagrams and code snippets where appropriate.

```cs
+-------------------+         +----------------------+
|     Screen        |         |   DataValidation     |
+-------------------+         +----------------------+
| - ID              |         | (static methods)     |
| - NumPremiumSeats |         | - IsValidFirstName() |
| - NumStandardSeats|         | - IsValidEmail()     |
+-------------------+         | - IsValidAge()       |
| + TotalSeats      |         | - ...                |
| + ToString()      |         +----------------------+
+-------------------+
```

```cs
Here is an example of a code snippet in Markdown

internal static class DataValidation
{
    // All methods are related to validation, showing high cohesion
    public static bool IsValidFirstName(string name) { ... }
    public static bool IsValidEmail(string email) { ... }
    public static bool IsValidAge(int age) { ... }
    // etc.
}
```



