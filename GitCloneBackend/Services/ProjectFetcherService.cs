using GitCloneBackend.DTO_s;
using GitCloneBackend.Repositories;
using Newtonsoft.Json.Linq;
using Octokit;

namespace GitCloneBackend.Services;

public class ProjectFetcherService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private string _githubUsername;
    private readonly GitHubClient _client;

    public ProjectFetcherService(IServiceProvider serviceProvider, GitHubClient client)
    {
        _serviceProvider = serviceProvider;
        _client = client;
    }
    public async Task<IReadOnlyList<Repository>> GetRepositories(string username)
    {
        _githubUsername = username;
        return await _client.Repository.GetAllForUser(_githubUsername);
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(50), stoppingToken);
            using (var scope = _serviceProvider.CreateScope())
            {
                var repositoryFetcher = scope.ServiceProvider.GetRequiredService<RepositoryFetcher>();

                var repositories = await GetRepositories(_githubUsername);
                foreach (var repository in repositories)
                {
                    await repositoryFetcher.SaveRepository(repository);
                }
            }
        }
    }
}
