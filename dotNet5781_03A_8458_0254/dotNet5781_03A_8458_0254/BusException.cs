using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace dotNet5781_02_8458_0254
{
    class BusException: Exception
    {
        public BusException() : base() { }
        public BusException(string message) : base(message) { }
        public BusException(string message, Exception inner) : base(message, inner) { }
        protected BusException(SerializationInfo info, StreamingContext context): base(info, context) { }
        override public string ToString()
        { 
            return "BusException:\n" + Message; 
        }
    }

}

