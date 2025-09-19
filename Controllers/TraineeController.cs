using Day2Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day2Task.Controllers
{
    public class TraineeController : Controller
    {
            private readonly ITIContext _context;

            public TraineeController(ITIContext context)
            {
                _context = context;
            }

            // 1- showResult(int id , int crsId)
            public IActionResult ShowResult(int id, int crsId)
            {
                var result = _context.CrsResults
                    .FirstOrDefault(r => r.TraineeId == id && r.CourseId == crsId);

                return View(result);
            }

            // 2- showCourseResult(int crsId)
            public IActionResult ShowCourseResult(int crsId)
            {
                var results = _context.CrsResults
                    .Where(r => r.CourseId == crsId)
                    .ToList();

                return View(results);
            }

           
        public IActionResult ShowTraineeResult(int traineeId)
        {
            var results = _context.CrsResults
                .Where(r => r.TraineeId == traineeId)
                .Include(r => r.Course) 
                .ToList();

            return View(results);
        }
        public IActionResult Index()
        {
            var trainees = _context.Trainees
                .Include(t => t.Department) 
                .ToList();

            return View(trainees);
        }

    }

}

