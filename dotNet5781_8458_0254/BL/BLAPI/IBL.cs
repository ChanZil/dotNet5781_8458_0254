using System;
using System.Collections.Generic;
using System.Text;

namespace BLAPI
{
    public interface IBL
    {
        #region Line
        IEnumerable<BO.BOLine> GetAllBOLines();
        BO.BOLine GetLine(int id);
        int CreateLine(int code, BO.Areas area, TimeSpan startAt, TimeSpan finishAt, TimeSpan frequency, IEnumerable<BO.BOStationInLine> listOfLineStation);
        void UpdateLine(BO.BOLine line);
        void DeleteLine(BO.BOLine bOLine);
        #endregion Line
        #region StationInLine
        IEnumerable<BO.BOStationInLine> GetAllStationInLine();
        IEnumerable<BO.BOStationInLine> GetAllStationInLineByCodeLine(int code);
        BO.BOStationInLine GetStationInLine(int lineId, int stationId);
        void CreateStationInLine(int lineId, int stationId, double distance,TimeSpan time,int index,int prev, int next);
        void UpdateStationInLine(BO.BOStationInLine stationInLine, int lineId, int index, int prev, int next);
        void DeleteStationInLine(BO.BOStationInLine stationInLine, int lineId);
        #endregion StationInLine
        #region Station
        IEnumerable<BO.BOStation> GetAllStations();
        void CreateStation(BO.BOStation station);
        void UpdateStation(BO.BOStation station);
        void DeleteStation(int id);
        #endregion Station
        #region LineStation
        IEnumerable<BO.BOLineStation> GetAllLineStationByStationId(int stationId);
        #endregion LineStation
        #region Bus
        IEnumerable<BO.BOBus> GetAllBOBuses();
        BO.BOBus GetBus(int id);
        void CreateBus(int id, DateTime fromDate, double total, double fuelRemain, BO.BusStatus status);
        void UpdateBus(BO.BOBus bus);
        void DeleteBus(BO.BOBus bOBus);
        #endregion Bus
    }
}
