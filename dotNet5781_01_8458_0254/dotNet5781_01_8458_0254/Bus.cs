using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_8458_0254
{
    class Bus
    {
        private string numBus; //num of the bus
        private DateTime dateOfStart; //the date of start
        private double kilometers; //how many kilometers the bus has
        private double gasKM; //kilometers since last refuling
        private double treatmentKM; //kilometers since the last treatment
        public DateTime dateOfLastTreat; //the date of the last treatment
        public Bus() //ctor
        {
        }
        public Bus(string numBus, DateTime dateOfStart) //ctor
        {
            this.numBus = numBus;
            this.dateOfStart = dateOfStart;
        }
        public string NumBus
        {
            get { return numBus; }
            set => numBus = value;
        }
        public double Kilometers
        {
            get { return kilometers; }
            set => kilometers = value;
        }
        public double GasKM
        {
            get { return gasKM; }
            set => gasKM = value;
        }
        public double TreatmentKM
        {
            get { return treatmentKM; }
            set => treatmentKM = value;
        }
        public DateTime DateOfStart
        {
            get { return dateOfStart; }
        }
        public DateTime DateOfLastTreat
        {
            get { return dateOfLastTreat; }
        }
        
    }
}
