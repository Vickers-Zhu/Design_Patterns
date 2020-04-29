using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DataAccess;

namespace TravelAgencies.Agencies
{
    public interface IPhoto
    {
        Photo Photo { get; }
    }

    public class Photo
    {
        public string Name { get; set; }
        public string Camera { get; set; }
        public double[] CameraSettings { get; set; }
        public DateTime Date { get; set; }
        public string WidthPx { get; set; }//Encrypted
        public string HeightPx { get; set; }//Encrypted
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Photo(string Name, string Camera, double[] CameraSettings,
            DateTime Date, string WidthPx, string HeightPx, double Longitude, double Latitude)
        {
            this.Name = Name;
            this.Camera = Camera;
            this.CameraSettings = CameraSettings;
            this.Date = Date;
            this.WidthPx = WidthPx;
            this.HeightPx = HeightPx;
            this.Longitude = Longitude;
            this.Latitude = Latitude;
        }
    }
}
