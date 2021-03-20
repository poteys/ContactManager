using System;
using System.Data.SqlClient;
using GestionnaireContactsModele;

namespace GestionnaireContactsDAL
{
    public class DAL
    {

        const string connectionString = @"Data Source=751FJW2\SQLEXPRESS;Initial Catalog=GestionnaireContact;Integrated Security=True;Connect Timeout=5";

        //Methode pour ajouter les informations dans la base de données
        public static void Ajouter(string nom, string prenom, int age, long telephone, string ville)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "insert into Contacts values (@nom,@prenom,@age,@telephone,@ville)";
                    command.Parameters.AddWithValue("@nom", nom);
                    command.Parameters.AddWithValue("@prenom", prenom);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@telephone", telephone);
                    command.Parameters.AddWithValue("@ville", ville);
                    command.ExecuteNonQuery();
                }

            }

        }

        //Methode pour supprimer les informations dans la base données
        public static void Supprimer(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "delete from Contacts where id = @idEnter";
                    command.Parameters.AddWithValue("@idEnter", id);

                    command.ExecuteNonQuery();
                }

            }

        }

        //Methode pour mettre à jour les informations dans la base données
        public static void Modifier(int id, string nom, string prenom)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
 
                    command.CommandText = "update Contacts set nom = @nom, prenom = @prenom where id = @idEnter";
                    command.Parameters.AddWithValue("@idEnter", id);
                    command.Parameters.AddWithValue("@nom", nom);
                    command.Parameters.AddWithValue("@prenom", prenom);
                    command.ExecuteNonQuery();
                }

            }

        }
        /*public static void AjouterParametres(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "insert into Contacts values (@nom,@prenom,@age,@telephone,@ville)";
                    command.Parameters.AddWithValue("@nom", contact.Nom);
                    command.Parameters.AddWithValue("@prenom", contact.Prenom);
                    command.Parameters.AddWithValue("@age", contact.Age);
                    command.Parameters.AddWithValue("@telephone", contact.Telephone);
                    command.Parameters.AddWithValue("@ville", contact.Ville);
                    command.ExecuteNonQuery();
                }

            }

        }*/
    }
}