using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using GestionnaireContactsModele;

namespace GestionnaireContactsDAL
{
    public class DAL
    {
        
        const string connectionString = @"Data Source=751FJW2\SQLEXPRESS;Initial Catalog=GestionnaireContact;Integrated Security=True;Connect Timeout=5";


        //Methode pour ajouter les informations dans la base de données
        public static void Ajouter(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "insert into Contacts(nom,prenom,age,telephone,ville,loisirs) values (@nom,@prenom,@age,@telephone,@ville,@loisirs)";
                    command.Parameters.AddWithValue("@nom", contact.Nom);
                    command.Parameters.AddWithValue("@prenom", contact.Prenom);
                    command.Parameters.AddWithValue("@age", Convert.ToInt32(contact.Age));
                    command.Parameters.AddWithValue("@telephone", contact.Telephone);
                    command.Parameters.AddWithValue("@ville", contact.Ville);
                    command.Parameters.AddWithValue("@loisirs", contact.Loisir);
                    command.ExecuteNonQuery();
                }

            }

        }

        //Methode pour ajouter un Gestionnaire dans la base de données
        public static void AjouterGestionnaire(Gestionnaire gestionnaire)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "insert into Gestionnaire (nom,prenom,email,password) values (@nom,@prenom,@email,@password)";
                    command.Parameters.AddWithValue("@nom", gestionnaire.Nom);
                    command.Parameters.AddWithValue("@prenom", gestionnaire.Prenom);
                    command.Parameters.AddWithValue("@email", gestionnaire.Email);
                    command.Parameters.AddWithValue("@password", gestionnaire.Password);
                    command.ExecuteNonQuery();
                }

            }

        }
        //Methode pour ajouter un Administrateur dans la base de données
        public static void AjouterAdministrateur(Administrateur administrateur)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "insert into Administrateur(nom,prenom,email,password) values (@nom,@prenom,@email,@password)";
                    command.Parameters.AddWithValue("@nom", administrateur.Nom);
                    command.Parameters.AddWithValue("@prenom", administrateur.Prenom);
                    command.Parameters.AddWithValue("@email", administrateur.Email);
                    command.Parameters.AddWithValue("@password", administrateur.Password);
                    command.ExecuteNonQuery();
                }

            }

        }

        //Methode pour connecter un Administrateur
        public static bool Connecter(Administrateur administrateur)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"select count(*) from Administrateur where email = @emailEnter and password = @passwordEnter";
                    command.Parameters.AddWithValue("@emailEnter", administrateur.Email);
                    command.Parameters.AddWithValue("@passwordEnter", administrateur.Password);

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

        //Methode pour connecter un Gestionnaire
        public static bool Connecter(Gestionnaire gestionnaire)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"select count(*) from Gestionnaire where email = @emailEnter and password = @passwordEnter";
                    command.Parameters.AddWithValue("@emailEnter", gestionnaire.Email);
                    command.Parameters.AddWithValue("@passwordEnter", gestionnaire.Password);

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

        //Methode pour afficher les informations
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
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    DataTable dataTable = new DataTable();

                    command.CommandText = "select * from Contacts where concat (nom,prenom,age,telephone,ville) like '%" + idRechercher + "%'";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);

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

        //Méthode pour rechercher un contact dans la BD selon un critère
        public static List<Contact> RechercherUnContactSelonCritere(string critere, string motCle)
        {
            List<Contact> contact = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT id, nom, prenom, age, telephone, ville, loisirs FROM Contacts WHERE " + critere + " = '" + motCle + "'";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contact c = new Contact();
                            c.Id = reader.GetInt32(0);
                            c.Nom = reader.GetString(1);
                            c.Prenom = reader.GetString(2);
                            c.Age = reader.GetInt32(3);
                            c.Telephone = reader.GetString(4);
                            c.Ville = reader.GetString(5);
                            c.Loisir = reader.GetString(6);
                            contact.Add(c);
                        }
                    }
                }
            }

            return contact;
        }

    }
}