using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_03B_8458_0254
{
    enum Status {isReady, isMid, inGas, inTreat};
    class Bus
    {
        private string numBus; //num of the bus
        private DateTime dateOfStart; //the date of start
        private double kilometers; //how many kilometers the bus has
        private double gasKM; //kilometers since last refuling
        private double treatmentKM; //kilometers since the last treatment
        public DateTime dateOfLastTreat; //the date of the last treatment
        private Status status; //the status of the bus
        public Bus() //ctor
        {
        }
        public Bus(string numBus, DateTime dateOfStart) //ctor
        {
            this.numBus = numBus;
            this.dateOfStart = dateOfStart;
        }
        public Bus(string numBus, DateTime dateOfStart, double kilometers, double gasKM, double treatmentKM, DateTime dateOfLastTreat, Status st) //ctor
        {
            this.numBus = numBus;
            this.dateOfStart = dateOfStart;
            this.kilometers = kilometers;
            this.gasKM = gasKM;
            this.treatmentKM = treatmentKM;
            this.dateOfLastTreat = dateOfLastTreat;
            this.status = st;
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
        public Status Status
        {
            get;set;
        }
        public override string ToString()
        {
            return numBus;
        }
    }
}


