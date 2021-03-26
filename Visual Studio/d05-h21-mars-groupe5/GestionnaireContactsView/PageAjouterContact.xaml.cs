using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using GestionnaireContactsBLL;
using GestionnaireContactsModele;

namespace GestionnaireContactsView
{

    /// <summary>
    /// Interaction logic for PageAjouterContact.xaml
    /// </summary>

    public partial class PageAjouterContact : Page
    {

        public PageAjouterContact()
        {
            InitializeComponent();
        }

        //Ajouter des informations dans la base de données
        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text
            };
            // Validation des champs obligatoires
            if (string.IsNullOrEmpty(this.txtNom.Text) || string.IsNullOrEmpty(this.txtPrenom.Text) || string.IsNullOrEmpty(this.txtTelephone.Text))
            {
                AfficherContactNonAjouteStatus();
            }
            // Validation longueur no. téléphone
            else if (BLL.ValiderLongueurTelephone(txtTelephone.Text) == false)
            {
                lblTelephone.Foreground = Brushes.Red;
                lblTelephoneStatus.Content = "Saisir un numéro téléphone à 10 chiffres !";
                lblTelephoneStatus.Foreground = Brushes.Red;
            }
      
            else
            {
                try
                {
                    Contact contacts = new Contact()
                    {
                        Nom = txtNom.Text,
                        Prenom = txtPrenom.Text,
                        Age = (string.IsNullOrEmpty(txtAge.Text)) ? null : (int?)int.Parse(txtAge.Text),
                        Telephone = txtTelephone.Text,
                        Ville = (string.IsNullOrEmpty(txtVille.Text)) ? null : txtVille.Text,
                        Loisir = (comboBoxLoisirs.SelectedIndex == -1) ? null : ((ComboBoxItem)comboBoxLoisirs.SelectedItem).Content.ToString()
                    };
           
                        BLL.Ajouter(contacts);
                        AfficherContactAjouteStatus();
                        EffacerInformation();
     
                   
                }
                // Validation format âge
                catch (FormatException ex)
                {
                    
                    lblAge.Foreground = Brushes.Red;
                    lblStatusAge.Content = "L'âge doit être un nombre!";
                    lblStatusAge.Foreground = Brushes.Red;
                }
            }
        }

        //Methode pour effacer les informations à l'ecran
        public void EffacerInformation()
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtAge.Clear();
            txtTelephone.Clear();
            txtVille.Clear();
            comboBoxLoisirs.SelectedIndex = -1;
        }

        //Bouton pour effacer les informations à l'écran
        private void BtnEffacer_Click(object sender, RoutedEventArgs e)
        {
            EffacerInformation();
        }

        private void BtnRetour(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
        }

        private void BtnEffacer_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        public void AfficherContactAjouteStatus()
        {
            lblStatus.Content = "Contact Ajouté";
            lblStatus.Foreground = Brushes.Green;
            lblStatusAge.Content = "";
            lblTelephoneStatus.Content = "";
        }

        //Methode affichage champs à remplir
        public void AfficherContactNonAjouteStatus()
        {
            lblStatus.Content = "Remplissez tous les champs requis svp";
            lblNom.Foreground = Brushes.Red;
            lblPrenom.Foreground = Brushes.Red;
            lblAge.Foreground = Brushes.Red;
            lblTelephone.Foreground = Brushes.Red;
            lblVille.Foreground = Brushes.Red;
            lblLoisirs.Foreground = Brushes.Red;
        }


    }

}