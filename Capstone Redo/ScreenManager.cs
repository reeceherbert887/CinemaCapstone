using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Redo
{
    public static class ScreenManager
    {
        private static List<Screen> AllScreens = new List<Screen>();

        public static void InitializeScreens()
        {
            AllScreens = FileManager.LoadScreens("CRScreens.txtx");
        }
        public static void DisplayScreens()
        {
            Console.WriteLine("--- Screens ---");
            foreach (var s in AllScreens)
            {
                Console.WriteLine($"{s.ID} - Premium: {s.NumPremiumSeats}, Standard: {s.NumStandardSeats}");
            }
        }

        public static Screen GetScreenByID(string id)
        {
            return AllScreens.FirstOrDefault(s => s.ID.Equals(id, StringComparison.OrdinalIgnoreCase));
        }
    }
}
