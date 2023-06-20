using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        public string Title { get; set; } = null!;

        [MaxLength(300, ErrorMessage = "Text cannot exceed 300 characters.")]
        public string Text { get; set; } = null!;

        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual User Owner { get; set; } = null!;

        public int CommentId { get; set; }
        
        [ForeignKey(nameof(CommentId))]
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();

        public int LikeId { get; set; }

        [ForeignKey(nameof(LikeId))]
        public virtual List<Like> Likes { get; set; } = new List<Like>();
        
    }
}