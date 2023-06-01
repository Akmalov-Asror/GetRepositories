using GitCloneBackend.Data;
using GitCloneBackend.DTO_s;
using GitCloneBackend.Repositories;
using GitCloneBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Octokit;

namespace GitCloneBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GithubRepositoryController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ProjectFetcherService _repositoryService;
    public GithubRepositoryController(AppDbContext context, ProjectFetcherService repositoryService)
    {
        _context = context;
        _repositoryService = repositoryService;
    }

    [HttpGet("gitRepositories")]
    public async Task<IActionResult> GetUsersAsync()
    {
        var users = await _context.Repositories.ToListAsync();
        
        return Ok(users);
    }





    [HttpPost]
    public async Task<IReadOnlyList<Repository>> GetRepositories([FromBody] UserDto user)
    {
        return await _repositoryService.GetRepositories(user.Username);
    }

}