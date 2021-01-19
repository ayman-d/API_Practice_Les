

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Command
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "How To Field is Required.")]
        public string HowTo { get; set; }
        [Required(ErrorMessage = "Line Field is Required.")]
        public string Line { get; set; }
        [Required(ErrorMessage = "Platform Field is Required.")]
        [StringLength(60, ErrorMessage = "Platform Field cannot be larger than 60 characters.")]
        public string Platform { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModified { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public Command()
        {
            this.CreateDate = DateTime.UtcNow;
        }
    }
}