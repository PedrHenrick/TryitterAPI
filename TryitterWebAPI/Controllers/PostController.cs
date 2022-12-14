using Microsoft.AspNetCore.Mvc;
using TryitterWebAPI.Models;
using TryitterWebAPI.Repository;

namespace TryitterWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostRepository _repository;

        public PostController(PostRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest();
            }
            _repository.CreatePost(post);
            return CreatedAtAction("Get", new { id = post.PostId }, post);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Post post)
        {
            if (post == null || post.PostId != id)
            {
                return BadRequest();
            }
            var postInDb = _repository.GetPostById(id);
            if (postInDb == null)
            {
                return NotFound();
            }
            _repository.UpdatePost(post, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var postInDb = _repository.GetPostById(id);
            if (postInDb == null)
            {
                return NotFound();
            }
            _repository.DeletePost(id);
            return NoContent();
        }
    }
}
