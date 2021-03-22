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

namespace GestionnaireContactsView
{
    /// <summary>
    /// Interaction logic for PageEnregistrementUtilisateur.xaml
    /// </summary>
    public partial class PageEnregistrementUtilisateur : Page
    {
        public PageEnregistrementUtilisateur()
        {
            InitializeComponent();
        }

        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            Contact contacts = new Contact()
            {
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text,
                Email = txtMail.Text,
                Password = pwdBox.Password
            };
            BLL.AjouterUser(contacts);
            MessageBox.Show("Utilisateur Ajouté !");
        }

        private void BtnEffacer_Click(object sender, RoutedEventArgs e)
        {

            EffacerInformation();
        }

        public void EffacerInformation()
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtMail.Clear();
            pwdBox.Clear();
        }
    }
}
