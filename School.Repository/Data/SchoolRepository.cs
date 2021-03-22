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
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;

        }

        public bool SaveChanges()
        {
            if (_context.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<CheckingAccount[]> GetAllCheckingAccountAsync()
        {
            IQueryable<CheckingAccount> query = _context.CheckingAccounts
            .AsNoTracking();

            query = query.OrderBy(_bank => _bank.Bank);

            return await query.ToArrayAsync();

        }
        public async Task<CheckingAccount> GetCheckingAccountByIdAsync(int Id)
        {
            IQueryable<CheckingAccount> query = _context.CheckingAccounts
            .AsNoTracking();

            CheckingAccount entity = await query.FirstOrDefaultAsync(_chkAcc => _chkAcc.Id == Id);
            return entity;

        }
        public async Task<Class[]> GetAllClassesAsync()
        {
            IQueryable<Class> query = _context.Classes
            .AsNoTracking()
            .Include(_teacher => _teacher.Teacher)
            .Include(_student => _student.Students)
            .Include(_discipline => _discipline.Discipline)
            .Include(_unit => _unit.Unit)
            .Include(_room => _room.Room);

            query = query.OrderBy(_start => _start.Start);


            return await query.ToArrayAsync();

        }

        public async Task<Contact[]> GetAllContactAsync()
        {
            IQueryable<Contact> query = _context.Contacts
            .AsNoTracking()
            .Include(_insMsg => _insMsg.instantMessage)
            .Include(_scNet => _scNet.socialNetwork);

            query = query.OrderBy(_email => _email.Email);

            return await query.ToArrayAsync();

        }

        public async Task<DisciplineTeacher[]> GetAllDisciplineAsync()
        {
            IQueryable<DisciplineTeacher> query = _context.Disciplines
            .AsNoTracking();

            query = query.OrderBy(_disp => _disp.Language);

            return await query.ToArrayAsync();
        }

        public Task<DisciplineTeacher[]> GetAllDisciplineByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<InstantMessage[]> GetAllInstantMessage()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Room[]> GetAllRoomAsync()
        {
            IQueryable<Room> query = _context.Rooms
            .AsNoTracking()
            .OrderBy(_Ident => _Ident.Identifier);

            return await query.ToArrayAsync();
        }
        public async Task<Room> GetRoomByIdAsync(int Id)
        {
            IQueryable<Room> query = _context.Rooms
             .AsNoTracking();
            Task<Room> entity = query.FirstOrDefaultAsync(_room => _room.Id == Id);

            return await entity;
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
        public async Task<Student> GetStudentByIdAsync(int Id)
        {
            IQueryable<Student> Students = _context.Students
            .AsNoTracking()
            .Include(_contact => _contact.Contact)
            .ThenInclude(_im => _im.instantMessage)
            .Include(_contact => _contact.Contact)
            .ThenInclude(_rs => _rs.socialNetwork)
            .Include(_address => _address.Address);

            Student student = await
            Students.FirstOrDefaultAsync(_student => _student.Id == Id);

            return student;

        }

        public async Task<Teacher[]> GetAllTeachersAsync()
        {
            IQueryable<Teacher> query = _context.Teachers
            .AsNoTracking()
                .Include(_contact => _contact.Contact)
                .ThenInclude(_socialNetwork => _socialNetwork.socialNetwork)
                .Include(_contact => _contact.Contact)
                    .ThenInclude(_instantMessage => _instantMessage.instantMessage);

            query = query.OrderBy(_name => _name.FullName);
            return await query.ToArrayAsync();
        }
        public async Task<Teacher> GetTeacherByIdAsync(int Id)
        {
            IQueryable<Teacher> query = _context.Teachers
            .AsNoTracking()
            .Include(_contact => _contact)
            .ThenInclude(_sNetwork => _sNetwork.Contact.socialNetwork)
            .Include(_contact => _contact)
            .ThenInclude(_im => _im.Contact.instantMessage);

            Task<Teacher> teacher = query.FirstOrDefaultAsync(_teacher => _teacher.Id == Id);

            return await teacher;
        }

        public async Task<Unit[]> GetAllUnitAsync()
        {
            IQueryable<Unit> query = _context.Units
            .AsNoTracking()
            .Include(_room => _room.Rooms)
            .Include(_students => _students.Students)
            .Include(_teacher => _teacher.Teachers)
            .Include(_address => _address.Address);

            query = query.OrderBy(_name => _name.Name);

            return await query.ToArrayAsync();
        }
        public async Task<Unit> GetUnitByIdAsync(int Id)
        {
            IQueryable<Unit> query = _context.Units
             .AsNoTracking()
             .Include(_room => _room.Rooms)
             .Include(_students => _students.Students)
             .Include(_teacher => _teacher.Teachers)
             .Include(_address => _address.Address);

            query = query.OrderBy(_unit => _unit.Name);

            Task<Unit> unit = query.FirstOrDefaultAsync(_unit => _unit.Id == Id);

            return await unit;
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

        public Task<SocialNetwork> GetSocialNetworkByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Address[]> GetAllAddressesAsync()
        {
            IQueryable<Address> query = _context.Addresses
            .AsTracking();
            query = query.OrderBy(str => str.Street);

            return await query.ToArrayAsync();
        }

        public async Task<Address> GetAddressesByIdAsync(int Id)
        {
            IQueryable<Address> query = _context.Addresses
            .AsTracking();

            query = query.OrderBy(stre => stre.Street);

            Address address = await query.FirstOrDefaultAsync(_address => _address.Id == Id);

            return address;

        }


    }
}
