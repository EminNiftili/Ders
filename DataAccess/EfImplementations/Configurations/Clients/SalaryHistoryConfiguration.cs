using Entities.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EfImplementations.Configurations.Clients
{
    public class SalaryHistoryConfiguration : BaseConfiguration<SalaryHistoryEntity>
    {
        public override void Configure(EntityTypeBuilder<SalaryHistoryEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("SalaryHistory", "client");

            builder.HasOne(x => x.Person)
                   .WithMany(x => x.SalaryHistories)
                   .HasForeignKey(x => x.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
