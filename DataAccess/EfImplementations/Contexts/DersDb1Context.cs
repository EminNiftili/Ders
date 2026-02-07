using DataAccess.EfImplementations.Configurations.Compositions;
using DataAccess.EfImplementations.Configurations.Educations;
using DataAccess.EfImplementations.Configurations.Clients;
using Entities.Compositions;
using Entities.Educations;
using Entities.Clients;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EfImplementations.Contexts
{
    public class DersDb1Context : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<PersonLessonEntity>(new PersonLessonConfiguration());
            modelBuilder.ApplyConfiguration<PersonMobileEntity>(new PersonMobileConfiguration());
            modelBuilder.ApplyConfiguration<PersonEntity>(new PersonConfiguration());
            modelBuilder.ApplyConfiguration<SalaryHistoryEntity>(new SalaryHistoryConfiguration());
            modelBuilder.ApplyConfiguration<LessonEntity>(new LessonConfiguration());
            modelBuilder.ApplyConfiguration<StudentEntity>(new StudentConfiguration());
            modelBuilder.ApplyConfiguration<IdentityCardEntity>(new IdentityCardConfiguration());
            modelBuilder.ApplyConfiguration<MobileEntity>(new MobileConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=DersDB1;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<PersonLessonEntity> PersonLessons { get; set; }
        public DbSet<PersonMobileEntity> PersonMobiles { get; set; }
        public DbSet<PersonEntity> People { get; set; }
        public DbSet<SalaryHistoryEntity> SalaryHistories { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<IdentityCardEntity> IdentityCards { get; set; }
        public DbSet<MobileEntity> Mobiles { get; set; }
    }
}
