using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.Comments;
using TimedAssignment.Services.CommentServices;

namespace TimedAssignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _commentService.GetCommentById(id));
        }

        [HttpGet("{idPost:int}")]
        public async Task<IActionResult> GetByPost(int idPost)
        {
            return Ok(await _commentService.GetCommentByPostId(idPost));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CommentCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _commentService.AddComment(model))
            {
                return Ok("Success!");
            }
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpPut]
        public async Task<IActionResult> Put(CommentEdit model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _commentService.UpdateComment(model))
            {
                return Ok("Success!");
            }
            else
                return StatusCode(500, "Internal Server Error");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id.");
            }

            if (await _commentService.DeleteComment(id))
            {
                return Ok("Success!");
            }
            else
                return StatusCode(500, "Internal Server Error");
        }
    }
}