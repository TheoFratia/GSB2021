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
    public class DaoLigneFraisHorsForfait
    {
        private Dbal unDbal;

        public DaoLigneFraisHorsForfait(Dbal myDbal)
        {
            this.unDbal = myDbal;
        }

        public void Insert(LigneFraisHorsForfait LigneFraisHorsForfait)
        {
            string query = " ligneFraisForfait (idVisiteur, mois, idFraitForfait, quentite) VALUES ('" + LigneFraisHorsForfait.Id + "',' " + LigneFraisHorsForfait.IdVisiteur + "','" + LigneFraisHorsForfait.Mois + "','" + LigneFraisHorsForfait.Libelle + "','" + LigneFraisHorsForfait.Date + "','" + LigneFraisHorsForfait.Montant + "')";
            this.unDbal.Insert(query);
        }

        public void Update(LigneFraisHorsForfait LigneFraisHorsForfait)
        {
            string query = " ligneFraisForfait (idVisiteur, mois, idFraitForfait, quentite) SET '" + LigneFraisHorsForfait.Mois + "','" + LigneFraisHorsForfait.Libelle + "','" + LigneFraisHorsForfait.Date + "','" + LigneFraisHorsForfait.Montant + "'";
            this.unDbal.Update(query);
        }

        public void Delete(LigneFraisHorsForfait LigneFraisHorsForfait)
        {
            string query = " visiteur WHERE idVisiteur ='" + LigneFraisHorsForfait.IdVisiteur + "'AND id ='" + LigneFraisHorsForfait.Id + "'";
            this.unDbal.Delete(query);
        }

        public List<LigneFraisHorsForfait> SelectAll()
        {
            List<LigneFraisHorsForfait> listLigneFraisForfait = new List<LigneFraisHorsForfait>();
            DataTable myTable = this.unDbal.SelectAll("ligneFraisHorsForfait");

            foreach (DataRow r in myTable.Rows)
            {
                listLigneFraisForfait.Add(new LigneFraisHorsForfait((int)r["id"], (string)r["idVisiteur"],(string)r["mois"], (string)r["libelle"], (DateTime)r["date"], (decimal)r["montant"]));
            }
            return listLigneFraisForfait;
        }

        public LigneFraisHorsForfait SelectById(string idFraisHorsForfait)
        {
            DataRow result = this.unDbal.SelectById("ligneFraisHorsForfait", "id = " + idFraisHorsForfait);
            return new LigneFraisHorsForfait((int)result["id"], (string)result["idVisiteur"], (string)result["mois"], (string)result["libelle"], (DateTime)result["date"], (decimal)result["montant"]);
        }
        public List<LigneFraisHorsForfait> selectbyFicheFrais(FicheFrais uneFicheFrais)
        {
            List<LigneFraisHorsForfait> listLigneFraisHorsForfait = new List<LigneFraisHorsForfait>();
            DataTable myTable = this.unDbal.SelectBYComposedFK2("ligneFraisHorsForfait", "idVisiteur", " mois", uneFicheFrais.UnVisiteur.Id, uneFicheFrais.Mois);
            foreach (DataRow r in myTable.Rows)
            {
                listLigneFraisHorsForfait.Add(new LigneFraisHorsForfait((int)r["id"], (string)r["idVisiteur"], (string)r["mois"], (string)r["libelle"], (DateTime)r["date"], (decimal)r["montant"]));
            }
            
            return listLigneFraisHorsForfait;
        }
    }
}
