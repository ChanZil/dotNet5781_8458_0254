using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DLAPI;
using BLAPI;

namespace BL
{
    public class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();
        #region Line
        public IEnumerable<BO.BOLine> GetAllBOLines()
        {
            return from item in dl.GetAllLines()
                   select GetLine(item.Id);
        }
        //public IEnumerable<BO.BOLine> GetAllLinesBy(Predicate<BO.BOLine> predicate)
        //{

        ////}
        public BO.BOLine GetLine(int id)
        {
            DO.Line line = dl.GetLine(id);
            DO.LineTrip lineTrip = dl.GetLineTrip(id);
            IEnumerable<BO.BOStationInLine> stationList = GetAllStationInLineBy(l => l.Code == id);
            BO.BOLine boline = new BO.BOLine { Id = line.Id, Code = line.Code, Area = (BO.Areas)line.Area, StartAt = lineTrip.StartAt, FinishAt = lineTrip.FinishAt, Frequency = lineTrip.Frequency, ListOfStationInLine = stationList };
            return boline;
        }
        public void CreateLine(int code, DO.Areas area, TimeSpan startAt, TimeSpan finishAt, TimeSpan frequency, IEnumerable<BO.BOStationInLine> listOfStationInLine)
        {
            BO.BOLine bl = new BO.BOLine { Code = code, Area = (BO.Areas)area, StartAt = startAt, FinishAt = finishAt, Frequency = frequency, ListOfStationInLine = listOfStationInLine };
            dl.CreateLine(bl.Code, area, listOfStationInLine.First().Code, listOfStationInLine.Last().Code);
            try
            {
                dl.CreateLineTrip(bl.Code, bl.StartAt, bl.FinishAt, bl.Frequency);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineIdExeption("Bad line id", ex);
            }
        }

        //public void UpdateLine(BO.BOLine line)
        //{

        //}

        //public void DeleteLine(BO.BOLine bOLine)
        //{
        //    //foreach (BO.BOStationInLine item in bOLine.ListOfStationInLine)
        //    //{
        //    //    DeleteStationInLine(item); //delete adStation linestation
        //    //}
        //    //try
        //    //{
        //    //    dl.DeleteLine(bOLine.Id);
        //    //    dl.DeleteLineTrip(bOLine.Id);
        //    //}
        //    //catch (DO.BadLineIdException ex)
        //    //{
        //    //    throw new BO.BadLineIdExeption("Bad line id", ex);
        //    //}
        //    ////remove from list
        //}
        #endregion Line
        #region StationInLine
        BO.BOStationInLine StationDoBoAdapter(DO.Station stationInLineDO)
        {
            BO.BOStationInLine stationBO = new BO.BOStationInLine();
            DO.Station stationDO;
            int id = stationInLineDO.Code;
            try
            {
                stationDO = dl.GetStation(id);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("bad station id", ex);
            }
            stationBO.Code = stationDO.Code;
            stationBO.Name = stationDO.Name;
            stationBO.Longitude = stationDO.Longitude;
            stationBO.Latitude = stationDO.Latitude;
            stationBO.Address = stationDO.Address;
            return stationBO;
        }
        public IEnumerable<BO.BOStationInLine> GetAllStationInLine()
        {
            var listOfStations = dl.GetAllStations();
            return from item in listOfStations
                   select StationDoBoAdapter(item);
        }
        public IEnumerable<BO.BOStationInLine> GetAllStationInLineBy(Predicate<BO.BOStationInLine> predicate)
        {
            throw new NotImplementedException();
        }

        public BO.BOStationInLine GetStationInLine(int id)
        {
            try
            {
                DO.Station station = dl.GetStation(id);
                return StationDoBoAdapter(station);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("bad station id", ex);
            }
        }
        //public void CreateStationInLine(int code, string name, double longitude, double latitude, string address)
        //{
        //    try
        //    {
        //        dl.CreateStation(code, name, longitude, latitude, address);
        //    }
        //    catch (DO.BadStationIdException ex)
        //    {
        //        throw new BO.BadStationIdException("bad station id", ex);
        //    }
        //}
        //public void UpdateStationInLine(BO.BOStationInLine stationInLine)
        //{
        //    try
        //    {
        //        dl.UpdateStation(dl.GetStation(stationInLine.Code));
        //    }
        //    catch (DO.BadStationIdException ex)
        //    {
        //        throw new BO.BadStationIdException("bad station id", ex);
        //    }
        //}
        //public void DeleteStationInLine(BO.BOStationInLine stationInLine)
        //{
        //    try
        //    {
        //        dl.DeleteStation(stationInLine.Code);
        //    }
        //    catch (DO.BadStationIdException ex)
        //    {
        //        throw new BO.BadStationIdException("bad station id", ex);
        //    }
        //}
        #endregion StationInLine
        #region Station
        //public IEnumerable<BO.BOStation> GetAllStations() 
        //{ 
        //}
        //public IEnumerable<BO.BOStation> GetAllGetAllStationsBy(Predicate<BO.BOStation> predicate)
        //{

        //}
        //public BO.BOLine GetStation(int id)
        //{

        //}
        //public void CreateStation(DO.Station station)
        //{ 

        //}
        //public void UpdateStation(BO.BOStation station)
        //{

        //}
        //public void DeleteStation(int id)
        //{

        //}
        #endregion Station
        #region  LineStation
        //public IEnumerable<BO.BOLineStation> GetAllLineStationBy(Predicate<BO.BOLineStation> predicate)
        //{

        //}
        //public BO.BOLineStation GetLineStation(int id)
        //{

        //}
        //public void CreateLineStation(DO.Line line)
        //{

        //}
        //public void DeleteLineStation(DO.Line line)
        //{

        //}
        #endregion  LineStation
    }
}


