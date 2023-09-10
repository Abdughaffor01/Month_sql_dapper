namespace Domain.Entities
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string city { get; set; }
    }
}
