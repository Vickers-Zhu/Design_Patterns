using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;

namespace TravelAgencies.Advertiser
{
    class OfferWebsite
    {
        List<IAds> offerList;
        List<Agency> agencyList;
        public OfferWebsite()
        {
            offerList = new List<IAds>();
            agencyList = new List<Agency>();

            AddAds();
        }

        public void AddAds()
        {
            IAds graphAd = new Graphic();
            IAds textAd = new Text();

            this.offerList.Add(textAd);
            this.offerList.Add(graphAd);
        }

        public void AddAgc(Agency agc)
        {
            this.agencyList.Add(agc);
        }

        public void Present()
        {
            foreach (Agency agency in agencyList)
            {
                agency.Accept(offerList[0]);
                agency.Accept(offerList[1]);
                offerList[0].posting();
                offerList[1].posting();
            }          
        }
    }
}
