using GestionFrais.ViewModel;
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
        private ObservableCollection<Etat> listEtat;
        private ObservableCollection<string> listMois;
        private string suivi;
        private ObservableCollection<FicheFrais> listFicheFrais;

        private ObservableCollection<FraisForfait> listFraisForfait;
        private ObservableCollection<LigneFraisForfait> listLigneFraisForfait;
        private ObservableCollection<LigneFraisHorsForfait> listLigneFraisHorsForfait;
        private ObservableCollection<Visiteur> listVisiteur;


        private string selectedMois;
        private Etat selectedEtat;
        private FicheFrais selectedFicheFrais;

        private ICommand updateFicheFrais;
        private ICommand etatFiche;

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
            set { listLigneFraisForfait = value;
                OnPropertyChanged("ListLigneFraisForfait");}
        }
        public ObservableCollection<LigneFraisHorsForfait> ListLigneFraisHorsForfait
        {
            get { return listLigneFraisHorsForfait; }
            set { listLigneFraisHorsForfait = value;
                OnPropertyChanged("ListLigneFraisHorsForfait");
            }
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
                    ListLigneFraisHorsForfait = new ObservableCollection<LigneFraisHorsForfait>(selectedFicheFrais.LesLigneFraisHorsForfait);
                }
                else
                {
                    ListLigneFraisForfait = null;
                    ListLigneFraisHorsForfait = null;
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

        public ICommand UpdateFicheFrais
        {
            get
            {
                if (this.updateFicheFrais == null)
                {
                    this.updateFicheFrais = new RelayCommand(() => UpdateLesFicheFrais(), () => true);
                }
                return this.updateFicheFrais;

            }
        }

        public ICommand EtatFiche
        {
            get
            {
                if (this.etatFiche == null)
                {
                    this.etatFiche = new RelayCommand(() => SuivreEtatFiche(), () => true);
                }
                return this.etatFiche;

            }
        }

        public string Suivi
        {
            get
            {
                return suivi;
            }

            set
            {
                suivi = value;
            }
        }

        public ObservableCollection<Etat> ListEtat
        {
            get
            {
                return listEtat;
            }

            set
            {
                listEtat = value;
            }
        }

        public Etat SelectedEtat
        {
            get
            {
                return selectedEtat;
            }

            set
            {
                selectedEtat = value;
                OnPropertyChanged("SelectedEtat");
            }
        }

        public ViewModelGestionFrais(DaoFicheFrais thedaofichefrais, DaoFraisForfait thedaofraisforfait, DaoLigneFraisForfait thedaolignefraisforfait, DaoLigneFraisHorsForfait thedaolignefraishorsforfait, DaoEtat theDaoEtat)
        {
            vmDaoFicheFrais = thedaofichefrais;
            vmDaoLigneFraisForfait = thedaolignefraisforfait;
            vmDaoLigneFraisHorsForfait = thedaolignefraishorsforfait;
            vmDaoEtats = theDaoEtat;

            listEtat = new ObservableCollection<Etat>(theDaoEtat.SelectListEtat());
            listMois = new ObservableCollection<string>(thedaofichefrais.SelectListMois());
            listFicheFrais = new ObservableCollection<FicheFrais>(thedaofichefrais.SelectAll());

        }
        private void UpdateLesFicheFrais()
        {
            if(selectedFicheFrais != null)
            {
                if(selectedEtat != null)
                {
                    FicheFrais uneFicheFrais = new FicheFrais(SelectedFicheFrais.UnVisiteur, SelectedFicheFrais.Mois, SelectedFicheFrais.MontantValide, SelectedFicheFrais.NbJustificatifs, SelectedFicheFrais.DateModif, SelectedFicheFrais.UnEtat);
                    uneFicheFrais.UnEtat.Id = SelectedEtat.Id;
                    vmDaoFicheFrais.Update(uneFicheFrais);
                }
                foreach(LigneFraisForfait lff in ListLigneFraisForfait)
                {
                    vmDaoLigneFraisForfait.Update(lff);
                }
                foreach (LigneFraisHorsForfait lfhf in ListLigneFraisHorsForfait)
                {
                    vmDaoLigneFraisHorsForfait.Update(lfhf);
                }
                vmDaoFicheFrais.Update(SelectedFicheFrais);
            }

        }

        private void SuivreEtatFiche()
        {
            if (selectedFicheFrais != null)
            {
                Suivi = selectedFicheFrais.UnEtat.Libelle;
                OnPropertyChanged("Suivi");
            }
        }
    }
}
