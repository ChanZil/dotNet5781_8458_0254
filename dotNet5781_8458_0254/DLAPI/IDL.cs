using System;
using System.Collections.Generic;
using System.Text;
using DO;

namespace DLAPI
{
    public interface IDL
    {
        #region Bus
        IEnumerable<DO.Bus> GetAllBuses();
        void CreateBus(DO.Bus bus);
        DO.Bus GetBus(int id);
        void UpdateBus(DO.Bus bus);
        void DeleteBus(int id);
        #endregion Bus
        #region Line
        IEnumerable<DO.Line> GetAllLines();
        int CreateLine(int code, Areas area, int firstS, int lastS);
        DO.Line GetLine(int id);
        void UpdateLine(DO.Line line);
        void DeleteLine(int id);
        #endregion Line
        #region Station
        IEnumerable<DO.Station> GetAllStations();
        IEnumerable<DO.Station> GetAllStationsBy(Predicate<DO.Station> predicate);
        void CreateStation(int code, string name, double longitude, double latitude, string address);
        DO.Station GetStation(int id);
        void UpdateStation(DO.Station station);
        void DeleteStation(int id);
        #endregion Station
        #region LineStation
        IEnumerable<DO.LineStation> GetAllLineStations();
        IEnumerable<DO.LineStation> GetAllLineStationsBy(Predicate<DO.LineStation> predicate);
        void CreateLineStation(int lineId, int stationId, int index, int prev, int next);
        DO.LineStation GetLineStation(int lineId, int stationId);
        void UpdateLineStation(DO.LineStation lineStation);
        void DeleteLineStation(int lineId, int stationId);
        #endregion LineStation
        #region AdjacentStations
        IEnumerable<DO.AdjacentStations> GetAllAdjacentStations();
        IEnumerable<DO.AdjacentStations> GetAllAdjacentStationsBy(Predicate<DO.AdjacentStations> predicate);
        void CreateAdjacentStations(int lineId, int codeStation1, int codeStation2, double distance, TimeSpan time);
        DO.AdjacentStations GetAdjacentStations(int lineId, int station1, int station2);
        void UpdateAdjacentStations(DO.AdjacentStations adjacentStations);
        void DeleteAdjacentStations(int lineId, int codeStation1, int codeStation2);
        #endregion AdjacentStations
        #region LineTrip
        IEnumerable<DO.LineTrip> GetAllLineTrip();
        void CreateLineTrip(int code, TimeSpan startAt, TimeSpan finishAt, TimeSpan frequency);
        DO.LineTrip GetLineTrip(int id);
        void UpdateLineTrip(DO.LineTrip lineTrip);
        void DeleteLineTrip(int id);
        #endregion LineTrip
    }
}
