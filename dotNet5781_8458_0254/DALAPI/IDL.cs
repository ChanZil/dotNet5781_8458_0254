using System;
using System.Collections.Generic;
using System.Text;
using DO;

namespace DALAPI
{
    public interface IDL
    {
        #region Bus
        void CreateBus(DO.Bus bus);
        DO.Bus GetBus(int id);
        void UpdateBus(DO.Bus bus);
        void DeleteBus(int id);
        #endregion Bus
        #region Line
        void CreateLine(DO.Line line);
        DO.Line GetLine(int id);
        void UpdateLine(DO.Line line);
        void DeleteLine(int id);
        #endregion Line
        #region Station
        void CreateStation(DO.Station station);
        DO.Station GetStation(int id);
        void UpdateStation(DO.Station station);
        void DeleteStation(int id);
        #endregion Station
        #region LineStation
        void CreateLineStation(DO.LineStation lineStation);
        DO.LineStation GetLineStation(int id);
        void UpdateLineStation(DO.LineStation lineStation);
        void DeleteLineStation(int id);
        #endregion LineStation
        #region LineTrip
        void CreateLineTrip(DO.LineTrip lineTrip);
        DO.LineTrip GetLineTrip(int id);
        void UpdateLineTrip(DO.LineTrip lineTrip);
        void DeleteLineTrip(int id);
        #endregion LineTrip
        #region BusOnTrip
        void CreateBusOnTrip(DO.BusOnTrip busOnTrip);
        DO.BusOnTrip GetBusOnTrip(int id);
        void UpdateBusOnTrip(DO.BusOnTrip busOnTrip);
        void DeleteBusOnTrip(int id);
        #endregion BusOnTrip
        #region AdjacentStations
        void CreateAdjacentStations(DO.AdjacentStations adjacentStations);
        DO.AdjacentStations GetAdjacentStations(int id);
        void UpdateAdjacentStations(DO.AdjacentStations adjacentStations);
        void DeleteAdjacentStations(int id);
        #endregion AdjacentStations
    }
}
