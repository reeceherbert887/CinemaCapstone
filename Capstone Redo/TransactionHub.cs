using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Redo
{
    public static class TransactionHub
    {
        /// <summary>
        /// Within This Class, Holds The Methods To Handle The Transaction Hub
        ///</summary>
        public static void Hub(TransactionMenu transaction)
        {
            // Base Total 
            transaction.TicketTotal = transaction.SelectedTicket.UnitPrice * transaction.NumberOfCustomers;
            transaction.ConcessionTotal = transaction.SelectedConcessions.Sum(c => c.Item.Price * c.Quantity);

            // Member Check
            var current = MembershipManager.CurrentMember;

            if (current !=null)
            {
                if (DateTimeManager.Expired(current.ExpiryDate))
                {
                    current.GoldMember= false;
                    current.ExpiryDate = null;
                    Console.WriteLine("Your Gold Membership Has Expired. You Are No Longer A Gold Member.");
                }

                // If Gold Member -> Apply Discount
                if (current.GoldMember)
                {
                    Console.WriteLine("Gold Member Discount Applied: 25%");
                    transaction.ConcessionTotal *= 0.75m; // 25% Discount
                }

                current.Visits++;
            }
            transaction.Total = transaction.TicketTotal + transaction.ConcessionTotal;
        }

        /// StartTransaction Triggers The Same Flow As GeneralStaff
        public static void StartTransaction(Staff ServingStaff)
        {


            // Show The Membership Menu (Sign In / Sign Up / Guest)
            MembershipManager.MembershipMenu();



            // Create a Transaction For This Manager Session
            var transaction = new TransactionMenu();

            // Proceed to MovieSelection
            MovieSelection.MovieMenu(ServingStaff, transaction);
        }
    }

}