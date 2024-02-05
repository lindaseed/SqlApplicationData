using SqlApplication.Context;
using SqlApplication.Entities;

namespace SqlApplication.Repositories;

public class AddressRepository(DataContext context) : BaseRepository<AddressEntity>(context)
{
    private readonly DataContext _context = context;

}
