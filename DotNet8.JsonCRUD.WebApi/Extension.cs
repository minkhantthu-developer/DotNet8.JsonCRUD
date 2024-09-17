namespace DotNet8.JsonCRUD.WebApi
{
    public static class Extension
    {
        public static BlogModel ToModel(this BlogRequestModel model)
        {
            return new BlogModel
            {
                BlogId = DevCode.GetUlid(),
                BlogTitle = model.BlogTitle,
                BlogAuthor = model.BlogAuthor,
                BlogContent = model.BlogContent,
            };
        }
    }
}
