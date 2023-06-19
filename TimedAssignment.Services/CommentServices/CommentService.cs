using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data;
using TimedAssignment.Models.Comments;

namespace TimedAssignment.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddComment(CommentCreate model)
        {
            var entity = _mapper.Map<Comment>(model);

            await _context.Comments.AddAsync(entity);

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
            throw new NotImplementedException();
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