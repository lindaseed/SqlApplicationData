using SqlApplication.Context;
using SqlApplication.Entities;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SqlApplication.Repositories;

public class AddressRepository(DataContext context) : BaseRepository<AddressEntity>(context)
{
    private readonly DataContext _context = context;
}
