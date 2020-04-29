using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;

namespace TravelAgencies.Advertiser
{
    class Text : IAds
    {
        protected List<RevieW> reviews;
        protected List<TripPerDay> trips;

        string Country { get; set; }
        double AverRating;
        double SumPrice;

        public void getting(Agency agency)
        {
            (reviews, trips, AverRating, SumPrice) = agency.GetTxAds();
            Country = agency.Country;
        }

        public void posting()
        {
            PostText();
        }

        private void PostText()
        {
            string ratingAver = AverRating.ToString().Trim();
            string priceSum = SumPrice.ToString().Trim();
            ratingAver = "Rating: " + ratingAver;
            priceSum = "Price: " + priceSum;
            Console.WriteLine(ratingAver);
            Console.WriteLine(priceSum);
            Console.WriteLine();
            int i = 1;
            foreach (TripPerDay day in trips)
            {
                Console.WriteLine($"Day {i++} in {Country}!");
                Console.WriteLine($"Accommodation: {day.booking.Name}");
                Console.WriteLine("Attractions:");
                Console.WriteLine($"        {day.trip1.Names}");
                Console.WriteLine($"        {day.trip2.Names}");
                Console.WriteLine($"        {day.trip3.Names}");
            }
            Console.WriteLine();
        }
    }
}
