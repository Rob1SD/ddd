using System;
using System.Net.NetworkInformation;

namespace ddd
{
    public class Salle : IEquatable<Salle>
    {
        public string Nom { get; }
        public int Etage { get; }
       
        

        public Salle(string Nom, int Etage)
        {
            this.Nom = Nom;
            this.Etage = Etage;
        }

        public bool Equals(Salle other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Nom, other.Nom) && int.Equals(Etage, other.Etage);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
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