using System;
using System.Collections.Generic;
using System.Text;

namespace DO
{
    public class LineStation
    {
        public int LineId { get; set; } //number of line
        public int Station { get; set; } //number of station
        public int LineStationIndex { get; set; } //number of station in the line
        public int PrevStation { get; set; } //the previous station in the line
        public int NextStation { get; set; } //the next station in the line
    }
}
