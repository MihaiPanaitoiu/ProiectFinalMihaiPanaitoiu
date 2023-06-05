using Data.Models;

namespace ProiectFinalMihaiPanaitoiu.Controllers.DTOS
{
    public class CourseToGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Mark> Marks { get; set; } = new List<Mark>();
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
