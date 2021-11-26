using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFraisModel.Buisness
{
    class Visiteur
    {
        private string id;
        private string nom;
        private string login;
        private string mdp;
        private string cp;
        private string ville;
        private DateTime  dateEmbauche;


        string Id { get; set; }
        string Login { get; set; }
        public string Nom { get; set; }
        public string Mdp { get; set; }
        public string Cp { get; set; }
        public string Ville { get; set; }
        public DateTime DateEmbauche { get; set; }
    }
}
