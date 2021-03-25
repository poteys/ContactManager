using GestionnaireContactsBLL;
using System.Windows;
using System.Windows.Controls;

namespace GestionnaireContactsView
{

    /// <summary>
    /// Interaction logic for PageAfficherTousLesContacts.xaml
    /// </summary>

    public partial class PageAfficherTousLesContacts : Page
    {

        public PageAfficherTousLesContacts()
        {
            InitializeComponent();
        }


        private void BtnRetour(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
        }

        private void AfficherContact(object sender, RoutedEventArgs e)
        {
            informationBase.ItemsSource = BLL.AfficherInformation().DefaultView;
        }

        private void InformationBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        /*private void InformationBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            informationBase.ItemsSource = dataTable.DefaultView;
        }*/
    }
}