using System;
using System.Collections.Generic;
using System.Linq;

namespace Capstone_Redo
{
    public class MovieSelection
    {
        private static int requiredAge;

        /// <summary>
        /// Handles displaying scheduled movies and letting general staff select from them.
        /// </summary>
        public static void MovieMenu(Staff servingStaff, TransactionMenu transaction)
        {


            List<Schedule> scheduleList = ScheduleManager.GetTodaySchedule();
            if (scheduleList == null || scheduleList.Count == 0)
            {
                Console.WriteLine("No scheduled movies available today.");
                return;
            }



            Console.WriteLine("--- Movie Selection Menu ---");
            Console.WriteLine($"Staff Serving: {servingStaff.StaffID} - {servingStaff.FirstName}");

            for (int i = 0; i < scheduleList.Count; i++)
            {
                var schedule = scheduleList[i];
                var movie = FileManager.GetMovieByID(schedule.MovieID); // Requires helper
                if (movie != null)
                {
                    Console.WriteLine($"{i + 1}. {movie.Title} - {movie.Length} mins - Rated: {movie.Rating} | Screen: {schedule.ScreenID} | Start Time: {schedule.StartTime:hh:mm tt}");
                }
            }

            Console.Write("Select a movie screening: ");
            if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 1 || selection > scheduleList.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Schedule selectedSchedule = scheduleList[selection - 1];
            Movie selectedMovie = FileManager.GetMovieByID(selectedSchedule.MovieID);

            transaction.SelectedMovie = selectedMovie;
            transaction.ScreenID = selectedSchedule.ScreenID;
            transaction.ScreenTime = selectedSchedule.StartTime;

            Console.WriteLine($"Selected: {selectedMovie.Title} at {selectedSchedule.StartTime:hh:mm tt} on screen {selectedSchedule.ScreenID}");

            // Proceed with ticket type
            Console.WriteLine("Select Type:");
            Console.WriteLine("1. Standard Ticket: £8");
            Console.WriteLine("2. Premium Ticket: £12");
            string ticketOption = Console.ReadLine();

            Console.WriteLine("Select Seat:");
            Console.WriteLine("1. Regular Seat (No Cost)");
            Console.WriteLine("2. VIP Seat (£3)");
            string seatOption = Console.ReadLine();
            transaction.SeatType = seatOption == "2" ? "VIP" : "Regular";

            int numCustomers = -1;

            // Group size validation
            do
            {
                Console.Write("Enter Number Of Customers (max 5): ");
                if (!int.TryParse(Console.ReadLine(), out numCustomers) || numCustomers < 1 || numCustomers > 5)
                {
                    Console.WriteLine("Group Size Must Be Between 1 And 5.");
                    numCustomers = -1; // Force retry
                }
            }
            while (numCustomers == -1);

            // Save number of customers to transaction
            transaction.NumberOfCustomers = numCustomers;

            // Get the required age for the movie
            int requiredAge = GetRequiredAgeForRating(selectedMovie.Rating); // Make sure selectedMovie is passed correctly

            // Ask for each customer’s age
            for (int i = 1; i <= numCustomers; i++)
            {
                int customerAge = -1;

                do
                {
                    Console.Write($"Enter Age For Customer {i}: ");
                    if (!int.TryParse(Console.ReadLine(), out customerAge) || customerAge < 0)
                    {
                        Console.WriteLine("Invalid Age. Enter a Valid Number.");
                        customerAge = -1; // Retry
                    }
                }
                while (customerAge == -1);

                if (!DataValidation.IsAgeAllowed(customerAge, requiredAge))
                {
                    Console.WriteLine($"Customer {i} is not old enough to see this movie (min age {requiredAge}). Transaction cancelled.");
                    return; // Stop the transaction
                }
            }

            // Create ticket after age validation
            Ticket ticket = ticketOption == "2"
                ? new Ticket("Premium", seatOption, numCustomers, 12.00m)
                : new Ticket("Standard", seatOption, numCustomers, 8.00m);

            transaction.SelectedTicket = ticket;


            Console.Write("Add Concessions? (y/n): ");
            if (Console.ReadLine().Trim().ToLower() == "y")
                transaction.SelectedConcessions = ConcessionSelection.ShowConcessionsMenu();

            MembershipManager.HandleOtherMembers();

            TransactionHub.Hub(transaction);
            TransactionPrinter.PrintSummary(transaction);

            Console.Write("Finalize Transaction? (y/n): ");
            if (Console.ReadLine().Trim().ToLower() == "y")
            {
                Console.Write("Print Receipt? (y/n): ");
                if (Console.ReadLine().Trim().ToLower() == "y")
                {
                    FileManager.SaveReceipt(transaction, servingStaff.StaffID, servingStaff.FirstName);
                }
                Console.WriteLine("Transaction Complete.");
            }
            else
            {
                Console.WriteLine("Transaction Cancelled.");
            }
        }
    

    /// <summary>
/// Converts age rating string to required minimum age.
/// </summary>
public static int GetRequiredAgeForRating(string rating)
        {
            return rating switch
            {
                "U" => 0,
                "12" => 12,
                "15" => 15,
                "18" => 18,
                _ => 0
            };
        }
    }
}