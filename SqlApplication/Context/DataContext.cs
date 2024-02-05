using Microsoft.EntityFrameworkCore;
using SqlApplication.Entities;

namespace SqlApplication.Context;

public partial class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    //public virtual DbSet<AddressEntity> Addresses { get; set; }
    //public virtual DbSet<CategoryEntity> Categories { get; set; }
    //public virtual DbSet<CompanyEntity> Companies { get; set; }
    //public virtual DbSet<CustomerEntity> Customers { get; set; }
    public virtual DbSet<ProductEntity> Products { get; set; }
    public virtual DbSet<CategoryEntity> Categories { get; set; }
}
