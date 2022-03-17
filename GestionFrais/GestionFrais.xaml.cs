using GSBFrais.Model.Data;
using GSBFraisModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GestionFrais.viewModel;

namespace GSB
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class GestionFrais : Window
    {
        private DaoFicheFrais thedaofichefrais;
        private DaoFraisForfait thedaofraisforfait;
        private DaoLigneFraisHorsForfait thedaolignefraishorsforfait;
        private DaoLigneFraisForfait thedaolignefraisforfait;
        public GestionFrais(DaoFicheFrais myDaoFicheFrais, DaoFraisForfait mydaofraisforfait, DaoLigneFraisForfait mydaolignefraisforfait, DaoLigneFraisHorsForfait mydaolignefraishorsforfait)
        {
            this.thedaofichefrais = myDaoFicheFrais;
            this.thedaofraisforfait = mydaofraisforfait;
            this.thedaofraisforfait = mydaofraisforfait;
            this.thedaolignefraishorsforfait = mydaolignefraishorsforfait;
            InitializeComponent();
            mainGrid.DataContext = new ViewModelGestionFrais(thedaofichefrais, thedaofraisforfait, thedaolignefraisforfait, thedaolignefraishorsforfait);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
