using Capstone_Redo;
using System.Data.Common;
using System.Transactions;

public class GeneralStaff : Staff
{
    /// <summary>
    /// Within This Class Holds The General Staff Member In The Cinema System. Inherits From Staff Class. 
    /// Aswell As Implements The Customer Menu. And Basic Transaction
    /// </summary>

    // Initializes A General Staff Member With Their Unique ID, First Name, And Last Name
    public GeneralStaff(string staffID, string firstName, string lastName)
        : base(staffID, firstName, lastName) { }


    // Represents The Role Of The Staff Member As A String
    public override string Role => "General Staff";

    // Displays The Customer Menu For General Staff Members To Interact With Customers
    public void CustomerMenu()
    {
        Console.WriteLine("--- Customer Menu ---");
        Console.WriteLine("1. Sign In");
        Console.WriteLine("2. Sign Up");
        Console.WriteLine("3. Sign In As Guest");
        Console.Write("Select An Option: ");
        string choice = Console.ReadLine();

        Membership membership = null; // Initialize member to null for guest sign-in
        TransactionMenu transaction = new TransactionMenu();  // ✅ Declare the transaction up front

        switch (choice)
        {


            case "1":
                MembershipManager.SignIn();
                ScheduleManager.InitializeSchedule();
                ScheduleManager.ShowScreeningSchedule();       // ✅ Correctly called from ScheduleManager
                MovieSelection.MovieMenu(this, transaction);
                break;

            case "2":
                MembershipManager.AddNewMember();
                ScheduleManager.InitializeSchedule();
                ScheduleManager.ShowScreeningSchedule();       // ✅ Correct usage
                MovieSelection.MovieMenu(this, transaction);
                break;

            case "3":
                ScheduleManager.InitializeSchedule();
                ScheduleManager.ShowScreeningSchedule();       // ✅ Correct usage
                MovieSelection.MovieMenu(this, transaction);
                break;

            default:
                Console.WriteLine("Invalid Option.");
                break;
        }
    }

    private void TransactionAndSchedule(TransactionMenu transaction)
    {
        var ScheduleList = ScheduleManager.GetTodaySchedule();

        if (ScheduleList.Count == 0)
        {
            Console.WriteLine("Np Screening Scheduled Today");
            return;
        }

        Console.WriteLine("--- Today's Screenings ---");
        for (int i = 0; i < ScheduleList.Count; i++)
        {
            var sched = ScheduleList[i];
            var movie = FileManager.LoadMovies("CRMovies.txt").Find(m => m.ID == sched.MovieID);
            if (movie != null)
            {
                Console.WriteLine($"{i + 1}. {sched.StartTime:hh\\:mm tt} - {movie.Title} - {movie.Length} mins - Rated: {movie.Rating} (Screen {sched.ScreenID})");
            }
        }
        Console.Write("Select a screening by number: ");
        if (!int.TryParse(Console.ReadLine(), out int selected) || selected < 1 || selected > ScheduleList.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        var chosenSchedule = ScheduleList[selected - 1];
        transaction.ScreenTime = chosenSchedule.StartTime;
        transaction.ScreenID = chosenSchedule.ScreenID;

    }
}