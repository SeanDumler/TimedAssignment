using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.Replies;
using TimedAssignment.Services.ReplyServices;

namespace TimedAssignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepliesController : ControllerBase
    {
        private readonly IReplyService _replyService;

        public RepliesController(IReplyService replyService)
        {
            _replyService = replyService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ReplyCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _replyService.AddReply(model))
            {
                return Ok("Success!");
            }
            else
                return StatusCode(500, "Internal Server Error.");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id <= 0)
                return BadRequest("invalid id");
            var reply = await _replyService.GetReplyById(id);
            if (reply is null)
                return NotFound();
            
            return Ok(reply);
        }

    }
}

// POST(Create) a Reply to a Reply using a Foreign Key relationship (required)
// GET Replies By Reply Id (required)
// GET Reply By Author Id
// PUT(Update) a Reply
// DELETE a Reply