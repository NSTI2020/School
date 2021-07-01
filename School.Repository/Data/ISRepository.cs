using System.Threading.Tasks;
using School.Domain.Entities;

namespace School.Repository.Data
{
    public interface ISRepository
    {
        //General
        void Add<T>(T any) where T : class;
        void Update<T>(T any) where T : class;
        void Delete<T>(T any) where T : class;
        void DeteleRange<T>(T[] any) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Student[]> Students(bool include);
        Task<Student> Student(int id, bool include);
        Task<Class[]> Classes(bool include);
        Task<Class> Class(int id, bool include);
        Task<Teacher[]> GetAllTeachersAsync(bool include);
        Task<Teacher> GetTeacherAsync(int id, bool include);
        Task<Discipline[]> Disciplines();
        Task<Unit[]> GetAllUnitsAsync(bool include);
        Task<Unit> GetUnitAsync(int id, bool include);


    }
}