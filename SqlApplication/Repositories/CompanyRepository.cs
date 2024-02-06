using SqlApplication.Context;
using SqlApplication.Entities;

namespace SqlApplication.Repositories;

public class CompanyRepository(DataContext context) : BaseRepository<CompanyEntity>(context)
{
    private readonly DataContext _context = context;
}
