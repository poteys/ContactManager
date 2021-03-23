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
            Contact contacts = new Contact()
            {
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text,
                Age = int.Parse(txtAge.Text),
                Telephone = txtTelephone.Text,
                Ville = txtVille.Text
            };

            if (DAL.ValiderLongueurTelephone(txtTelephone.Text) == false)
            {
                MessageBox.Show("Saisir numero à 10 chiffres !");
            }
            else if (DAL.ValiderChamps(contacts) == false)
            {
                MessageBox.Show("Saisir tous les champs requis !");
            }
            else if(comboBoxLoisirs.SelectedIndex == 0)
            {
                contacts.Loisir = "Sport";
                BLL.Ajouter(contacts);
                EffacerInformation();
            }
            else if (comboBoxLoisirs.SelectedIndex == 1)
            {
                contacts.Loisir = "Lecture";
                BLL.Ajouter(contacts);
                EffacerInformation();
            }
            else if (comboBoxLoisirs.SelectedIndex == 2)
            {
                contacts.Loisir = "Cinema";
                BLL.Ajouter(contacts);
                EffacerInformation();
            }
            else
            {
                BLL.Ajouter(contacts);
                EffacerInformation();
            }
            //Ajoute un nouvel utilisateur si toutes les conditions sont remplies
            /*if (DAL.ValiderChamps(txtNom.Text, txtPrenom.Text, txtTelephone.Text, txtVille.Text) && DAL.ValiderLongueurTelephone(txtTelephone.Text))
            {
                BLL.Ajouter(txtNom.Text, txtPrenom.Text, int.Parse(txtAge.Text), txtTelephone.Text, txtVille.Text);
                lblNotificationEnregistrer.Content = "Utilisateur ajouté !";
            }

            //Verifie si tous les champs ne sont pas remplis
            else if (DAL.ValiderChamps(txtNom.Text, txtPrenom.Text, txtTelephone.Text, txtVille.Text) == false && DAL.ValiderLongueurTelephone(txtTelephone.Text) == false)
            {
                MessageBox.Show("Saisir tous les champs requis !");

            }

            //Si la longueur du telephone n'est pas égale à 10 ce message va s'afficher
            else if (DAL.ValiderChamps(txtNom.Text, txtPrenom.Text, txtTelephone.Text, txtVille.Text) && DAL.ValiderLongueurTelephone(txtTelephone.Text) == false)
            {
                MessageBox.Show("Saisir numero à 10 chiffres !");
            }*/



        }

        //Methode pour effacer les informations à l'ecran
        public void EffacerInformation()
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtAge.Clear();
            txtTelephone.Clear();
            txtVille.Clear();
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