using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DALAPI;
using BLAPI;
namespace BL
{
    class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();
        #region Line
        public IEnumerable<BO.BOLine> GetAllBOLines()
        {
            var tmp = from line1 in dl.GetAllLines()
                      from line2 in dl.GetAllLineTripBy(l => l.LineId == line1.Id)
                      select new
                      {
                          Id = line1.Id,
                          Code = line1.Code,
                          Area = line1.Area,
                          StartAt = line2.StartAt,
                          FinishAt = line2.FinishAt,
                          Frequency = line2.Frequency
                      };
            var tmp1 = from item in tmp
                       from i in dl.GetAllLineStationsBy(l => l.LineId == item.Id)
                       select new { Code = i.LineId, Name = i., };
        }
        public void CreateLine(int code, DO.DOenums.Areas area, TimeSpan startAt, TimeSpan finishAt, TimeSpan frequency, IEnumerable<BO.BOStationInLine> listOfStationInLine)
        {
            BO.BOLine bl = new BO.BOLine { Code = code, Area = area, StartAt = startAt, FinishAt = finishAt, Frequency = frequency, ListOfStationInLine = listOfStationInLine };
            dl.CreateLine(bl.Code, bl.Area, listOfStationInLine.First().Code, listOfStationInLine.Last().Code);
            try
            {
                dl.CreateLineTrip(bl.Code, bl.StartAt, bl.FinishAt, bl.Frequency);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineIdExeption("Bad line id", ex);
            }
            //add bl to list
        }

        public void UpdateLine(BO.BOLine line)
        {

        }

        public void DeleteLine(BO.BOLine bOLine)
        {
            foreach (BO.BOStationInLine item in bOLine.ListOfStationInLine)
            {
                DeleteStationInLine(item); //delete adStation linestation
            }
            try
            {
                dl.DeleteLine(bOLine.Id);
                dl.DeleteLineTrip(bOLine.Id);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineIdExeption("Bad line id", ex);
            }
            //remove from list
        }
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
            stationBO.Code= stationDO.Code;
            stationBO.Name = stationDO.Name;
            stationBO.Longitude = stationDO.Longitude;
            stationBO.Latitude = stationDO.Latitude;
            stationBO.Address = stationDO.Address;

            return stationBO;
        }
        public IEnumerable<BO.BOStationInLine> GetAllStationInLineBy(Predicate<BO.BOStationInLine> predicate)
        {
            throw new NotImplementedException();
        }

        BO.BOStationInLine GetStationInLine(int id)
        {
            try
            {
                DO.Station station=dl.GetStation(id);
                return StationDoBoAdapter(station);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("bad station id", ex);
            }
        }
        void CreateStationInLine(int code, string name, double longitude, double latitude, string address)
        {
            try
            {
                dl.CreateStation(code, name, longitude, latitude, address);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("bad station id", ex);
            }
        }
        void UpdateStationInLine(BO.BOStationInLine stationInLine)
        {
            try
            {
                dl.UpdateStation(dl.GetStation(stationInLine.Code));
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("bad station id", ex);
            }
        }
        public void DeleteStationInLine(BO.BOStationInLine stationInLine)
        {
            try
            {
                dl.DeleteStation(stationInLine.Code);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("bad station id", ex);
            }
        }
        #endregion StationInLine
    }
}


