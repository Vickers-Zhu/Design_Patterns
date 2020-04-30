using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;
using TravelAgencies.Encryption;

namespace TravelAgencies.DataAccess
{
	class ListNode
	{
		public ListNode Next { get; set; }
		public string Name { get; set; }
		public string Rating { get; set; }//Encrypted
		public string Price { get; set; }//Encrypted
	}
	class BookingDatabase : IEnumerable
	{
		public ListNode[] Rooms { get; set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        public BookingDatabaseEnum GetEnumerator()
        {
            return new BookingDatabaseEnum(Rooms);
        }
    }

    class BookingDatabaseEnum : IEnumerator
    {
        public ListNode[] Rooms;

        static int c = 0;
        static int r = 0;
        static ListNode nodeB;
        static bool isGenerated = false;

        public BookingDatabaseEnum(ListNode[] Rooms)
        {
            this.Rooms = Rooms;
        }

        object IEnumerator.Current => this.Current;

        public Booking Current
        {
            get
            {
                string name = nodeB.Name;
                string rating = nodeB.Rating;
                string price = nodeB.Price;
                isGenerated = true;
                rating = TakingElement.bookDecrypter.Handle(new Numb(rating), 1).Number;
                price = TakingElement.bookDecrypter.Handle(new Numb(price), 1).Number;
                return new Booking(name, rating, price);
            }
        }

        public bool MoveNext()
        {
            if (c < Rooms.Length)
            {
                if (c == 0) isGenerated = false;
                nodeB = Rooms[c];
                for (int o = 0; o < r; o++)
                {
                    if (nodeB != null)
                    {
                        if (nodeB.Next != null)
                        {
                            nodeB = nodeB.Next;
                        }
                        else
                        {
                            c++;
                            return this.MoveNext();
                        }
                    }        
                }
                return c++ < Rooms.Length;
            }
            else
            {
                c = 0;
                if (isGenerated)
                {
                    r++;
                    return this.MoveNext();
                }
                r = 0;
                return isGenerated;
            }
        }

        public void Reset()
        {
            c = 0;  
            r = 0;
        }
    }
}
