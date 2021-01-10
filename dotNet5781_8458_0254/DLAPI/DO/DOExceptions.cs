using System;
using System.Collections.Generic;
using System.Text;

namespace DO
{
    [Serializable]
    #region BusIdExeption

    public class BadBusIdException : Exception
    {
        public int ID;
        public BadBusIdException(int id) : base() => ID = id;
        public BadBusIdException(int id, string message) :
            base(message) => ID = id;
        public BadBusIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;
        public override string ToString() => base.ToString() + $", bad bus id: {ID}";
    }

    #endregion BusIdExeption
    #region StationIdExeption

    public class BadStationIdException : Exception
    {
        public int ID;
        public BadStationIdException(int id) : base() => ID = id;
        public BadStationIdException(int id, string message) :
            base(message) => ID = id;
        public BadStationIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;
        public override string ToString() => base.ToString() + $", bad station id: {ID}";
    }

    #endregion StationIdExeption
    #region LineIdExeption

    public class BadLineIdException : Exception
    {
        public int ID;
        public BadLineIdException(int id) : base() => ID = id;
        public BadLineIdException(int id, string message) :
            base(message) => ID = id;
        public BadLineIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;
        public override string ToString() => base.ToString() + $", bad line id: {ID}";
    }

    #endregion LineIdExeption
    #region AdjacentStationsExeption
    public class BadAdjacentStationsException : Exception
    {
        public int c1, c2;
        public BadAdjacentStationsException(int i, int j) : base()
        { c1 = i; c2 = j; }
        public BadAdjacentStationsException(int i, int j, string message) :
            base(message)
        { c1 = i; c2 = j; }
        public BadAdjacentStationsException(int i, int j, string message, Exception innerException) :
            base(message, innerException)
        { c1 = i; c2 = j; }
        public override string ToString() => base.ToString() + $", bad adjacentStations. code station 1: {c1}, code station 2: {c2}";
    }

    #endregion AdjacentStationsExeption
    #region LineStationsExeption

    public class BadLineStationException : Exception
    {
        public int c1, c2;
        public BadLineStationException(int i, int j) : base()
        { c1 = i; c2 = j; }
        public BadLineStationException(int i, int j, string message) :
            base(message)
        { c1 = i; c2 = j; }
        public BadLineStationException(int i, int j, string message, Exception innerException) :
            base(message, innerException)
        { c1 = i; c2 = j; }
        public override string ToString() => base.ToString() + $", bad line station. code line: {c1}, code station: {c2}";
    }

    #endregion LineStationsExeption
}
