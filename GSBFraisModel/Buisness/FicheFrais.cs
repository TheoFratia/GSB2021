using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFraisModel.Buisness
{
    class FicheFrais
    {
        private Visiteur unVisiteur;
        private string mois;
        private Etat unEtat;
        private decimal montantValide;
        private int nbJustificatifs;
        private DateTime dateModif;

        internal Visiteur UnVisiteur { get; set; }
        public string Mois { get; set; }
        internal Etat UnEtat { get; set; }
        public decimal MontantValide { get; set; }
        public int NbJustificatifs { get; set; }
        public DateTime DateModif { get; set; }
    }
}
