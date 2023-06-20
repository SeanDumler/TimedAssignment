using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Data;

namespace TimedAssignment.Models.Likes
{
    public class LikeEdit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public int PostId { get; set; }
        
    }
}