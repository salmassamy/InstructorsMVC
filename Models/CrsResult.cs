namespace Day2Task.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        public int TraineeId { get; set; }
        public int CourseId { get; set; }

        // Navigation properties
        public Trainee? Trainee { get; set; }
        public Course? Course { get; set; }
    }
}