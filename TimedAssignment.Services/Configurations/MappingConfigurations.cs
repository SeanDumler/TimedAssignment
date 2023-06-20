using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TimedAssignment.Data;
using TimedAssignment.Models.Comments;
using TimedAssignment.Models.Likes;
using TimedAssignment.Models.Posts;
using TimedAssignment.Models.Replies;
using TimedAssignment.Models.Users;

namespace TimedAssignment.Services.Configurations
{
    public class MappingConfigurations : Profile
    {
        public MappingConfigurations()
        {
            CreateMap<Post, PostCreate>().ReverseMap();
            CreateMap<Post, PostListItem>().ReverseMap();
            CreateMap<Post, PostDetail>().ReverseMap();
            CreateMap<Post, PostEdit>().ReverseMap();

            CreateMap<Comment, CommentCreate>().ReverseMap();
            CreateMap<Comment, CommentListItem>().ReverseMap();
            CreateMap<Comment, CommentDetail>().ReverseMap();
            CreateMap<Comment, CommentEdit>().ReverseMap();

            CreateMap<Like, LikeCreate>().ReverseMap();
            CreateMap<Like, LikeListItem>().ReverseMap();
            CreateMap<Like, LikeDetail>().ReverseMap();
            CreateMap<Like, LikeEdit>().ReverseMap();
            
            CreateMap<Reply, ReplyCreate>().ReverseMap();
            CreateMap<Reply, ReplyListItem>().ReverseMap();
            CreateMap<Reply, ReplyDetail>().ReverseMap();
            CreateMap<Reply, ReplyEdit>().ReverseMap();

            CreateMap<User,UserEntityVM>().ReverseMap();
        }
    }
}