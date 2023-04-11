using Microsoft.EntityFrameworkCore;

namespace UTS_DRWA.Models;

public class JadwalGuruContext : DbContext
{
    public JadwalGuruContext(DbContextOptions<JadwalGuruContext> options)
        : base(options)
    {
    }

    public DbSet<JadwalGuru> JadwalGurus { get; set; } = null!;
}