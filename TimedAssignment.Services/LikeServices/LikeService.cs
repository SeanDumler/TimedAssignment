using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Data;
using TimedAssignment.Models.Likes;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TimedAssignment.Services.LikeServices
{
    public class LikeService : ILikeService
    {
        private readonly ApplicationDbContext _context;
        

        public LikeService(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task<bool> AddLike(LikeCreate model)
        {
           var entity = new Like
           {
             
             OwnerId = model.OwnerId,
             PostId = model.PostId
            
           };
        await _context.Likes.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteLike(int id)
        {
            var like = await _context.Likes.FirstOrDefaultAsync(l => l.Id == id);
            if(like is null)
            return false;
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<LikeDetail> GetLikeById(int id)
        {
            var like = await _context.Likes.FirstOrDefaultAsync(l => l.Id == id);
            if(like is null)
               return new LikeDetail();
        
            return new LikeDetail
            {
                Id = like.Id,
                OwnerId = like.OwnerId,
                PostId = like.PostId,
                Post = like.Post,
            };

        }

        public async Task<List<LikeListItem>> GetLikes()
        {
            return await _context.Likes.Include(like => like.Post).Select(like => new LikeListItem
            {
                
                OwnerId = like.OwnerId,
                PostId = like.PostId,
                
            }).ToListAsync();
        }

        public async Task<bool> UpdateLike(LikeEdit model)
        {
           var like = await _context.Likes.Include(like => like.Post).SingleOrDefaultAsync(l => l.Id == model.Id);
           if(like is null)
            return false;
            
            like.Id = model.Id;
            like.OwnerId = model.OwnerId;
            like.PostId = model.PostId;
            
            
            await _context.SaveChangesAsync();
            return true;
        }
    }
}