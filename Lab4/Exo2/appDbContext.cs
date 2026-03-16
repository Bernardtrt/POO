using Microsoft.EntityFrameworkCore;

namespace Lab41;

public class Games : DbContext
{
    public DbSet<ComputerGame> CG { get; set; }
    public DbSet<Character> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Games.db");
    }
}