using Microsoft.EntityFrameworkCore;
using SqlApplication.Context;
using SqlApplication.Entities;

namespace SqlApplication.Repositories;

public class ProductRepository(DataContext context) : BaseRepository<ProductEntity>(context)
{
    private readonly DataContext _context = context;
}