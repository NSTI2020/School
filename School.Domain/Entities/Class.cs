using System;
using System.Collections.Generic;

namespace School.Domain.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int roomId { get; set; }
        public Room Room { get; set; }
    }
}
