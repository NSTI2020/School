using System.Collections;
using System.Collections.Generic;

namespace School.Domain.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Room> UnitRoom { get; set; } = new List<Room>();
        //Address
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Complement { get; set; }
        public List<CheckingAccount> UnitCAccount { get; set; } = new List<CheckingAccount>();

    }
}
