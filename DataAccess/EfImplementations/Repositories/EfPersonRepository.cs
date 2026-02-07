using DataAccess.Repositories;
using Entities.Clients;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EfImplementations.Repositories
{
    public class EfPersonRepository : GenericRepository<PersonEntity>, IPersonRepository
    {
        public EfPersonRepository(DbContext context) : base(context, true)
        {
        }

        public PersonEntity? FindByEmail(string email)
        {
            IQueryable<PersonEntity> resultQuery = DbSet.AsQueryable();
            if (CanInclude)
            {
                resultQuery = this.IncludedQuery(resultQuery);
            }
            return resultQuery.FirstOrDefault(x => x.Email == email);
        }

        protected override IQueryable<PersonEntity> IncludedQuery(IQueryable<PersonEntity> query)
        {
            return query.Include(x => x.IdentityCard)
                        .Include(x => x.SalaryHistories)
                        .Include(x => x.PersonLessons)
                            .ThenInclude(x => x.Lesson)
                        .Include(x => x.PersonMobiles)
                            .ThenInclude(x => x.Mobile)
                        .Include(x => x.Student);
        }
    }
}
