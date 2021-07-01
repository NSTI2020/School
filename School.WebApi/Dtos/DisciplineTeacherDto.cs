namespace School.WebApi.Dtos
{
    public class DisciplineTeacherDto
    {
         public int Id {get; set;}
        public int? DisciplineId { get; set; }
        public virtual DisciplineDto Discipline { get; set; }
        public int? TeacherId { get; set; }
        public virtual TeacherDto Teacher { get; set; }
    }
}