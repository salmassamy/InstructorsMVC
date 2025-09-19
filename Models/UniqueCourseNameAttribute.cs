using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Day2Task.Models
{
   
    public class UniqueCourseNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var db = (ITIContext)validationContext.GetService(typeof(ITIContext))!;
            var name = value?.ToString()?.Trim();

            if (string.IsNullOrWhiteSpace(name))
                return ValidationResult.Success;

            var course = (Course)validationContext.ObjectInstance;

            var exists = db.Courses.Any(c => c.Name == name && c.Id != course.Id);
            if (exists)
                return new ValidationResult("Course name must be unique");

            return ValidationResult.Success;
        }
    }

  
    public class CustomMinDegreeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var course = (Course)validationContext.ObjectInstance;

           
            if (course == null) return ValidationResult.Success;

            if (course.MinDegree >= course.Degree)
                return new ValidationResult("MinDegree must be less than Degree");

            return ValidationResult.Success;
        }
    }
}
