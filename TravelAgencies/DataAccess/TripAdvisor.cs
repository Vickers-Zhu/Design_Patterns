//I certify that this assignment is entirely my own work, \
//performed independently and without any help from the sources which are not allowed.
//Jiyi Zhu
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;
using TravelAgencies.Encryption;

namespace TravelAgencies.DataAccess
{
	class TripAdvisorDatabase : IEnumerable
	{
		public Guid[] Ids;
		public Dictionary<Guid, string>[] Names { get; set; }
		public Dictionary<Guid, string> Prices { get; set; }//Encrypted
		public Dictionary<Guid, string> Ratings { get; set; }//Encrypted
		public Dictionary<Guid, string> Countries { get; set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        public TripAdvisorDatabaseEnum GetEnumerator()
        {
            return new TripAdvisorDatabaseEnum(Ids, Names, Prices, Ratings, Countries);
        }
    }

    class TripAdvisorDatabaseEnum : IEnumerator
    {
        public Guid[] Ids;
        public Dictionary<Guid, string>[] Names;
        public Dictionary<Guid, string> Prices;//Encrypted
        public Dictionary<Guid, string> Ratings;//Encrypted
        public Dictionary<Guid, string> Countries;

        static int m = 0;
        int n = 0;
        string name = "";

        public TripAdvisorDatabaseEnum(Guid[] Ids, Dictionary<Guid, string>[] Names,
            Dictionary<Guid, string> Prices, Dictionary<Guid, string> Ratings,
            Dictionary<Guid, string> Countries)
        {
            this.Ids = Ids;
            this.Names = Names;
            this.Prices = Prices;
            this.Ratings = Ratings;
            this.Countries = Countries;
        }

        object IEnumerator.Current => this.Current;

        public Trip Current
        {
            get
            {
                string Prices = TakingElement.tripDecrypter.
                    Handle(new Numb(this.Prices[Ids[m]]), 3).Number;
                string Ratings = TakingElement.tripDecrypter.
                    Handle(new Numb(this.Ratings[Ids[m]]), 3).Number;
                return new Trip(this.name, Prices, Ratings,
                    Countries[Ids[m++]]);//Very Important!!!
            }
        }

        public bool MoveNext()
        {
            if(m < Ids.Length)
            {
                if (n < Names.Length)
                {
                    if (Names[n].TryGetValue(Ids[m], out this.name))
                    {
                        n = 0;
                        m++;
                        return true;
                    }
                    else
                    {
                        n++;
                        return this.MoveNext();
                    }
                }
            }
            m = 0;
            return false;
        }

        public void Reset()
        {
            m = 0;
        }
    }
}

