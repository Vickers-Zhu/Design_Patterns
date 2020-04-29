using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.Agencies
{
    class TripPerDay
    {
        public Trip trip1 { get;  }
        public Trip trip2 { get;  }
        public Trip trip3 { get;  }
        public Booking booking { get;  }

        public TripPerDay(Trip trip1, Trip trip2, Trip trip3, Booking booking)
        {
            this.trip1 = trip1;
            this.trip2 = trip2;
            this.trip3 = trip3;
            this.booking = booking;
        }
    }
}
