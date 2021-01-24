using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BO
{
    /// <summary>
    /// This BO class based on: DO.Line + DO.LineTrip 
    /// It also has a collection of BO.BOStationInLine- stations in this line, that based on: 
    /// DO.Station + DO.LineStation + DO.AdjacentStations
    /// </summary>
    public class BOLine
    {
        public int Id { get; set; } //id of the bus line 
        public int Code { get; set; } //number line
        public Areas Area { get; set; } //the area of the bus line
        public TimeSpan StartAt { get; set; } //time of start
        public TimeSpan FinishAt { get; set; } //time of finish
        public TimeSpan Frequency { get; set; } //
        public IEnumerable<BOStationInLine> ListOfStationInLine { get; set; }
    }
}
