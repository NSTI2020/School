using System.Linq;
using System.Threading.Tasks;
using School.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace School.Repository.Data
{

    public class SRepository : ISRepository
    {

        //Refer dbase
        private readonly SContext _context;
        public SRepository(SContext context)
        {
            _context = context;
        }

        //Generics Methos CRUD
        public void Add<T>(T any) where T : class
        {
            _context.Add(any);
            //   _context.AddAsync(any);
        }
        public void Update<T>(T any) where T : class
        {
            _context.Update(any);
        }
        public void Delete<T>(T any) where T : class
        {
            _context.Remove(any);
        }
        public void DeteleRange<T>(T[] any) where T : class
        {
            _context.RemoveRange(any);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        //Seach, query
        public Task<Class[]> Classes(bool include)
        {
            throw new System.NotImplementedException();


        }

        public Task<Class> Class(int id, bool include)
        {
            throw new System.NotImplementedException();
        }
        public Task<Student[]> Students(bool include)
        {
            throw new System.NotImplementedException();
        }
        public Task<Student> Student(int id, bool include)
        {
            throw new System.NotImplementedException();
        }
        public async Task<Teacher[]> GetAllTeachersAsync(bool include)
        {
            IQueryable<Teacher> query = _context.Teachers
              .AsNoTracking();

            if (include)
            {
                query = query
               .Include(_pull => _pull.Contact)
               .Include(_pull => _pull.Address)
               .Include(_pull => _pull.Disciplines);
            }

            query = query.OrderBy(_name => _name.FullName);
            return await query.ToArrayAsync();

        }
        public async Task<Teacher> GetTeacherAsync(int id, bool include)
        {
            IQueryable<Teacher> query = _context.Teachers
             .AsNoTracking();

            if (include)
            {
                query = query
               .Include(_pull => _pull.Contact)
               .Include(_pull => _pull.Address)
               .Include(_pull => _pull.Disciplines);
            }

            query = query.Where(teacherId => teacherId.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Unit[]> GetAllUnitsAsync(bool include)
        {
            IQueryable<Unit> query = _context.Units
            .AsNoTracking();
         /*   if (include)
            {
                query = query
               .Include(_pull => _pull.Contact)
               .Include(_pull => _pull.Address)
               .Include(_pull => _pull.CheckingAccounts)
               .Include(_pull => _pull.Rooms)
               .Include(_pull => _pull.Students)
               .Include(_pull => _pull.Teachers);              
            }*/
            query = query.OrderBy(_name => _name.Name);

            return await query.ToArrayAsync();
            
        }

        public async Task<Unit> GetUnitAsync(int id, bool include)
        {
            throw new System.NotImplementedException();
        }
        public async Task<Discipline[]> Disciplines()
        {
            IQueryable<Discipline> query = _context.Disciplines
            .AsNoTracking();
            query = query.OrderBy(id => id.Id);
            return await query.ToArrayAsync();
        }


    }
}