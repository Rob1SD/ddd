using System.Collections.Generic;

namespace Recrutement.Infrastructure
{
    public interface IRepository<T>
    {
        IEnumerable<T> Collection { get; }

        bool Ajouter(T obj);
        bool Supprimer(T obj);
    }
}