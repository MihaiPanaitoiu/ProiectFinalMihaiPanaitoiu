using Data.Models;
using ProiectFinalMihaiPanaitoiu.Controllers.DTOS;

namespace ProiectFinalMihaiPanaitoiu.Utils
{
    public static class MarkUtils
    {
        public static MarkToGetDto? ToDto(this Mark mark) =>
             mark is null ? null 
            : new MarkToGetDto
            {
                Id = mark.Id,
                Value = mark.Value,
                GivenDate = mark.GivenDate,
                CourseId = mark.CourseId,
                CourseName = mark.Course.Name,
            };

        public static IEnumerable<MarkToGetDto?> ToDto(this IEnumerable<Mark> marks) 
            => marks is null ? new List<MarkToGetDto>() : marks.Select(m => m.ToDto());

        public static Mark ToEntity(this MarkToCreateDto mark)
        {
            if (mark == null)
            {
                return null;
            }
            return new Mark
            {
                Value = mark.Value,
                CourseId = mark.CourseId,
                StudentId = mark.StudentId,
            };
        }
    }
}
