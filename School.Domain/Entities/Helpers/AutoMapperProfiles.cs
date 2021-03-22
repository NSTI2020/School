using AutoMapper;
using School.Domain.Entities.Dtos;

namespace School.Domain.Entities.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<CheckingAccount, CheckingAccountDto>();
            CreateMap<Class, ClassDto>();
            CreateMap<Contact, ContactDto>();
            //CreateMap<Discipline, DisciplineDto>();
            CreateMap<InstantMessage, InstantMessageDto>();
            CreateMap<Room, RoomDto>();
            CreateMap<SocialNetwork, SocialNetworkDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<Unit, UnitDto>();
        }
    }
}
