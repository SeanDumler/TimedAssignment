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
        private readonly ApplicationDbContext _mapper;
        private readonly ApplicationDbContext _context;
        public ReplyService(ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> IReplyService.AddReply(ReplyCreate model)
        {
            var reply = _mapper.Map<Reply>(model);
            Reply.UserId = _userID;

            await _context.Reply.AddAsync(reply);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> IReplyService.DeleteReply(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ReplyDetail> IReplyService.GetReplyByReplyId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ReplyDetail> IReplyService.GetReplyById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IReplyService.UpdateReply(ReplyEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
