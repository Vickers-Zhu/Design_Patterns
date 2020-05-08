//I certify that this assignment is entirely my own work, \
//performed independently and without any help from the sources which are not allowed.
//Jiyi Zhu
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DataAccess;
using TravelAgencies.Agencies;
using TravelAgencies.Encryption;
using TravelAgencies.Advertiser;

namespace TravelAgencies
{
	class Program
	{
		static void Main(string[] args) { new Program().Run(); }

		private const int WebsitePermanentOfferCount = 2;
		private const int WebsiteTemporaryOfferCount = 3;
		private Random rd = new Random(257);

		//----------
		//YOUR CODE - additional fileds/properties/methods
		//----------

		public void Run()
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			(
				BookingDatabase accomodationData, 
				TripAdvisorDatabase tripsData, 
				ShutterStockDatabase photosData, 
				OysterDatabase reviewData
			) = Init.Init.Run();

            //----------
            //YOUR CODE - set up everything
            TakingElement taker = new TakingElement(accomodationData, tripsData, photosData, reviewData);
            Agency pl = new AgencyPL(new FactoryPL(taker), new Random(rd.Next(1, 10086)));
            Agency fr = new AgencyFR(new FactoryFR(taker), new Random(rd.Next(1, 10086)));
            Agency it = new AgencyIT(new FactoryIT(taker), new Random(rd.Next(1, 10086)));

            OfferWebsite offerWebsite = new OfferWebsite(WebsiteTemporaryOfferCount, WebsitePermanentOfferCount);
            offerWebsite.AddAgc(pl);
            offerWebsite.AddAgc(fr);
            offerWebsite.AddAgc(it);
            offerWebsite.AddOffers();
            //----------

            while (true)
            {
                Console.Clear();
                //----------
                //YOUR CODE - run
                //----------

                //uncomment
                Console.WriteLine("\n\n=======================FIRST PRESENT======================");
                offerWebsite.Present();
                Console.WriteLine("\n\n=======================SECOND PRESENT======================");
                offerWebsite.Present();
                Console.WriteLine("\n\n=======================THIRD PRESENT======================");
                offerWebsite.Present();

                if (HandleInput()) break;
            }
            Console.ReadLine();
		}
		bool HandleInput()
		{
			var key = Console.ReadKey(true);
			return key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Q;
		}
    }
}
