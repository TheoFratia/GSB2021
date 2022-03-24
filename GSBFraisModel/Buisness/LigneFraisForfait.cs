using GSBFraisModel.Buisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFrais.Model.Buisness
{
    public class LigneFraisForfait
    {
        private FicheFrais uneFicheFrais;
        private string idVisiteur;
        private string idFraitForfait;
        private string mois;
        private int quantite;

        public LigneFraisForfait(string unIdVisiteur, string unMois,string unIdFraitForfait , int uneQuantite, FicheFrais maFicheFrais)
        {
            this.idVisiteur = unIdVisiteur;
            this.mois = unMois;
            this.idFraitForfait = unIdFraitForfait;
            this.quantite = uneQuantite;
            this.uneFicheFrais = maFicheFrais;
        }
        public LigneFraisForfait(string unIdVisiteur, string unMois, string unIdFraitForfait, int uneQuantite)
        {
            this.idVisiteur = unIdVisiteur;
            this.mois = unMois;
            this.idFraitForfait = unIdFraitForfait;
            this.quantite = uneQuantite;
        }
        public string IdVisiteur
        {
            get
            {
                return idVisiteur;
            }

            set
            {
                idVisiteur = value;
            }
        }

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

        public int Quantite
        {
            get
            {
                return quantite;
            }

            set
            {
                quantite = value;
            }
        }

        public string IdFraitForfait
        {
            get
            {
                return idFraitForfait;
            }

            set
            {
                idFraitForfait = value;
            }
        }
    }
}
