using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    /// <summary>
    /// This BO class based on DO.Station. 
    /// It also has a collection of BO.BOLineStation- lines that passes in this station, that based on: 
    /// DO.Line + DO.LineStation
    /// </summary>
    public class BOStation
    {
        public int Code { get; set; } //code station
        public string Name { get; set; } //name of the ststion
        public string Address { get; set; } //address of the station
        public double Longitude { get; set; } //location
        public double Latitude { get; set; } //location
        public IEnumerable<BOLineStation> ListOfLines { get; set; }
    }
}
