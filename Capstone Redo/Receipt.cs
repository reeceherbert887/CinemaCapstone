using System;
using System.Collections.Generic;

namespace Capstone_Redo
{
    public class Receipt
    {
        /// <summary>
        /// Within This Class, Holds The Base Information For The Receipt, This Includes The Receipt ID, Staff ID, Movie Title,
        /// </summary>

        public string ReceiptID { get; set; }
        public string StaffID { get; set; }
        public string MovieTitle { get; set; }
        public string TicketType { get; set; }
        public List<(string SeatType, decimal Price)> Seats { get; set; }
        public decimal TicketTotal { get; set; }
        public decimal ConcessionTotal { get; set; }
        public List<(string ItemName, int Quantity, decimal LineTotal)> ConcessionItems { get; set; }

        public Receipt(string receiptID, string staffID, string movieTitle, string ticketType, decimal ticketTotal)
        {
            ReceiptID = receiptID;
            StaffID = staffID;
            MovieTitle = movieTitle;
            TicketType = ticketType;
            TicketTotal = ticketTotal;

            Seats = new List<(string, decimal)>();
            ConcessionItems = new List<(string, int, decimal)>();
            ConcessionTotal = 0.00m;
        }

        public void AddSeat(string seatType, decimal price)
        {
            Seats.Add((seatType, price));
        }

        public void AddConcessionItem(string itemName, int quantity, decimal pricePerItem)
        {
            decimal lineTotal = quantity * pricePerItem;
            ConcessionItems.Add((itemName, quantity, lineTotal));
            ConcessionTotal += lineTotal;
        }

        public decimal FinalTotal()
        {
            return TicketTotal + ConcessionTotal;
        }

        public override string ToString()
        {
            string output = $"[ReceiptID:{ReceiptID}]%[StaffID:{StaffID}]%[Movie:{MovieTitle}]%[TicketType:{TicketType}]\n";

            output += "Seats:\n";
            foreach (var seat in Seats)
            {
                output += $"- {seat.SeatType}: £{seat.Price:F2}\n";
            }

            output += "Concessions:\n";
            foreach (var item in ConcessionItems)
            {
                output += $"- {item.Quantity}x {item.ItemName} (£{item.LineTotal:F2})\n";
            }

            output += $"Ticket Total: £{TicketTotal:F2}\n";
            output += $"Concession Total: £{ConcessionTotal:F2}\n";
            output += $"Final Total: £{FinalTotal():F2}";

            return output;
        }
    }
}
