namespace School.Domain.Entities
{
    public class UnitTeacher
    {
     //   public int Id { get; set; }
        public int? UnitId { get; set; }
        public Unit Unit { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}