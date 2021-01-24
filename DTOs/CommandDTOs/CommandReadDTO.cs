using System;
using System.Collections.Generic;
using Commander.DTOs.FeedbackDTOs;

namespace Commander.DTOs.CommandDTOs
{
    public class CommandReadDTO
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string Platform { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModified { get; set; }
        public virtual ICollection<FeedbackReadDTO> Feedbacks { get; set; }
    }
}