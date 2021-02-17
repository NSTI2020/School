using System.Collections.Generic;

namespace School.Domain.Entities.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ContactDtoId { get; set; }
        public ContactDto ContactDto { get; set; }

        public List<DisciplineDto> DisciplineDto { get; set; }
        public int AddressDtoId { get; set; }
        public AddressDto AddressDto { get; set; }
    }
}
