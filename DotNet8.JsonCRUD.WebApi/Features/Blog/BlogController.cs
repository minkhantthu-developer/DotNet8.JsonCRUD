using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.JsonCRUD.WebApi.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        private readonly BL_BLog _bl_blog;

        public BlogController(BL_BLog bl_Blog)
        {
            _bl_blog = bl_Blog;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            var model = await _bl_blog.GetBlogAsync();
            return Content(model);
        }
    }
}
