using GestionnaireContactsBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        private void BtnAfficher_Click(object sender, RoutedEventArgs e)
        {

            

        }
        

        private void AfficherContact(object sender, RoutedEventArgs e)
        {
            informationBase.ItemsSource = BLL.AfficherInformation().DefaultView;
        }
        

        /*private void InformationBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            informationBase.ItemsSource = dataTable.DefaultView;
        }*/
    }
}