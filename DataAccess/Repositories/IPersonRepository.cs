using Entities.Clients;

namespace DataAccess.Repositories
{
    public interface IPersonRepository : IRepository<PersonEntity>
    {
        PersonEntity? FindByEmail(string email);
    }
}
