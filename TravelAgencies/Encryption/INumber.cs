using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.Encryption
{
    interface INumber
    {
        string Number { get; }
    }

    class Numb : INumber
    {
        private string number;
        public Numb(string numb)
        {
            this.number = numb;
        }

        public string Number => number;
    }
}
