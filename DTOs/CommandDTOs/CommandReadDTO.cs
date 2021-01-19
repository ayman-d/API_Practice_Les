using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.DTOs.CommandDTOs
{
    public class CommandReadDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "How To Field is Required.")]
        public string HowTo { get; set; }
        [Required(ErrorMessage = "Line Field is Required.")]
        public string Line { get; set; }

        // removing the Platform property to test the logic of DTO making
        [Required(ErrorMessage = "Platform Field is Required.")]
        [StringLength(60, ErrorMessage = "Platform Field cannot be larger than 60 characters.")]
        public string Platform { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}