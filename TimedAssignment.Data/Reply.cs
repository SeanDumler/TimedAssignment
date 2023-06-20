using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Data
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        public int CommentId { get; set; }
        
        [MaxLength(300)]
        [ForeignKey(nameof(CommentId))]
        public virtual Comment Comment { get; set; } = null!;

        public string OwnerId { get; set; } = null!;

        [ForeignKey(nameof(OwnerId))]
        public User User { get; set; } = null!;
        [Required]
        [MaxLength(300)]
        public string Text { get; set; } = null!;
    }
}