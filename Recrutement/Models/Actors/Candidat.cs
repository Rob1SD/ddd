namespace Recrutement.Models.Actors
{
    public class Candidat
    {
        public Personne Personne { get; }
        public Profil Profil { get; }
        public Candidat(Personne personne, Profil profil)
        {
            Personne = personne;
            Profil = profil;
        }
    }
}