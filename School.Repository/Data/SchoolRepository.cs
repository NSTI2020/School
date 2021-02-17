using System.Threading.Tasks;
using School.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace School.Repository.Data
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolDbContext _context;
        public SchoolRepository(SchoolDbContext context)
        {
            _context = context;
        }
        //GENERAL
        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }

        public void Delete<T>(T Entity) where T : class
        {
            _context.Remove(Entity);
        }
        public void Update<T>(T Entity) where T : class
        {
            _context.Update(Entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 1)
            {
                return true;
            }
            return false;

        }



        public Task<CheckingAccount[]> GetAllCheckingAccountAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Class[]> GetAllClassesAsync()
        {
            IQueryable<Class> query = _context.Classes
            .AsNoTracking()
            .Include(_teacher => _teacher.Discipline)
            .Include(_student => _student.Students)
            .Include(_discipline => _discipline.Discipline)
            .Include(_unit => _unit.Unit);

            query = query.OrderBy(_start => _start.Start);


            return await query.ToArrayAsync();

        }

        public Task<Contact[]> GetAllContactAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Discipline[]> GetAllDisciplineAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Discipline[]> GetAllDisciplineByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<InstantMessage[]> GetAllInstantMessage()
        {
            throw new System.NotImplementedException();
        }

        public Task<Room[]> GetAllRoomAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<SocialNetwork[]> GetAllSocialNetworkAsync()
        {
            IQueryable<SocialNetwork> query = _context.socialNetworks
            .AsNoTracking();

            query = query.OrderBy(_name => _name.Name);
            return await query.ToArrayAsync();
        }

        public async Task<Student[]> GetAllStudentAsync()
        {
            IQueryable<Student> query = _context.Students
            .AsNoTracking()
                .Include(_dicipline => _dicipline)
                .Include(_contact => _contact.Contact)
                .ThenInclude(_socialNetwork => _socialNetwork.socialNetwork)
                .Include(_contact => _contact.Contact)
                    .ThenInclude(_instantMessage => _instantMessage.instantMessage);

            query = query.OrderBy(_name => _name.Name);
            return await query.ToArrayAsync();
        }

        public async Task<Teacher[]> GetAllTeachersAsync()
        {
            IQueryable<Teacher> query = _context.Teachers
            .AsNoTracking()
                .Include(_dicipline => _dicipline)
                .Include(_contact => _contact.Contact)
                .ThenInclude(_socialNetwork => _socialNetwork.socialNetwork)
                .Include(_contact => _contact.Contact)
                    .ThenInclude(_instantMessage => _instantMessage.instantMessage);

            query = query.OrderBy(_name => _name.Name);
            return await query.ToArrayAsync();
        }

        public async Task<Unit[]> GetAllUnitAsync()
        {
            IQueryable<Unit> query = _context.Units
            .AsNoTracking();
            //   .Include(_room => _room.Room);

            query = query.OrderBy(_name => _name.Name);
            return await query.ToArrayAsync();
        }

        public Task<CheckingAccount> GetCheckingAccountByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Class> GetClassByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Contact> GetContactByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<InstantMessage> GetInstantMessageByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Room> GetRoomByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<SocialNetwork> GetSocialNetworkByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> GetStudentByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Teacher> GetTeacherByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Unit> GetUnitByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }


    }
}
