//I certify that this assignment is entirely my own work, \
//performed independently and without any help from the sources which are not allowed.
//Jiyi Zhu
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;
using TravelAgencies.Encryption;

namespace TravelAgencies.DataAccess
{
	class PhotMetadata
	{
		public string Name { get; set; }
		public string Camera { get; set; }
		public double[] CameraSettings { get; set; }
		public DateTime Date { get; set; }
		public string WidthPx { get; set; }//Encrypted
		public string HeightPx { get; set; }//Encrypted
		public double Longitude { get; set; }
		public double Latitude { get; set; }
    }
	class ShutterStockDatabase : IEnumerable
	{
		public PhotMetadata[][][] Photos;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        public ShutterStockDatabaseEnum GetEnumerator()
        {
            return new ShutterStockDatabaseEnum(Photos);
        }
    }

    class ShutterStockDatabaseEnum : IEnumerator
    {
        public PhotMetadata[][][] Photos;

        static int i = 0;
        static int j = 0;
        static int k = 0;

        public ShutterStockDatabaseEnum(PhotMetadata[][][] Photos)
        {
            this.Photos = Photos;
        }

        object IEnumerator.Current => this.Current;

        public Photo Current
        {
            get
            {
                string WidthPx = TakingElement.photoDecrypter.
                    Handle(new Numb(Photos[i][j][k].WidthPx), 2).Number;
                string HeightPx = TakingElement.photoDecrypter.
                    Handle(new Numb(Photos[i][j][k].HeightPx), 2).Number;
                return new Photo(Photos[i][j][k].Name,
                    Photos[i][j][k].Camera,
                    Photos[i][j][k].CameraSettings,
                    Photos[i][j][k].Date,
                    WidthPx, HeightPx,
                    Photos[i][j][k].Longitude,
                    Photos[i][j][k++].Latitude);//Vital part
            }
        }

        public bool MoveNext()
        {
            if (i < Photos.Length)
            {
                if (Photos[i] != null)
                {
                    if (j < Photos[i].Length)
                    {
                        if (Photos[i][j] != null)
                        {
                            if (k < Photos[i][j].Length)
                            {
                                if (Photos[i][j][k] != null)
                                {
                                    string WidthPx = TakingElement.photoDecrypter.
                                        Handle(new Numb(Photos[i][j][k].WidthPx), 2).Number;
                                    string HeightPx = TakingElement.photoDecrypter.
                                        Handle(new Numb(Photos[i][j][k].HeightPx), 2).Number;
                                    if (double.Parse(WidthPx) == 0.0 || double.Parse(HeightPx) == 0.0)
                                    {
                                        ++k;
                                        this.MoveNext();
                                    }
                                    else return true;
                                }
                                else
                                {
                                    ++k;
                                    return this.MoveNext();
                                }
                            }
                            else
                            {
                                k = 0;
                                ++j;
                                return this.MoveNext();
                            }
                        }
                        else
                        {
                            ++j;
                            return this.MoveNext();
                        }
                    }
                    else
                    {
                        j = 0;
                        ++i;
                        return this.MoveNext();
                    }
                }
                else
                {
                    ++i;
                    return this.MoveNext();
                } 
            }
            return i < Photos.Length;
        }

        public void Reset()
        {
            i = 0;
            j = 0;
            k = 0;
        }
    }
}
