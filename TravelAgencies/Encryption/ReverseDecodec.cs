using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.Encryption
{
    class ReverseDecodec : IDecrypt
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
            char[] result = number.Trim().ToCharArray();
            Array.Reverse(result);
            return new string(result).Trim();
        }
        public void SetNext(IDecrypt decrypt)
        {
            this.next = decrypt;
        }
    }
}
