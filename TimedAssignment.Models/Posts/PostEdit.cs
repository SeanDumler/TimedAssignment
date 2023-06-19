using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Posts
{
    public class PostEdit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(300, ErrorMessage = "Text cannot exceed 300 characters.")]
        public string Text { get; set; } = null!;
    }
}