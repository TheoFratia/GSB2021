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
using System.Windows.Data;
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
        private string rechercheNom;
        private Etat selectedEtat;
        private FicheFrais selectedFicheFrais;
        private LigneFraisForfait selectedForfait;
        private LigneFraisHorsForfait selectedHorsForfait;

        private ICommand updateFicheFrais;
        private ICommand etatFiche;
        private ICommand refusLigne;
        private ICommand report;
        private ICommand validerFicheFrais;
        
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

        public ICommand ValiderFicheFrais
        {
            get
            {
                if (this.validerFicheFrais == null)
                {
                    this.validerFicheFrais = new RelayCommand(() => Valider(), () => true);
                }
                return this.validerFicheFrais;

            }
        }

        private void Valider()
        {
            if (SelectedFicheFrais.UnEtat.Id != "RB" && SelectedFicheFrais.UnEtat.Id != "CL")
            {
                SelectedFicheFrais.UnEtat.Id = "VA";
                SelectedFicheFrais.UnEtat.Libelle = "Validée et mise en paiement";
                Suivi = SelectedFicheFrais.UnEtat.Libelle;
                vmDaoFicheFrais.Update(SelectedFicheFrais);
                OnPropertyChanged("Suivi");
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
        public ICommand Report
        {
            get
            {
                if (this.report == null)
                {
                    this.report = new RelayCommand(() => ReporterMois(), () => true);
                }
                return this.report;

            }
        }

        public ICommand RefusLigne
        {
            get
            {
                if (this.refusLigne == null)
                {
                    this.refusLigne = new RelayCommand(() => RefuserLaLigne(), () => true);
                }
                return this.refusLigne;
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

        public LigneFraisForfait SelectedForfait
        {
            get
            {
                return selectedForfait;
            }

            set
            {
                selectedForfait = value;
                OnPropertyChanged("SelectedForfait");
                selectedHorsForfait = null;
            }
        }

        public LigneFraisHorsForfait SelectedHorsForfait
        {
            get
            {
                return selectedHorsForfait;
            }

            set
            {
                selectedHorsForfait = value;
                OnPropertyChanged("SelectedHorsForfait");
                selectedForfait = null;
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
            listVisiteur = new ObservableCollection<Visiteur>();

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
                SelectedFicheFrais.UnEtat.Libelle = SelectedEtat.Libelle;
                Suivi = SelectedFicheFrais.UnEtat.Libelle;
                vmDaoFicheFrais.Update(SelectedFicheFrais);
            }

        }
        private void RefuserLaLigne()
        {
            if(SelectedHorsForfait != null && SelectedForfait == null)
            {
                vmDaoLigneFraisHorsForfait.Delete(selectedHorsForfait);
                listLigneFraisHorsForfait.Remove(SelectedHorsForfait);
                selectedFicheFrais.LesLigneFraisHorsForfait = new List<LigneFraisHorsForfait>(selectedFicheFrais.LesLigneFraisHorsForfait);
            }
        }
        private void ReporterMois()
        {
            DateTime today = DateTime.Now;
            string date = today.ToString("yyyyMM");
            if (SelectedHorsForfait != null)
            {
                    if(vmDaoFicheFrais.SelectById(SelectedHorsForfait.IdVisiteur, date) != null)
                    {
                        LigneFraisHorsForfait lfhf = new LigneFraisHorsForfait(SelectedHorsForfait.Id, SelectedHorsForfait.IdVisiteur, date, SelectedHorsForfait.Libelle, SelectedHorsForfait.Date, SelectedHorsForfait.Montant);
                        vmDaoLigneFraisHorsForfait.Update(lfhf);
                        listLigneFraisHorsForfait.Remove(SelectedHorsForfait);
                    }
                }
                else
                {
                    FicheFrais uneFicheFrais = new FicheFrais(SelectedFicheFrais.UnVisiteur, date, SelectedFicheFrais.MontantValide, SelectedFicheFrais.NbJustificatifs, SelectedFicheFrais.DateModif, SelectedFicheFrais.UnEtat);
                    vmDaoFicheFrais.Insert(uneFicheFrais);
                    LigneFraisHorsForfait lfhf = new LigneFraisHorsForfait(SelectedHorsForfait.Id, SelectedHorsForfait.IdVisiteur, date, SelectedHorsForfait.Libelle, SelectedHorsForfait.Date, SelectedHorsForfait.Montant);
                    vmDaoLigneFraisHorsForfait.Update(lfhf);
                    listLigneFraisHorsForfait.Remove(SelectedHorsForfait);
                    selectedFicheFrais.LesLigneFraisHorsForfait = new List<LigneFraisHorsForfait>(selectedFicheFrais.LesLigneFraisHorsForfait);
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
