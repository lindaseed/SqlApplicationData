using Microsoft.EntityFrameworkCore;
using SqlApplication.Context;
using SqlApplication.Entities;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SqlApplication.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context)
{
    private readonly DataContext _context = context;
}
