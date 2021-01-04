using System;
using System.Collections.Generic;
using System.Text;

namespace DO
{
    public class LineTrip
    {
        public int LineId { get; set; } //number of bus line
        public TimeSpan StartAt { get; set; } //time of start
        public TimeSpan FinishAt { get; set; } //time of finish
        public TimeSpan Frequency { get; set; } //the frequency of the line
    }
}
