using System;
using System.Collections.Generic;

namespace Recrutement.Models
{
    public class Salle : IEquatable<Salle>
    {
        public string Nom { get; }
        public int Etage { get; }
       
         private readonly List<Creneau> _creneauxIndisponibles;

        public Salle(string nom, int etage)
        {
            this.Nom = nom;
            this.Etage = etage;
            _creneauxIndisponibles = new List<Creneau>();
        }

        public bool AjouterIndisponibilite(Creneau indispo) {
            if (!EstDisponible(indispo))
                return false;
            
            _creneauxIndisponibles.Add(indispo);

            if (_creneauxIndisponibles.IndexOf(indispo) >= 0)
                return true;
            
            return false;
        }
        public bool EstDisponible(Creneau creneauSouhaite)
        {
            if (_creneauxIndisponibles.IndexOf(creneauSouhaite) < 0)
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