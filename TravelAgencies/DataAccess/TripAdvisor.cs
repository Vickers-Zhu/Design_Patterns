using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.DataAccess
{
	class TripAdvisorDatabase 
	{
		public Guid[] Ids;
		public Dictionary<Guid, string>[] Names { get; set; }
		public Dictionary<Guid, string> Prices { get; set; }//Encrypted
		public Dictionary<Guid, string> Ratings { get; set; }//Encrypted
		public Dictionary<Guid, string> Countries { get; set; }
	}
}

