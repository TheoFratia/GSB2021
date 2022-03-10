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
        private DaoEtat unDaoEtat;

        public DaoFicheFrais(Dbal mydbal, DaoVisiteurs myDaoVisiteur, DaoEtat myEtat)
        {
            this.thedbal = mydbal;
            this.unDaoVisiteur = myDaoVisiteur;
            this.unDaoEtat = myEtat;
        }

        public void Insert(FicheFrais theFicheFrais)
        {
            string query = "FicheFrais (idVisiteur, mois, nbJustificatifs, montantValide, dateModif, idEtat) VALUES ('" + theFicheFrais.UnVisiteur.Id + "','" + theFicheFrais.Mois + "','" + theFicheFrais.NbJustificatifs + "','" + theFicheFrais.MontantValide + "','" + theFicheFrais.DateModif + "','" + theFicheFrais.UnEtat.Id + "')";
            this.thedbal.Insert(query);
        }

        public void Delete(FicheFrais theFicheFrais)
        {
            string query = "FicheFrais where idVisiteur='" + theFicheFrais.UnVisiteur.Id + "'AND mois='" + theFicheFrais.Mois + "';";
            this.thedbal.Delete(query);
        }

        public void Update(FicheFrais theFicheFrais)
        {
            string query = "FicheFrais SET mois='" + theFicheFrais.Mois + "', nbJustificatifs='" + theFicheFrais.NbJustificatifs + "',montantValide ='" + theFicheFrais.MontantValide + "',dateModif ='" + theFicheFrais.DateModif + "',adresse='" + "';";
            this.thedbal.Update(query);
        }

        public List<FicheFrais> SelectAll()
        {
            List<FicheFrais> listVisiteur = new List<FicheFrais>();
            DataTable myTable = this.thedbal.SelectAll("FicheFrais");

            foreach (DataRow r in myTable.Rows)
            {
                Visiteur unVisiteur = unDaoVisiteur.SelectById((string)r["idVisiteur"]);
                Etat unEtat = unDaoEtat.SelectById((string)r["idEtat"]);
                listVisiteur.Add(new FicheFrais(unVisiteur,(string)r["mois"], (decimal)r["montantValide"], (int)r["nbJustificatifs"], (DateTime)r["dateModif"], unEtat));
            }
            return listVisiteur;
        }

        public FicheFrais SelectById(string idVisiteur, string mois)
        {
            DataRow result = this.thedbal.SelectById2("FicheFrais", idVisiteur, mois);
            Visiteur unVisiteur = unDaoVisiteur.SelectById((string)result["idVisiteur"]);
            Etat unEtat = unDaoEtat.SelectById((string)result["id"]);
            return new FicheFrais(unVisiteur, (string)result["mois"], (decimal)result["montantValide"], (int)result["nbJustificatifs"], (DateTime)result["dateModif"], (Etat)result["Etat"]);
        }

        /*public FicheFrais SelectListMois()
        {
            string query = "SELECT Distinct(mois) FROM FicheFrais Order by mois desc";
        } SELECTbymois*/

    }
}
