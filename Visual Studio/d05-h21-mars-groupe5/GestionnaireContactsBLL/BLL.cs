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

        //Methode connecter un administrateur
        public static bool ConnecterAdministrateur(Administrateur administrateur)
        {
            return DAL.Connecter(administrateur);
        }

        //Methode connecter un gestionnaire
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
        public static void Modifier(Contact contact)
        {
            //DAL.Modifier(id, nom, prenom);
            DAL.Modifier(contact);
        }

        public static List<Contact> AfficherContacts()
        {
            return DAL.AfficherContacts();
        }

        //Méthode pour rechercher un contact dans la BD selon un critère
        public static List<Contact> RechercherUnContactSelonCritere(string critere, string motCle)
        {
            List<Contact> contact = DAL.RechercherUnContactSelonCritere(critere, motCle);
            return contact;
        }
        //Méthode pour filtrer l'affichage de tous les contacts
        public static List<Contact> FiltrerLesContacts(int noFiltre)
        {
            List<Contact> contacts = DAL.FiltrerLesContacts(noFiltre);
            return contacts;
        }

        //Methode pour valider la longueur du numero de telephone
        public static bool ValiderLongueurTelephone(string telephone)
        {
            bool longueurTel = DAL.ValiderLongueurTelephone(telephone);
            return longueurTel;
        }

        // Méthode pour valider si l'id saisie existe dans la BD
        public static bool ValiderId(int id)
        {
            bool idExiste = DAL.ValiderId(id);
            return idExiste;
        }

        //Methode pour verifier si le contact existe dans la base de données
        public static bool CheckContactExist(Contact contact)
        {
            return DAL.CheckContactExist(contact);
        }

    }

}