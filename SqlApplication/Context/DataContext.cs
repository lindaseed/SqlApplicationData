using Microsoft.EntityFrameworkCore;
using SqlApplication.Entities;

namespace SqlApplication.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase($"{Guid.NewGuid()}");
    }
}
