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
    /// Interaction logic for MenuPrincipalGestionnaire.xaml
    /// </summary>

    public partial class MenuPrincipalGestionnaire : Page
    {

        public MenuPrincipalGestionnaire()
        {
            InitializeComponent();
        }

        private void BtnAjouterContact(object sender, RoutedEventArgs e)
        {
            this.framePage.NavigationService.Navigate(new PageAjouterContact());
            this.lblBienvenu.Visibility = Visibility.Hidden;
        }

        private void BtnEditerContact(object sender, RoutedEventArgs e)
        {
            this.framePage.NavigationService.Navigate(new PageEditerContact());
            this.lblBienvenu.Visibility = Visibility.Hidden;
        }

        private void BtnSupprimerContact(object sender, RoutedEventArgs e)
        {
            this.framePage.NavigationService.Navigate(new PageSupprimerContact());
            this.lblBienvenu.Visibility = Visibility.Hidden;
        }

        private void BtnAfficherTousLesContacts(object sender, RoutedEventArgs e)
        {
            this.framePage.NavigationService.Navigate(new PageAfficherTousLesContacts());
            this.lblBienvenu.Visibility = Visibility.Hidden;
        }

        private void BtnRechercherContact(object sender, RoutedEventArgs e)
        {
            this.framePage.NavigationService.Navigate(new PageRechercherContact());
            this.lblBienvenu.Visibility = Visibility.Hidden;
        }

        private void BtnFiltrerContacts(object sender, RoutedEventArgs e)
        {
            this.framePage.NavigationService.Navigate(new PageFiltrerContacts());
            this.lblBienvenu.Visibility = Visibility.Hidden;
        }

        private void BtnSortir(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void BtnDeconnecterClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageLogin());
        }
    }

}