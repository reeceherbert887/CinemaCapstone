using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Capstone_Redo
{
    public static class MembershipManager
    {
        /// <summary>
        /// Within This Class, Holds The Methods To Handle Memberships, This Includes Signing In, Adding New Members,
        /// Offering Gold Memberships, And Handling Other Members.
        /// </summary>

        // Tracks Member of Users Signed In or New Members
        public static Membership CurrentMember { get; set; }
        private static List<Membership> AllMembers = new List<Membership>();

        public static void InitializeMemberships()
        {
            // Initialize Predefined Memberships
            AllMembers = FileManager.LoadMembers("CRPreMembers.txt");
        }

        public static void MembershipMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("--- Customer Menu ---");
                Console.WriteLine("1. Sign In");
                Console.WriteLine("2. Sign Up");
                Console.WriteLine("3. Sign In As Guest");
                Console.Write("Select An Option: ");
                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        SignIn();
                        running = false;
                        break;

                    case "2":
                        AddNewMember();
                        running = false;
                        break;

                    case "3":
                        Console.WriteLine("\nProceeding as Guest...");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid Option. Try Again.");
                        break;
                }
            }
        }

        public static void SignIn()
        {
            Console.Write("Enter Your Membership ID: ");
            string id = Console.ReadLine()?.Trim();

            var found = AllMembers.Find(m =>
            m.ID.Equals(id, StringComparison.OrdinalIgnoreCase)
        ) ?? AllMembers.Find(m =>
            m.ID.Equals(id, StringComparison.OrdinalIgnoreCase)
        );

            if (found != null)
            {
                string status = found.GoldMember ? "Gold Member" : "Non Member";
                Console.WriteLine($"Weclome Back {found.FirstName} {found.LastName} - Status {status}");
                CurrentMember = found;
            }
            else
            {
                Console.WriteLine("\nMembership ID Not Found. Please Try Again.");
                CurrentMember = null; // No Member Selected
            }

        }

        public static void AddNewMember()
        {
            string firstName, lastName, email, phone;
            int age;
            // First Name
            do
            {
                Console.Write("Enter First Name : ");
                string firstInput = Console.ReadLine();
                if (!DataValidation.IsValidFirstName(firstInput))
                {
                    Console.WriteLine("Invalid First Name.");
                    continue;
                }
                firstName = DataValidation.CapitalizeFirstLetters(firstInput);
                break;
            } while (true);

            // Last Name
            do
            {
                Console.Write("Enter Last Name: ");
                string firstInput = Console.ReadLine();
                if (!DataValidation.IsValidLastName(firstInput))
                {
                    Console.WriteLine("Invalid Last Name.");
                    continue;
                }
                lastName = DataValidation.CapitalizeFirstLetters(firstInput);
                break;
            } while (true);




            do
            {
                Console.Write("Enter Email (Must Contain Number And Special Char): ");
                email = Console.ReadLine();
                if (!DataValidation.IsValidEmail(email))
                    Console.WriteLine("Invalid Email.");
            } while (!DataValidation.IsValidEmail(email));

            do
            {
                Console.Write("Enter UK Phone Number (##### ######): ");
                phone = Console.ReadLine();
                if (!DataValidation.IsValidPhoneNumber(phone))
                    Console.WriteLine("Invalid Phone Number. Must Be In UK Format.");
            }
            while (!DataValidation.IsValidPhoneNumber(phone));

            //Capalize First and Last Names
            firstName = char.ToUpper(firstName[0]) + firstName.Substring(1).ToLower();
            lastName = char.ToUpper(lastName[0]) + lastName.Substring(1).ToLower();

            //creates A New Membership ID
            string newID = "NM" + (AllMembers.Count + 1).ToString("D2");
            // Creates and Adds New Member
            var nm = new Membership(newID, firstName, lastName, email);
            AllMembers.Add(nm);


            string status = nm.GoldMember ? "Gold Member" : "Non Member";
            Console.WriteLine($"New Member: {nm.FirstName} {nm.LastName} {nm.ID} - Status {status}");
            CurrentMember = nm;
        }
        public static void OfferGoldMember()
        {
            // Always Pull From MembershipManager
            var current = MembershipManager.CurrentMember;

            // Only Offer If Someone Is Signed In AND Not Already Gold
            if (current != null && !current.GoldMember)
            {
                Console.WriteLine("Would You Like To Upgrade To Gold Member Status? (y/n)");
                string upgradeChoice = Console.ReadLine()?.Trim().ToLower();

                if (upgradeChoice != "y")
                {
                    current.GoldMember = true;
                    current.ExpiryDate = DateTime.Now.AddYears(1); // Set Expiry To 1 Year From Now
                    Console.WriteLine("You Have Been Upgraded To Gold Member Status.");

                    //Save The Updated Member Information TBI
                }

                else if (current?.GoldMember == true)
                {
                    Console.WriteLine("You a" +
                        "Are Already a Gold Member.");
                }
                else
                {
                    Console.WriteLine("You Chose Not To Upgrade To Gold Member Status.");
                }
            }

        }
        public static void HandleOtherMembers()
        {
            //If Guest, Offer Signup
            if (CurrentMember == null)
            {
                Console.WriteLine("You Are Currently Signed In As A Guest.");
                Console.WriteLine("Would You Like To Sign Up For A Membership? (y/n)");
                string OtherMemberchoice = Console.ReadLine()?.Trim().ToLower();

                if (OtherMemberchoice == "y")
                {
                    // Proceed to Add New Member
                    AddNewMember();
                    //Must Be A Member To Be Gold Member
                    OfferGoldMember();
                }
                else
                {
                    Console.WriteLine("Continuing as Guest.");
                }
                return;
            }
            // If Already Gold -> Skip
            if (CurrentMember.GoldMember)
            {
                Console.WriteLine("You Are Already A Gold Member.");
                return;
            }

            // If Standard -> Offer Upgrade
            Console.WriteLine("Would You Like To Upgrade To Gold Member Status? (y/n)");
            string upgradeChoice = Console.ReadLine()?.Trim().ToLower();

            if (upgradeChoice == "y")
            {
                CurrentMember.GoldMember = true;
                CurrentMember.ExpiryDate = DateTime.Now.AddYears(1); // Set Expiry To 1 Year From Now
                Console.WriteLine("You Have Been Upgraded To Gold Member Status.");
                //Save The Updated Member Information TBI
            }
            else
            {
                Console.WriteLine("You Chose Not To Upgrade To Gold Member Status.");
            }
        }
    }
}