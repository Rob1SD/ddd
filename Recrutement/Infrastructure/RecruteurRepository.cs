using System.Collections.Generic;
using System.Linq;
using Recrutement.Models.Actors;

namespace Recrutement.Infrastructure
{
    public class RecruteurRepository : IRepository<Recruteur>
    {
        public IEnumerable<Recruteur> Collection => _collection;

        private readonly List<Recruteur> _collection;

        public RecruteurRepository()
        {
            _collection = new List<Recruteur>();   
        }

        public bool Ajouter(Recruteur recruteur)
        {
            if (_collection.Any(rec => rec.Equals(recruteur))) return false;
            _collection.Add(recruteur);
            return true;
        }
        

        public bool Supprimer(Recruteur recruteur) => _collection.Remove(recruteur);
    }
}