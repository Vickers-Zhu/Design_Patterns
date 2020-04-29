using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.Encryption
{
    interface IDecrypt
    {
        INumber Handle(INumber number, int dataIdentifier);
        void SetNext(IDecrypt decrypt);
    }
}
