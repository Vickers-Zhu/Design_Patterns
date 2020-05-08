//I certify that this assignment is entirely my own work, \
//performed independently and without any help from the sources which are not allowed.
//Jiyi Zhu
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
        Random r;
        private int temper;
        private int perman;
        public OfferWebsite(int temper, int perman)
        {
            r = new Random(Guid.NewGuid().GetHashCode());
            offerList = new List<IAds>();
            agencyList = new List<Agency>();
            this.temper = temper;
            this.perman = perman;
        }

        public void AddOffers()
        {
            for (int i = 0; i < temper; i++)
            {
                AddAds(r.Next(2, 8));
            }
            for (int i = 0; i < perman; i++)
            {
                AddAds(null);
            }
        }

        public void AddAds(int? times)
        {
            IAds graphAd = new Graphic(times);
            IAds textAd = new Text(times);

            this.offerList.Add(textAd);
            this.offerList.Add(graphAd);
            int rnb = r.Next(0, agencyList.Count());
            Console.WriteLine(rnb);
            SetUpOffer(textAd, graphAd, agencyList[rnb]);
        }

        private void SetUpOffer(IAds textAd, IAds graphAd, Agency agency)
        {
            agency.Overdue(agency.factory, new Random(Guid.NewGuid().GetHashCode()));
            agency.Accept(textAd);
            agency.Accept(graphAd);      
        }

        public void AddAgc(Agency agc)
        {
            this.agencyList.Add(agc);
        }

        public void Present()
        {
            foreach (IAds ads in offerList)
            {
                ads.posting();             
            }                 
        }
    }
}
