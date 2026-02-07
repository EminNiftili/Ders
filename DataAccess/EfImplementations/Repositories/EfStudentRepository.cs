using DataAccess.Repositories;
using Entities.Educations;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EfImplementations.Repositories
{
    public class EfStudentRepository : GenericRepository<StudentEntity>, IStudentRepository
    {
        public EfStudentRepository(DbContext context) : base(context, true)
        {
        }

        protected override IQueryable<StudentEntity> IncludedQuery(IQueryable<StudentEntity> query)
        {
            return query.Include(x => x.Person)
                            .ThenInclude(x => x!.SalaryHistories)
                        .Include(x => x.Person)
                            .ThenInclude(x => x!.IdentityCard)
                        .Include(x => x.Person)
                            .ThenInclude(x => x!.PersonMobiles)
                                .ThenInclude(x => x.Mobile)
                        .Include(x => x.Person)
                            .ThenInclude(x => x!.Student);
        }
    }
}
