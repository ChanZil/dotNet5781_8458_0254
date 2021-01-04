using System;
using System.Collections.Generic;
using System.Text;

namespace BLAPI
{
    public interface IBL
    {
        #region Line
        IEnumerable<BO.BOLine> GetAllLines();
        IEnumerable<BO.BOLine> GetAllLinesBy(Predicate<BO.BOLine> predicate);
        BO.BOLine GetLine(int id);
        void CreateLine(int code,DO.DOenums.Areas area, TimeSpan startAt, TimeSpan finishAt, TimeSpan frequency, IEnumerable<BO.BOStationInLine> listOfLineStation);
        void UpdateLine(BO.BOLine line);
        void DeleteLine(int id);
        #endregion Line
        #region StationInLine
        IEnumerable<BO.BOStationInLine> GetAllStationInLineBy(Predicate<BO.BOStationInLine> predicate);
        BO.BOStationInLine GetStationInLine(int id);
        void CreateStationInLine(DO.Station station, int index);
        void UpdateStationInLine(BO.BOStationInLine stationInLine);
        void DeleteStationInLine(int id);
        #endregion StationInLine
        #region Station
        IEnumerable<BO.BOStation> GetAllStations();
        IEnumerable<BO.BOStation> GetAllGetAllStationsBy(Predicate<BO.BOStation> predicate);
        BO.BOLine GetStation(int id);
        void CreateStation(DO.Station station);
        void UpdateStation(BO.BOStation station);
        void DeleteStation(int id);
        #endregion Station
        #region LineStation
        IEnumerable<BO.BOLineStation> GetAllLineStationBy(Predicate<BO.BOLineStation> predicate);
        BO.BOLineStation GetLineStation(int id);
        void CreateLineStation(DO.Line line);
        void DeleteLineStation(DO.Line line);
        #endregion LineStation
    }
}
