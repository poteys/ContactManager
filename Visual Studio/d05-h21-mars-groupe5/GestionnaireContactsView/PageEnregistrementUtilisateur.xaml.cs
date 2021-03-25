﻿using System;
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
