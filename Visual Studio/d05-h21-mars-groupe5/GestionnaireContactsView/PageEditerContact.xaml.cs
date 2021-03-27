using GestionnaireContactsBLL;
using GestionnaireContactsModele;
using System;
using System.Collections.Generic;
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
            this.datagridAffichageContacts.ItemsSource = BLL.AfficherContacts();
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
                    if (BLL.ValiderIdPourModification(contacts.Id))
                    {
                        BLL.Modifier(contacts);
                        MessageBox.Show("Contact modifié avec succès !");
                        EffacerInformation();
                        this.datagridAffichageContacts.ItemsSource = BLL.AfficherContacts();
                    }
                    else
                    {
                        MessageBox.Show("Cet ID n'existe pas !");
                    }
                }
                // Validation format
                catch (FormatException ex)
                {
                    MessageBox.Show("L'ID et l'âge doivent être des nombres !");
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

        private void TxtId_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (BLL.ValiderIdPourModification(int.Parse(this.txtId.Text)))
                {
                    this.lblWarning.Content = "";
                    List<Contact> contact = new List<Contact>();
                    contact = BLL.RechercherUnContactSelonCritere("id", this.txtId.Text);

                    this.txtNom.Text = contact[0].Nom;
                    this.txtPrenom.Text = contact[0].Prenom;
                    this.txtAge.Text = contact[0].Age.ToString();
                    this.txtTelephone.Text = contact[0].Telephone;
                    this.txtVille.Text = contact[0].Ville;
                    if (contact[0].Loisir == "Sport")
                    {
                        this.comboBoxLoisirs.SelectedIndex = 0;
                    }
                    else if (contact[0].Loisir == "Lecture")
                    {
                        this.comboBoxLoisirs.SelectedIndex = 1;
                    }
                    else if (contact[0].Loisir == "Cinema")
                    {
                        this.comboBoxLoisirs.SelectedIndex = 2;
                    }
                    else if (contact[0].Loisir == "Musique")
                    {
                        this.comboBoxLoisirs.SelectedIndex = 3;
                    }
                    else
                    {
                        this.comboBoxLoisirs.SelectedIndex = -1;
                    }
                }
                else
                {
                    this.lblWarning.Content = "Cet ID n'existe pas !";
                }
            }
            catch (FormatException ex)
            {
                this.lblWarning.Content = "L'ID doit être un nombre !";
                this.EffacerInformation();
            }

        }
    }

}