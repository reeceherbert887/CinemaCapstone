# Abstraction (10%)

What is abstraction?
With in my project, i have used abstraction to cover up large logic sets behind clean, simple interfaces. and separate the responsibilities across classes. For example, in my "manager classes" that hold a lot of the logic and  keep them separate from the other classes that house the interface. I used the file manager to read (and to attempt to write however, again, i was unable to write to the file. By using abstraction to well abstract key information, it makes the program a lot smoother and less brittle and prone to breaking. 

Pros-
Simplifies Use: Classes like FileManager handle complex file logic behind a simple interface (e.g., LoadConcessions()).
Separation of Concerns: Your logic-heavy manager classes are separate from UI/menu classes, keeping the program modular.
Less Fragile Code: Changes in one class don’t ripple out because other parts interact with abstractions, not implementations.

Cons-
Harder to Understand Internals: Debugging or extending a class might be tough without seeing how the abstraction works underneath.
Overhead of Interface Design: Designing abstract base classes or interfaces (like Membership) requires careful planning.
Incomplete Abstraction: If the abstraction layer is poorly designed (e.g., your file writing logic), it can break functionality or make it harder to debug.

Example of Membership abstraction:
```cs
public string ID { get; private set; }
// First Name Of The Member, e.g., "John"
public string FirstName { get; private set; }
// Last Name Of The Member, e.g., "Doe"

public decimal GetDiscount()
```
Screen class abstracts the concept of a cinema screen. It exposes properties for ID and seat counts, hiding implementation details. Other parts of the program interact with Screen objects without knowing how data is stored.
```cs
public class Screen
{
    public string ID { get; set; } // Unique Identifier For The Screen IE: S01
    public int NumPremiumSeats { get; set; } // Name Of The Screen IE: "Screen 1"
    public int NumStandardSeats { get; set; } // Seating Capacity Of The Screen IE: 100
```
Data Validation class abstracts all input validation logic. Other classes use these static methods to ensure data integrity without needing to know the specific validation rules.
```cs
internal static class DataValidation
{
    public static bool IsValidFirstName(string name) =>
        !string.IsNullOrWhiteSpace(name) &&
        name.Length >= 6 && name.Length <= 20 &&
        Regex.IsMatch(name, @"^[A-Za-z]+$");
```

```cs
+-------------------+         +----------------------+
|      Movie        |         |      FileManager     |
+-------------------+         +----------------------+
| - ID              |         | (static methods)     |
| - Title           |         | + LoadMovies()       |
| - Length          |         | + LoadScreens()      |
| - Rating          |         | + LoadSchedule()     |
+-------------------+         +----------------------+
| + ToString()      |
+-------------------+
```
