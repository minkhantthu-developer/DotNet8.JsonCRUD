using DotNet8.JsonCRUD.WebApi.Features.Blog;
using DotNet8.JsonCRUD.WebApi.Helpers;

namespace DotNet8.JsonCRUD.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFeature(this IServiceCollection services)
        {
            return services.AddScoped<JsonFileHelper>()
                           .AddScoped<DA_Blog>()
                           .AddScoped<BL_BLog>();
        }
    }
}
