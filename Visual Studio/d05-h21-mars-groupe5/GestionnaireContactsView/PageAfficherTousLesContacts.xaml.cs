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

        private void AfficherContact(object sender, RoutedEventArgs e)
        {
            informationBase.ItemsSource = BLL.AfficherContacts();
        }

    }

}