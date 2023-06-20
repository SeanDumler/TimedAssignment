using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Replies
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(300, ErrorMessage = "Text cannot exceed 300 characters.")]
        public string Text { get; set; }
        
        [Required]
        public int CommentId { get; set; }
    }
}