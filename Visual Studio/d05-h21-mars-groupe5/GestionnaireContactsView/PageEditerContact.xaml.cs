using GestionnaireContactsBLL;
using GestionnaireContactsModele;
using System;
using System.Windows;
using System.Windows.Controls;

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

        //Bouton pour éditer les informations dans la base de données
        private void BtnEditer_Click(object sender, RoutedEventArgs e)
        {
            // Validation des champs obligatoires
            if (string.IsNullOrEmpty(this.txtId.Text) || string.IsNullOrEmpty(this.txtNom.Text) || string.IsNullOrEmpty(this.txtPrenom.Text) || string.IsNullOrEmpty(this.txtTelephone.Text))
            {
                MessageBox.Show("Saisir tous les champs obligatoires!");
            }
            // Validation longueur no. téléphone
            else if (BLL.ValiderLongueurTelephone(this.txtTelephone.Text) == false)
            {
                MessageBox.Show("Saisir un numéro téléphone à 10 chiffres!");
            }
            else
            {
                try
                {
                    Contact contacts = new Contact
                    {
                        Id = int.Parse(this.txtId.Text),
                        Nom = txtNom.Text,
                        Prenom = txtPrenom.Text,
                        Age = (string.IsNullOrEmpty(txtAge.Text)) ? null : (int?)int.Parse(txtAge.Text),
                        Telephone = txtTelephone.Text,
                        Ville = (string.IsNullOrEmpty(txtVille.Text)) ? null : txtVille.Text,
                        Loisir = (comboBoxLoisirs.SelectedIndex == -1) ? null : ((ComboBoxItem)comboBoxLoisirs.SelectedItem).Content.ToString()
                    };

                    // Validation de l'id
                    if (BLL.ValiderId(contacts.Id))
                    {
                        BLL.Modifier(contacts);
                        MessageBox.Show("Contact modifié avec succès!");
                        EffacerInformation();
                    }
                    else
                    {
                        MessageBox.Show("Cet ID n'existe pas!");
                    }
                }
                // Validation format
                catch (FormatException ex)
                {
                    MessageBox.Show("L'ID et l'âge doivent être des nombres!");
                }
            }
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
            comboBoxLoisirs.SelectedIndex = -1;
        }

        private void BtnRetour(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
        }

    }

}