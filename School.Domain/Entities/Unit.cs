using System.Collections;
using System.Collections.Generic;

namespace School.Domain.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoomsId { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public int CheckingAccountsId { get; set; }
        public List<CheckingAccount> CheckingAccounts { get; set; } = new List<CheckingAccount>();
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
