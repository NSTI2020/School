using System.Collections.Generic;

namespace School.Domain.Entities
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public int StudentsId { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public int TeachersId { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

    }

}
