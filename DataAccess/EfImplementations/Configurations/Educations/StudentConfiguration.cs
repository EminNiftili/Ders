using Entities.Educations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EfImplementations.Configurations.Educations
{
    public class StudentConfiguration : BaseConfiguration<StudentEntity>
    {
        public override void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Students", "education");

            builder.HasOne(x => x.Person)
                   .WithOne(x => x.Student)
                   .HasForeignKey<StudentEntity>(x => x.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
