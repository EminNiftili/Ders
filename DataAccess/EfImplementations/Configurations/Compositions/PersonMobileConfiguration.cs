using Entities.Compositions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EfImplementations.Configurations.Compositions
{
    public class PersonMobileConfiguration : BaseConfiguration<PersonMobileEntity>
    {
        public override void Configure(EntityTypeBuilder<PersonMobileEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("PersonPhoneNumberCompositions", "composition");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Person)
                   .WithMany(x => x.PersonMobiles)
                   .HasForeignKey(x => x.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(x => x.Mobile)
                   .WithMany()
                   .HasForeignKey(x => x.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
