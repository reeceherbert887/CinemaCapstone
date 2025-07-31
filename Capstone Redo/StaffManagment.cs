using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Capstone_Redo
{
    /// <summary>
    /// This Staff Managment Class Ha Become The Main Point Of Accsess For Staff. 
    /// </summary>
    public static class StaffManagment
    {
        private static readonly string GeneralPath = Path.Combine("Data", "CRGeneralStaff.txt");
        private static readonly string ManagerPath = Path.Combine("Data", "CRManagerStaff.txt");

        public static void AddStaff()
        {
            

            Console.WriteLine("--- Add Staff ---");

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


            Console.WriteLine("Select Role:");
            Console.WriteLine("1. General Staff");
            Console.WriteLine("2. Manager Staff");
            string input = Console.ReadLine();

            bool isManager = input == "2";

            string newID = GenerateNewID(isManager);
            if (newID == null)
            {
                Console.WriteLine("Maximum Staff Limit Reached.");
                return;
            }

            string role = isManager ? "manager" : "general staff";
            string newEntry = $"[ID:{newID}]%[FirstName:{firstName}]%[LastName:{lastName}]%[Role:{role}]";
            string path = isManager ? ManagerPath : GeneralPath;

            File.AppendAllText(path, newEntry + Environment.NewLine);
            Console.WriteLine($"New Staff Member Added: ID:{newID}, Name: {firstName} {lastName}");
        }

        public static void ViewStaff()
        {
            Console.WriteLine("--- Staff List ---");

            var staffFiles = new[] { "Data/CRGeneralStaff.txt", "Data/CRManagerStaff.txt" };

            foreach (var file in staffFiles)
            {
                if (!File.Exists(file)) continue;

                var lines = File.ReadAllLines(file);

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split('%');

                    if (parts.Length < 4)
                    {
                        Console.WriteLine("Skipping Invalid Line.");
                        continue;
                    }
                    try
                    {

                        string id = parts[0].Replace("[ID:", "").Replace("]", "").Trim();
                        string first = parts[1].Replace("[FirstName:", "").Replace("]", "").Trim();
                        string last = parts[2].Replace("[LastName:", "").Replace("]", "").Trim();
                        string role = parts[3].Replace("[Role:", "").Replace("]", "").Trim();

                        Console.WriteLine($"ID: {id} | Name: {first} {last} | Role: {role}");
                    }
                    catch
                    {
                        Console.WriteLine("Skipping Invalid Line.");
                    }
                }
            }


        }


        public static void RemoveStaff()
        {
            Console.Write("Enter Staff ID To Remove: ");
            string inputID = Console.ReadLine().Trim().ToUpper();

            bool removed = TryRemoveFromFile(GeneralPath, inputID) || TryRemoveFromFile(ManagerPath, inputID);

            Console.WriteLine(removed ? "Staff Removed Successfully." : "Staff Not Found.");
        }

        private static bool TryRemoveFromFile(string path, string id)
        {
            if (!File.Exists(path)) return false;

            var lines = File.ReadAllLines(path).ToList();
            int originalCount = lines.Count;

            lines = lines.Where(l => !l.Contains($"[ID:{id}]")).ToList();
            File.WriteAllLines(path, lines);

            return lines.Count < originalCount;
        }

        private static string GenerateNewID(bool isManager)
        {
            string prefix = isManager ? "MS" : "GS";
            int max = isManager ? 3 : 10;

            string path = isManager ? ManagerPath : GeneralPath;

            if (!File.Exists(path)) return $"{prefix}01";

            var lines = File.ReadAllLines(path);
            var numbers = new List<int>();

            foreach (string line in lines)
            {
                Match match = Regex.Match(line, $@"\[ID:{prefix}(\d+)\]");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int number))
                {
                    numbers.Add(number);
                }
            }

            for (int i = 1; i <= max; i++)
            {
                if (!numbers.Contains(i))
                {
                    return $"{prefix}{i:00}";
                }
            }

            return null; // No available slot
        }

        private static string Capitalise(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "";
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}