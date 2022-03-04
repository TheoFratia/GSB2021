using GSBFrais.Model.Buisness;
using GSBFrais.Model.Data;
using GSBFraisModel.Buisness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFraisModel.Data
{
    public class DaoFicheFrais
    {
        private Dbal thedbal;
        private DaoVisiteurs unDaoVisiteur;

        public DaoFicheFrais(Dbal mydbal)
        {
            this.thedbal = mydbal;
        }

        public void Insert(FicheFrais theFicheFrais)
        {
            string query = "FicheFrais (idVisiteur, mois, nbJustificatifs, montantValide, dateModif, idEtat) VALUES (" + theFicheFrais.UnVisiteur.Id + ",'" + theFicheFrais.Mois + "," + theFicheFrais.NbJustificatifs + "," + theFicheFrais.MontantValide + "," + theFicheFrais.DateModif + "," + theFicheFrais.UnEtat.Id + "')";
            this.thedbal.Insert(query);
        }

        public void Delete(FicheFrais theFicheFrais)
        {
            string query = "FicheFrais where idVisiteur=" + theFicheFrais.UnVisiteur.Id + "AND mois=" + theFicheFrais.Mois + ";'";
            this.thedbal.Delete(query);
        }

        public void Update(FicheFrais theFicheFrais)
        {
            string query = "FicheFrais SET mois= " + theFicheFrais.Mois + " , nbJustificatifs= " + theFicheFrais.NbJustificatifs + ",montantValide =" + theFicheFrais.MontantValide + ",dateModif =" + theFicheFrais.DateModif + " ,adresse=" + ";'";
            this.thedbal.Update(query);
        }

        public List<FicheFrais> SelectAll()
        {
            List<FicheFrais> listVisiteur = new List<FicheFrais>();
            DataTable myTable = this.thedbal.SelectAll("FicheFrais");

            foreach (DataRow r in myTable.Rows)
            {
                Visiteur unVisiteur = unDaoVisiteur.SelectById((string)r["idVisiteur"]);
                listVisiteur.Add(new FicheFrais(unVisiteur,(string)r["mois"], (decimal)r["montantValide"], (int)r["nbJustificatifs"], (DateTime)r["dateModif"], (string)r["Etat"]));
            }
            return listVisiteur;
        }

        public FicheFrais SelectById(string idVisiteur, string mois)
        {
            DataRow result = this.thedbal.SelectById2("FicheFrais", idVisiteur, mois);
            Visiteur unVisiteur = unDaoVisiteur.SelectById((string)result["idVisiteur"]);
            return new FicheFrais(unVisiteur, (string)result["mois"], (decimal)result["montantValide"], (int)result["nbJustificatifs"], (DateTime)result["dateModif"], (string)result["Etat"]);
        }
    }
}
