using System.Windows;
using System.Windows.Controls;
using GestionnaireContactsBLL;
using GestionnaireContactsModele;

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
            this.NavigationService.Navigate(new PageLogin());
        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNom.Text) || string.IsNullOrEmpty(this.txtPrenom.Text) || string.IsNullOrEmpty(this.txtMail.Text) || string.IsNullOrEmpty(this.pwdBox.Password.ToString()) || this.comboBoxRoles.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
            else
            {
                Administrateur administrateur = new Administrateur()
                {
                    Nom = txtNom.Text,
                    Prenom = txtPrenom.Text,
                    Email = txtMail.Text,
                    Password = pwdBox.Password
                };

                Gestionnaire gestionnaire = new Gestionnaire()
                {
                    Nom = txtNom.Text,
                    Prenom = txtPrenom.Text,
                    Email = txtMail.Text,
                    Password = pwdBox.Password
                };

                if (comboBoxRoles.SelectedIndex == 0)
                {
                    BLL.AjouterAdministrateur(administrateur);
                    MessageBox.Show("Utilisateur Ajouté !");
                    this.NavigationService.Navigate(new PageLogin());
                }
                else
                {
                    BLL.AjouterGestionnaire(gestionnaire);
                    MessageBox.Show("Utilisateur Ajouté !");
                    this.NavigationService.Navigate(new PageLogin());
                }
            }
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
            this.comboBoxRoles.SelectedIndex = -1;
        }

    }

}