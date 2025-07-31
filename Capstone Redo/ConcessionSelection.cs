using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Capstone_Redo
{
    public static class ConcessionSelection
    {
        /// <summary>
        /// Within This Class, Holds The Methods To Handle The Concession Selection Menu.
        /// </summary>
        /// <returns></returns>
        public static List<(Concession Item, int Quantity)> ShowConcessionsMenu()
        {
            //Load All Concessions From File
            List<Concession> concessions = FileManager.LoadConcessions("CRConcessions.txt");
            var selectedConcessions = new List<(Concession, int)>();

            bool adding = true;

            while (adding)
            {

                Console.WriteLine("--- Concessions ---");

                //Display Full Menu: Item + Price
                for (int i = 0; i < concessions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {concessions[i].Item} - £{concessions[i].Price:F2}");
                }

                // Ask User Which Concession They Want
                Console.Write("Which Item Would You Like? ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > concessions.Count)
                {
                    Console.WriteLine("Invalid Selection. Please Try Again.");
                    continue;
                }

                Concession selected = concessions[choice - 1];

                // Ask How Many Of That Concession
                Console.Write($"How Many {selected.Item} Would You Like?: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 1)
                {
                    Console.WriteLine("Invalid Quantity. Try Again.");
                    continue;
                }

                // Add To List
                selectedConcessions.Add((selected, quantity));
                Console.WriteLine($"{quantity}x {selected.Item} (£{selected.Price * quantity:F2})");

                // Instead Of Typing 0 → Ask Yes/No If They Want More
                Console.Write("\nWould You Like To Add More Concessions? (y/n): ");
                string more = Console.ReadLine()?.Trim().ToLower();

                if (more != "y") // Anything Other Than 'y' Stops
                {
                    adding = false;
                }
            }

            return selectedConcessions;
        }
    }
}