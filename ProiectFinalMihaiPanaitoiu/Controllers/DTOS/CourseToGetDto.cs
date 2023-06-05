using Data.Models;

namespace ProiectFinalMihaiPanaitoiu.Controllers.DTOS
{
    public class CourseToGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CourseToGetStudentMarkDto> StudentMarks { get; set; } = new();
    }
    public class CourseToGetStudentMarkDto
    {
        public int MarkId { get; set; }
        public int MarkValue { get; set; }
        public DateTime? GivenDate { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }
}
