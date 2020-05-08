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

    class TripIT : ITrip
    {
        Trip trip;
        public Trip Trip
        {
            get
            {
                if (trip.Countries == "Italy")
                    return this.trip;
                else return null;
            }
        }

        public TripIT(Trip trip)
        {
            this.trip = trip;
        }
    }

    class PhotoIT : IPhoto
    {
        Photo photo;
        public Photo Photo
        {
            get
            {
                if (photo.Longitude <= 15.2 &&
                    photo.Longitude >= 8.8 &&
                    photo.Latitude <= 44.0 &&
                    photo.Latitude >= 37.7)
                    return this.photo;
                else return null;
            }
        }

        public PhotoIT(Photo photo)
        {
            this.photo = photo;
        }
    }

    class ReviewIT : IReview
    {
        public RevieW Review { get; }

        public ReviewIT(RevieW revieW)
        {
            this.Review = revieW;
        }
    }
}
