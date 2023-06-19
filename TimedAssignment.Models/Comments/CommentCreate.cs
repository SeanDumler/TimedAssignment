using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace TimedAssignment.Models.Comments
{
    public class CommentCreate
    {
        [Required]
        [MaxLength(300, ErrorMessage = "Text cannot exceed 300 characters.")]
        public string Text { get; set; } = null!;
    }
}