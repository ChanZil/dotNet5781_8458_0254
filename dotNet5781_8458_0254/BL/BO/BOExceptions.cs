using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    [Serializable]
    public class BadLineIdExeption : Exception
    {
        public int ID;
        public BadLineIdExeption(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadLineIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad line id: {ID}";
    }

    [Serializable]
    public class BadStationIdException : Exception
    {
        public int ID;
        public BadStationIdException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadStationIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad station id: {ID}";
    }

    [Serializable]
    public class BadBusIdException : Exception
    {
        public int ID;
        public BadBusIdException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadBusIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad bus license number: {ID}";
    }
}
