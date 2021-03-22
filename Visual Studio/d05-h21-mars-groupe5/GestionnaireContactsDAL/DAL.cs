using System;
using System.Data;
using System.Data.SqlClient;
using GestionnaireContactsModele;

namespace GestionnaireContactsDAL
{
    public class DAL
    {

        const string connectionString = @"Data Source=751FJW2\SQLEXPRESS;Initial Catalog=GestionnaireContact;Integrated Security=True;Connect Timeout=5";


        //Methode pour ajouter les informations dans la base de données
        public static void Ajouter(Contact contact /*string nom, string prenom, int age, string telephone, string ville*/)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "insert into Contacts(nom,prenom,age,telephone,ville) values (@nom,@prenom,@age,@telephone,@ville)";
                    command.Parameters.AddWithValue("@nom", contact.Nom);
                    command.Parameters.AddWithValue("@prenom", contact.Prenom);
                    command.Parameters.AddWithValue("@age", Convert.ToInt32(contact.Age));
                    command.Parameters.AddWithValue("@telephone", contact.Telephone);
                    command.Parameters.AddWithValue("@ville", contact.Ville);
                    command.ExecuteNonQuery();
                }

            }

        }
        //Methode pour ajouter un utilisateur dans la base de données
        public static void AjouterUser(Contact contact /*string nom, string prenom, int age, string telephone, string ville*/)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "insert into Enregistrement(nom,prenom,email,password) values (@nom,@prenom,@email,@password)";
                    command.Parameters.AddWithValue("@nom", contact.Nom);
                    command.Parameters.AddWithValue("@prenom", contact.Prenom);
                    command.Parameters.AddWithValue("@email", contact.Email);
                    command.Parameters.AddWithValue("@password", contact.Password);
                    command.ExecuteNonQuery();
                }

            }

        }

        //Methode pour se connecter à la base de données
        public static bool Connecter(Contact contact /*string nom, string prenom, int age, string telephone, string ville*/)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"select count(*) from Enregistrement where email = @emailEnter and password = @passwordEnter";
                    command.Parameters.AddWithValue("@emailEnter", contact.Email);
                    command.Parameters.AddWithValue("@passwordEnter", contact.Password);
                    //SqlDataReader sqlDataReader = command.ExecuteReader();

                    object idObj = command.ExecuteScalar();

                    Console.WriteLine(idObj);
                    if (Convert.ToInt32(idObj) == 1)
                    {  
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }

        //Methode pour supprimer les informations dans la base données
        public static string Supprimer(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "delete from Contacts where id = @idEnter";
                    command.Parameters.AddWithValue("@idEnter", id);
                    int ligneAffectee = command.ExecuteNonQuery();

                    if (ligneAffectee != 0)
                    {
                        return "Utilisateur supprimé";
                    }
                    else
                    {
                        return "Utilisateur existe pas !";
                    }

                }

            }

        }

        //Methode pour mettre à jour les informations dans la base données
        public static void Modifier(Contact contact, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "update Contacts set nom = @nom, prenom = @prenom, age = @age, telephone = @telephone, ville = @ville where id = @idEnter";
                    command.Parameters.AddWithValue("@idEnter", id);
                    command.Parameters.AddWithValue("@nom", contact.Nom);
                    command.Parameters.AddWithValue("@prenom", contact.Prenom);
                    command.Parameters.AddWithValue("@age", Convert.ToInt32(contact.Age));
                    command.Parameters.AddWithValue("@telephone", contact.Telephone);
                    command.Parameters.AddWithValue("@ville", contact.Ville);
                    command.ExecuteNonQuery();
                }

            }

        }

        public static DataTable AfficherInformation()
        {
            const string connectionString = @"Data Source=751FJW2\SQLEXPRESS;Initial Catalog=GestionnaireContact;Integrated Security=True;Connect Timeout=5";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {

                    DataTable dataTable = new DataTable();
                    command.CommandText = @"select * from Contacts";
                    SqlDataReader dataReader = command.ExecuteReader();
                    dataTable.Load(dataReader);

                    return dataTable;
                }
            }

        }

        //Methode pour rechercher un ID
        public static void RechercherID(string idRechercher)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    DataTable dataTable = new DataTable();

                    command.CommandText = "select * from Contacts where concat (nom,prenom,age,telephone,ville) like '%" + idRechercher + "%'";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                    //dataGrid_DataBase.ItemsSource = dataTable.DefaultView;

                }
            }
        }



        //Methode de validation des champs
        public static bool ValiderChamps(Contact contact /*string nom, string prenom, string telephone, string ville*/)
        {
            bool isRempli = true;

            if (contact.Nom == string.Empty)
            {
                isRempli = false;
            }

            if (contact.Prenom == string.Empty)
            {
                isRempli = false;
            }

            if (contact.Telephone == string.Empty)
            {
                isRempli = false;
            }
            if (contact.Ville == string.Empty)
            {
                isRempli = false;
            }

            //if (nom == string.Empty)
            //{
            //    isRempli = false;
            //}
            //if (prenom == string.Empty)
            //{
            //    isRempli = false;
            //}
            //if (telephone == string.Empty)
            //{
            //    isRempli = false;
            //}
            //if(ville == string.Empty)
            //{
            //    isRempli = false;
            //}
            return isRempli;
        }

        //Methode pour valider la longueur du numero de telephone
        //La longueur doit être de 10 chiffres sinon elle va rejeter la l'ajout de l'utilisateur
        public static bool ValiderLongueurTelephone(string telephone)
        {
            bool longueur = false;
            if (telephone.Length == 10)
            {
                longueur = true;
            }
            return longueur;
        }

        public static bool ValiderId(bool id)
        {
            bool idExist = false;

            if (id == true)
            {
                idExist = true;
            }
            return idExist;
        }
    }
}