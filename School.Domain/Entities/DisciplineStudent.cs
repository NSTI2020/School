namespace School.Domain.Entities
{
    public class DisciplineStudent
    {
        public int Id { get; set; }
        public string _Language { get; set; }
        public Student Student {get; set;}
    }
}