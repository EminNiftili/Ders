namespace Entities.Clients
{
    public class SalaryHistoryEntity : BaseEntity
    {
        public int PersonId { get; set; }
        public decimal OldSalary { get; set; }
        public decimal NewSalary { get; set; }

        public PersonEntity? Person { get; set; }
    }
}
