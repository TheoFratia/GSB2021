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
            this.UnVisiteur = Visiteur;
            this.Mois = unMois;
            this.montantValide = unMontantValide;
            this.nbJustificatifs = unNbJustificatifs;
            this.dateTime = uneDateModif;
            this.UnEtat = unEtat;
        }

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

        public string Mois
        {
            get
            {
                return mois;
            }

            set
            {
                mois = value;
            }
        }

        public Visiteur UnVisiteur
        {
            get
            {
                return unVisiteur;
            }

            set
            {
                unVisiteur = value;
            }
        }

        public Etat UnEtat
        {
            get
            {
                return unEtat;
            }

            set
            {
                unEtat = value;
            }
        }

        public override string ToString()
        {
            return "Fiche Frais :  " + Mois + " - " + UnVisiteur.Id + " - " + UnVisiteur.Nom + "  " + UnVisiteur.Prenom +"\n";
        }
    }
}
