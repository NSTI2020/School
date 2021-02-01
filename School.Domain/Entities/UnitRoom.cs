namespace School.Domain.Entities
{
    public class UnitRoom
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}
