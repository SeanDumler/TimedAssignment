using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.Replies;
using TimedAssignment.Data;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace TimedAssignment.Services.ReplyServices
{
    public class ReplyService : IReplyService
    {
        private readonly string _userId;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReplyService(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            var userClaims = httpContext.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims!.FindFirst("uId")!.Value;
            _userId = value;
            if (_userId is null)
            {
                throw new Exception("User is not properly signed in");
            }
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddReply(ReplyCreate model)
        {
            var reply = _mapper.Map<Reply>(model);
            reply.OwnerId = _userId;
            await _context.Replies.AddAsync(reply);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteReply(int id)
        {
            var reply = await _context.Replies.FindAsync(id);
            if (reply?.OwnerId != _userId)
                return false;

            _context.Replies.Remove(reply);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReplyDetail> GetReplyById(int id)
        {
            var reply = await _context.Replies.
                    FirstOrDefaultAsync(x=>x.Id == id && x.OwnerId == _userId);
            if (reply is null)
            return new ReplyDetail();
            var replyDetail = _mapper.Map<ReplyDetail>(reply);
            replyDetail.UserId = _userId;
            return replyDetail;
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
