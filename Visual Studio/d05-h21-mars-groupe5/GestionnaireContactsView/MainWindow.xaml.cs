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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Ajouter des informations dans la base de données
        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            Contact contacts = new Contact
            {
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text,
                Age = int.Parse(txtAge.Text),
                Telephone = txtTelephone.Text,
                Ville = txtVille.Text
            };

            BLL.Ajouter(contacts);
            EffacerInformation();
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


            //BLL.AjouterParametre(txtNom.Text, txtPrenom.Text, int.Parse(txtAge.Text), txtTelephone.Text, txtVille.Text);
        }

        //Bouton pour effacer les informations à l'écran
        private void BtnEffacer_Click(object sender, RoutedEventArgs e)
        {
            EffacerInformation();
        }


        //Bouton pour quitter l'application
        private void BtnQuitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
            EffacerInformation();
        }

        //Bouton pour supprimer les informations dans la base de données
        private void BtnEditer_Click(object sender, RoutedEventArgs e)
        {
            BLL.Modifier(int.Parse(txtId.Text), txtNom.Text, txtPrenom.Text);
        }

        private void BtnRe_Click(object sender, RoutedEventArgs e)
        {
            RechercherId();
        }

        //Methode pour rechercher id et afficher
        public void RechercherId()
        {
            const string connectionString = @"Data Source=751FJW2\SQLEXPRESS;Initial Catalog=GestionnaireContact;Integrated Security=True;Connect Timeout=5";

            /*DataTable dataTable = new DataTable();
            BLL.Rechercher(txtId.Text);
            informationBase.ItemsSource = dataTable.DefaultView;*/
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    DataTable dataTable = new DataTable();

                    command.CommandText = "select * from Contacts where concat (nom,prenom,age,telephone,ville) like '%" + txtId.Text + "%'";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                    informationBase.ItemsSource = dataTable.DefaultView;

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
        }
    }
}
