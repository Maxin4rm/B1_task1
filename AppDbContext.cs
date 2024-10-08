using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace B1_task1;

public class ApplicationDbContext : DbContext
{
    const string connectionString = "Server=localhost;Port=5432;Database=b1_task1;Username=postgres;Password=postgres;";
    public DbSet<FileDataTable> FileDataTable { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
    }
}
