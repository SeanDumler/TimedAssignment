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
        [MaxLength(300)]
        [ForeignKey(nameof(CommentId))]
        public virtual Reply CommentId { get; set; }
        public Guid AuthorId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Text { get; set; }
    }
}