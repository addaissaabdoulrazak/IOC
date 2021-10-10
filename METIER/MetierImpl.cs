using IOC.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOC.METIER
{
    public class MetierImpl : IMetier
    {
        /* au niveau de la representation UML il existe une dependance entre nos classe car on peut remarquer que la classe MetierImpl
         a besoin d'utiliser la couche DAO donc il faut Obligatoireemnt declarer une propriété*/
        public IDao Dao { get ;set;}

        //constructeur paramètrer
        public MetierImpl(IDao dao)
        {
            this.Dao = dao;
        }
        //constructeur non paramètrer
        public MetierImpl()
        {
             
        }
        public double Calcul()
        {
            double data = Dao.GetValue();

            return data * 8;
        }
    }
}
