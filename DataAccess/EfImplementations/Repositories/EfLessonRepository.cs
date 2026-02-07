using DataAccess.Repositories;
using Entities.Educations;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EfImplementations.Repositories
{
    public class EfLessonRepository : GenericRepository<LessonEntity>, ILessonRepository
    {
        public EfLessonRepository(DbContext context) : base(context, true)
        {
        }

        protected override IQueryable<LessonEntity> IncludedQuery(IQueryable<LessonEntity> query)
        {
            return query.Include(x => x.PersonLessons)
                            .ThenInclude(x => x.Person)
                                .ThenInclude(x => x!.SalaryHistories)
                        .Include(x => x.PersonLessons)
                            .ThenInclude(x => x.Person)
                                .ThenInclude(x => x!.IdentityCard)
                        .Include(x => x.PersonLessons)
                            .ThenInclude(x => x.Person)
                                .ThenInclude(x => x!.PersonMobiles)
                                    .ThenInclude(x => x.Mobile)
                        .Include(x => x.PersonLessons)
                            .ThenInclude(x => x.Person)
                                .ThenInclude(x => x!.Student);
        }
    }
}
