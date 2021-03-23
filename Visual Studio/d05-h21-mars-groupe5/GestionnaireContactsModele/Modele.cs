using System;

namespace GestionnaireContactsModele
{
    public class Contact
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int? Age { get; set; }
        public string Telephone { get; set; }
        public string Ville { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Loisir { get; set; }


    }

    public class Gestionnaire
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class Administrateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}