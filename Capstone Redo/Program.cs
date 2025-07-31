using Capstone_Redo;
using System;
using System.Collections;
using System.Collections.Generic;

public static class Program
{

    /// <summary>
    /// Entry Point For The Hullywood Cinema Program, This Is Also Where The Handaling Of The User Interaction Begins And Is Stored
    /// 
    /// </summary>

    public static void Main(string[] args)
    {
        Program.Welcome();
    }

    public static void Welcome()
    {
        Console.WriteLine("Welcome To Hullywood Cinema");


        Console.WriteLine("--- Main Menu ---");
        Console.WriteLine("1. Sign In");
        Console.WriteLine("2. View Transactions");
        Console.WriteLine("3. Exit Program");
        Console.Write("Select An Option: ");

        string option = Console.ReadLine();

        if (option == "1")
            SignIn();
        else if (option == "3")
            Environment.Exit(0);
        else
        {
            Console.WriteLine("Invalid Option. Press Any Key To Return To Menu...");
            Console.ReadKey();
            Welcome();
        }
    }

    private static void SignIn()
    {
        Console.WriteLine("--- Staff Sign In ---");
        Console.Write("Enter Staff ID: ");
        string inputID = Console.ReadLine().Trim().ToUpper();

        // Load Staff Data From Files
        var staffList = FileManager.LoadStaff("CRGeneralStaff.txt", "CRManagerStaff.txt");
        // DEBUG: Print loaded staff IDs to verify file reading

        // Matching Staff ID
        Staff staff = staffList.Find(s => s.StaffID.Equals(inputID, StringComparison.OrdinalIgnoreCase));

        if (staff != null)
        {
            // Staff Found, Display Their Information
            Console.WriteLine($"Staff Number: {staff.StaffID} - {staff.FirstName}");

            // Initialize Memberships
            MembershipManager.InitializeMemberships();

            // Ready to go to Membership Menu next
            if (staff is ManagerStaff managerStaff)
            {
                ScheduleManager.InitializeSchedule();
                managerStaff.ShowManagerOptions();
            }
            else if (staff is GeneralStaff generalStaff)
            {
                generalStaff.CustomerMenu();
            }
            else
            {
                Console.WriteLine("Unknown Staff Type. Press Any Key To Return To Menu...");
                Console.ReadKey();
                Welcome();
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Press Any Key To Return To Menu...");
            Console.ReadKey();
            Welcome();
        }
    }
}