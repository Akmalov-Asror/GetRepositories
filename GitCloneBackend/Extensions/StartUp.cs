using GitCloneBackend.Repositories;

namespace GitCloneBackend.Extensions;

public static class StartUp
{
    private static readonly RepositoryFetcher _repositoryFetcher;
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {

        builder.Services.AddHttpClient();

        builder.Services.AddScoped<RepositoryFetcher>();

        builder.Services.AddControllers();

    }
    
}