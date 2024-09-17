namespace DotNet8.JsonCRUD.WebApi.Features.Blog
{
    public class BL_BLog
    {
        private readonly DA_Blog _da_blog;

        public BL_BLog(DA_Blog da_blog)
        {
            _da_blog = da_blog;
        }

        #region GetBlog

        public async Task<Result<BlogListResponseModel>> GetBlogAsync()
        {
            return await _da_blog.GetBlogAsync();
        }

        #endregion

        #region GetBlogById

        public async Task<Result<BlogResponseModel>> GetBlogByIdAsync(string BlogId)
        {
            Result<BlogResponseModel> response;
            if (BlogId.IsNullOrEmpty())
            {
                response = Result<BlogResponseModel>.Failure();
                goto result;
            }
            response = await _da_blog.GetBlogByIdAsync(BlogId);
        result:
            return response;
        }

        #endregion

        #region CreateBlog

        public async Task<Result<BlogResponseModel>> CreateBlogAsync(BlogRequestModel requestModel)
        {
            Result<BlogResponseModel> response;
            var result = requestModel.IsValid();
            if (result.IsError)
            {
                response = Result<BlogResponseModel>.Failure(result.message);
                goto result;
            }
            response = await _da_blog.CreateBlogAsync(requestModel);
        result:
            return response;
        }

        #endregion

        #region PutBlog

        public async Task<Result<BlogResponseModel>> PutBlogAsync(
        string blogId,
        BlogRequestModel requestModel
        )
        {
            Result<BlogResponseModel> response;
            if (blogId.IsNullOrEmpty())
            {
                response = Result<BlogResponseModel>.Failure();
                goto result;
            }
            var result = requestModel.IsValid();
            if (result.IsError)
            {
                response = Result<BlogResponseModel>.Failure(result.message);
                goto result;
            }
            response = await _da_blog.PutBlogAsync(blogId, requestModel);
        result:
            return response;
        }

        #endregion

        #region PatchBlog

        public async Task<Result<BlogResponseModel>> PatchBlogAsync(
      string blogId,
      BlogRequestModel requestModel
      )
        {
            Result<BlogResponseModel> response;
            if (blogId.IsNullOrEmpty())
            {
                response = Result<BlogResponseModel>.Failure();
                goto result;
            }
            response = await _da_blog.PatchBlogAsync(blogId, requestModel);
        result:
            return response;
        }

        #endregion

        #region DeleteBlog

        public async Task<Result<BlogResponseModel>> DeleteBlogAsync(string blogId)
        {
            Result<BlogResponseModel> response;
            if (blogId.IsNullOrEmpty())
            {
                response = Result<BlogResponseModel>.Failure();
                goto result;
            }
            response = await _da_blog.DeleteBlogAsync(blogId);
        result:
            return response;
        }

        #endregion
    }
}
