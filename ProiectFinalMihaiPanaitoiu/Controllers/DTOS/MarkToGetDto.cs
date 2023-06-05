using Data.Models;

namespace ProiectFinalMihaiPanaitoiu.Controllers.DTOS
{
    public class MarkToGetDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime GivenDate { get; set; }
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
