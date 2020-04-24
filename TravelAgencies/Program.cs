using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DataAccess;

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
            //----------

            while (true)
            {
				Console.Clear();
               
				//----------
				//YOUR CODE - run
				//----------

				//uncomment
				// Console.WriteLine("\n\n=======================FIRST PRESENT======================");
                // offerWebsite.Present();
                // Console.WriteLine("\n\n=======================SECOND PRESENT======================");
                // offerWebsite.Present();
                // Console.WriteLine("\n\n=======================THIRD PRESENT======================");
                // offerWebsite.Present();


                if (HandleInput()) break;
			}
		}
		bool HandleInput()
		{
			var key = Console.ReadKey(true);
			return key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Q;
		}
    }
}
