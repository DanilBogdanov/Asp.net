namespace DanilDev.Services.CostControl.Entity
{
    public class Account
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
