using System;

namespace Capstone_Redo
{
    /// <summary>
    /// Represents a movie ticket with type, seat, price, and quantity.
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Type of ticket (Standard or Premium).
        /// </summary>
        public string TicketType { get; set; }

        /// <summary>
        /// Seat type (VIP or Regular).
        /// </summary>
        public string SeatType { get; set; }

        /// <summary>
        /// Number of tickets.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price per unit ticket.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Total price of all tickets.
        /// </summary>
        public decimal TotalPrice => UnitPrice * Quantity;

        /// <summary>
        /// Constructs a Ticket object with given details.
        /// </summary>
        public Ticket(string ticketType, string seatType, int quantity, decimal unitPrice)
        {
            TicketType = ticketType;
            SeatType = seatType;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}