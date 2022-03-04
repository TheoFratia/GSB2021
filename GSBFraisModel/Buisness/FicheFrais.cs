using GSBFrais.Model.Buisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFraisModel.Buisness
{
    public class FicheFrais
    {
        private Visiteur unVisiteur;
        private string mois;
        private Etat unEtat;
        private decimal montantValide;
        private int nbJustificatifs;
        private DateTime dateModif;
        private DateTime dateTime;

        public FicheFrais(Visiteur Visiteur, string unMois, decimal unMontantValide, int unNbJustificatifs, DateTime uneDateModif, string unEtat)
        {
            this.unVisiteur = Visiteur;
            this.mois = unMois;
            this.montantValide = unMontantValide;
            this.nbJustificatifs = unNbJustificatifs;
            this.dateTime = uneDateModif;
            this.unEtat.Id = unEtat;
        }

        internal Visiteur UnVisiteur { get; set; }
        public string Mois { get; set; }
        internal Etat UnEtat { get; set; }
        public decimal MontantValide { get; set; }
        public int NbJustificatifs { get; set; }
        public DateTime DateModif { get; set; }
    }
}
