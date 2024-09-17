namespace DotNet8.JsonCRUD.WebApi.Features.Blog;

public class DA_Blog
{
    private readonly JsonFileHelper _jsonFile;

    public DA_Blog(JsonFileHelper jsonFile)
    {
        _jsonFile = jsonFile;
    }

    #region GetBlog

    public async Task<Result<BlogListResponseModel>> GetBlogAsync()
    {
        Result<BlogListResponseModel> response;
        try
        {
            var lst = await _jsonFile.GetJsonStringAsync<BlogModel>();
            var model = new BlogListResponseModel(lst);
            response = Result<BlogListResponseModel>.Success(model);
        }
        catch (Exception ex)
        {
            response = Result<BlogListResponseModel>.Failure(ex);
        }
        return response;
    }

    #endregion

    #region GetBlogById

    public async Task<Result<BlogResponseModel>> GetBlogByIdAsync(string BlogId)
    {
        Result<BlogResponseModel> response;
        try
        {
            var lstBlog = await _jsonFile.GetJsonStringAsync<BlogModel>();
            var blog = lstBlog.FirstOrDefault(x => x.BlogId == BlogId);
            if (blog is null)
            {
                response = Result<BlogResponseModel>.NotFound();
                goto result;
            }
            var blogResponse = new BlogResponseModel(blog);
            response = Result<BlogResponseModel>.Success(blogResponse);
        }
        catch (Exception ex)
        {
            response = Result<BlogResponseModel>.Failure(ex);
        }
    result:
        return response;
    }

    #endregion

    #region CreateBlog

    public async Task<Result<BlogResponseModel>> CreateBlogAsync(BlogRequestModel requestModel)
    {
        Result<BlogResponseModel> response;
        try
        {
            var blog = requestModel.ToModel();
            var lst = await _jsonFile.GetJsonStringAsync<BlogModel>();
            lst.Add(blog);
            await _jsonFile.WriteJson(lst);
            response = Result<BlogResponseModel>.SaveSuccess();
        }
        catch (Exception ex)
        {
            response = Result<BlogResponseModel>.Failure(ex);
        }
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
        try
        {
            var lstBlog = await _jsonFile.GetJsonStringAsync<BlogModel>();
            var item = lstBlog.FirstOrDefault(x => x.BlogId == blogId);
            if (item is null)
            {
                response = Result<BlogResponseModel>.NotFound();
                goto result;
            }
            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;
            await _jsonFile.WriteJson(lstBlog);
            response = Result<BlogResponseModel>.UpdateSuccess();
        }
        catch (Exception ex)
        {
            response = Result<BlogResponseModel>.Failure(ex);
        }
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
        try
        {
            var lstBlog = await _jsonFile.GetJsonStringAsync<BlogModel>();
            var item = lstBlog.FirstOrDefault(x => x.BlogId == blogId);
            if (item is null)
            {
                response = Result<BlogResponseModel>.NotFound();
                goto result;
            }
            if (!requestModel.BlogTitle.IsNullOrEmpty())
            {
                item.BlogTitle = requestModel.BlogTitle;
            }
            if (!requestModel.BlogAuthor.IsNullOrEmpty())
            {
                item.BlogAuthor = requestModel.BlogAuthor;
            }
            if (!requestModel.BlogContent.IsNullOrEmpty())
            {
                item.BlogContent = requestModel.BlogContent;
            }
            await _jsonFile.WriteJson(lstBlog);
            response = Result<BlogResponseModel>.UpdateSuccess();
        }
        catch (Exception ex)
        {
            response = Result<BlogResponseModel>.Failure(ex);
        }
    result:
        return response;
    }

    #endregion

    #region DeleteBlog

    public async Task<Result<BlogResponseModel>> DeleteBlogAsync(string blogId)
    {
        Result<BlogResponseModel> response;
        try
        {
            var lst = await _jsonFile.GetJsonStringAsync<BlogModel>();
            if (!lst.Any(x => x.BlogId == blogId))
            {
                response = Result<BlogResponseModel>.NotFound();
                goto result;
            }
            var lstBlog = lst.Where(x => x.BlogId != blogId).ToList();
            await _jsonFile.WriteJson(lstBlog);
            response = Result<BlogResponseModel>.DeleteSuccess();
        }
        catch (Exception ex)
        {
            response = Result<BlogResponseModel>.Failure(ex);
        }
    result:
        return response;
    }

    #endregion
}
