using System;
using System.Collections.Generic;
using System.Text;

namespace IOC.DAO
{
    class DaoImpl : IDao
    {
        public double GetValue()
        {
            double data= 90;

            return data;
        }
    }
}
