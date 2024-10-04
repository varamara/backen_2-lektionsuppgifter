using Microsoft.EntityFrameworkCore;
using Models;

namespace Contexts;

public class Data : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=backend.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Employee>()
            .HasData(
                new { Id = 1, Name = "Test employee", Salary = 1000.00 });
        base.OnModelCreating(modelBuilder);
    }

}