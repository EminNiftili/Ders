using Entities;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity: BaseEntity
    {
        void Add(TEntity entity);
        TEntity GetById(int id);
        TEntity? GetByIdOrDefault(int id);
        IEnumerable<TEntity> Gets(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> Gets();
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
    }
}
