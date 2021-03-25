using System;
using System.Windows;
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
            // Validation des champs obligatoires
            if (string.IsNullOrEmpty(this.txtNom.Text) || string.IsNullOrEmpty(this.txtPrenom.Text) || string.IsNullOrEmpty(this.txtTelephone.Text))
            {
                MessageBox.Show("Saisir tous les champs obligatoires!");
            }
            // Validation longueur no. téléphone
            else if (BLL.ValiderLongueurTelephone(txtTelephone.Text) == false)
            {
                MessageBox.Show("Saisir un numéro téléphone à 10 chiffres!");
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
                    MessageBox.Show("Contact ajouté avec succès!");
                    EffacerInformation();
                }
                // Validation format âge
                catch (FormatException ex)
                {
                    MessageBox.Show("L'âge doit être un nombre!");
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

    }

}