using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.Comments;

namespace TimedAssignment.Services.CommentServices
{
    public interface ICommentService
    {
        Task<bool> AddComment(CommentCreate model);
        Task<bool> UpdateComment(CommentEdit model);
        Task<bool> DeleteComment(int id);
        Task<CommentDetail> GetCommentByPostId(int id);
        Task<CommentDetail> GetCommentById(int id);
    }
}