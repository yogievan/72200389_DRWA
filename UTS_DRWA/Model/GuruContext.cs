using Microsoft.EntityFrameworkCore;

namespace UTS_DRWA.Models;

public class GuruContext : DbContext
{
    public GuruContext(DbContextOptions<GuruContext> options)
        : base(options)
    {
    }

    public DbSet<Guru> Gurus { get; set; } = null!;
}