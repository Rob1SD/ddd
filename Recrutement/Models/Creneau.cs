using System;
using System.Net.NetworkInformation;

namespace ddd
{
    public class Creneau : IEquatable<Creneau>
    {
        public DateTime Date { get; }
        public string HeureDebut { get; }
        public string HeureFin { get; }
        

        public Creneau(DateTime Date, int duree)
        {
            this.Date = Date;
            HeureDebut = Date.ToLongTimeString();
            HeureFin = Date.AddMinutes(duree).ToLongTimeString();
        }

        public bool Equals(Creneau other) => Date.Equals(other.Date) 
                                             && string.Equals(HeureDebut, other.HeureDebut) 
                                             && string.Equals(HeureFin, other.HeureFin);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Creneau) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Date.GetHashCode();
                hashCode = (hashCode * 397) ^ (HeureDebut != null ? HeureDebut.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (HeureFin != null ? HeureFin.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}