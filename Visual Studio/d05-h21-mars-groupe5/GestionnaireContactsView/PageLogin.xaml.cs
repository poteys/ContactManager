using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using GestionnaireContactsBLL;
using GestionnaireContactsModele;

namespace GestionnaireContactsView
{

    /// <summary>
    /// Interaction logic for PageLogin.xaml
    /// </summary>

    public partial class PageLogin : Page
    {

        public PageLogin()
        {
            InitializeComponent();
        }

        //Bouton retour
        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
        }

        //Bouton se connecter
        private void BtnConnecter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtMail.Text) || string.IsNullOrEmpty(this.pwdBox.Password.ToString()) || this.comboBoxRole.SelectedIndex == -1)
            {
                lblStatut.Content = "Veuillez remplir \ntous les champs";
                lblStatut.Foreground = Brushes.Red;
            }
            else
            {
                Gestionnaire gestionnaire = new Gestionnaire()
                {
                    Email = txtMail.Text,
                    Password = pwdBox.Password
                };
                Administrateur administrateur = new Administrateur()
                {
                    Email = txtMail.Text,
                    Password = pwdBox.Password
                };

                if (BLL.ConnecterAdministrateur(administrateur) && comboBoxRole.SelectedIndex == 0)
                {
                    this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
                    
                }
                else if (BLL.ConnecterGestionnaire(gestionnaire) && comboBoxRole.SelectedIndex == 1)
                {
                    this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
                    
                }
                else
                {
                    lblStatut.Content = "Utilisateur non trouvé";
                    lblStatut.Foreground = Brushes.Red;
                }
            }
        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageEnregistrementUtilisateur());
        }

        private void BtnSortir(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

    }

}