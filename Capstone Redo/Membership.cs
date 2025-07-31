using System;
using System.Collections.Generic;

namespace Capstone_Redo
{

    /// <summary>
    /// Within This Class, Holds The Base Information For The Membership, This Includes The ID, First Name, Last Name, Email,
    /// </summary>

    public class Membership
    {
        // Unique IDEntifier For The Membership, e.g., "PM01"
        public string ID { get; private set; }
        // First Name Of The Member, e.g., "John"
        public string FirstName { get; private set; }
        // Last Name Of The Member, e.g., "Doe"
        public string LastName { get; private set; }
        // Email Address Of The Member, e.g., "
        public string Email { get; private set; }
        // Visits Made By The Member, e.g., 5
        public int Visits { get; set; }
        // Gold Membership Status, e.g., True or False
        public bool GoldMember { get; set; }
        // Expiry Date Of The Membership, e.g., 2023-12-31
        public System.DateTime? ExpiryDate { get; set; }


        // Constructor To Initialize The Membership With ID, First Name, And Email
        public Membership(string id, string firstName, string lastName, string email, int visits = 0, bool goldMember = false, System.DateTime? expiryDate = null)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName; // Set To Empty For Now, As You're Not Using It From File
            Email = email;
            Visits = visits;
            GoldMember = goldMember;
            ExpiryDate = expiryDate;

        }
        public override string ToString() => $"{FirstName} {LastName} [{ID}] Visits:{Visits} Gold:{GoldMember} Exp:{ExpiryDate?.ToShortDateString() ?? "N/A"}";
    }
}