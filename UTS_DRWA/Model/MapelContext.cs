using Microsoft.EntityFrameworkCore;

namespace UTS_DRWA.Models;

public class MapelContext : DbContext
{
    public MapelContext(DbContextOptions<GuruContext> options)
        : base(options)
    {
    }

    public DbSet<Mapel> Mapels { get; set; } = null!;
}