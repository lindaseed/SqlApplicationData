using SqlApplication.Context;
using SqlApplication.Entities;

namespace SqlApplication.Repositories;

public class CategoryRepository(DataContext context) : BaseRepository<CategoryEntity>(context)
{
    private readonly DataContext _context = context;

   
}
