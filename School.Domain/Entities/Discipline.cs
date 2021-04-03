using System.Collections.Generic;

namespace School.Domain.Entities
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public List<DisciplineTeacher> ListDisciplinesTeachers { get; set; }
    }
}