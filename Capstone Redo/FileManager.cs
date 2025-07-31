using Capstone_Redo;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class FileManager
{
    /// <summary>
    /// Handles Loading Data, Staff, Members, Movies, Concessions And Tickets From Files
    ///Provides Methods To Load Staff, Members, Movies, Concessions, And Tickets From Specified Files.
    /// </summary>

    // Loads General And Manager Staff From Specified Files, Combines And displays Them in A List, For The Program To Read,
    public static List<Staff> LoadStaff(string generalFile, string managerFile)
    {
        var AllStaff = new List<Staff>();
        LoadFromFile(generalFile, false, AllStaff);
        LoadFromFile(managerFile, true, AllStaff);
        return AllStaff;
    }

    // Helper Method To Load Staff From A File Based On Its Role
    public static void LoadFromFile(string fileName, bool isManager, List<Staff> staffList)
    {
        string fullPath = Path.Combine("Data", fileName);

        if (!File.Exists(fullPath))
            return;

        foreach (var line in File.ReadAllLines(fullPath))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            // Only parse correct format
            if (!line.Contains("[ID:") || !line.Contains("%[FirstName:"))
            {
                Console.WriteLine($"Skipping invalid line: {line}");
                continue;
            }

            try
            {
                string[] parts = line.Split('%');

                string id = parts[0].Replace("[ID:", "").Replace("]", "").Trim();
                string firstName = parts[1].Replace("[FirstName:", "").Replace("]", "").Trim();
                string lastName = parts[2].Replace("[LastName:", "").Replace("]", "").Trim();
                string role = parts[3].Replace("[Role:", "").Replace("]", "").Trim().ToLower();

                if (isManager)
                    staffList.Add(new ManagerStaff(id, firstName, lastName));
                else
                    staffList.Add(new GeneralStaff(id, firstName, lastName));
            }
            catch
            {
                Console.WriteLine($"Failed to parse line in {fileName}: {line}");
            }
        }
    }

    // Load Members From File
    public static List<Membership> LoadMembers(string fileName)
    {
        var memberships = new List<Membership>();
        string fullPath = Path.Combine("Data", fileName);

        if (!File.Exists(fullPath)) return memberships;

        foreach (var line in File.ReadAllLines(fullPath))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split('%');

            string id = "";
            string firstName = "";
            string lastName = "";
            string email = "";

            int visits = 0;
            bool isGold = false;
            System.DateTime? expiryDate = null;

            foreach (var part in parts)
            {
                if (part.StartsWith("[ID:"))
                    id = part.Replace("[ID:", "").Replace("]", "").Trim();

                else if (part.StartsWith("[FirstName:"))
                    firstName = part.Replace("[FirstName:", "").Replace("]", "").Trim();

                else if (part.StartsWith("[LastName:"))
                    lastName = part.Replace("[LastName:", "").Replace("]", "").Trim();

                else if (part.StartsWith("[Email:"))
                    email = part.Replace("[Email:", "").Replace("]", "").Trim();

                else if (part.StartsWith("[Visits:"))
                    int.TryParse(part.Replace("[Visits:", "").Replace("]", "").Trim(), out visits);

                else if (part.StartsWith("[Gold:"))
                    bool.TryParse(part.Replace("[Gold:", "").Replace("]", "").Trim(), out isGold);

                else if (part.StartsWith("[Expiry:") || part.StartsWith("[Expirery:")) // allow both spellings
                {
                    string expiryText = part.Replace("[Expiry:", "").Replace("[Expirery:", "").Replace("]", "").Trim();
                    if (!string.IsNullOrEmpty(expiryText) && expiryText != "N/A")
                    {
                        if (System.DateTime.TryParse(expiryText, out var parsedDate))
                            expiryDate = parsedDate;
                    }
                }
            }

            memberships.Add(new Membership(id, firstName, lastName, email, visits, isGold, expiryDate));
        }

        return memberships;
    }




    //load Movies From File
    public static List<Movie> LoadMovies(string filePath)
    {
        var movies = new List<Movie>();
        string fullPath = Path.Combine("Data", filePath);

        if (!File.Exists(fullPath)) return movies;

        foreach (var line in File.ReadAllLines(fullPath))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split('%');
            if (parts.Length < 4)
            {
                // Ensure there are enough parts
                Console.WriteLine($"Invalid line format in {filePath}: {line}");
                continue;
            }
            string id = parts[0].Replace("[ID:", "").Replace("]", "").Trim();
            string title = parts[1].Replace("[Title:", "").Replace("]", "").Trim();
            int length = int.Parse(parts[2].Replace("[Length:", "").Replace("]", "").Trim());        // Line 149 ✅
            string rating = parts[3].Replace("[Rating:", "").Replace("]", "").Trim(); // Added

            movies.Add(new Movie(id, title, length, rating));
        }
        return movies;
    }

    // Load Concessions From file
    public static List<Concession> LoadConcessions(string fileName)
    {
        List<Concession> concessions = new List<Concession>();
        string path = Path.Combine("Data", fileName);

        if (!File.Exists(path))
            return concessions;

        foreach (var line in File.ReadAllLines(path))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split('%');
            string id = parts[0].Replace("[ID:", "").Replace("]", "").Trim();
            string item = parts[1].Replace("[Item:", "").Replace("]", "").Trim();
            string priceStr = parts[2].Replace("[Price:", "").Replace("]", "").Trim();

            if (decimal.TryParse(priceStr, out decimal price))
            {
                concessions.Add(new Concession(id, item, price));
            }
        }

        return concessions;
    }

    public static void SaveConcession(string fileName, Concession concession)
    {
        string path = Path.Combine("Data", fileName);
        int priceInPence = (int)(concession.Price);
        string line = $"[ID:{concession.ID}]%[Item:{concession.Item}]%[Price:{priceInPence}]";
        File.AppendAllLines(path, new[] { line });
    }


    public static void OverwriteConcessions(string fileName, List<Concession> concessions)
    {
        string path = Path.Combine("Data", fileName);
        List<string> lines = new List<string>();

        foreach (var concession in concessions)
        {
            int priceInPence = (int)(concession.Price);
            lines.Add($"[ID:{concession.ID}]%[Item:{concession.Item}]%[Price:{priceInPence}]");
        }

        File.WriteAllLines(path, lines);
    }

    // Load Ticket Types From File
    public static List<Ticket> LoadTickets(string fileName)
    {
        var tickets = new List<Ticket>();
        string fullPath = Path.Combine("Data", fileName);
        if (!File.Exists(fullPath)) return tickets;
        foreach (var line in File.ReadAllLines(fullPath))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            string[] parts = line.Split('%');
            if (parts.Length < 3) continue; // Ensure there are enough parts
            string id = parts[0].Replace("[ID:", "").Replace("]", "").Trim();
            string type = parts[1].Replace("[Type:", "").Replace("]", "").Trim();
            decimal price = decimal.Parse(parts[2].Replace("[Price:", "").Replace("]", "").Trim());
            tickets.Add(new Ticket(type, "Regular", 1, price));
        }
        return tickets;
    }

    public static void SaveReceipt(TransactionMenu transaction, string staffID, string staffName)
    {
        string filePath = "CRReceipts.txt";
        StringBuilder receipt = new StringBuilder();

        receipt.Append($"[ID:{staffID}]%%");
        receipt.Append($"[Name:{staffName}]%");
        receipt.Append("[Items]%");
        receipt.Append($"Movie: {transaction.SelectedMovie.Title}%");
        receipt.Append($"TicketType: {transaction.SelectedTicket.TicketType} x{transaction.NumberOfCustomers}%");
        receipt.Append($"SeatType: {transaction.SeatType}%");

        foreach (var concession in transaction.SelectedConcessions)
        {
            receipt.Append($"{concession.Quantity} x {concession.Item.Item} - £{concession.Item.Price:F2} each%%");
        }

        receipt.Append($"Total: £{transaction.Total:F2}%%");

        File.AppendAllText(filePath, receipt.ToString() + Environment.NewLine);
    }

    public static List<Screen> LoadScreens(string path)
    {
        List<Screen> screens = new List<Screen>();

        if (!File.Exists(path))
            return screens;

        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            try
            {
                string[] parts = line.Split('%', StringSplitOptions.RemoveEmptyEntries);

                string id = parts[0].Replace("[ID:", "").Replace("]", "").Trim();
                int premium = int.Parse(parts[1].Replace("[NumPremiumSeats:", "").Replace("]", "").Trim());
                int standard = int.Parse(parts[2].Replace("[NumStandardSeats:", "").Replace("]", "").Trim());

                screens.Add(new Screen(id, premium, standard));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to parse screen line: {line}\nError: {ex.Message}");
            }
        }

        return screens;
    }

    public static Movie GetMovieByID(string movieID)
    {
        var movies = LoadMovies("CRMovies.txt");
        return movies.FirstOrDefault(m => m.ID.Equals(movieID, StringComparison.OrdinalIgnoreCase));
    }


    public static List<Schedule> LoadSchedule(string dateFile)
    {
        var schedules = new List<Schedule>();
        string fullPath = Path.Combine("Data", dateFile);
        if (!File.Exists(fullPath)) return schedules;
        foreach (var line in File.ReadAllLines(fullPath))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            string[] parts = line.Split('%');
            if (parts.Length < 4) continue; // Ensure there are enough parts
            string id = parts[0].Replace("[ID:", "").Replace("]", "").Trim();
            string movieId = parts[1].Replace("[MovieID:", "").Replace("]", "").Trim();
            System.DateTime startTime = System.DateTime.Parse(parts[2].Replace("[StartTime:", "").Replace("]", "").Trim());
            string screenId = parts[3].Replace("[ScreenID:", "").Replace("]", "").Trim();
            schedules.Add(new Schedule(id, movieId, startTime, screenId));
        }
        return schedules;
    }

    public static void SaveSchedule(string dateFile, List<Schedule> schedules)
    {
        string fullPath = Path.Combine("Data", dateFile);
        List<string> lines = new List<string>();
        foreach (var schedule in schedules)
        {
            lines.Add($"[ID:{schedule.ID}]%[MovieID:{schedule.MovieID}]%[StartTime:{schedule.StartTime:yyyy-MM-dd HH:mm:ss}]");
        }
        File.WriteAllLines(fullPath, lines);
    }

    public static bool ConcessionIDExists(string id)
    {
        var lines = File.ReadAllLines("CRConcessions.txt");
        return lines.Any(line => line.Contains($"[ID:{id}]"));
    }

    public static bool MovieIDExists(string id)
    {
        var lines = File.ReadAllLines("CRMovies.txt");
        return lines.Any(line => line.Contains($"[ID:{id}]"));
    }


}