using GSBFrais.Model.Buisness;
using GSBFraisModel.Buisness;
using GSBFraisModel.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFrais.Model.Data
{
    public class DaoLigneFraisForfait
    {
        private Dbal unDbal;

        public DaoLigneFraisForfait(Dbal myDbal)
        {
            this.unDbal = myDbal;
        }

        public void Insert(LigneFraisForfait uneLigneFraisForfait)
        {
            string query = " ligneFraisForfait (idVisiteur, mois, idFraitForfait, quantite) VALUES ('" + uneLigneFraisForfait.IdVisiteur + "','" + uneLigneFraisForfait.Mois + "','" + uneLigneFraisForfait.IdFraitForfait + "','" + uneLigneFraisForfait.Quantite + "')";
            this.unDbal.Insert(query);
        }

        public void Update(LigneFraisForfait uneLigneFraisForfait)
        {
            string query = " ligneFraisForfait SET quantite=" + uneLigneFraisForfait.Quantite
                + " WHERE idVisiteur ='" + uneLigneFraisForfait.IdVisiteur.Replace("'", "''") 
                + "' AND mois='" + uneLigneFraisForfait.Mois.Replace("'", "''")
                + "' AND idFraisForfait='" + uneLigneFraisForfait.IdFraitForfait.Replace("'", "''") + "'";
            this.unDbal.Update(query);
        }

        public void Delete(LigneFraisForfait uneLigneFraisForfait)
        {
            string query = " ligneFraisForfait WHERE idVisiteur ='" + uneLigneFraisForfait.IdVisiteur + "' AND idFraisForfait ='"+ uneLigneFraisForfait.IdFraitForfait + "'";
            this.unDbal.Delete(query);
        }

        public List<LigneFraisForfait> SelectAll()
        {
            List<LigneFraisForfait> listLigneFraisForfait = new List<LigneFraisForfait>();
            DataTable myTable = this.unDbal.SelectAll("ligneFraisForfait");

            foreach (DataRow r in myTable.Rows)
            {
                listLigneFraisForfait.Add(new LigneFraisForfait((string)r["idVisiteur"], (string)r["mois"], (string)r["idFraisForfait"], (int)r["quantite"]));
            }
            return listLigneFraisForfait;
        }

        public LigneFraisForfait SelectById(string idFraisForfait)
        {
            DataRow result = this.unDbal.SelectById("ligneFraisForfait", "idFraisForfait = " + idFraisForfait);
            return new LigneFraisForfait((string)result["idVisiteur"], (string)result["mois"], (string)result["idFraisForfait"], (int)result["quantite"]);
        }

        public List<LigneFraisForfait> selectbyFicheFrais(FicheFrais uneFicheFrais)
        {
            List<LigneFraisForfait> listLigneFraisForfait = new List<LigneFraisForfait>();
            DataTable myTable = this.unDbal.SelectBYComposedFK2("ligneFraisForfait", "idVisiteur", " mois",uneFicheFrais.UnVisiteur.Id,uneFicheFrais.Mois);

            foreach (DataRow r in myTable.Rows)
            {
                listLigneFraisForfait.Add(new LigneFraisForfait((string)r["idVisiteur"], (string)r["mois"], (string)r["idFraisForfait"], (int)r["quantite"]));
            }
            return listLigneFraisForfait;
        }
    }
}
