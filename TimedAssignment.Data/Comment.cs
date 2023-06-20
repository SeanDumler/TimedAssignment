using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Data
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(300, ErrorMessage = "Text cannot exceed 300 characters.")]
        public string Text { get; set; } = null!;

        // public List<Post> Posts { get; set; } = new List<Post>();

        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual Reply User { get; set; } = null!;
    }
}