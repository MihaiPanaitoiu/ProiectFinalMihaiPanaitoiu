using System.ComponentModel.DataAnnotations;

namespace ProiectFinalMihaiPanaitoiu.DTOS
{
    public class StudentToCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = " First Name cannot be empty")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " Last Name cannot be empty")]
        public string LastName { get; set; }

        [Range(12, 90), Required(ErrorMessage = " Age is required")]
        public int Age { get; set; }
    }
}
