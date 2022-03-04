using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFrais.Model.Buisness
{
    public class LigneFraisForfait
    {
        private string idVisiteur;
        private string idFraitForfait;
        private DateTime mois;
        private decimal quantite;

        public LigneFraisForfait(string unIdVisiteur, DateTime unMois,string unIdFraitForfait , decimal uneQuantite)
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

        public DateTime Mois
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

        public decimal Quantite
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
