using System;
using System.Collections.Generic;
using System.Text;

namespace DO
{
    public class Line
    {
        public int Id { get; set; } //id of the bus line 
        public int Code { get; set; } //number line
        public DOenums.Areas Area { get; set; } //the area of the bus line
        public int FirstStation { get; set; } //number of first station in the line
        public int LastStation { get; set; } //number of last station in the line

    }
}
