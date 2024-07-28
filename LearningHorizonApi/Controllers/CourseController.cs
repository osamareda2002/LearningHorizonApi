using LearningHorizonApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningHorizonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {   
            var courses = await _context.Courses.ToListAsync();
            return Ok(courses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddCourseModel model)
        {
            var newCourse = new Course
            {
                courseCreator = model.courseCreator,
                coursePrice = model.coursePrice,
                courseTittle = model.courseTittle,
            };

            await _context.Courses.AddAsync(newCourse);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Course created successfully!" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id,[FromBody] AddCourseModel model)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course==null)
                return NotFound(new { message = "Course not found." });
            if (model.courseCreator!=null) course.courseCreator=model.courseCreator;
            if (model.courseTittle!=null) course.courseTittle=model.courseTittle;
            if (model.coursePrice!=null) course.coursePrice=model.coursePrice;

            return Ok(new { message = "Course updated successfully!" });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return NotFound(new { message = "Course not found." });
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Course has deleted successfully!" });

        }
    }
}
