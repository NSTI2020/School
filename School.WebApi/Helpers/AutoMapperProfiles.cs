using AutoMapper;
using School.Domain.Entities;
using School.WebApi.Dtos;

namespace School.WebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
                CreateMap<Teacher, TeacherDto>().ReverseMap();
                CreateMap<Contact, ContactDto>().ReverseMap();
                CreateMap<Discipline, DisciplineDto>().ReverseMap();
                CreateMap<Address, AddressDto>().ReverseMap();
           //     CreateMap<Unit, UnitDto>().ReverseMap();

        }
    }
}