namespace School.Domain.Entities
{
    public class DisciplineClass
    {
        public int Id { get; set; }
        public string _Language { get; set; }
        public Student Student { get; set; }
    }
}