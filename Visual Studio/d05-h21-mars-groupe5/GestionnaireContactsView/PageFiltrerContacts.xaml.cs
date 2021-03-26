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
            AfficherDataGrid();
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
                /*List<Contact> contacts = BLL.FiltrerLesContacts(noFiltre);
                foreach (Contact c in contacts)
                {
                    this.txtboxAffichage.Text += "Id : " + c.Id + System.Environment.NewLine + "Nom : " + c.Nom + System.Environment.NewLine + "Prénom : " + c.Prenom + System.Environment.NewLine + "Âge : " + c.Age + System.Environment.NewLine + "No. téléphone : " + c.Telephone + System.Environment.NewLine + "Ville : " + c.Ville + System.Environment.NewLine + "Loisirs : " + c.Loisir + System.Environment.NewLine + "-----------------------------------" + System.Environment.NewLine;
                }*/
            }
        }

        private void BtnRetour(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
        }


        //Methode affichage data grid
        public void AfficherDataGrid()
        {
            //dataGrid.ItemsSource = BLL.FiltrerContactsDataTable(noFiltre).DefaultView;
            dataGrid.ItemsSource = BLL.FiltrerLesContacts(noFiltre);
        }

    }

}