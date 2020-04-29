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

        static int i = 0;
        static int j = 0;
        static int k = 0;

        static int m = 0;

        static int c = 0;
        static int r = 0;
        static ListNode nodeB;
        static bool isGenerated = false;

        static BSTNode node;
        static Stack<BSTNode> stack = new Stack<BSTNode>();

        public TakingElement(BookingDatabase accomodationData,
                TripAdvisorDatabase tripsData,
                ShutterStockDatabase photosData,
                OysterDatabase reviewData)
        {
            this.accomodationData = accomodationData;
            this.tripsData = tripsData;
            this.photosData = photosData;
            this.reviewData = reviewData;

            if(node == null)
                node = reviewData.Reviews;
            if (nodeB == null)
                nodeB = accomodationData.Rooms[0];
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
                string name = "";
                for (; m < tripsData.Ids.Length;)
                {
                    for (int n = 0; n < tripsData.Names.Length; n++)
                    {
                        if (tripsData.Names[n].TryGetValue(tripsData.Ids[m], out name))
                        {
                            string Prices = TakingElement.tripDecrypter.
                                Handle(new Numb(tripsData.Prices[tripsData.Ids[m]]), 3).Number;
                            string Ratings = TakingElement.tripDecrypter.
                                Handle(new Numb(tripsData.Ratings[tripsData.Ids[m]]), 3).Number;
                            return new Trip(name, Prices,Ratings,
                                tripsData.Countries[tripsData.Ids[m++]]);//Very Important!!!
                        }
                    }
                }
                m = 0;
            }
        }

        public Photo GetPhoto()
        {
            while (true)
            {
                for (; i < photosData.Photos.Length; i++)
                {
                    if (photosData.Photos[i] != null)
                    {
                        for (; j < photosData.Photos[i].Length; j++)
                        {
                            if (photosData.Photos[i][j] != null)
                            {
                                for (; k < photosData.Photos[i][j].Length; k++)
                                {
                                    if (photosData.Photos[i][j][k] != null)
                                    {
                                        string WidthPx = TakingElement.photoDecrypter.
                                            Handle(new Numb(photosData.Photos[i][j][k].WidthPx), 2).Number;
                                        string HeightPx = TakingElement.photoDecrypter.
                                            Handle(new Numb(photosData.Photos[i][j][k].HeightPx), 2).Number;
                                        return new Photo(photosData.Photos[i][j][k].Name,
                                            photosData.Photos[i][j][k].Camera,
                                            photosData.Photos[i][j][k].CameraSettings,
                                            photosData.Photos[i][j][k].Date,
                                            WidthPx, HeightPx,
                                            photosData.Photos[i][j][k].Longitude,
                                            photosData.Photos[i][j][k++].Latitude);//Very Important!!!!
                                    }
                                }
                            }
                        }
                    }
                }
                i = 0;
                j = 0;
                k = 0;
            }
        }

        public RevieW GetReview()
        {
            while (true)
            {
                while (node != null || stack.Count > 0)
                {
                    while (node != null)
                    {
                        stack.Push(node);
                        string Review = node.Review;
                        string UserName = node.UserName;
                        node = node.Left;
                        return new RevieW(Review, UserName);
                    }
                    if (stack.Count > 0)
                    {
                        node = stack.Pop();
                        node = node.Right;
                    }
                }
                stack.Clear();
                node = reviewData.Reviews;
            }
        }

        public Booking GetBooking()
        {
            while (true)
            {
                if (c == 0) isGenerated = false;
                for (; c < accomodationData.Rooms.Length; c++)
                {
                    nodeB = accomodationData.Rooms[c];

                    for (int o = 0; o < r; o++)
                    {
                        if (nodeB != null)
                            nodeB = nodeB.Next;
                        else
                            break;
                    }
                    if (nodeB != null)
                    {
                        c++;
                        string name = nodeB.Name;
                        string rating = nodeB.Rating;
                        string price = nodeB.Price;
                        isGenerated = true;
                        rating = TakingElement.bookDecrypter.Handle(new Numb(rating), 1).Number;
                        price = TakingElement.bookDecrypter.Handle(new Numb(price), 1).Number;
                        return new Booking(name, rating, price);
                    }
                }
                c = 0;
                if (isGenerated)
                    r++;
                else r = 0;
            }
        }
    }
}
