namespace Asp_In_Action.Services.CostControl.Entity
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
        public User User { get; set; }
    }
}
