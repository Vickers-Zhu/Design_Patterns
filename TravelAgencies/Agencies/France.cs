//I certify that this assignment is entirely my own work, \
//performed independently and without any help from the sources which are not allowed.
//Jiyi Zhu
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DataAccess;

namespace TravelAgencies.Agencies
{

    class TripFR : ITrip
    {
        Trip trip;
        public Trip Trip
        {
            get
            {
                if (trip.Countries == "France")
                    return this.trip;
                else return null;
            }
        }

        public TripFR(Trip trip)
        {
            this.trip = trip;
        }
    }

    class PhotoFR : IPhoto
    {
        Photo photo;
        public Photo Photo
        {
            get
            {
                if (photo.Longitude <= 5.4 &&
                    photo.Longitude >= 0.0 &&
                    photo.Latitude <= 50.0 &&
                    photo.Latitude >= 43.6)
                    return this.photo;
                else return null;
            }
        }

        public PhotoFR(Photo photo)
        {
            this.photo = photo;
        }
    }

    class ReviewFR : IReview
    {
        public RevieW Review { get; }

        public ReviewFR(RevieW revieW)
        {
            this.Review = revieW;
        }
    }
}
