using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Day2Task.Models
{
    public class Instructor
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }

        [Precision(18, 2)] // أضف هذا السطر
        public decimal Salary { get; set; }

        public string? Address { get; set; }
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }

        // Navigation properties
        [ForeignKey("CourseId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Course? Course { get; set; }

        [ForeignKey("DepartmentId")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Department?  Department { get; set; }
    }
}