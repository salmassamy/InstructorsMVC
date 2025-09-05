namespace Day2Task.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Manager { get; set; }

        // Navigation properties
        public List<Course>? Courses { get; set; }
        public List<Trainee>? Trainees { get; set; }

        public ICollection<Instructor>? Instructors { get; set; }
    }
}