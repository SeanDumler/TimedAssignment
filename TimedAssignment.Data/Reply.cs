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
        [MaxLength(512)]
        [ForeignKey(nameof(UserId))]
        public virtual Reply UserId { get; set; }
        public Guid AuthorId { get; set; }
        [Required]
        [MaxLength(512)]
        public string Text { get; set; }
    }
}