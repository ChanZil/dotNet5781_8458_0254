﻿using System;
using System.Collections.Generic;
using System.Text;
using BL;

namespace BLAPI
{
    public static class BLFactory
    {
        public static IBL GetBL(string type)
        {
            switch (type)
            {
                case "1":
                    return new BLImp();
                case "2":
                //return new BLImp2();
                default:
                    return new BLImp();
            }
        }
    }
}
