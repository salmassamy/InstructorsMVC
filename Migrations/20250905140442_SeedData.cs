using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Day2Task.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Manager",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Manager", "Name" },
                values: new object[,]
                {
                    { 1, "Ahmed", "SD" },
                    { 2, "Mona", "Java" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Degree", "DepartmentId", "MinDegree", "Name" },
                values: new object[,]
                {
                    { 1, 100, 1, 50, "C#" },
                    { 2, 100, 1, 60, "OOP" },
                    { 3, 100, 2, 50, "Java SE" }
                });

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "Address", "DepartmentId", "Grade", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Cairo", 1, 85, "salma.png", "Salma" },
                    { 2, "Alex", 2, 90, "omar.png", "Omar" }
                });

            migrationBuilder.InsertData(
                table: "CrsResults",
                columns: new[] { "Id", "CourseId", "Degree", "TraineeId" },
                values: new object[,]
                {
                    { 1, 1, 80, 1 },
                    { 2, 3, 95, 2 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Address", "CourseId", "DepartmentId", "Image", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "Cairo", 1, 1, "ali.png", "Dr. Ali", 10000m },
                    { 2, "Giza", 3, 2, "sara.png", "Dr. Sara", 12000m }
                });
        }

        /// <inheritdoc />

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // احذف الأول الـ dependent data
            migrationBuilder.Sql("DELETE FROM CrsResults");
            migrationBuilder.Sql("DELETE FROM Instructors");
            migrationBuilder.Sql("DELETE FROM Trainees");
            migrationBuilder.Sql("DELETE FROM Courses");
            migrationBuilder.Sql("DELETE FROM Departments");

            // ولو كنت ضايف عمود Manager في Departments، لازم يتشال برضه
            migrationBuilder.DropColumn(
                name: "Manager",
                table: "Departments");
        }


    }
}
