using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;

namespace TravelAgencies.Advertiser
{
    class Graphic : IAds
    {
        protected List<Photo> photos;
        protected List<TripPerDay> trips;
        string Country { get; set; }

        public void getting(Agency agency)
        {
            (photos, trips) = agency.GetPtAds();
            Country = agency.Country;
        }

        public void posting()
        {
            PostGraph();
        }
      
        private void PostGraph()
        {
            foreach (Photo photo in photos)
            {
                switch (Country)
                {
                    case "Poland":
                        Console.Write($"{photo.Name.Replace('s', 'ś').Replace('c', 'ć')}");
                        break;
                    case "Italy":
                        Console.Write($"Dello_{photo.Name}");
                        break;
                    case "France":
                        Console.Write($"{photo.Name}");
                        break;
                }
                Console.WriteLine($" ({photo.WidthPx}x{photo.HeightPx})");
            }
            Console.WriteLine();
        }
    }
}
