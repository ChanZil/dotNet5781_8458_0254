using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class BOStation
    {
        public int Code { get; set; } //code station
        public string Name { get; set; } //name of the ststion
        public string Address { get; set; } //address of the station
        public double Longitude { get; set; } //location
        public double Latitude { get; set; } //location
        public DO.DOenums.Areas Area { get; set; } //the area of the bus line
        public IEnumerable<BOLineStation> ListOfLines { get; set; }
    }
}
