using Microsoft.EntityFrameworkCore;

namespace Day2Task.Models
{
    public class ITIContext : DbContext
    {
        public ITIContext(DbContextOptions<ITIContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Instructor - Department (أضف هذه العلاقة)
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Instructor - Course
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Course)
                .WithMany(c => c.Instructors)
                .HasForeignKey(i => i.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Course - Department
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Trainee - Department
            modelBuilder.Entity<Trainee>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Trainees)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // CrsResult - Course
            modelBuilder.Entity<CrsResult>()
                .HasOne(r => r.Course)
                .WithMany(c => c.CrsResults)
                .HasForeignKey(r => r.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // CrsResult - Trainee
            modelBuilder.Entity<CrsResult>()
                .HasOne(r => r.Trainee)
                .WithMany(t => t.CrsResults)
                .HasForeignKey(r => r.TraineeId)
                .OnDelete(DeleteBehavior.Restrict);
            // ======================
            // 🔹 Data Seeding
            // ======================

            // Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "SD", Manager = "Ahmed" },
                new Department { Id = 2, Name = "Java", Manager = "Mona" }
            );

            // Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "C#", Degree = 100, MinDegree = 50, DepartmentId = 1 },
                new Course { Id = 2, Name = "OOP", Degree = 100, MinDegree = 60, DepartmentId = 1 },
                new Course { Id = 3, Name = "Java SE", Degree = 100, MinDegree = 50, DepartmentId = 2 }
            );

            // Trainees
            modelBuilder.Entity<Trainee>().HasData(
                new Trainee { Id = 1, Name = "Salma", Address = "Cairo", Grade = 85, DepartmentId = 1, Image = "salma.png" },
                new Trainee { Id = 2, Name = "Omar", Address = "Alex", Grade = 90, DepartmentId = 2, Image = "omar.png" }
            );

            // Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, Name = "Dr. Ali", Salary = 10000, Address = "Cairo", DepartmentId = 1, CourseId = 1, Image = "ali.png" },
                new Instructor { Id = 2, Name = "Dr. Sara", Salary = 12000, Address = "Giza", DepartmentId = 2, CourseId = 3, Image = "sara.png" }
            );

            // CrsResults
            modelBuilder.Entity<CrsResult>().HasData(
                new CrsResult { Id = 1, Degree = 80, CourseId = 1, TraineeId = 1 },
                new CrsResult { Id = 2, Degree = 95, CourseId = 3, TraineeId = 2 }
            );
        }
    }
}
