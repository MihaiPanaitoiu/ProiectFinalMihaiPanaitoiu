using System.ComponentModel.DataAnnotations;

namespace ProiectFinalMihaiPanaitoiu.DTOS
{
    public class MarkToCreateDto
    {
        [Range(1, 10)]
        public int Value { get; set; }
        [Range(1, int.MaxValue)]
        public int StudentId { get; set; }
        [Range(1, int.MaxValue)]
        public int CourseId { get; set; }
    }
}
