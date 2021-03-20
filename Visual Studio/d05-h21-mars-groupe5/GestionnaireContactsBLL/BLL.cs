using System;
using GestionnaireContactsModele;
using GestionnaireContactsDAL;

namespace GestionnaireContactsBLL
{
    public class BLL
    {

        //Methode pour ajouter les informations dans la base de données
        public static void Ajouter(string nom, string prenom, int age, string telephone, string ville)
        {
            DAL.ValiderChamps(nom, prenom, telephone, ville);

            DAL.Ajouter(nom, prenom, age, telephone, ville);
        }

        //Methode pour supprimer les informations dans la base de données
        public static void Supprimer(int id)
        {
            DAL.Supprimer(id);
        }

        //Methode pour modifier les informations dans la base de données
        public static void Modifier(int id, string nom, string prenom)
        {
            DAL.Modifier(id, nom, prenom);
        }


    }
}
