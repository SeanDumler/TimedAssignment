using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.Posts;

namespace TimedAssignment.Services.PostServices
{
    public interface IPostService
    {
        Task<bool> AddPost(PostCreate model);
        Task<bool> UpdatePost(PostEdit model);
        Task<bool> DeletePost(int id);
        Task<PostDetail> GetPostById(int id);
        Task<List<PostListItem>> GetPosts();
    }
}