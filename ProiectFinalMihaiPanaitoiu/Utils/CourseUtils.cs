using Data.Models;
using ProiectFinalMihaiPanaitoiu.Controllers.DTOS;

namespace ProiectFinalMihaiPanaitoiu.Utils
{
    public static class CourseUtils
    {
        public static CourseToGetDto ToDto(this Course course)
        {
            if (course == null)
            {
                return null;
            }

            return new CourseToGetDto
            {
                Id = course.Id,
                Name = course.Name,
            };
        }

        public static Course ToEntity(this CourseToCreateDto course)
        {
            if (course == null)
            {
                return null;
            }
            return new Course
            {
                Name = course.Name,
            };
        }
    }
}
