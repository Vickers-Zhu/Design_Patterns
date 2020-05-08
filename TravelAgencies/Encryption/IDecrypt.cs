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
    interface IDecrypt
    {
        INumber Handle(INumber number, int dataIdentifier);
        void SetNext(IDecrypt decrypt);
    }
}
