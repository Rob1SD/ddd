namespace Recrutement.Models.Actors
{
    public class Personne
    {
        public string Nom { get; }
        public string Prenom { get; }

        public Personne(string prenom, string nom) {
        this.Nom = nom;
        this.Prenom = prenom;
        }
        
        
    }
    
}