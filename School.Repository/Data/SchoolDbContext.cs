using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Repository.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<DisciplineTeacher> DisciplinesTeachers { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<SocialNetwork> socialNetworks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Unit> Units { get; set; }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DisciplineTeacher>().HasKey(_dt => new {_dt.DisciplineId, _dt.TeacherId});
        }
    }

}

