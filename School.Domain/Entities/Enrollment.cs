using System;
using System.Collections.Generic;

namespace School.Domain.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public DateTime DateOfEnrollment { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<Discipline> Disciplines { get; set; }
    }
}