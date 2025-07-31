using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Redo
{
    public class Screen
    {
        public string ID { get; set; } // Unique Identifier For The Screen IE: S01
        public int NumPremiumSeats { get; set; } // Name Of The Screen IE: "Screen 1"
        public int NumStandardSeats { get; set; } // Seating Capacity Of The Screen IE: 100


        public Screen(string id, int numPremiumSeats, int numStandardSeats)
        {
            ID = id;
            NumPremiumSeats = numPremiumSeats;
            NumStandardSeats = numStandardSeats;
        }

        // Returns A String Representation Of The Screen
        public int TotalSeats => NumPremiumSeats + NumStandardSeats;
        public override string ToString()
        {
            return $"{ID} - {NumPremiumSeats} Premium Seats, {NumStandardSeats} Standard Seats (Total: {TotalSeats})";
        }

    }



}