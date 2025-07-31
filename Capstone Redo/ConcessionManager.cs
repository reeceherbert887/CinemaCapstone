using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Capstone_Redo
{
    public class ConcessionManager
    {
        private const string FilePath = "CRConcessions.txt";
        public static List<Concession> AllConcessions = new List<Concession>();


        public static void InitializeConcessions()
        {
            AllConcessions = FileManager.LoadConcessions(FilePath);
        }




        public static void AddConcession(string Item, decimal Price)
        {
            string concessionID;
            do
            {
                Console.Write("Enter a new Concession ID (e.g., C01): ");
                concessionID = Console.ReadLine().Trim();

                if (!DataValidation.IsValidConcessionID(concessionID))
                {
                    Console.WriteLine("Invalid ID. Must Start with 'C' Followed By Digits.");
                    concessionID = null;
                    continue;
                }

                if (FileManager.ConcessionIDExists(concessionID))
                {
                    Console.WriteLine("ID Already Exists. Please Enter a Unique One.");
                    concessionID = null;
                }
            }
            while (string.IsNullOrEmpty(concessionID));

            // Use the validated ID directly
            var NewConcession = new Concession(concessionID, Item, Price);

            AllConcessions.Add(NewConcession);
            FileManager.SaveConcession(FilePath, NewConcession);

            Console.WriteLine($"{NewConcession} Has Been Added Cuccessfully.");
        }


        public static bool RemoveConcession(string identifier)
        {
            var ItemToRemove = AllConcessions.FirstOrDefault(c =>
        c.ID.Equals(identifier, StringComparison.OrdinalIgnoreCase) ||
        c.Item.Equals(identifier, StringComparison.OrdinalIgnoreCase));

            if (ItemToRemove != null)
            {
                AllConcessions.Remove(ItemToRemove);
                FileManager.OverwriteConcessions(FilePath, AllConcessions);
                Console.WriteLine("Concession Removed Successfully.");
                return true;
            }
            else
            {
                Console.WriteLine($"Concession '{identifier}' Not Found.");
                return false;
            }
        }

        public static void ViewConcessions()
        {
            Console.WriteLine("--- Concessions ---");
            if (AllConcessions.Count == 0)
            {
                Console.WriteLine("No Concessions Avaiable.");
                return;
            }

            foreach (var concession in AllConcessions)
            {
                Console.WriteLine(concession.ToString());
            }
        }

        private static string GenerateConcessionID()
        {
            if (!File.Exists(FilePath)) return "CI01";

            var lines = File.ReadAllLines(FilePath);
            var numbers = new List<int>();

            foreach (string line in lines)
            {
                Match match = Regex.Match(line, @"\[ID:CI0(\d+)\]");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int number))
                {
                    numbers.Add(number);
                }
            }

            for (int i = 1; i <= 99; i++)
            {
                if (!numbers.Contains(i))
                {
                    return $"CI0{i:00}";
                }
            }

            return null; // No available slot
        }
    }
}