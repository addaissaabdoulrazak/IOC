using System;
using System.IO;
using IOC.DAO;
using IOC.METIER;


namespace IOC
{
    class Program
    {
        static void Main(string[] args)
        {
/*-----------------------------------------------------------------------------------------------------------------------------------------------------*
 *  Partie 2:Injection des depandance par instanciation dynamique   car aucun class n'est utiliser si ce n'est que des Interface                       *
 *  c'est a dire que les classe ne sont pas fournis lors de la compilation, il ne sont fourni que lors de l'execution par configuartion                *
 *-----------------------------------------------------------------------------------------------------------------------------------------------------*/
            string path = "C:\\Users\\USER-PC\\source\\repos\\IOC\\config.txt";
            /*Creation d'un Objet permettant d'effectuer un e lecture Ligne par ligne*/
            //    StreamReader sr = new StreamReader(path);
            //string daoClassName = sr.ReadLine();
            //string metierClassName = sr.ReadLine();
            //Console.WriteLine(daoClassName);
            //Console.WriteLine(metierClassName);
            //Console.ReadKey();

            /*------------------------------------------------------------------------------------------------------------------------------------------------------*
             *              si vous voulez lire le contenue d'un fichier dans la  globalité utiliser un Table                                                       *
             *------------------------------------------------------------------------------------------------------------------------------------------------------*/


            String[] AllDataFile = System.IO.File.ReadAllLines(path);
            string daoClassName = AllDataFile[0];
            string metierClassName = AllDataFile[1];

            /* 1- Nous allons Instancier dynamiquement nos deux classe grâce a la classe "type" et Activator*/
            /* 2- je rappel que dans le fichier(config.txt) nous avons specifier le chemin d'accès a nos classe implementer nos differente interface */
            /* 3- la classe type me permet d'obtenir le nom et le type de la calsse daoImpl*/
            Type typeDao = Type.GetType(daoClassName);

            /*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*
             *                                                                                                                                                                 *
             *  Activator permet de creer une instance de type DaoImpl(class implémentant l'interface IDao ). ATTENTION : nous pouvons affectez  un Objet de sous type         *
             *  a un type générique même s'il sagissais des interfaces la relation [EST-UN] existerait entre la classe implementant L'interface et l'interface elle même       *
             *  EX: considerons une interface Animal et une classe Chat implementant l'interface Animal il est possible de declarer une variable de type Animal et lui affecté *
             *         un objet(utilisation de new <<instanciation>>) de type chat car on peu dire <<qu'un chat est une Animal>> => Le polymorphisme dans tout ces Etat        *
             *                                                                                                                                                                 *
             *         c'est ce principe qui est mis en Evidance dans ce exercice avec :IDao dao=(IDao)Activator.CreateInstance(typeDao)                                       *
             *-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
            IDao dao = (IDao)Activator.CreateInstance(typeDao);
            Type typeMetier = Type.GetType(metierClassName);

            //on passe dao en paramètre car il existe une relation de depandance entre la classe MetierImpl ei IDao
            IMetier metier = (IMetier)Activator.CreateInstance(typeMetier, dao);
            Console.WriteLine(" Résultat = " + metier.Calcul());
            Console.ReadKey();

            /* Parite 1: Decommenté et tester 
            // -1 Dans un premier temps nous allons effectuer l'instanciation Static remarquer la presence de new()
            DaoImpl Dao = new DaoImpl();
            MetierImpl metier = new MetierImpl(Dao);
            Console.WriteLine("Resultat=" + metier.Calcul());
            Console.ReadKey();*/
        }

    }
}
