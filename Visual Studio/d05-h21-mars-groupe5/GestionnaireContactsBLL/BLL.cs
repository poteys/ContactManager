using System;
using GestionnaireContactsModele;
using GestionnaireContactsDAL;

namespace GestionnaireContactsBLL
{
    public class BLL
    {
        public static void Ajouter(string nom, string prenom, int age , long telephone, string ville)
        {
            DAL.Ajouter(nom, prenom, age, telephone, ville);
        }

    }
}
