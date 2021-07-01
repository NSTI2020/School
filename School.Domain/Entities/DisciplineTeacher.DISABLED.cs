using System.Collections.Generic;

namespace School.Domain.Entities
{
    public class DisciplineTeacher
    {
        public int Id {get; set;}
        public int? DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }

}
