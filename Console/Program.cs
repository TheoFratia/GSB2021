using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSBFraisModel.Data;
using GSBFraisModel.Buisness;
using GSBFrais.Model.Data;
using GSBFrais.Model.Buisness;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Dbal unDbal = new Dbal();
            Visiteur unVisiteur = new Visiteur("f22", "Fratia", "Theo", "fratia.theo", "motDePasse", "8 GD azerty", "42000", "Saint-Etienne", new DateTime(2002-11-25));
            DaoVisiteurs unDaoVisiteur = new DaoVisiteurs(unDbal);
            unDaoVisiteur.Insert(unVisiteur);
            //test.Insert("Visiteur VALUES('f22', 'Fratia', 'Theo', 'fratia.theo', 'motDePasse', '8 GD azerty', '42000', 'Saint-Etienne', '2002-11-25')");
        }
    }
}
