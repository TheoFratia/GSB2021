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
        private DaoEtat thedaoetat;
        public GestionFrais(DaoFicheFrais myDaoFicheFrais, DaoFraisForfait mydaofraisforfait, DaoLigneFraisForfait mydaolignefraisforfait, DaoLigneFraisHorsForfait mydaolignefraishorsforfait, DaoEtat mydaoEtat)
        {
            this.thedaofichefrais = myDaoFicheFrais;
            this.thedaofraisforfait = mydaofraisforfait;
            this.thedaolignefraisforfait = mydaolignefraisforfait;
            this.thedaolignefraishorsforfait = mydaolignefraishorsforfait;
            this.thedaoetat = mydaoEtat;
            
            InitializeComponent();
            mainGrid.DataContext = new ViewModelGestionFrais(thedaofichefrais, thedaofraisforfait, thedaolignefraisforfait, thedaolignefraishorsforfait, thedaoetat);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedIndex != null)
            {
                comboBox1.Visibility = Visibility.Visible;
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBox1.Visibility = Visibility.Hidden;
        }
    }
}
