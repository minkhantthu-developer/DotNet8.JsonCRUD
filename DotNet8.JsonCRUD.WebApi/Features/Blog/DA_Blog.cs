using DotNet8.JsonCRUD.WebApi.Helpers;
using DotNet8.JsonCRUD.WebApi.Models;

namespace DotNet8.JsonCRUD.WebApi.Features.Blog;

public class DA_Blog
{
    private readonly JsonFileHelper _jsonFile;

    public DA_Blog(JsonFileHelper jsonFile)
    {
        _jsonFile = jsonFile;
    }

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

}
