using Entities.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.EfImplementations.Configurations.Clients
{
    public class IdentityCardConfiguration : BaseConfiguration<IdentityCardEntity>
    {
        public override void Configure(EntityTypeBuilder<IdentityCardEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("IdentityCards", "client");

            builder.Property(x => x.RegisteredAddress)
                   .HasColumnName("RegisterAdress");

            builder.HasOne(x =>x.Person)
                   .WithOne(x => x.IdentityCard)
                   .HasForeignKey<IdentityCardEntity>(x => x.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);   
        }
    }
}
