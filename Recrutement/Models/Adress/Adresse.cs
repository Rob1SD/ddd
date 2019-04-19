using System;
using System.ComponentModel.DataAnnotations;

namespace ddd
{
    public class Adresse
    {
        public string Pays { get; }
        public Ville Ville { get; }
        public Voie Voie { get; }

        public Adresse(string pays, Ville ville, Voie voie)
        {
            Pays = pays;
            Ville = ville;
            Voie = voie;
        }

        public override string ToString() => Voie.Numero + " " + Voie.Nom + " " + Ville.CodePostal + " " + Ville.Nom + " " + Pays;
    }
}