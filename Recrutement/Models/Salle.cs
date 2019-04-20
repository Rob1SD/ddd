using System;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace ddd
{
    public class Salle : IEquatable<Salle>
    {
        public string Nom { get; }
        public int Etage { get; }
       
         private readonly List<Creneau> CreneauxIndisponibles;

        public Salle(string Nom, int Etage)
        {
            this.Nom = Nom;
            this.Etage = Etage;
            CreneauxIndisponibles = new List<Creneau>();
        }

        public bool AjouterIndisponibilite(Creneau Indispo) {
            if (!EstDisponible(Indispo))
                return false;
            
            CreneauxIndisponibles.Add(Indispo);

            if (CreneauxIndisponibles.IndexOf(Indispo) >= 0)
                return true;
            
            return false;
        }
        public bool EstDisponible(Creneau creneauSouhaite)
        {
            if (CreneauxIndisponibles.IndexOf(creneauSouhaite) < 0)
                return true;
            return false;

        }

        public bool Equals(Salle other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Nom, other.Nom) && Equals(Etage, other.Etage);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Salle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Nom.GetHashCode();
                hashCode = (hashCode * 397) ^ Etage.GetHashCode();
                hashCode = (hashCode * 397) ^ Etage.GetHashCode();
                return hashCode;
            }
        }
    }
}