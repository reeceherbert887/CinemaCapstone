using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Redo
{
    public static class TransactionPrinter
    {
        /// <summary>
        /// Within This Class, Holds The Methods To Print The Summary Of The Transaction
        ///</summary>
        public static void PrintSummary(TransactionMenu transaction)
        {
            if (transaction == null) return;

            Console.WriteLine("--- Concession Summary ---");
            foreach (var concession in transaction.SelectedConcessions)
            {
                Console.WriteLine($"{concession.Quantity} x {concession.Item.Item} - £{concession.Item.Price:F2} each");
            }
            Console.WriteLine($"Total Concession Cost: £{transaction.ConcessionTotal:F2}");
            Console.WriteLine("--- Ticket Summary ---");
            Console.WriteLine($"{transaction.NumberOfCustomers} x {transaction.SelectedTicket.TicketType} Ticket - {transaction.SeatType} Seat - £{transaction.SelectedTicket.UnitPrice:F2} each");
            Console.WriteLine($"Total Ticket Cost: £{transaction.TicketTotal:F2}");
            Console.WriteLine($"Grand Total: £{transaction.Total:F2}");
        }
    }

}
