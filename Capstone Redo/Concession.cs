using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Redo
{
    /// <summary>
    /// Holds Information About The Concessions That Are Available To Purchase At The Cinema
    /// </summary>
    public class Concession
    {
        public string ID { get; set; }// Unique Identifier For The Concession Item
        public string Item { get; set; }// Name Of The Concession Item
        public decimal Price { get; set; }// Price of the concession item as a decimal

        // Constructor To Initialize The Concession Item With ID, Name, And Price
        public Concession(string id, string item, decimal price)
        {
            ID = id;
            Item = item;
            Price = price;
        }

        // Returns A String Representation Of The Concession Item
        public override string ToString()
        {
            return $"ID: {ID} | Item: {Item} | Price £{Price}";
        }
    }
}