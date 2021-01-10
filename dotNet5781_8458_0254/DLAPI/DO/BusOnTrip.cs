using System;
using System.Collections.Generic;
using System.Text;

namespace DO
{
    public class BusOnTrip
    {
        public int Id { get; set; } //id of bus on trip 
        public int LicenceNum { get; set; } //license number of the bus
        public int LineId { get; set; } //number of line
        public TimeSpan PlannedTakeOff { get; set; } //formal time of take off
        public TimeSpan ActualTakeOff { get; set; } //actual time of take off
        public int PrevStation { get; set; } //the number of the last station where the bus was
        public TimeSpan PrevStationAt { get; set; } //when the bus was at the last station
        public TimeSpan NextStationAt { get; set; } //when the bus will arrive to the next station
    }
}
