//I certify that this assignment is entirely my own work, \
//performed independently and without any help from the sources which are not allowed.
//Jiyi Zhu
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DataAccess;

namespace TravelAgencies.Agencies
{
    public interface IReview
    {
        RevieW Review { get; }
    }

    public class RevieW
    {
        public string Review { get; set; }
        public string UserName { get; set; }

        public RevieW(string Review, string UserName)
        {
            this.Review = Review;
            this.UserName = UserName;
        }
    }
}
