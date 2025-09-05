namespace Day2Task.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int DepartmentId { get; set; }

        // Navigation properties
        public Department? Department { get; set; }
        public List<Instructor>? Instructors { get; set; }
        public List<CrsResult>? CrsResults { get; set; }
    }
}