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

        private int? times;

        public Graphic(int? times)
        {
            this.times = times;
        }

        public void getting(Agency agency)
        {
            (photos, trips) = agency.GetPtAds();
            Country = agency.Country;
        }

        public void posting()
        {
            if (this.times != null)
            {
                if (this.times <= 0) return;
                this.times--;
            }
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
