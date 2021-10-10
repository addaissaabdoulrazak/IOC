using System;
using System.Collections.Generic;
using System.Text;

namespace IOC.DAO
{
   public interface IDao
    {
     //pas besoin de specifier le mot clé public car toute les methode d'une interface sont public en c# 
        double GetValue();
    }
}
