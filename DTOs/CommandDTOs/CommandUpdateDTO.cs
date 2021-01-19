using System.ComponentModel.DataAnnotations;

namespace Commander.DTOs.CommandDTOs
{
    public class CommandUpdateDTO
    {
        // [Required(ErrorMessage = "How To Field is Required.")]
        public string HowTo { get; set; }
        // [Required(ErrorMessage = "Line Field is Required.")]
        public string Line { get; set; }
        // [Required(ErrorMessage = "Platform Field is Required.")]
        // [StringLength(60, ErrorMessage = "Platform Field cannot be larger than 60 characters.")]
        // public string Platform { get; set; }
    }
}