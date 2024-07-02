using LoginSystem.API.Model;
using Microsoft.EntityFrameworkCore;

namespace LoginSystem.API.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Users> Users { get; set; } = default!;
}