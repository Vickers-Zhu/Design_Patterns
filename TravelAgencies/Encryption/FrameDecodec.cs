using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.Encryption
{
    class FrameDecodec : IDecrypt
    {
        IDecrypt next;
        public INumber Handle(INumber number, int dataIdentifier)
        {
            int n = 0;
            switch (dataIdentifier)
            {
                case 1:
                    n = 2;
                    break;
                case 2:
                    n = 1;
                    break;
                case 3:
                    n = 2;
                    break;
            }
            long result = HandleSingle(number.Number, n);
            if (result != -1)
            {
                if (next != null && n != 0)
                    return this.next.Handle
                        (new Numb(result.ToString().Trim()), dataIdentifier);
                else return new Numb(result.ToString().Trim());
            }
            else
            {
                Console.WriteLine("FrameDecoding error ");
                Console.ReadKey();
                return null;
            }
        }

        private long HandleSingle(string number, int n)
        {
            long numb = long.Parse(number);
            int length = number.Trim().Length;
            long left = 0;
            long right = 0;
            long result = 0;
            for (int i = 0; i < n; i++)
            {
                left = left * 10 + numb % 10;
                numb /= 10;
            }
            for (int i = 0; i < length - 2 * n; i++)
            {
                result = result * 10 + numb % 10;
                numb /= 10;
            }
            for (int i = 0; i < n; i++)
            {
                right = right * 10 + numb % 10;
                numb /= 10;
            }
            char[] rStr = result.ToString().Trim().ToCharArray();
            Array.Reverse(rStr);
            result = long.Parse(new string(rStr).Trim());
            char[] ls = left.ToString().Trim().ToCharArray();
            Array.Reverse(ls);
            if (new string(ls).Trim() == right.ToString().Trim() && isConsec(left))
            {
                return result;
            }
            else return -1;
        }

        private bool isConsec(long numb)
        {
            bool result = true;
            long digit = numb % 10;
            for (int i = 0; i < numb.ToString().Trim().Length; i++)
            {
                if (digit-- != numb % 10)
                {
                    result = false;
                }
                numb /= 10;
            }
            return result;
        }

        public void SetNext(IDecrypt decrypt)
        {
            this.next = decrypt;
        }
    }
}
