using System.Collections;
using System.Collections.Generic;
using System;

namespace School.Domain.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
        public List<CheckingAccount> CheckingAccounts { get; set; }
        public List<Student> Students { get; set; }
        //public List<UnitTeacher> Teachers { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
