using System.ComponentModel.DataAnnotations;

namespace ProiectFinalMihaiPanaitoiu.DTOS
{
    public class CourseToCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = " Course name cannot be empty")]
        public string Name { get; set; }
    }
}
