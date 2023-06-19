using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Data;

namespace TimedAssignment.Models.Likes
{
    public class LikeCreate
    {
        
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public int PostId { get; set; }
       
    }
}