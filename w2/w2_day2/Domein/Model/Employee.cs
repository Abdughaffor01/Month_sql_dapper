namespace Domein.Model
{
    public class Employee : Person
    {
        public int DepartmentId { get; set; }
        public string Position { get; set; }
    }
}
