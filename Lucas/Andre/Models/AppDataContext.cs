using Microsoft.EntityFrameworkCore;

namespace Andre.Models;

public class AppDataContext : DbContext
{
    public DbSet<Funcionario> FolhaDePagamentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=lucas_andre.db");
    }
}