using DotNet8.JsonCRUD.WebApi.Models;

namespace DotNet8.JsonCRUD.WebApi.Features.Blog
{
    public class BL_BLog
    {
        private readonly DA_Blog _da_blog;

        public BL_BLog(DA_Blog da_blog)
        {
            _da_blog = da_blog;
        }

        public async Task<Result<BlogListResponseModel>> GetBlogAsync()
        {
            return await _da_blog.GetBlogAsync();
        }
    }
}
