using GestionnaireContactsBLL;
using GestionnaireContactsModele;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GestionnaireContactsView
{

    /// <summary>
    /// Interaction logic for PageFiltrerContacts.xaml
    /// </summary>

    public partial class PageFiltrerContacts : Page
    {
        int noFiltre = 0;

        public PageFiltrerContacts()
        {
            InitializeComponent();
            dataGrid.ItemsSource = BLL.AfficherContacts();
        }

        private void btnRechercherClick(object sender, RoutedEventArgs e)
        {
            if (this.cboxFiltres.SelectedIndex == -1)
            {

                lblStatus.Content = "Veuillez sélectionner une option";
                lblStatus.Foreground = Brushes.Red;
            }
            else
            {
                if (this.opParNomPrenom.IsSelected)
                {
                    noFiltre = 1;
                }
                else if (this.opAgeASC.IsSelected)
                {
                    noFiltre = 2;
                }
                else if (this.opAgeDESC.IsSelected)
                {
                    noFiltre = 3;
                }
                else if (this.opParVille.IsSelected)
                {
                    noFiltre = 4;
                }
                else if (this.opParLoisirs.IsSelected)
                {
                    noFiltre = 5;
                }
                else if (this.opParTelephone.IsSelected)
                {
                    noFiltre = 6;
                }
                AfficherDataGrid();
            }
        }

        //Methode affichage data grid
        public void AfficherDataGrid()
        {
            dataGrid.ItemsSource = BLL.FiltrerLesContacts(noFiltre);
        }

    }

}