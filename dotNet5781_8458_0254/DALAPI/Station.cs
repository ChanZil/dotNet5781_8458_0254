using System;
using System.Collections.Generic;
using System.Text;

namespace DO
{
    public class Station
    {
        public int Code { get; set; } //code station מספר רץ
        public string Name { get; set; } //name of the ststion
        public double Longitude { get; set; } //location
        public double Latitude { get; set; } //location
        public string Address { get; set; } //address of the station
    }
}
