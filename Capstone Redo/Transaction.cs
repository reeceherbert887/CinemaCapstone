using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Redo
{
    /// <summary>
    /// Within This Class Holds, The Transaction Menu of Movies, Tickets, Concession StaffID And Totals For The Project. Stores all customer choices for a transaction. Such As Selected Movie, Ticket, Seat Type,
    /// Number Of Customers, Customer Ages, Selected Concessions, Ticket Total, Concession Total, And Overall Total.
    /// </summary>

    public class TransactionMenu
    {
        /// <summary>
        /// 
        /// </summary>
        public Movie SelectedMovie { get; set; }
        public Ticket SelectedTicket { get; set; }
        public string SeatType { get; set; }
        public int NumberOfCustomers { get; set; }
        public List<int> CustomerAges { get; set; } = new List<int>();
        public List<(Concession Item, int Quantity)> SelectedConcessions { get; set; } = new List<(Concession, int)>();

        public decimal TicketTotal { get; set; }
        public decimal ConcessionTotal { get; set; }
        public decimal Total { get; set; }

        // Scheduling Info
        public DateTime ScreenTime { get; set; }
        public string ScreenID { get; set; }

        
        public string ReceiptID { get; set; }

        public override string ToString()
        {
            string movieTitle = SelectedMovie?.Title ?? "N/A";
            string ticketType = SelectedTicket?.TicketType ?? "N/A";
            string concessions = SelectedConcessions.Count > 0
                ? string.Join(", ", SelectedConcessions.ConvertAll(c => c.Item))
                : "None";

            return $"Movie: {movieTitle} | Ticket: {ticketType} | Seat: {SeatType} | Customers: {NumberOfCustomers} | Concessions: {concessions} | Screen: {ScreenID} | Time: {ScreenTime:hh\\:mm tt}";
        }

    }
}