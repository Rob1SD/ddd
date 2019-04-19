namespace ddd
{
    public class Candidat
    {
        public Personne Personne { get; }
        public Profil Profil { get; }
        public Candidat(Personne personne, Profil profil)
        {
            this.Personne = personne;
            this.Profil = profil;
        }
    }
}