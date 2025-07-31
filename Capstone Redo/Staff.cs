using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Redo
{
    public abstract class Staff
    {
        /// <summary>
        /// Within This Class, Holds The Base Information For The Staff Member, This Includes The Staff ID, First Name, Last Name, And Role.
        /// </summary>

        // Unique Identifier For The Staff Member IE: GS01, MS01
        public string StaffID { get; private set; }
        // First Name Of The Staff Member IE: John
        public string FirstName { get; private set; }
        // Last Name Of The Staff Member IE: Doe
        public string LastName { get; private set; }

        // Constructor To Initialize The Staff Member With ID, First Name, And Last Name
        public Staff(string staffID, string firstName, string lastName)
        {
            StaffID = staffID;
            FirstName = firstName;
            LastName = lastName;
        }

        public abstract string Role { get; }
        // Returns A String Representation Of The Staff Member
        public override string ToString()
        {
            return $"{FirstName} {LastName} ({Role})";
        }
    }
}
