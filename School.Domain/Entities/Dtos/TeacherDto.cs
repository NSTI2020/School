using System;
using System.Collections.Generic;

namespace School.Domain.Entities.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MaritalStatus { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
        public int? ContactId { get; set; }
        public ContactDto Contact { get; set; }
        //public int UnitId { get; set; }
        // public Unit Unit { get; set; }
        public int? AddressId { get; set; }
        public AddressDto Address { get; set; }
        public List<DisciplineDto> Disciplines { get; set; }
    }
}
