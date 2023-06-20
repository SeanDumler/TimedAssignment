using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.Replies;
using TimedAssignment.Data;
using AutoMapper;

namespace TimedAssignment.Services.ReplyServices
{
    public class ReplyService : IReplyService
    {
        private readonly string _userId;
        private readonly ApplicationDbContext _context;
        public ReplyService(ApplicationDbContext context)
        {
            _context = context;
            _userId = userId
        }

        public async Task<bool> AddReply(ReplyCreate model)
        {
            
        }

        public async Task<bool> DeleteReply(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ReplyDetail> GetReplyByReplyId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ReplyDetail> GetReplyById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateReply(ReplyEdit model)
        {
            throw new NotImplementedException();
        }

        public Task<ReplyDetail> GetReplyByCommentId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
