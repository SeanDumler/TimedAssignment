using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Replies
{
    public class ReplyEdit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "Text cannot exceed 300 characters.")]
        public string Text { get; set; } = null!;
    }
}