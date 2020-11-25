using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8458_0254
{
    class BusStop
    {
        static public Random rand = new Random();
        protected int busStationKey; //the code of the station
        protected int latitude; //location
        protected int longitude; //location
        protected string address; //address of the station
        static int numCode = 100000; //a static var to automatically fill the station's code
        public BusStop(string address = null) //ctor
        {
            this.busStationKey = numCode;
            numCode++; 
            this.latitude = rand.Next(-90, 90);
            this.longitude = rand.Next(-180, 180);
            this.address = address;
        }
        public int BusStationKey
        {
            get { return busStationKey; }
        }
        public int Latitude
        {
            get { return latitude; }
        }
        public int Longitude
        {
            get { return longitude; }
        }
        public string Address
        {
            get {return address;}
            set => address = value;
        }
        public override string ToString() //override function ToString
        {
            return "Bus Station Code: " + busStationKey + ", " + latitude +"°N " + longitude + "°E"; //returns the details of the bus station
        }
    }
}
