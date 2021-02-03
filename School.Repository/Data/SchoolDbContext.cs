using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Repository.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<SocialNetwork> socialNetworks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        //   public DbSet<DisciplineStudent> DisciplinesStudents { get; set; }
        // public DbSet<DisciplineTeacher> DisciplinesTeachers { get; set; }
        public DbSet<Unit> Units { get; set; }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>().HasKey(_id => _id.Id);
            builder.Entity<Contact>().HasMany(_instantMessage => _instantMessage.instantMessage).WithOne();
            builder.Entity<Contact>().HasMany(_socialNetwork => _socialNetwork.socialNetwork).WithOne();

            builder.Entity<Unit>().HasKey(_id => _id.Id);
            builder.Entity<Unit>().HasMany(_checkingAccounts => _checkingAccounts.CheckingAccounts).WithOne();
            builder.Entity<Unit>().HasMany(_rooms => _rooms.Rooms).WithOne();

            builder.Entity<Student>().HasKey(_id => _id.Id);
            builder.Entity<Student>().HasOne(_contact => _contact.Contact).WithOne();
            builder.Entity<Student>().HasMany(_discipline => _discipline.Discipline).WithOne();

            builder.Entity<Class>().HasKey(_id => _id.Id);
            builder.Entity<Class>().HasOne(_teacher => _teacher.Teacher).WithOne();
            builder.Entity<Class>().HasOne(_discipline => _discipline.Discipline).WithOne();
            builder.Entity<Class>().HasOne(_room => _room.Room).WithOne();
            builder.Entity<Class>().HasOne(_unit => _unit.Unit).WithOne();
            builder.Entity<Class>().HasMany(_students => _students.Students);




        }
    }

}

