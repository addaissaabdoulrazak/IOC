using System;
using System.Collections.Generic;
using System.Text;

namespace IOC.DAO
{
   public class DaoImpl2:IDao
    {
        public double GetValue()
        {
            double data = 2;

            return data;
        }
    }
}
