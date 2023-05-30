using GitCloneBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitCloneBackend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Repository> Repositories { get; set; }
}