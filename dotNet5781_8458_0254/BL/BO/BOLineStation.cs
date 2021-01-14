using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class BOLineStation
    {
        public int Id { get; set; } //id of the bus line 
        public int Code { get; set; } //number line
        public Areas Area { get; set; } //the area of the line
        public int LineStationIndex { get; set; } //number of station in the line

    }
}
