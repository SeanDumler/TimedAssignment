using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.Likes;

namespace TimedAssignment.Services.LikeServices
{
    public interface ILikeService
    {
        Task<bool> AddLike(LikeCreate model);
        Task<LikeDetail> GetLikeById(int Id);
        Task<List<LikeListItem>> GetLikes();
        Task<bool> UpdateLike(LikeEdit model);
        Task<bool> DeleteLike(int id);
    }


}