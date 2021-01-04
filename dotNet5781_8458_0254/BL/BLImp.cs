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
                      from line2 in dl.GetAllLineTripBy(l=>l.LineId==line1.Id)
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
                  select new { Code =i.LineId, Name=i., };
        }
        public void CreateLine(int code, DO.DOenums.Areas area, TimeSpan startAt, TimeSpan finishAt, TimeSpan frequency, IEnumerable<BO.BOStationInLine> listOfLineStation)
        {
            BO.BOLine bl = new BO.BOLine { Code = code, Area = area, StartAt = startAt, FinishAt = finishAt, Frequency = frequency, ListOfLineStation = listOfLineStation };
            dl.CreateLine(bl.Code, bl.Area, listOfLineStation.First().Code, listOfLineStation.Last().Code);
            dl.CreateLineTrip(bl.Code, bl.StartAt, bl.FinishAt, bl.Frequency);
            //add bl to list
        }
        public void DeleteLine(BO.BOLine bOLine)
        {
            var tmp = from item in bOLine.ListOfLineStation
                      from 

        }
        #endregion Line
    }
}
