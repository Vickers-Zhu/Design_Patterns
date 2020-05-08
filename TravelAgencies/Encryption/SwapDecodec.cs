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
    class SwapDecodec : IDecrypt
    {
        private IDecrypt next;
        public INumber Handle(INumber number, int dataIdentifier)
        {
            if (next != null)
                return this.next.Handle(new Numb(HandleSingle(number.Number)), dataIdentifier);
            else
                return new Numb(HandleSingle(number.Number));
        }

        private string HandleSingle(string number)
        {
            string result = "".Trim();
            char pre = '\0';
            foreach (char c in number)
            {
                if (pre == '\0')
                {
                    pre = c;
                }
                else
                {
                    result += c.ToString().Trim() + pre.ToString().Trim();
                    pre = '\0';
                }
            }
            if (number.Length % 2 != 0)
                result += number[number.Length - 1];
            return result.Trim();
        }

        public void SetNext(IDecrypt decrypt)
        {
            this.next = decrypt;
        }
    }
}
