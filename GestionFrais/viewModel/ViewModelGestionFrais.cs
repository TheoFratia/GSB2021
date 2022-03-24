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


        private string selectedMois;
        private FicheFrais selectedFicheFrais;

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
        public FicheFrais SelectedFicheFrais
        {
            get
            {
                return selectedFicheFrais;
            }

            set
            {
                selectedFicheFrais = value;
             
                OnPropertyChanged("SelectedFicheFrais");
                if (selectedFicheFrais != null)
                {
                    ListLigneFraisForfait = new ObservableCollection<LigneFraisForfait>(selectedFicheFrais.LesLigneFraisForfait);
                    OnPropertyChanged("ListFraisForfait");
                }
            }
        }

        public string SelectedMois
        {
            get
            {
                return selectedMois;
            }

            set
            {
                selectedMois = value;
                OnPropertyChanged("SelectedMois");
                listFicheFrais = new ObservableCollection<FicheFrais>(vmDaoFicheFrais.SelectByMonth(SelectedMois));
                OnPropertyChanged("ListFicheFrais");
            }
        }

        public ViewModelGestionFrais(DaoFicheFrais thedaofichefrais, DaoFraisForfait thedaofraisforfait, DaoLigneFraisForfait thedaolignefraisforfait, DaoLigneFraisHorsForfait thedaolignefraishorsforfait)
        {
            vmDaoFicheFrais = thedaofichefrais;

            listMois = new ObservableCollection<string>(thedaofichefrais.SelectListMois());
            listFicheFrais = new ObservableCollection<FicheFrais>(thedaofichefrais.SelectAll());

        }
    }
}
