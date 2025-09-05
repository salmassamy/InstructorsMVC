namespace Day2Task.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public int Grade { get; set; }
        public int DepartmentId { get; set; }

        // Navigation properties
        public Department? Department { get; set; }
        public List<CrsResult>? CrsResults { get; set; }
    }
}