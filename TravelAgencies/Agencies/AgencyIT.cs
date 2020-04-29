﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Advertiser;
using TravelAgencies.Encryption;

namespace TravelAgencies.Agencies
{
    class AgencyIT : Agency
    {
        public override string Country => "Italy";
        public AgencyIT(AgencyFactory factory, Random r) : base(factory, r) { }

        public override void Accept(IAds ads)
        {
            ads.getting(this);
        }
    }
}