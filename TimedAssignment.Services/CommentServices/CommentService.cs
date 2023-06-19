using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data;
using TimedAssignment.Models.Comments;
using TimedAssignment.Models.Posts;

namespace TimedAssignment.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _userID;

        public CommentService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context, IMapper mapper)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims!.FindFirst("uID")!.Value;

            _userID = value;

            if (_userID is null)
                throw new Exception("Attempted to build NoteService with User ID claim.");

            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddComment(CommentCreate model)
        {
            var comment = _mapper.Map<Comment>(model);
            comment.UserId = _userID;

            await _context.Comments.AddAsync(comment);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment is null) return false;

            _context.Comments.Remove(comment);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<CommentDetail> GetCommentByPostId(int id)
        {
            var comment = await _context.Comments.Where(n => n.UserId == _userID).ToListAsync();

            if (comment is null) return new CommentDetail { };

            return _mapper.Map<CommentDetail>(comment);
        }

        public async Task<CommentDetail> GetCommentById(int id)
        {
            var comment = await _context.Comments.Include(c => c.Text).SingleOrDefaultAsync(x => x.ID == id);

            if (comment is null) return new CommentDetail { };

            return _mapper.Map<CommentDetail>(comment);
        }

        public async Task<bool> UpdateComment(CommentEdit model)
        {
            var comment = await _context.Comments.Include(c => c.Text).FirstOrDefaultAsync(x => x.ID == model.ID);

            if (comment is null) return false;

            comment.Text = model.Text;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}