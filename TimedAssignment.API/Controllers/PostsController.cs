using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.Posts;
using TimedAssignment.Services.PostServices;

namespace TimedAssignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _postService.AddPost(model))
            {
                return Ok("Success!");
            }
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
                return BadRequest("invalid id");
            var reply = await _postService.GetPostById(id);
            if (reply is null)
                return NotFound();

            return Ok(reply);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var replies = await _postService.GetPosts();

            return Ok(replies);
        }


    }
}