using GitCloneBackend.Data;
using GitCloneBackend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GitCloneBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GithubRepositoryController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly RepositoryFetcher _repositoryFetcher;
    public GithubRepositoryController(AppDbContext context, RepositoryFetcher repositoryFetcher)
    {
        _context = context;
        _repositoryFetcher = repositoryFetcher;
    }

    [HttpGet("gitRepositories")]
    public async Task<IActionResult> GetUsersAsync()
    {
        var users = await _context.Repositories.ToListAsync();
        
        return Ok(users);
    }

}