# Self commenting code and explicit comments (5%)

Describe how you have documented your code in terms of naming conventions for member variables and member methods, explicit comments (that add value and not clutter) and summary comments.

With a brand new clean version of a repositpry the commits are fare more up to date and clear, i have uses a collection os summary and in line comments to keep track of my program and what it is doing. 


```cs
/ Checks if the provided email is valid using .NET's MailAddress class.
// Returns false if the email is empty or not in a valid format.
public static bool IsValidEmail(string email)
{
    if (string.IsNullOrWhiteSpace(email))
        return false;

    try
    {
        var addr = new MailAddress(email);
        return addr.Address == email;
    }
    catch
    {
        return false;
    }
}

 ```
