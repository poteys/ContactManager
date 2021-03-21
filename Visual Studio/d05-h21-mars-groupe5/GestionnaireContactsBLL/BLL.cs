using System;
using GestionnaireContactsModele;
using GestionnaireContactsDAL;

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

        /*public static void AjouterParametre(string nom, string prenom, int age, string telephone, string ville)
        {
            Contact contact = new Contact();
            DAL.AjouterParametres(contact);
        }*/

        //Methode pour supprimer les informations dans la base de données
        public static void Supprimer(int id)
        {
            DAL.ValiderId(Convert.ToBoolean(id));
            DAL.Supprimer(id);
        }

        //Methode pour modifier les informations dans la base de données
        public static void Modifier(int id, string nom, string prenom)
        {
            DAL.Modifier(id, nom, prenom);
        }

        public static void Rechercher(string id)
        {
            DAL.RechercherID(id);
        }


    }
}
