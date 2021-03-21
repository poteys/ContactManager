using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace GestionnaireContactsView
{

    /// <summary>
    /// Interaction logic for PageAfficherTousLesContacts.xaml
    /// </summary>

    public partial class PageAfficherTousLesContacts : Page
    {

        public PageAfficherTousLesContacts()
        {
            InitializeComponent();
        }

        //private void BtnRe_Click(object sender, RoutedEventArgs e)
        //{
        //    RechercherId();
        //}

        ////Methode pour rechercher id et afficher
        //public void RechercherId()
        //{
        //    const string connectionString = @"Data Source=751FJW2\SQLEXPRESS;Initial Catalog=GestionnaireContact;Integrated Security=True;Connect Timeout=5";

        //    /*DataTable dataTable = new DataTable();
        //    BLL.Rechercher(txtId.Text);
        //    informationBase.ItemsSource = dataTable.DefaultView;*/
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = connection.CreateCommand())
        //        {
        //            DataTable dataTable = new DataTable();

        //            command.CommandText = "select * from Contacts where concat (nom,prenom,age,telephone,ville) like '%" + txtId.Text + "%'";
        //            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        //            dataAdapter.Fill(dataTable);
        //            informationBase.ItemsSource = dataTable.DefaultView;

        //        }
        //    }
        //}

        private void BtnRetour(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPrincipalGestionnaire());
        }

    }
}