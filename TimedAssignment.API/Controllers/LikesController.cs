using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.Likes;
using TimedAssignment.Services.LikeServices;

namespace TimedAssignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _likeService.GetLikes());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id) 
        {
            var like = await _likeService.GetLikeById(id);
            if(like is null)
              return NotFound();
            else
                return Ok (like);

        }
        [HttpPost]
        public async Task<IActionResult> post(LikeCreate model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(await _likeService.AddLike(model))
                return Ok("like Created");
            else 
            return StatusCode (500, "Internal Server Error");   
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _likeService.DeleteLike(id))
                return Ok("Like deleted!");
            else 
                return StatusCode(500, "Internal Server Error");
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(LikeEdit model, int id)
        {
            if(id != model.Id)
            {
                return BadRequest("Invalid Id.");
            }
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }   
            if(await _likeService.UpdateLike(model))
                 return Ok ("Like Updated");

            else
                return StatusCode(500, "Internal Server Error");    

        }
    }
}