using System.Collections.Generic;
using System.Linq;
using Recrutement.Models;

namespace Recrutement.Infrastructure
{
    public class SalleRepository : IRepository<Salle>
    {
        public IEnumerable<Salle> Collection => _collection;
        private List<Salle> _collection;
        public SalleRepository() {
            _collection = new List<Salle>();
        }
        public bool Ajouter(Salle obj)
        {
            if (_collection.Any(rec => rec.Equals(obj))) return false;
            _collection.Add(obj);
            return true;
        }

        public bool Supprimer(Salle obj) => _collection.Remove(obj);
    }
}