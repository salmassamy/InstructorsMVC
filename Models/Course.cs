using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2Task.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course Name is required")]
        [MaxLength(20, ErrorMessage = "Max length is 20 characters")]
        [MinLength(2, ErrorMessage = "Min length is 2 characters")]
        [UniqueCourseName] 
        public string? Name { get; set; }

        [Required(ErrorMessage = "Degree is required")]
        [Range(50, 100, ErrorMessage = "Degree must be between 50 and 100")]
        public int Degree { get; set; }

        [Required(ErrorMessage = "Min Degree is required")]
        [CustomMinDegreeValidation] 
        public int MinDegree { get; set; }

        [Required(ErrorMessage = "Hours is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Hours must be greater than 0")]
        public int Hours { get; set; }

        public int DepartmentId { get; set; }
        public string? Description { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
        public List<Instructor>? Instructors { get; set; }
        public List<CrsResult>? CrsResults { get; set; }
    }
}