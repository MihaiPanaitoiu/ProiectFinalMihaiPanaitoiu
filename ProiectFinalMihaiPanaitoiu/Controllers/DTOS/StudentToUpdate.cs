using System.ComponentModel.DataAnnotations;

namespace ProiectFinalMihaiPanaitoiu.Controllers.DTOS
{
    public class StudentToUpdateDto
    {
        [Required(ErrorMessage = " Id cannot be empty or 0"), Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " First Name cannot be empty")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " First Name cannot be empty")]
        public string LastName { get; set; }

        [Range(12, 90)]
        public int Age { get; set; }
    }
}
