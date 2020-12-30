using System;
using System.Collections.Generic;
using System.Text;
using DALAPI;
using DS;
using DO;

namespace DL
{
    sealed class DLObject : IDL
    {
        static readonly DLObject instance = new DLObject();
        #region singelton

        #endregion singelton
        #region Bus
        public void CreateBus(DO.Bus bus)
        {
            //חריגה- לבדוק אם האוטובוס לא נמצא כבר
            DataSource.listBuses.Add(bus.Clone());
        }
        public DO.Bus GetBus(int id)
        {
            
        }
        public void UpdateBus(DO.Bus bus)
        {

        }
        public void DeleteBus(int id)
        {

        }
        #endregion Bus
    }
}
