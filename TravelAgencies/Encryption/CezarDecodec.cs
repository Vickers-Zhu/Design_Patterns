//I certify that this assignment is entirely my own work, \
//performed independently and without any help from the sources which are not allowed.
//Jiyi Zhu
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.Encryption
{
    class CezarDecodec : IDecrypt
    {
        IDecrypt next;

        public INumber Handle(INumber number, int dataIdentifier)
        {
            int n = 0;
            switch (dataIdentifier)
            {
                case 1:
                    n = -1;
                    break;
                case 2:
                    n = 4;
                    break;
            }
            if (this.next != null && n != 0)
            {
                return this.next.Handle(new Numb(HandleSingle(number.Number, n)), dataIdentifier);
            }
            else
                return new Numb(HandleSingle(number.Number, n));
        }

        private string HandleSingle(string number, int n)
        {
            string result = "".Trim();
            foreach (char c in number)
            {
                int a = int.Parse(c.ToString().Trim());
                if (a - n < 0) a += 10;
                a -= n;
                a %= 10;

                result += a.ToString().Trim();
            }
            return result.Trim();
        }

        public void SetNext(IDecrypt decrypt)
        {
            this.next = decrypt;
        }
    }
}
