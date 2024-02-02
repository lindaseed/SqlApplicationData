using Microsoft.EntityFrameworkCore;
using SqlApplication.Entities;

namespace SqlApplication.Context;

public class DataContext : DbContext
{

    public DataContext()
    {
        
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase($"{Guid.NewGuid()}");
    }

    public DbSet<ProductEntity> Products { get; set; }
}
