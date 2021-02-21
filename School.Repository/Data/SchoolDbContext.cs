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
            builder.Entity<Address>().HasKey(_id => _id.Id);

            builder.Entity<Discipline>().HasKey(_id => _id.Id);

            builder.Entity<Unit>().HasKey(_id => _id.Id);
            builder.Entity<Unit>().HasMany(_checkingAccounts => _checkingAccounts.CheckingAccounts).WithOne();
            builder.Entity<Unit>().HasMany(_rooms => _rooms.Rooms).WithOne();

            builder.Entity<Student>().HasKey(_id => _id.Id);
            builder.Entity<Student>().HasOne(_contact => _contact.Contact).WithOne();
            builder.Entity<Student>().HasOne(_address => _address.Address).WithOne();

            builder.Entity<Teacher>().HasKey(_id => _id.Id);
            builder.Entity<Teacher>().HasOne(_contact => _contact.Contact).WithOne();
            builder.Entity<Teacher>().HasOne(_address => _address.Address).WithOne();

            builder.Entity<Class>().HasKey(_id => _id.Id);
            builder.Entity<Class>().HasOne(_teacher => _teacher.Teacher).WithOne();
            builder.Entity<Class>().HasOne(_discipline => _discipline.Discipline);
            builder.Entity<Class>().HasOne(_room => _room.Room).WithOne();
            builder.Entity<Class>().HasOne(_unit => _unit.Unit).WithOne();
            builder.Entity<Class>().HasMany(_students => _students.Students);




        }
    }

}

