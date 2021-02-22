using System.Collections;
using System.Collections.Generic;

namespace School.Domain.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<CheckingAccount> CheckingAccounts { get; set; } = new List<CheckingAccount>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
