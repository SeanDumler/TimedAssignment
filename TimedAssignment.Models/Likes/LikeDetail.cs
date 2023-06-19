using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Data;

namespace TimedAssignment.Models.Likes
{
    public class LikeDetail
    {

        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; } = new Post();
    }
}