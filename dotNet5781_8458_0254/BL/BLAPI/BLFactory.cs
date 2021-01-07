using System;
using System.Collections.Generic;
using System.Text;
using BL;

namespace BLAPI
{
    public static class BLFactory
    {
        public static IBL GetBL()
        {
            return new BLImp();
        }
    }
}
