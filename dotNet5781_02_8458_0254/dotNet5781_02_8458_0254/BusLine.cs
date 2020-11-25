using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8458_0254
{
    class BusLine: IComparable
    {
        protected int busLineCode; //code of the bus line
        protected BusStopLine firstStation; //first station in the bus line
        protected BusStopLine LastStation; //last station in the bus line
        protected string area; //the area of the line
        protected List<BusStopLine> stations = new List<BusStopLine>(); //a list of all the stations in the bus line
        public BusLine(int busLine, BusStopLine firstStation, BusStopLine LastStation, string area) //ctor
        {
            this.BusLineCode = busLine;
            this.firstStation = firstStation;
            this.LastStation = LastStation;
            this.area = area;
            stations.Add(firstStation); //add the first station to the list
            stations.Add(LastStation); //add the last station to the list
        }
        public BusLine(int busLine, List<BusStopLine> station , string area) //ctor
        {
            this.BusLineCode = busLine;
            this.area = area;
            int count = 0;
            foreach (BusStopLine item in stations)
            {
                this.stations.Add(item);
                count++;
            }
            //firstStation = stations[0];
            //LastStation = stations[count];
        }
        public BusLine(int code) //ctor
        {
            busLineCode = code;
        }
        public override string ToString() //override function ToString
        {
            string busDetails = "Bus line: " + BusLineCode + "Area: " + area; //the details of the bus line
            foreach(BusStopLine item in stations) //pass the stations list to return the details of each station
                busDetails += item.ToString();
            return busDetails; //return all the details
        }
        public void AddStation(BusStopLine busStopLine) //add a station to the list
        {
            foreach (BusStopLine item in stations) //pass the stations list to find the place of the 
                if (busStopLine.BusStationKey < item.BusStationKey)
                    stations.Insert(stations.IndexOf(item) - 1, busStopLine); //insert a station to the list according the order of the code
        }
        public void RemoveStation(BusStopLine busStopLine) //remove a station from the list
        {
            foreach (BusStopLine item in stations) 
            {
                if (busStopLine.BusStationKey == item.BusStationKey)
                    stations.RemoveAt(stations.IndexOf(item));
            }
        }
        public bool IsExist(BusStopLine busStopLine) 
        {
            foreach (BusStopLine item in stations)
            {
                if (busStopLine.BusStationKey == item.BusStationKey)
                    return true;
            }
            return false;
        }
        public double DistanceOfStations(BusStopLine b1, BusStopLine b2)
        {
            return Math.Abs(b1.Distance - b2.Distance);
        }
        public double TimeOfStations(BusStopLine b1, BusStopLine b2) 
        {
            return Math.Abs(b1.Time - b2.Time);
        }
        public BusLine SubLine(BusStopLine b1, BusStopLine b2)
        {
            BusLine busLine = new BusLine(this.BusLineCode, b1, b2, this.area);
            return busLine;
        }
        public int CompareTo(object obj)
        {
            double timeOfLine1 = 0, timeOfLine2 = 0;
            foreach(BusStopLine item in stations)
                timeOfLine1 += item.Time;
            BusLine b = (BusLine)obj;
            foreach (BusStopLine item in b.stations)
                timeOfLine2 += item.Time;
            return timeOfLine1.CompareTo(timeOfLine2);
        }
        public int BusLineCode
        {
            get;
            set;
        }
        public List<BusStopLine> Stations
        {
            get;
            set;
        }
    }
}
