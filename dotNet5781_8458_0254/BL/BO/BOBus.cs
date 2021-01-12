using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BOBus
    {
        public int LicenseNum { get; set; } //license number of the bus
        public DateTime FromDate { get; set; } //date of start
        public double TotalTrip { get; set; } //the total number of kilometers
        public double FuelRemain { get; set; } //how many gas left
        public BusStatus Status { get; set; } //the status of the bus
    }
}
