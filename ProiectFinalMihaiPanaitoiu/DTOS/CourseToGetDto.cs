using Data.Models;

namespace ProiectFinalMihaiPanaitoiu.DTOS
{
    public class CourseToGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CourseToGetStudentMarkDto> StudentMarks { get; set; } = new();
    }
}
