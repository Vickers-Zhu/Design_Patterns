using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.Encryption
{
    class PushDecodec : IDecrypt
    {
        private IDecrypt next;
        public INumber Handle(INumber number, int dataIdentifier)
        {
            int n = 0;
            switch (dataIdentifier)
            {
                case 2:
                    n = -3;
                    break;
                case 3:
                    n = 3;
                    break;

            }
            if (this.next != null && n != 0)
                return this.next.Handle(new Numb(HandleSingle(number.Number, n)), dataIdentifier);
            else
                return new Numb(HandleSingle(number.Number, n));
        }

        private string HandleSingle(string number, int n)
        {
            string left = "".Trim();
            string right = "".Trim();
            string result = number;
            if (n > 0)
            {

                for (int i = 0; i < n; i++)
                {
                    left = result.Substring(0, 1).Trim();
                    right = result.Substring(1).Trim();
                    result = (right + left).Trim();
                }
                return result;
            }
            else if (n < 0)
            {
                n = Math.Abs(n);
                for (int i = 0; i < n; i++)
                {
                    left = result.Substring(0, number.Length-1).Trim();
                    right = result.Substring(number.Length-1).Trim();
                    result = (right + left).Trim();
                }
                return (right + left).Trim();
            }
            else return number;
        }

        public void SetNext(IDecrypt decrypt)
        {
            this.next = decrypt;
        }
    }
}
