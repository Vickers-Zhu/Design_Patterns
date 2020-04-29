using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Encryption;
using TravelAgencies.Advertiser;

namespace TravelAgencies.Agencies
{
    abstract class Agency
    {
        protected List<Photo> photos;
        protected List<RevieW> reviews;
        protected List<TripPerDay> trips;
        protected int days;
        public abstract string Country { get; }

        public abstract void Accept(IAds ads);

        public Agency(AgencyFactory factory, Random r)
        {
            Overdue(factory, r);
        }

        public void Overdue(AgencyFactory factory, Random r)
        {
            photos = new List<Photo>();
            reviews = new List<RevieW>();
            trips = new List<TripPerDay>();

            this.days = r.Next(1, 4);
            for (int i = 0; i < this.days; i++)
            {
                Trip trip1 = null;
                Trip trip2 = null;
                Trip trip3 = null;
                Booking booking = null;
                Photo photo = null;
                while (trip1 == null) trip1 = factory.CreateTrip().Trip;
                while (trip2 == null) trip2 = factory.CreateTrip().Trip;
                while (trip3 == null) trip3 = factory.CreateTrip().Trip;
                while (booking == null) booking = factory.CreateBooking();
                trips.Add(new TripPerDay(trip1, trip2, trip3, booking));

                while (photo == null) photo = factory.CreatePhoto().Photo;
                photos.Add(photo);
            }
        }

        protected double AverRating()
        {
            if (trips == null) return 0.0;
            double result = 0.0;

            foreach (TripPerDay day in trips)
            {
                result += double.Parse(day.trip1.Ratings) +
                    double.Parse(day.trip2.Ratings) +
                    double.Parse(day.trip3.Ratings) + 
                    double.Parse(day.booking.Rating);
            }
            result /= trips.Count() * 4.0;
            return result;
        }

        protected double SumPrice()
        {
            if (trips == null) return 0.0;
            double result = 0.0;
            foreach (TripPerDay day in trips)
            {
                result += double.Parse(day.trip1.Prices) +
                    double.Parse(day.trip2.Prices) +
                    double.Parse(day.trip3.Prices) +
                    double.Parse(day.booking.Price);
            }
            return result;
        }

        public (List<Photo>, List<TripPerDay>) GetPtAds()
        {
            return (photos, trips);
        }

        public (List<RevieW>, List<TripPerDay>, double, double) GetTxAds()
        {
            return (reviews, trips, AverRating(), SumPrice());
        }
    }
}
