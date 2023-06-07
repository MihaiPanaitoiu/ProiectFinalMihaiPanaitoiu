using Data.Models;
using ProiectFinalMihaiPanaitoiu.DTOS;

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
                StudentMarks = course.Marks.Select(m => new CourseToGetStudentMarkDto {
                    MarkId = m.Id,
                    MarkValue = m.Value,
                    GivenDate = m.GivenDate,
                    StudentId = m.StudentId,
                    StudentName = course.Students.Where(s => s.Id == m.StudentId).Select(s=> s.FirstName + " " + s.LastName).FirstOrDefault() ?? ""
                }).ToList()
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
