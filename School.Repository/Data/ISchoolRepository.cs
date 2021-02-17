using System.Threading.Tasks;
using School.Domain.Entities;

namespace School.Repository.Data
{
    public interface ISchoolRepository
    {
        //General
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T Entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Gets Students
        Task<Student[]> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int Id);


        //Gets Teachers
        Task<Teacher[]> GetAllTeachersAsync();
        Task<Teacher> GetTeacherByIdAsync(int Id);


        //Gets Class
        Task<Class[]> GetAllClassesAsync();
        Task<Class> GetClassByIdAsync(int Id);

        //Gets ChekingAccounts
        Task<CheckingAccount[]> GetAllCheckingAccountAsync();
        Task<CheckingAccount> GetCheckingAccountByIdAsync(int Id);


        //Gets Contacts
        Task<Contact[]> GetAllContactAsync();
        Task<Contact> GetContactByIdAsync(int Id);


        //Gets Discipline
        Task<Discipline[]> GetAllDisciplineAsync();
        Task<Discipline[]> GetAllDisciplineByIdAsync(int Id);


        //Gets InstantMessage
        Task<InstantMessage[]> GetAllInstantMessage();
        Task<InstantMessage> GetInstantMessageByIdAsync(int Id);


        //Gets Room
        Task<Room[]> GetAllRoomAsync();
        Task<Room> GetRoomByIdAsync(int Id);


        //gets SocialNetwork
        Task<SocialNetwork[]> GetAllSocialNetworkAsync();
        Task<SocialNetwork> GetSocialNetworkByIdAsync(int Id);


        //Unit
        Task<Unit[]> GetAllUnitAsync();
        Task<Unit> GetUnitByIdAsync(int Id);



    }
}
