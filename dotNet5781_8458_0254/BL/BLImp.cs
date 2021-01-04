using System;
using System.Collections.Generic;
using System.Text;
using DALAPI;
using BLAPI;

namespace BL
{
    class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();
        #region Line
        public IEnumerable<BO.BOLine> GetAllLines()
        {

        }
#endregion Line
    }
}
