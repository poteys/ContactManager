﻿using System;
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
        public static void Modifier(Contact contact)
        {
            //DAL.Modifier(id, nom, prenom);
            DAL.Modifier(contact);
        }

        //Methode pour modifier les informations dans la base de données
        public static List<Contact> ModifierContact(Contact contact)
        {
            //DAL.Modifier(id, nom, prenom);
            return DAL.ModifierContact(contact);
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
        //Méthode pour rechercher un contact dans la BD selon un critère
        public static DataTable RechercherContactCritere(string critere, string motCle)
        {
            
            return DAL.RechercherContactCritere(critere, motCle);
        }

        //Méthode pour filtrer l'affichage de tous les contacts
        public static List<Contact> FiltrerLesContacts(int noFiltre)
        {
            List<Contact> contacts = DAL.FiltrerLesContacts(noFiltre);
            return contacts;
        }
        public static DataTable FiltrerContactsDataTable(int noFiltre)
        {
            
            return DAL.FiltrerContactsDataTable(noFiltre);
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

    }

}