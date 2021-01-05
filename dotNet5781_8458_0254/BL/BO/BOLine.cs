using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BO
{
    public class BOLine
    {
        public int Id { get; set; } //id of the bus line 
        public int Code { get; set; } //number line
        public DO.DOenums.Areas Area { get; set; } //the area of the bus line
        public TimeSpan StartAt { get; set; } //time of start
        public TimeSpan FinishAt { get; set; } //time of finish
        public TimeSpan Frequency { get; set; } //
        public IEnumerable<BOStationInLine> ListOfStationInLine { get; set; }
    }
}
