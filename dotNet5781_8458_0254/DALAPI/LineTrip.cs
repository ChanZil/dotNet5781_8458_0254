using System;
using System.Collections.Generic;
using System.Text;

namespace DO
{
    public class LineTrip
    {
        public int Id { get; set; } //id of line in trip 
        public int LineId { get; set; } //number of bus line
        public TimeSpan StartAt { get; set; } //time of start
        public TimeSpan Frequency { get; set; } //
        public TimeSpan FinishAt { get; set; } //time of finish

    }
}
