using System;
using System.Collections.Generic;
using System.Text;
using DO;

namespace DALAPI
{
    public interface IDL
    {
        #region Bus
        IEnumerable<DO.Bus> GetAllBuses();
        IEnumerable<DO.Bus> GetAllBusesBy(Predicate<DO.Bus> predicate);
        void CreateBus(DO.Bus bus);
        DO.Bus GetBus(int id);
        void UpdateBus(DO.Bus bus);
        void UpdateBus(int id, Action<DO.Bus> update);
        void DeleteBus(int id);
        #endregion Bus
        #region Line
        IEnumerable<DO.Line> GetAllLines();
        IEnumerable<DO.Line> GetAllLinesBy(Predicate<DO.Line> predicate);
        void CreateLine(int code, Areas area, int firstS, int lastS);
        DO.Line GetLine(int id);
        void UpdateLine(DO.Line line);
        void UpdateLine(int id, Action<DO.Line> update);
        void DeleteLine(int id);
        #endregion Line
        #region Station
        IEnumerable<DO.Station> GetAllStations();
        IEnumerable<DO.Station> GetAllStationsBy(Predicate<DO.Station> predicate);
        void CreateStation(int code, string name, double longitude, double latitude, string address);
        DO.Station GetStation(int id);
        void UpdateStation(DO.Station station);
        void UpdateStation(int id, Action<DO.Station> update);
        void DeleteStation(int id);
        #endregion Station
        #region LineStation
        IEnumerable<DO.LineStation> GetAllLineStations();
        IEnumerable<DO.LineStation> GetAllLineStationsBy(Predicate<DO.LineStation> predicate);
        void CreateAllLineStations(int lineId, int stationId, int index, int prev, int next);
        DO.LineStation GetLineStation(int lineId, int stationId);
        void UpdateLineStation(DO.LineStation lineStation);
        void UpdateLineStations(int lineId, int stationId, Action<DO.LineStation> update);
        void DeleteLineStation(int lineId, int stationId);
        #endregion LineStation
        #region AdjacentStations
        IEnumerable<DO.AdjacentStations> GetAllAdjacentStations();
        IEnumerable<DO.AdjacentStations> GetAllAdjacentStationsBy(Predicate<DO.AdjacentStations> predicate);
        void CreateAdjacentStations(int codeStation1, int codeStation2, double distance, TimeSpan time);
        DO.AdjacentStations GetAdjacentStations(int station1, int station2);
        void UpdateAdjacentStations(DO.AdjacentStations adjacentStations);
        void UpdateAdjacentStations(int codeStation1, int codeStation2, Action<DO.AdjacentStations> update);
        void DeleteAdjacentStations(int codeStation1, int codeStation2);
        #endregion AdjacentStations
        #region LineTrip
        IEnumerable<DO.LineTrip> GetAllLineTrip();
        IEnumerable<DO.LineTrip> GetAllLineTripBy(Predicate<DO.LineTrip> predicate);
        void CreateLineTrip(int code, TimeSpan startAt, TimeSpan finishAt, TimeSpan frequency);
        DO.LineTrip GetLineTrip(int id);
        void UpdateLineTrip(DO.LineTrip lineTrip);
        void UpdateLineTrip(int id, Action<DO.LineTrip> update);
        void DeleteLineTrip(int id);
        #endregion LineTrip
    }
}
