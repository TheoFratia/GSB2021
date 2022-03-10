﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GSBFraisModel.Data;
using GSBFraisModel.Buisness;
using GSBFrais.Model.Data;
using GSBFrais.Model.Buisness;


namespace GSB
{

    public partial class App : Application
    {
        private Dbal thedbal;
        private DaoEtat thedaoetat;
        private DaoFraisForfait thedaofraisforfait;
        private DaoFicheFrais thedaofichefrais;
        private DaoLigneFraisForfait thedaolignefraisforfait;
        private DaoLigneFraisHorsForfait thedaolignefraishorsforfait;
        private DaoVisiteurs thedaovisiteurs;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            thedbal = new Dbal();
            thedaovisiteurs = new DaoVisiteurs(thedbal);
            thedaoetat = new DaoEtat(thedbal);
            thedaofraisforfait = new DaoFraisForfait(thedbal);
            thedaofichefrais = new DaoFicheFrais(thedbal, thedaovisiteurs, thedaoetat);
            thedaolignefraisforfait = new DaoLigneFraisForfait(thedbal);
            thedaolignefraishorsforfait = new DaoLigneFraisHorsForfait(thedbal);
           

            // Create the startup window
            GestionFrais wnd = new GestionFrais(thedaofichefrais, thedaofraisforfait, thedaolignefraisforfait, thedaolignefraishorsforfait);
            wnd.Show();

        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}