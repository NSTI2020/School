using System;
using System.Collections.Generic;

namespace School.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime Birthday { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<DisciplineTeacher> Disciplines {get; set;}= new List<DisciplineTeacher>();

    }

}
