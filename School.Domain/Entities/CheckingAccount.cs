using System.Collections.Generic;

namespace School.Domain.Entities
{
    public class CheckingAccount
    {
        public int Id { get; set; }
        public string Bank { get; set; }
        public int Agency { get; set; }
        public string Type { get; set; }
        public int Account { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

    }
}
