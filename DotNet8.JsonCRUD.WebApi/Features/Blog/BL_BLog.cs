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

        public async Task<Result<BlogResponseModel>> CreateBlogAsync(BlogRequestModel requestModel)
        {
            Result<BlogResponseModel> response;
            var result = requestModel.IsValid();
            if(result.IsError)
            {
                response=Result<BlogResponseModel>.Failure(result.message);
                goto result;
            }
            response= await _da_blog.CreateBlogAsync(requestModel);
        result:
            return response;
        }
    }
}
