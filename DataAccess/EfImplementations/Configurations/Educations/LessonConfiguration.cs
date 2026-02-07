using Entities.Educations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EfImplementations.Configurations.Educations
{
    public class LessonConfiguration : BaseConfiguration<LessonEntity>
    {
        public override void Configure(EntityTypeBuilder<LessonEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Lessons", "education");

            builder.HasMany(x =>x.PersonLessons)
                   .WithOne(x => x.Lesson)
                   .HasForeignKey(x => x.LessonId)
                   .OnDelete(DeleteBehavior.Cascade);


            var defaultLessons = new LessonEntity[]
            {
                new LessonEntity
                {
                    Id = 1,
                    SpecialtyName = "Riyaziyyat",
                    FacultyName = "MexMat",
                },
                new LessonEntity
                {
                    Id = 2,
                    SpecialtyName = "Mexanika",
                    FacultyName = "MexMat",
                },
                new LessonEntity
                {   
                    Id = 3,
                    SpecialtyName = "Komputer muhendisli",
                    FacultyName = "Kibernetika",
                },
                new LessonEntity
                {
                    Id = 4,
                    SpecialtyName = "Informatika",
                    FacultyName = "Kibernetika",
                },
                new LessonEntity
                {
                    Id = 5,
                    SpecialtyName = "Serq Etomologiyasi",
                    FacultyName = "Dil ve Edebiyyat",
                },
                new LessonEntity
                {
                    Id = 6,
                    SpecialtyName = "Azerbaycan Tarixi",
                    FacultyName = "Tarix",
                },
                new LessonEntity
                {
                    Id = 7,
                    SpecialtyName = "Rus Tarixi",
                    FacultyName = "Tarix",
                },
            };
            builder.HasData(defaultLessons);
        }
    }
}
