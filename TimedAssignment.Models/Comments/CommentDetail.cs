using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.Posts;

namespace TimedAssignment.Models.Comments
{
    public class CommentDetail
    {
        public int ID { get; set; }

        public string Text { get; set; } = null!;

        public string UserId { get; set; } = null!;
    }
}