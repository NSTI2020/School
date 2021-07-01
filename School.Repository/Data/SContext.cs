using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Repository.Data
{
    public class SContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitTeacher> UnitsTeachers { get; set; }

        public SContext(DbContextOptions<SContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //  builder.Entity<Teacher>().HasKey(_id => _id.Id);
            //  builder.Entity<Student>().HasKey(_id => _id.Id);
            //  builder.Entity<Unit>().HasKey(_id => _id.Id);
            //  builder.Entity<Room>().HasKey(_id => _id.Id);
            //  builder.Entity<Discipline>().HasKey(_id => _id.Id);
            //  builder.Entity<Class>().HasKey(_id => _id.Id);
            //  builder.Entity<Contact>().HasKey(_id => _id.Id);
            //  builder.Entity<Address>().HasKey(_id => _id.Id);
            //  builder.Entity<Enrollment>().HasKey(_id => _id.Id);
            //builder.Entity<UnitTeacher>().HasMany<Teacher>().WithOne().HasForeignKey(_uId => _uId.Units);
            //builder.Entity<UnitTeacher>().HasMany<Unit>().WithOne().HasForeignKey(_tId => _tId.Teachers);
            //builder.Entity<UnitTeacher>().HasKey(Unit => Unit.UnitId);
           //builder.Entity<Unit>().HasMany(_teachers => _teachers.Teachers);
            //builder.Entity<Teacher>().HasMany(_units => _units.Units);

        //  builder.Entity<Unit>().HasKey(_unit => _unit.Id);
        //  builder.Entity<Teacher>().HasKey(_teacher => _teacher.Id);
        //  builder.Entity<Discipline>().HasKey(_discipline => _discipline.Id);
//
//         builder.Entity<UnitTeacher>().HasKey(_unitTeacher => _unitTeacher.Id);
//
        builder.Entity<UnitTeacher>()
        .HasKey(_ut => new { _ut.UnitId, _ut.TeacherId });





        }

    }
}