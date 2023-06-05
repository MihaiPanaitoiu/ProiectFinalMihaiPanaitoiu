﻿using System.ComponentModel.DataAnnotations;

namespace ProiectFinalMihaiPanaitoiu.Controllers.DTOS
{
    public class AddressToUpdateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = " City cannot be empty")]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = " Street cannot be empty")]
        public string Street { get; set; }

        [Required(ErrorMessage = " Number cannot be empty"), Range(1, int.MaxValue)]
        public int Number { get; set; }
    }
}
