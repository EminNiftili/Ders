using Entities.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EfImplementations.Configurations.Clients
{
    public class MobileConfiguration : BaseConfiguration<MobileEntity>
    {
        public override void Configure(EntityTypeBuilder<MobileEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("PhoneNumbers", "client");

            builder.Property(x => x.Number)
                   .HasColumnName("PhoneNumber");
        }
    }
}
