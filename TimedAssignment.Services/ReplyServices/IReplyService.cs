using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.Replies;

namespace TimedAssignment.Services.ReplyServices
{
    public interface IReplyService
    {
        Task<bool> AddReply(ReplyCreate model);
        Task<bool> UpdateReply(ReplyEdit model);
        Task<bool> DeleteReply(int id);
        Task<ReplyDetail> GetReplyByCommentId(int id);
        Task<ReplyDetail> GetReplyById(int id);
    }
}