using Entities.Compositions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EfImplementations.Configurations.Compositions
{
    public class PersonLessonConfiguration : BaseConfiguration<PersonLessonEntity>
    {
        public override void Configure(EntityTypeBuilder<PersonLessonEntity> builder)
        {
            builder.ToTable("PersonLessonCompositions", "composition");

            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PersonId)
                   .HasColumnName("PersonId")
                   .IsRequired();

            builder.Property(x => x.LessonId)
                   .HasColumnName("LessonId")
                   .IsRequired();

            builder.HasOne(x => x.Lesson)
                   .WithMany(x => x.PersonLessons)
                   .HasForeignKey(x => x.LessonId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Person)
                   .WithMany(x => x.PersonLessons)
                   .HasForeignKey(x => x.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
