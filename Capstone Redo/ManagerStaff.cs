using Capstone_Redo;
using System.Diagnostics;
public class ManagerStaff : Staff
{
    /// <summary>
    ///  Within THis Class Holds Manager-Level Staff Member With Additional Responsibilities And Functionality. 
    ///  Such As Managing Staff, Scheduling, Concessions Adding And Removing Staff. 
    /// </summary>

    // Initializes A New Instance Of The ManagerStaff Class With The Specified Staff ID, First Name, And Last Name.
    public ManagerStaff(string staffID, string firstName, string lastName)
        : base(staffID, firstName, lastName) { }


    // Represents The Role Of The Staff Member As A String
    public override string Role => "Manager";


    // Displays The Customer Menu For Manager Staff Members To Interact With Customers

    // Displays The Manager Options Menu For Manager Staff Members To Manage Staff, Transactions, And Concessions
    public void ShowManagerOptions()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("--- Manager Options ---");
            Console.WriteLine("1. Add Staff");
            Console.WriteLine("2. View Staff");
            Console.WriteLine("3. Remove Staff");
            Console.WriteLine("4. Set Sechedule");
            Console.WriteLine("5. Manage Concessions");
            Console.WriteLine("6. Start Transaction");
            Console.WriteLine("7. Exit Program");
            Console.Write("Select an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    StaffManagment.AddStaff();
                    break;
                case "2":
                    StaffManagment.ViewStaff();
                    break;
                case "3":
                    StaffManagment.RemoveStaff();
                    break;
                case "4":
                    ScheduleManager.LoadSchedule();
                    ScheduleManager.ScheduleMenu(); // Set Schedule
                    break;
                case "5":
                    ConcessionManager.InitializeConcessions();
                    ManageConcessions(); // Manage Concessions
                    break;
                case "6":
                    TransactionHub.StartTransaction(this); // Start A New Transaction
                    running = false; // Exit The Loop
                    break;

                case "7":

                    ExitProgram();
                    Environment.Exit(0);
                    break;

            }

        }

    }

    private void ManageConcessions()
    {
        bool running = true;
        while (running)
        {
           
            Console.WriteLine("--- Concession Management ---");
            Console.WriteLine("1. Add Concession");
            Console.WriteLine("2. Remove Concession");
            Console.WriteLine("3. View All Concessions");
            Console.WriteLine("4. Exit");
            Console.Write("Select An Option: ");
            string choice = Console.ReadLine()?.Trim();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter Concession Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Price (in pence): ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        ConcessionManager.AddConcession(name, price);
                    }
                    else
                    {
                        Console.WriteLine("Invalid price.");
                    }
                    break;
                case "2":

                    ConcessionManager.InitializeConcessions();
                    Console.Write("Enter ID of Concession to Remove: ");
                    string Input = Console.ReadLine();
                    ConcessionManager.RemoveConcession(Input);
                    break;
                case "3":
                    ConcessionManager.ViewConcessions();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Option. Try Again.");
                    break;
            }
        }
    }


    // Sets The Schedule For Staff Members. This Method Is Currently A Stub And Will Be Implemented Later To Handle Staff Scheduling Logic.
    private void SetSchedule()
    {
        Console.WriteLine("--- Set Schedule ---");

        Console.WriteLine("Set Schedule functionality is not implemented yet.");
        // Implement the logic to set staff schedules here
        string newID = Console.ReadLine();
    }


    // Views Staff Transactions. This Method Is Currently A Stub And Will Be Implemented Later To Handle Viewing Staff Transactions Logic.
    private void ViewStaffTransactions()
    {
        Console.WriteLine("--- View Staff Transactions ---");
        Console.WriteLine("View Staff Transactions functionality is not implemented yet.");
        // Implement the logic to view staff transactions here
        string newID = Console.ReadLine();
    }

    // Exits The Program 
    private void ExitProgram()
    {
        Console.WriteLine("Exiting program...");
        Environment.Exit(0);
    }
}