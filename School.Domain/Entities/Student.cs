using System.Collections.Generic;

namespace School.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}
