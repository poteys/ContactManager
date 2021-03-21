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
using GestionnaireContactsBLL;
using GestionnaireContactsModele;
using GestionnaireContactsDAL;
using System.Data;
using System.Data.SqlClient;

namespace GestionnaireContactsView
{

    /// <summary>
    /// Interaction logic for PageSupprimerContact.xaml
    /// </summary>

    public partial class PageSupprimerContact : Page
    {

        public PageSupprimerContact()
        {
            InitializeComponent();
        }

        //Bouton pour supprimer les informations dans la base de données
        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (DAL.ValiderId(Convert.ToBoolean(int.Parse(txtId.Text))) == true)
            {
                BLL.Supprimer(int.Parse(txtId.Text));
                MessageBox.Show("Utilisateur supprimé !");
            }

            else if (DAL.ValiderId(Convert.ToBoolean(int.Parse(txtId.Text))) == false)
            {
                MessageBox.Show("Id existe pas !");
            }
        }

        private void BtnRetour(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
        }

    }

}