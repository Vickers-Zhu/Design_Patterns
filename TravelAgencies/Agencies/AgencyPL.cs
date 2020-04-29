using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Advertiser;
using TravelAgencies.Encryption;

namespace TravelAgencies.Agencies
{
    class AgencyPL : Agency
    {
        public override string Country => "Poland";
        public AgencyPL(AgencyFactory factory, Random r) : base(factory, r) { }

        public override void Accept(IAds ads)
        {
            ads.getting(this);
        }
    }
}
