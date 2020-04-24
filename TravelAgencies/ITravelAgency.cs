using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.Agencies
{
	public interface ITravelAgency
	{
		ITrip CreateTrip();
		IPhoto CreatePhoto();
		IReview CreateReview();
	}
}