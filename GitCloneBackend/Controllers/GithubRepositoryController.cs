using GitCloneBackend.Data;
using GitCloneBackend.DTO_s;
using GitCloneBackend.Repositories;
using GitCloneBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Octokit;

namespace GitCloneBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GithubRepositoryController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ProjectFetcherService _projectFetcherService;
    public GithubRepositoryController(AppDbContext context, ProjectFetcherService repositoryService)
    {
        _context = context;
        _projectFetcherService = repositoryService;
    }

    [HttpGet("GetRepositories/{username}")]
    public async Task<IActionResult> GetRepositories(string username)
    {
        await _projectFetcherService.GetRepositories(username);

        var repositories = await _context.Repositories.ToListAsync();

        return Ok(repositories);
    }

}