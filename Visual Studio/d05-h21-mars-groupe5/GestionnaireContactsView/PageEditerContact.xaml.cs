using GestionnaireContactsBLL;
using GestionnaireContactsModele;
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
    /// Interaction logic for PageEditerContact.xaml
    /// </summary>

    public partial class PageEditerContact : Page
    {

        public PageEditerContact()
        {
            InitializeComponent();
        }

        //Bouton pour supprimer les informations dans la base de données
        private void BtnEditer_Click(object sender, RoutedEventArgs e)
        {
            //BLL.Modifier(int.Parse(txtId.Text), txtNom.Text, txtPrenom.Text);
            Contact contacts = new Contact
            {
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text,
                Age = int.Parse(txtAge.Text),
                Telephone = txtTelephone.Text,
                Ville = txtVille.Text
            };
            BLL.Modifier(contacts, int.Parse(txtId.Text));
            EffacerInformation();
        }

        //Bouton pour effacer les informations à l'écran
        private void BtnEffacer_Click(object sender, RoutedEventArgs e)
        {
            EffacerInformation();
        }

        //Methode pour effacer les informations à l'ecran
        public void EffacerInformation()
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtAge.Clear();
            txtTelephone.Clear();
            txtVille.Clear();
            txtId.Clear();
        }

        private void BtnRetour(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
        }

    }

}