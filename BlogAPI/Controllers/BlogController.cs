using AutoMapper;
using BlogData.Repository;
using BlogData.Repository.IRepository;
using BlogModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("/api/Blog")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogsRepository blogRepository;

        public BlogController(IBlogsRepository _blogRepository)
        {
            blogRepository = _blogRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Blog> blog = blogRepository.GetAll().ToList();
            return Ok(blog);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            var blog = blogRepository.Get(u => u.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] Blog blog)
        {
            blogRepository.Add(blog);
            blogRepository.Save();
            return CreatedAtAction(nameof(GetById), new { id = blog.Id }, blog);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Blog blog)
        {
            if (blog == null || id != blog.Id)
            {
                return NotFound();
            }
            blogRepository.Update(blog);
            blogRepository.Save();
            return Ok(blog);
        }

        [HttpDelete("{id}")]
       [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            Blog blog = blogRepository.Get(u => u.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            blogRepository.Remove(blog);
            blogRepository.Save();

            return NoContent();
        }
    }
}

