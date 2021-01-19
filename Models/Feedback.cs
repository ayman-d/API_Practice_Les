using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Message field is required.")]
        [StringLength(200, ErrorMessage = "Feedback cannot be longer than 200 characters.")]
        public string Message { get; set; }
        public DateTime? CreateDate { get; set; }
        public int CommandId { get; set; }
        public virtual Command Command { get; set; }

        public Feedback()
        {
            this.CreateDate = DateTime.UtcNow;
        }
    }
}