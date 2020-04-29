using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.Agencies
{
    interface IBooking
    {
        Booking Booking { get; }
    }

    class Booking
    {
        public string Name { get; set; }
        public string Rating { get; set; }//Encrypted
        public string Price { get; set; }//Encrypted

        public Booking(string Name, string Rating, string Price)
        {
            this.Name = Name;
            this.Rating = Rating;
            this.Price = Price;
        }
    }
}
