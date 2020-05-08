//I certify that this assignment is entirely my own work, \
//performed independently and without any help from the sources which are not allowed.
//Jiyi Zhu
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;
using TravelAgencies.Encryption;

namespace TravelAgencies.DataAccess
{
    class TakingElement
    {
        BookingDatabase accomodationData;
        TripAdvisorDatabase tripsData;
        ShutterStockDatabase photosData;
        OysterDatabase reviewData;

        static public IDecrypt bookDecrypter;
        static public IDecrypt photoDecrypter;
        static public IDecrypt tripDecrypter;

        public TakingElement(BookingDatabase accomodationData,
                TripAdvisorDatabase tripsData,
                ShutterStockDatabase photosData,
                OysterDatabase reviewData)
        {
            this.accomodationData = accomodationData;
            this.tripsData = tripsData;
            this.photosData = photosData;
            this.reviewData = reviewData;

            if (bookDecrypter == null || photoDecrypter == null || tripDecrypter == null)
                SetDecrypter();
        }

        private void SetDecrypter()
        {
            IDecrypt CezarDecodec = new CezarDecodec();
            IDecrypt ReverseDecodec = new ReverseDecodec();
            IDecrypt FrameDecodec = new FrameDecodec();
            IDecrypt SwapDecodec = new SwapDecodec();
            IDecrypt PushDecodec = new PushDecodec();

            bookDecrypter = new SwapDecodec();
            bookDecrypter.SetNext(CezarDecodec);
            CezarDecodec.SetNext(ReverseDecodec);
            ReverseDecodec.SetNext(FrameDecodec);

            CezarDecodec = new CezarDecodec();
            ReverseDecodec = new ReverseDecodec();
            FrameDecodec = new FrameDecodec();
            SwapDecodec = new SwapDecodec();
            PushDecodec = new PushDecodec();

            photoDecrypter = new ReverseDecodec();
            photoDecrypter.SetNext(PushDecodec);
            PushDecodec.SetNext(FrameDecodec);
            FrameDecodec.SetNext(CezarDecodec);

            CezarDecodec = new CezarDecodec();
            ReverseDecodec = new ReverseDecodec();
            FrameDecodec = new FrameDecodec();
            SwapDecodec = new SwapDecodec();
            PushDecodec = new PushDecodec();

            tripDecrypter = new PushDecodec();
            tripDecrypter.SetNext(SwapDecodec);
            SwapDecodec.SetNext(FrameDecodec);
            PushDecodec = new PushDecodec();
            FrameDecodec.SetNext(PushDecodec);
        }

        public Trip GetTrip()
        {
            while (true)
            {
                foreach (Trip trip in tripsData)
                {                   
                    return trip;
                }
            }
        }

        public Photo GetPhoto()
        {
            while (true)
            {
                foreach (Photo photo in photosData)
                {
                    return photo;
                }
            }
        }

        public RevieW GetReview()
        {
            while (true)
            {
                foreach (RevieW review in reviewData)
                {
                    return review;
                }
            }
        }

        public Booking GetBooking()
        {
            while (true)
            {
                foreach (Booking booking in accomodationData)
                {
                    return booking;
                }
            }
        }
    }
}
