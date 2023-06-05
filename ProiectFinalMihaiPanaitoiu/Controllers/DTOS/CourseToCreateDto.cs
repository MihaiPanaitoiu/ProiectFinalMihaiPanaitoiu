using System.ComponentModel.DataAnnotations;

namespace ProiectFinalMihaiPanaitoiu.Controllers.DTOS
{
    public class CourseToCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = " Course name cannot be empty")]
        public string Name { get; set; }
    }
}
