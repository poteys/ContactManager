using GestionnaireContactsModele;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GestionnaireContactsView
{

    /// <summary>
    /// Interaction logic for PageRechercherContact2.xaml
    /// </summary>

    public partial class PageRechercherContact2 : Page
    {

        public bool CheckedNom { get; set; }
        public bool CheckedPrenom { get; set; }
        public bool CheckedAge { get; set; }
        public bool CheckedTelephone { get; set; }
        public bool CheckedVille { get; set; }
        public bool CheckedLoisirs { get; set; }

        public PageRechercherContact2()
        {
            InitializeComponent();

        }

        private void BtnRechercherClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtboxCritere.Text))
            {
                MessageBox.Show("Veuillez fournir l'information");
            }
            else
            {
                try
                {
                    List<Contact> contact = new List<Contact>();

                    string critere = "";
                    if (this.CheckedNom)
                    {
                        critere = "nom";
                    }
                    else if (this.CheckedPrenom)
                    {
                        critere = "prenom";
                    }
                    else if (this.CheckedAge)
                    {
                        critere = "age";
                        int age = int.Parse(this.txtboxCritere.Text);
                    }
                    else if (this.CheckedTelephone)
                    {
                        critere = "telephone";
                    }
                    else if (this.CheckedVille)
                    {
                        critere = "ville";
                    }
                    else if (this.CheckedLoisirs)
                    {
                        critere = "loisirs";
                    }

                    contact = GestionnaireContactsBLL.BLL.RechercherUnContactSelonCritere(critere, this.txtboxCritere.Text);

                    this.txtboxAffichage.Text = "Résultat de la recherche :" + Environment.NewLine;
                    foreach (Contact c in contact)
                    {
                        this.txtboxAffichage.Text += "Id : " + c.Id + System.Environment.NewLine + "Nom : " + c.Nom + System.Environment.NewLine + "Prénom : " + c.Prenom + System.Environment.NewLine + "Âge : " + c.Age + System.Environment.NewLine + "No. téléphone : " + c.Telephone + System.Environment.NewLine + "Ville : " + c.Ville + System.Environment.NewLine + "Loisirs : " + c.Loisir + System.Environment.NewLine + "-----------------------------------" + System.Environment.NewLine;
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("L'âge doit être un nombre!");
                }

            }
        }

        private void BtnRetour(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
        }

        private void BtnRetournerClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageRechercherContact());
        }

    }

}