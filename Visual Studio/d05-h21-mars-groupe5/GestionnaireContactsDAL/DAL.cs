using System;
using System.Data.SqlClient;
using GestionnaireContactsModele;

namespace GestionnaireContactsDAL
{
    public class DAL
    {

        const string connectionString = @"Data Source=751FJW2\SQLEXPRESS;Initial Catalog=GestionnaireContact;Integrated Security=True;Connect Timeout=5";

        public static void Ajouter(string nom, string prenom, int age, long telephone, string ville)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "insert into Contacts(nom,prenom,age,telephone,ville) values('"+nom+"','"+prenom+"'," + age+","+telephone+",'"+ville+"')";
                    command.ExecuteNonQuery();
                }

            }

        }
    }
}