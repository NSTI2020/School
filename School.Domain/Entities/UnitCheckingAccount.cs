namespace School.Domain.Entities
{
    public class UnitCheckingAccount
    {
        public int Id { get; set; }
        public int CheckingAccountId { get; set; }
        public CheckingAccount CheckingAccount { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}
