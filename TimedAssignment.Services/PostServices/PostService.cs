using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data;
using TimedAssignment.Models.Posts;

namespace TimedAssignment.Services.PostServices
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PostService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddPost(PostCreate model)
        {
            var entity = _mapper.Map<Post>(model);

            await _context.Posts.AddAsync(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync();
            if(post is null) return false;

            _context.Posts.Remove(post);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PostDetail> GetPostById(int id)
        {
            var post = await _context.Posts.Include(p=>p.UserId).SingleOrDefaultAsync(x=>x.Id==id);

            if(post is null) return new PostDetail{};

            return _mapper.Map<PostDetail>(post);
        }

        public async Task<List<PostListItem>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();

            var postsListItems = _mapper.Map<List<PostListItem>>(posts);

            return postsListItems;
        }

        public async Task<bool> UpdatePost(PostEdit model)
        {
            var post = await _context.Posts.Include(p=>p.UserId).SingleOrDefaultAsync(x=>x.Id==model.Id);

            if(post is null) return false;

            post.Title = model.Title;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}