using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.Agencies
{
    public interface ITrip
    {
        Trip Trip { get;  }
    }

    public class Trip
    {
        public string Names { get; set; }
        public string Prices { get; set; }//Encrypted
        public string Ratings { get; set; }//Encrypted
        public string Countries { get; set; }

        public Trip(string Names, string Prices, string Ratings, string Countries)
        {
            this.Names = Names;
            this.Prices = Prices;
            this.Ratings = Ratings;
            this.Countries = Countries;
        }
    }
}
