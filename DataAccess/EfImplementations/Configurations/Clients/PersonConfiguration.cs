using Entities.Educations;
using Entities.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EfImplementations.Configurations.Clients
{
    public class PersonConfiguration : BaseConfiguration<PersonEntity>
    {
        public override void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("People", "client");

            builder.HasIndex(x => x.RefreshToken)
                .IsUnique(false);

            builder.Property(x => x.PersonSalary)
                   .HasColumnName("Salary");

            builder.Property(x => x.RefreshToken)
                .IsRequired()
                .HasDefaultValue("NoToken")
                .HasMaxLength(500);

            builder.Property(x => x.Email)
                   .HasColumnName("Email")
                   .IsRequired();

            builder.HasOne(x => x.Student)
                   .WithOne(x => x.Person)
                   .HasForeignKey<StudentEntity>(x => x.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(x => x.IdentityCard)
                   .WithOne(x => x.Person)
                   .HasForeignKey<IdentityCardEntity>(x => x.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.SalaryHistories)
                   .WithOne(x => x.Person)
                   .HasForeignKey(x => x.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PersonMobiles)
                   .WithOne(x => x.Person)
                   .HasForeignKey(x => x.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PersonLessons)
                   .WithOne(x => x.Person)
                   .HasForeignKey(x => x.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
