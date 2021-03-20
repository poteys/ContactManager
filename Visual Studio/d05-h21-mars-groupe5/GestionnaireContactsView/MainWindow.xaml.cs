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
            BLL.Ajouter(txtNom.Text, txtPrenom.Text, int.Parse(txtAge.Text), txtTelephone.Text, txtVille.Text);
            lblNotificationEnregistrer.Content = "Utilisateur ajouté !";

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
        }

        //Bouton pour quitter l'application
        private void BtnQuitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Bouton pour supprimer les informations dans la base de données
        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {

            try
            {
            BLL.Supprimer(int.Parse(txtId.Text));
            }
            catch
            {
                MessageBox.Show("Cet Id exist pas ");
            }
        }


        //Bouton pour supprimer les informations dans la base de données
        private void BtnEditer_Click(object sender, RoutedEventArgs e)
        { 
            BLL.Modifier(int.Parse(txtId.Text), txtNom.Text, txtPrenom.Text);
        }
    }
}
