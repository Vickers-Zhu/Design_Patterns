using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DataAccess;

namespace TravelAgencies.Agencies
{
    abstract class AgencyFactory : ITravelAgency
    {
        public abstract IPhoto CreatePhoto();
        public abstract IReview CreateReview();
        public abstract ITrip CreateTrip();
        public abstract Booking CreateBooking();
        protected TakingElement taker;
        public AgencyFactory(TakingElement taker)
        {
            this.taker = taker;
        }
    }

    class FactoryPL : AgencyFactory
    {
        public FactoryPL(TakingElement taker) : base(taker) { }

        public override IPhoto CreatePhoto()
        {
            return new PhotoPL(taker.GetPhoto());
        }

        public override IReview CreateReview()
        {
            return new ReviewPL(taker.GetReview());
        }

        public override ITrip CreateTrip()
        {
            return new TripPL(taker.GetTrip());
        }

        public override Booking CreateBooking()
        {
            return taker.GetBooking();
        }
    }

    class FactoryIT : AgencyFactory
    {
        public FactoryIT(TakingElement taker) : base(taker) { }

        public override IPhoto CreatePhoto()
        {
            return new PhotoIT(taker.GetPhoto());
        }

        public override IReview CreateReview()
        {
            return new ReviewIT(taker.GetReview());
        }

        public override ITrip CreateTrip()
        {
            return new TripIT(taker.GetTrip());
        }

        public override Booking CreateBooking()
        {
            return taker.GetBooking();
        }
    }

    class FactoryFR : AgencyFactory
    {
        public FactoryFR(TakingElement taker) : base(taker) { }

        public override IPhoto CreatePhoto()
        {
            return new PhotoFR(taker.GetPhoto());
        }

        public override IReview CreateReview()
        {
            return new ReviewFR(taker.GetReview());
        }

        public override ITrip CreateTrip()
        {
            return new TripFR(taker.GetTrip());
        }

        public override Booking CreateBooking()
        {
            return taker.GetBooking();
        }
    }
}
