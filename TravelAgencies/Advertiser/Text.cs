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

        private int? times;

        public Text(int? times)
        {
            this.times = times;
        }

        public void getting(Agency agency)
        {
            (reviews, trips, AverRating, SumPrice) = agency.GetTxAds();
            Country = agency.Country;
        }

        public void posting()
        {
            if (this.times != null)
            {
                if (this.times <= 0)
                {
                    Console.WriteLine("This offer is expired");
                    Console.WriteLine();
                    return;
                } 
                this.times--;
            }
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
            foreach (RevieW review in reviews)
            {
                switch (Country)
                {
                    case "Poland":
                        Console.Write($"{review.UserName.Replace('e', 'ę').Replace('a', 'ą')}: ");
                        Console.WriteLine($"{review.Review.Replace('e', 'ę').Replace('a', 'ą')}.");
                        break;
                    case "Italy":
                        Console.Write($"Dello_{review.UserName}: ");
                        Console.WriteLine($"{review.Review}.");
                        break;
                    case "France":
                        string[] words = review.Review.Split(' ');
                        string newRw = "";
                        foreach (string wd in words)
                        {
                            string la = "la";
                            if (wd.Length >= 4) la = wd;
                            newRw += la + " ";
                        }
                        newRw = newRw.Trim();
                        Console.Write($"{review.UserName}: ");
                        Console.WriteLine($"{newRw}.");
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}
