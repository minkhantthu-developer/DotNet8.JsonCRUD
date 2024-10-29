namespace DotNet8.JsonCRUD.WebApi.Features.Blog;

[Route("api/blog")]
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

    [HttpGet("City")]
    public async Task<IActionResult> GetCities()
    {
        var jsonStr = System.IO.File.ReadAllText("Data/City.json");
        var lst=jsonStr.ToObject<CityModel>();
        return Content(lst);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogById(string id)
    {
        var response = await _bl_blog.GetBlogByIdAsync(id);
        return Content(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostBlog(BlogRequestModel requestModel)
    {
        var response = await _bl_blog.CreateBlogAsync(requestModel);
        return Content(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBlog(string id, BlogRequestModel requestModel)
    {
        var response = await _bl_blog.PutBlogAsync(id, requestModel);
        return Content(response);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchBlog(string id, BlogRequestModel requestModel)
    {
        var response = await _bl_blog.PatchBlogAsync(id, requestModel);
        return Content(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(string id)
    {
        var response = await _bl_blog.DeleteBlogAsync(id);
        return Content(response);
    }
}
