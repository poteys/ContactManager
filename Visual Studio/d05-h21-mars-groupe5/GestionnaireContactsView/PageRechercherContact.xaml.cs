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

namespace GestionnaireContactsView
{

    /// <summary>
    /// Interaction logic for PageRechercherContact.xaml
    /// </summary>

    public partial class PageRechercherContact : Page
    {

        private PageRechercherContact2 page2;

        public PageRechercherContact()
        {
            InitializeComponent();
            this.page2 = new PageRechercherContact2();
        }

        private void BtnSuivante(object sender, RoutedEventArgs e)
        {
            if (!(bool)this.rbtnNom.IsChecked && !(bool)this.rbtnPrenom.IsChecked && !(bool)this.rbtnAge.IsChecked && !(bool)this.rbtnTelephone.IsChecked && !(bool)this.rbtnVille.IsChecked && !(bool)this.rbtnLoisirs.IsChecked)
            {
                MessageBox.Show("Veuillez sélectionner une option!");
            }
            else
            {
                if ((bool)this.rbtnNom.IsChecked)
                {
                    this.page2.CheckedNom = true;
                    this.page2.lblCritere.Content = "Nom :";
                }
                else if ((bool)this.rbtnPrenom.IsChecked)
                {
                    this.page2.CheckedPrenom = true;
                    this.page2.lblCritere.Content = "Prénom :";
                }
                else if ((bool)this.rbtnAge.IsChecked)
                {
                    this.page2.CheckedAge = true;
                    this.page2.lblCritere.Content = "Âge :";
                }
                else if ((bool)this.rbtnTelephone.IsChecked)
                {
                    this.page2.CheckedTelephone = true;
                    this.page2.lblCritere.Content = "No. téléphone :";
                }
                else if ((bool)this.rbtnVille.IsChecked)
                {
                    this.page2.CheckedVille = true;
                    this.page2.lblCritere.Content = "Ville :";
                }
                else if ((bool)this.rbtnLoisirs.IsChecked)
                {
                    this.page2.CheckedLoisirs = true;
                    this.page2.lblCritere.Content = "Loisirs :";
                }

                this.NavigationService.Navigate(this.page2);
            }
        }

        private void BtnRetour(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
        }

    }

}