using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.Comments;
using TimedAssignment.Models.Likes;

namespace TimedAssignment.Models.Posts
{
    public class PostDetail
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Text { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public string User { get; set; } = null!;

        public int CommentId { get; set; }
        
        public virtual List<CommentListItem> Comments { get; set; } = new List<CommentListItem>();

        public int LikeId { get; set; }

        public virtual List<LikeListItem> Likes { get; set; } = new List<LikeListItem>();
    }
}