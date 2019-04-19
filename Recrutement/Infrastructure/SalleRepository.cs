using System.Collections.Generic;
using System.Linq;

namespace ddd
{
    public class SalleRepository : IRepository<Salle>
    {
        public IEnumerable<Salle> Collection => collection;
        private List<Salle> collection;
        public SalleRepository() {
            this.collection = new List<Salle>();
        }
        public bool Ajouter(Salle obj)
        {
            if (collection.Any(rec => rec.Equals(obj))) return false;
            collection.Add(obj);
            return true;
        }

        public bool Supprimer(Salle obj) => collection.Remove(obj);
    }
}