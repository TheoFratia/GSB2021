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

        public FicheFrais(Visiteur Visiteur, string unMois, decimal unMontantValide, int unNbJustificatifs, DateTime uneDateModif, Etat unEtat)
        {
            this.unVisiteur = Visiteur;
            this.mois = unMois;
            this.montantValide = unMontantValide;
            this.nbJustificatifs = unNbJustificatifs;
            this.dateTime = uneDateModif;
            this.unEtat = unEtat;
        }

        internal Visiteur UnVisiteur { get; set; }
        public string Mois { get; set; }
        internal Etat UnEtat { get; set; }
        public decimal MontantValide
        {
            get
            {
                return montantValide;
            }
            set { montantValide = value; }
        }
        public int NbJustificatifs
        {
            get
            {
                return nbJustificatifs;
            }
            set
            {
                nbJustificatifs = value;
            }
        }
        public List<LigneFraisForfait> LesLigneFraisForfait { get; set; }
        public List<LigneFraisHorsForfait> LesLigneFraisHorsForfait { get; set; }


        public DateTime DateModif { get; set; }

        public override string ToString()
        {
            return "Fiche Frais :  " + mois + " - " + unVisiteur.Id + " - " + unVisiteur.Nom + "  " + unVisiteur.Prenom +"\n";
        }
    }
}
