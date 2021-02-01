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
        public List<Discipline> Discipline { get; set; } = new List<Discipline>();
        //Address
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Complement { get; set; }

    }
}
