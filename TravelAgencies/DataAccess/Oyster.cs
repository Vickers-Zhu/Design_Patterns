using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;
using TravelAgencies.Encryption;

//Oyster is a website with reviews of various holiday destinations.
namespace TravelAgencies.DataAccess
{
	class BSTNode
	{
		public string Review { get; set; }
		public string UserName { get; set; }
		public BSTNode Left { get; set; }
		public BSTNode Right { get; set; }
	}
	class OysterDatabase : IEnumerable
	{
		public BSTNode Reviews { get; set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }
        public OysterDatabaseEnum GetEnumerator()
        {
            return new OysterDatabaseEnum(Reviews);
        }
    }

    class OysterDatabaseEnum : IEnumerator
    {
        public BSTNode Reviews;

        static BSTNode node;
        static Stack<BSTNode> stack = new Stack<BSTNode>();

        public OysterDatabaseEnum(BSTNode Reviews)
        {
            this.Reviews = Reviews;
            if (node == null && stack.Count == 0)
                node = Reviews;
        }

        object IEnumerator.Current => this.Current;

        public RevieW Current
        {
            get
            {
                stack.Push(node);
                string Review = node.Review;
                string UserName = node.UserName;
                node = node.Left;
                return new RevieW(Review, UserName);
            }
        }

        public bool MoveNext()
        {
            if (node != null)
            {
                return true;
            }
            if (stack.Count > 0)
            {
                node = stack.Pop();
                node = node.Right;
                return this.MoveNext();
            }        
            return false;
        }

        public void Reset()
        {
            stack.Clear();
            node = this.Reviews;
        }
    }
}
