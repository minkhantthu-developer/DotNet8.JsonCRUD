namespace DotNet8.JsonCRUD.WebApi.Models;

public class BlogModel
{
    public int BlogId { get; set; }

    public string? BlogTitle { get; set; }

    public string? BlogAuthor { get; set; }

    public string? BlogContent { get; set; }

    public Result<BlogResponseModel> IsValid()
    {
        Result<BlogResponseModel> response;
        if (BlogTitle.IsNullOrEmpty())
        {
            response = Result<BlogResponseModel>.Failure("BlogTitle cannot be Empty");
            goto result;
        }
        if (BlogAuthor.IsNullOrEmpty())
        {
            response = Result<BlogResponseModel>.Failure("BlogAuthor cannot be Empty");
            goto result;
        }
        if (BlogContent.IsNullOrEmpty())
        {
            response = Result<BlogResponseModel>.Failure("BlogContent cannot be Empty");
            goto result;
        }
        response = Result<BlogResponseModel>.Success();
        result:
        return response;
    }
}
