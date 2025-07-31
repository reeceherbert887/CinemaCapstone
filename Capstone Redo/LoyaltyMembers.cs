using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Redo
{
    /// <summary>
    /// Within This Class, Holds The Information For Loyalty Members, Including Their ID, Name, Email, Visits, Gold Membership Status, And Expiry Date.
    ///</summary>
    public class LoyaltyMembers : Membership
    {
        public LoyaltyMembers(string id, string firstName, string lastName, string email, int visits = 0, bool goldMember = false, System.DateTime? expiryDate = null)
            : base(id, firstName, lastName, email, visits, goldMember, expiryDate =null)
        {
        }

        public decimal GetDiscount()
        {
            // Example Logic For Discount Calculation
            if (GoldMember)
            {
                return 0.75m; // 25% Discount For Gold Members
            }
            else if (Visits > 10)
            {
                return 0.10m; // 10% Discount For Members With More Than 10 Visits
            }
            return 0.0m; // No Discount
        }
    }
}
