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
    class TripPL : ITrip
    {
        Trip trip;
        public Trip Trip
        {
            get
            {
                if (trip.Countries == "Poland")
                    return this.trip;
                else return null;
            }
        }

        public TripPL(Trip trip)
        {
            this.trip = trip;
        }
    }

    class PhotoPL : IPhoto
    {
        Photo photo;
        public Photo Photo
        {
            get
            {
                if (photo.Longitude <= 23.5 &&
                    photo.Longitude >= 14.4 &&
                    photo.Latitude <= 54.2 &&
                    photo.Latitude >= 49.8)
                    return this.photo;
                else return null;
            }
        }

        public PhotoPL(Photo photo)
        {
            this.photo = photo;
        }
    }

    class ReviewPL : IReview
    {
        public RevieW Review { get; }

        public ReviewPL(RevieW revieW)
        {
            this.Review = revieW;
        }
    }
}
