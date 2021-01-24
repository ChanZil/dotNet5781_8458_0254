using System;
using System.Collections.Generic;
using System.Text;

namespace DO
{
    public class AdjacentStations
    {
        public int LineId { get; set; } //code of the line
        public int Station1 { get; set; } //code of station 1
        public int Station2 { get; set; } //code of station 2
        public double Distance { get; set; } //the distance between the stations
        public TimeSpan Time { get; set; } //the time between the stations
    }
}
