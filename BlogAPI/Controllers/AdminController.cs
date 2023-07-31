using BlogData.Repository.IRepository;
using BlogModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/Admin/[action]")]
    public class AdminController : ControllerBase
    {
        private readonly IBlogsRepository _blogRepository;
        public AdminController(IBlogsRepository blogRepository)
        {
            _blogRepository = blogRepository;

        }
        [HttpGet]
        public IActionResult GetAllNoActionTakenBlogs()
        {
            IEnumerable<Blog> blog = _blogRepository.GetAll(b => b.IsApproved == false && b.IsRejected == false);
            if (blog == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(blog);
            }

        }
        [HttpGet]
        public IActionResult ApprovedBlog(int id)
        {
            if (id == 0)
            {
                return BadRequest();

            }

            Blog blog = _blogRepository.Get(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();

            }
            blog.IsApproved = true;
            _blogRepository.Save();
            return Ok(blog);
        }
        [HttpGet]
        public IActionResult RejectBlog(int id)
        {
            if (id == 0)
            {
                return BadRequest();

            }

            Blog blog = _blogRepository.Get(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();

            }
            blog.IsRejected = true;
            _blogRepository.Save();
            return Ok(blog);
        }
    }
}
