using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Redo
{
    public static class DateTimeManager
    {
        /// <summary>
        /// Within This Class, Holds The Methods To Handle Date And Time Operations.
        /// </summary>

        public static string GetCurrentDateTime()
        {
            var now = System.DateTime.Now;
            return now.ToString("dd/mm/yyyy");
        }

        public static string FormatedDate(System.DateTime date)
        {
            // Format The Date As A String
            return date.ToString("dd/mm/yyy");
        }

        public static bool Expired(System.DateTime? expiryDate)
        {
            if (!expiryDate.HasValue) return false; // No Expiry Date Means Not Expired

            return expiryDate.Value < System.DateTime.Now;

        }
    }
}
