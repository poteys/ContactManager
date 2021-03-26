using GestionnaireContactsModele;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GestionnaireContactsBLL;
using GestionnaireContactsDAL;
using GestionnaireContactsModele;

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

                    contact = BLL.RechercherUnContactSelonCritere(critere, this.txtboxCritere.Text);
                    //dataGrid.ItemsSource = BLL.RechercherContactCritere(critere, this.txtboxCritere.Text).DefaultView;

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

        private void TxtboxCritere_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            AfficherData();
        }

        public void AfficherData()
        {
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
                if (int.TryParse(critere, out int a))
                {
                    int age = int.Parse(this.txtboxCritere.Text);
                }
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
            dataGrid.ItemsSource = BLL.RechercherUnContactSelonCritere(critere, this.txtboxCritere.Text);
        }
    }

}