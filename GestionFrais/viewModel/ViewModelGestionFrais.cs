using GSBFrais.Model.Buisness;
using GSBFrais.Model.Data;
using GSBFraisModel.Buisness;
using GSBFraisModel.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestionFrais.viewModel
{
    public class ViewModelGestionFrais : ViewModelBase
    {
        private ObservableCollection<string> listMois;
        private ObservableCollection<FicheFrais> listFicheFrais;
        private ObservableCollection<FraisForfait> listFraisForfait;
        private ObservableCollection<LigneFraisForfait> listLigneFraisForfait;
        private ObservableCollection<LigneFraisHorsForfait> listLigneFraisHorsForfait;
        private ObservableCollection<Visiteur> listVisiteur;


        private ICommand updateCommand;

        private DaoEtat vmDaoEtats;
        private DaoFicheFrais vmDaoFicheFrais;
        private DaoFraisForfait vmDaoFraisForfait;
        private DaoLigneFraisForfait vmDaoLigneFraisForfait;
        private DaoLigneFraisHorsForfait vmDaoLigneFraisHorsForfait;
        private DaoVisiteurs vmDaoVisiteurs;

      
        public ObservableCollection<FicheFrais> ListFicheFrais
        {
            get { return listFicheFrais; }
            set { listFicheFrais = value; }
        }
        public ObservableCollection<Visiteur> ListVisiteur
        {
            get { return listVisiteur; }
            set { listVisiteur = value; }
        }
        public ObservableCollection<FraisForfait> ListFraisForfait
        {
            get { return listFraisForfait; }
            set { listFraisForfait = value; }
        }
        public ObservableCollection<LigneFraisForfait> ListLigneFraisForfait
        {
            get { return listLigneFraisForfait; }
            set { listLigneFraisForfait = value; }
        }
        public ObservableCollection<LigneFraisHorsForfait> ListLigneFraisHorsForfait
        {
            get { return listLigneFraisHorsForfait; }
            set { listLigneFraisHorsForfait = value; }
        }

        public ObservableCollection<string> ListMois
        {
            get
            {
                return listMois;
            }

            set
            {
                listMois = value;
            }
        }

        public ViewModelGestionFrais(DaoFicheFrais thedaofichefrais, DaoFraisForfait thedaofraisforfait, DaoLigneFraisForfait thedaolignefraisforfait, DaoLigneFraisHorsForfait thedaolignefraishorsforfait)
        {
            vmDaoFicheFrais = thedaofichefrais;
            vmDaoFraisForfait = thedaofraisforfait;
            vmDaoLigneFraisForfait = thedaolignefraisforfait;
            vmDaoLigneFraisHorsForfait = thedaolignefraishorsforfait;

            listFicheFrais = new ObservableCollection<FicheFrais>(thedaofichefrais.SelectAll());
            listMois = new ObservableCollection<string>(thedaofichefrais.SelectListMois());
            /*listFraisForfait = new ObservableCollection<FraisForfait>(thedaofraisforfait.SelectAll());
            listLigneFraisForfait = new ObservableCollection<FraisForfait>(thedaolignefraisforfait.SelectAll());
            listLigneFraisHorsForfait = new ObservableCollection<FraisForfait>(thedaolignefraishorsforfait.SelectAll());

            //je relie (ou connecte) les deux listes entre elles, comme ça quand je sélectione un fromage, le pays est mis à jour dans la combobox
            foreach (Fromage thef in ListFromages)
            {
                int i = 0;
                while (thef.Origin.Name != listPays[i].Name) i++;
                thef.Origin = listPays[i];
            }*/

        }
    }
}
