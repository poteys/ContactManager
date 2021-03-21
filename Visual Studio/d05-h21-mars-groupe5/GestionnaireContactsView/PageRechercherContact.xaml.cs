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

        public PageRechercherContact()
        {
            InitializeComponent();
        }

        private void CheckNom(object sender, RoutedEventArgs e)
        {

        }

        private void CheckPrenom(object sender, RoutedEventArgs e)
        {

        }

        private void CheckAge(object sender, RoutedEventArgs e)
        {

        }

        private void CheckTelephone(object sender, RoutedEventArgs e)
        {

        }

        private void CheckVille(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSuivante(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageRechercherContact2());
        }

        private void BtnRetour(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
        }

    }

}