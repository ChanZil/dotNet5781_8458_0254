using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
   public class BOStationInLine
    {
        public int Code { get; set; } //code station
        public string Name { get; set; } //name of the station
        public double Longitude { get; set; } //location
        public double Latitude { get; set; } //location
        public string Address { get; set; } //address of the station
    }
}
