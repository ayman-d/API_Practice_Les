using System;
using System.ComponentModel.DataAnnotations;
using Commander.Models;

namespace Commander.DTOs.FeedbackDTOs
{
    public class FeedbackReadDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime? CreateDate { get; set; }
        public int CommandId { get; set; }
    }
}