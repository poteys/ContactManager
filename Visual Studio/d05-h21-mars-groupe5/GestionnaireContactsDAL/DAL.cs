using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using GestionnaireContactsModele;

namespace GestionnaireContactsDAL
{
    public class DAL
    {
        
        private static string connectionString = @"Data Source="+ System.Environment.MachineName + @"\SQLEXPRESS;Initial Catalog=GestionnaireContact;Integrated Security=True;Connect Timeout=5";

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
                    command.Parameters.AddWithValue("@telephone", contact.Telephone);

                    if (contact.Age != null)
                    {
                        command.Parameters.AddWithValue("@age", Convert.ToInt32(contact.Age));
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@age", DBNull.Value);
                    }

                    if (contact.Ville != null)
                    {
                        command.Parameters.AddWithValue("@ville", contact.Ville);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ville", DBNull.Value);
                    }

                    if (contact.Loisir != null)
                    {
                        command.Parameters.AddWithValue("@loisirs", contact.Loisir);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@loisirs", DBNull.Value);
                    }

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
                        return "Contact supprimé";
                    }
                    else
                    {
                        return "Ce contact n'existe pas!";
                    }
                }
            }
        }

        //Methode pour mettre à jour les informations dans la base données
        public static void Modifier(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "update Contacts set nom = @nom, prenom = @prenom, age = @age, telephone = @telephone, ville = @ville, loisirs = @loisirs where id = @idEnter";
                    command.Parameters.AddWithValue("@idEnter", contact.Id);
                    command.Parameters.AddWithValue("@nom", contact.Nom);
                    command.Parameters.AddWithValue("@prenom", contact.Prenom);
                    command.Parameters.AddWithValue("@telephone", contact.Telephone);

                    if (contact.Age != null)
                    {
                        command.Parameters.AddWithValue("@age", Convert.ToInt32(contact.Age));
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@age", DBNull.Value);
                    }

                    if (contact.Ville != null)
                    {
                        command.Parameters.AddWithValue("@ville", contact.Ville);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ville", DBNull.Value);
                    }

                    if (contact.Loisir != null)
                    {
                        command.Parameters.AddWithValue("@loisirs", contact.Loisir);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@loisirs", DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }

            }

        }

        //Methode pour afficher les informations
        public static DataTable AfficherInformation()
        {
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

        // Méthode pour valider si l'id saisie existe dans la BD
        public static bool ValiderId(int id)
        {
            int idBD = 0;
            bool idExist = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT id FROM Contacts WHERE id = " + id;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idBD = reader.GetInt32(0);
                        }
                    }
                }
            }

            if (id == idBD)
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
                            c.Age = (!reader.IsDBNull(3)) ? (Int32?)reader.GetInt32(3) : null;
                            c.Telephone = reader.GetString(4);
                            c.Ville = (!reader.IsDBNull(5)) ? reader.GetString(5) : null;
                            c.Loisir = (!reader.IsDBNull(6)) ? reader.GetString(6) : null;
                            contact.Add(c);
                        }
                    }
                }
            }

            return contact;
        }

        //Méthode pour filtrer l'affichage de tous les contacts
        public static List<Contact> FiltrerLesContacts(int noFiltre)
        {
            List<Contact> contacts = new List<Contact>();

            string filtre;
            string filtre1 = "ORDER BY nom, prenom ASC";
            string filtre2 = "ORDER BY age ASC";
            string filtre3 = "ORDER BY age DESC";
            string filtre4 = "ORDER BY ville ASC";
            string filtre5 = "ORDER BY loisirs ASC";
            string filtre6 = "ORDER BY telephone ASC";
            if (noFiltre == 1)
            {
                filtre = filtre1;
            }
            else if (noFiltre == 2)
            {
                filtre = filtre2;
            }
            else if (noFiltre == 3)
            {
                filtre = filtre3;
            }
            else if (noFiltre == 4)
            {
                filtre = filtre4;
            }
            else if (noFiltre == 5)
            {
                filtre = filtre5;
            }
            else
            {
                filtre = filtre6;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT id, nom, prenom, age, telephone, ville, loisirs FROM Contacts " + filtre;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contact c = new Contact();
                            c.Id = reader.GetInt32(0);
                            c.Nom = reader.GetString(1);
                            c.Prenom = reader.GetString(2);
                            c.Age = (!reader.IsDBNull(3)) ? (Int32?)reader.GetInt32(3) : null;
                            c.Telephone = reader.GetString(4);
                            c.Ville = (!reader.IsDBNull(5)) ? reader.GetString(5) : null;
                            c.Loisir = (!reader.IsDBNull(6)) ? reader.GetString(6) : null;
                            contacts.Add(c);
                        }
                    }
                }
            }

            return contacts;
        }

    }
}