using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
   public class BOStationInLine
    {
        public int Code { get; set; } //code station
        public string Name { get; set; } //name of the station
        public string Address { get; set; } //address of the station
        public int StationIndex { get; set; } //number of station in the line
        public double Distance { get; set; } //the distance between the stations
        public TimeSpan Time { get; set; } //the time between the stations
    }
}
