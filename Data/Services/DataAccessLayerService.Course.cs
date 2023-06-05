using Data.Models;
using Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public Course CreateCourse(Course course)
        {
            if (ctx.Courses.Any(x => x.Id == course.Id))
            {
                throw new Exception("Error creating the course");
            }
            ctx.Add(course);
            ctx.SaveChanges();
            return course;
        }

        public IEnumerable<Course> GetCourses() => ctx.Courses.Include(s => s.Students).Include(m => m.Marks);
    }
}
