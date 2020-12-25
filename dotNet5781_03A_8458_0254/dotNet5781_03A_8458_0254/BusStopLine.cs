using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8458_0254
{
    class BusStopLine:BusStop
    {
        protected double distance; //the distance between this station to the one before it
        protected double time; //the time it takes from this station to the one before it
        public BusStopLine() : base()
        {
            distance = rand.Next(1, 100); //a random number
            time = distance * 0.1; //each meter takes 0.1 time 
        }
        public double Distance
        {
            get { return distance; }
        }
        public double Time
        {
            get { return time; }
        }
    }
}
