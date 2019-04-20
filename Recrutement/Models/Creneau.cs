using System;
using System.Net.NetworkInformation;

namespace ddd
{
    public class Creneau : IEquatable<Creneau>
    {
        public DateTime DateDebut { get; }
        public DateTime DateFin { get; }
        

        public Creneau(DateTime dateDebut, int dureeMinutes)
        {
            DateDebut = dateDebut;
            DateFin = dateDebut.AddMinutes(dureeMinutes);
        }
        
        public Creneau(DateTime dateDebut, TimeSpan duree)
        {
            DateDebut = dateDebut;
            DateFin = dateDebut.Add(duree);
        }

        public bool SeChevauche(Creneau creneau) => !(DateFin.CompareTo(creneau.DateDebut) < 0 
                                                      || DateDebut.CompareTo(creneau.DateFin) >= 0);

        public bool Equals(Creneau other) => DateDebut.Equals(other.DateDebut) 
                                             && DateFin.Equals(other.DateFin);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Creneau) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = DateDebut.GetHashCode();
            return hashCode;
        }
    }
}