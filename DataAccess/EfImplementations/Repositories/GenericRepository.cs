using DataAccess.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EfImplementations.Repositories
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> 
        where TEntity : BaseEntity
    {
        protected readonly bool CanInclude;
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected GenericRepository(DbContext context, bool canInclude)
        {
            CanInclude = canInclude;
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this.Delete(entity.Id);
        }

        public void Delete(int id)
        {
            var data = this.GetById(id);
            if(data == null)
            {
                throw new ArgumentNullException("Item not found in database");
            }
            DbSet.Remove(data);
        }

        public TEntity GetById(int id)
        {
            IQueryable<TEntity> resultQuery = DbSet.AsQueryable();
            if(CanInclude)
            {
                resultQuery = this.IncludedQuery(resultQuery);
            }
            return resultQuery.First(x => x.Id == id);
        }

        public TEntity? GetByIdOrDefault(int id)
        {
            IQueryable<TEntity> resultQuery = DbSet.AsQueryable();
            if (CanInclude)
            {
                resultQuery = this.IncludedQuery(resultQuery);
            }
            return resultQuery.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TEntity> Gets(Func<TEntity, bool> predicate)
        {
            IQueryable<TEntity> resultQuery = DbSet.AsQueryable();
            if (CanInclude)
            {
                resultQuery = this.IncludedQuery(resultQuery);
            }
            return resultQuery.Where(predicate).AsEnumerable();
        }

        public IEnumerable<TEntity> Gets()
        {
            return this.Gets(x => true);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        protected abstract IQueryable<TEntity> IncludedQuery(IQueryable<TEntity> query);
    }
}
