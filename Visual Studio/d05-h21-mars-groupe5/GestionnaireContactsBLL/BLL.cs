using System;
using System.Data;
using GestionnaireContactsModele;
using GestionnaireContactsDAL;
using System.Collections.Generic;

namespace GestionnaireContactsBLL
{
    public class BLL
    {

        //Methode pour ajouter les informations dans la base de données
        /*public static void Ajouter(string nom, string prenom, int age, string telephone, string ville)
        {
            DAL.ValiderChamps(nom, prenom, telephone, ville);
            DAL.ValiderLongueurTelephone(telephone);

            DAL.Ajouter(nom, prenom, age, telephone, ville);
        }*/

        //Methode pour ajouter les informations dans la base de données
        public static void Ajouter(Contact contact)
        {

            DAL.Ajouter(contact);
        }

        //Methode pour ajouter un gestionnaire
        public static void AjouterGestionnaire(Gestionnaire gestionnaire)
        {
            DAL.AjouterGestionnaire(gestionnaire);
        }

        //Methode pour ajouter un administrateur
        public static void AjouterAdministrateur(Administrateur administrateur)
        {
            DAL.AjouterAdministrateur(administrateur);
        }

        public static bool ConnecterAdministrateur(Administrateur administrateur)
        {
            return DAL.Connecter(administrateur);
        }
        public static bool ConnecterGestionnaire(Gestionnaire gestionnaire)
        {
            return DAL.Connecter(gestionnaire);
        }

        //Methode pour supprimer les informations dans la base de données
        public static string Supprimer(int id)
        {

            return DAL.Supprimer(id);
        }

        //Methode pour modifier les informations dans la base de données
        public static void Modifier(Contact contact, int id)
        {
            //DAL.Modifier(id, nom, prenom);
            DAL.Modifier(contact, id);
        }

        public static void Rechercher(string id)
        {
            DAL.RechercherID(id);
        }

        public static DataTable AfficherInformation()
        {
            return DAL.AfficherInformation();
        }

        //Méthode pour rechercher un contact dans la BD selon un critère
        public static List<Contact> RechercherUnContactSelonCritere(string critere, string motCle)
        {
            List<Contact> contact = DAL.RechercherUnContactSelonCritere(critere, motCle);
            return contact;
        }

    }
}
