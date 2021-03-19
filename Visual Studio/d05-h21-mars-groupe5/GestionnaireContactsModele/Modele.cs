using System;

namespace GestionnaireContactsModele
{
    public class Contact
    {

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int? Age { get; set; }
        public long Telephone { get; set; }
        public string Ville { get; set; }

    }
}