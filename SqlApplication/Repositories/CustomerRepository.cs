using Microsoft.EntityFrameworkCore;
using SqlApplication.Context;
using SqlApplication.Entities;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SqlApplication.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context)
{
    private readonly DataContext _context = context;

    //public override CustomerEntity Create(CustomerEntity entity)
    //{
    //    return base.Create(entity);
    //}

    //public override bool Delete(Expression<Func<CustomerEntity, bool>> predicate)
    //{
    //    return base.Delete(predicate);
    //}

    //public override bool Exists(Expression<Func<CustomerEntity, bool>> predicate)
    //{
    //    return base.Exists(predicate);
    //}

    //public override IEnumerable<CustomerEntity> GetAll()
    //{
    //    try
    //    {
    //        return _context.Customers.Include(x => x.Address).ToList();
    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR ::  " + ex.Message); }
    //    return null!;
    //}

    //public override CustomerEntity GetOne(Expression<Func<CustomerEntity, bool>> predicate)
    //{
    //    try
    //    {
    //        return _context.Customers.Include(x => x.Address).FirstOrDefault(predicate, null!);
    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR ::  " + ex.Message); }
    //    return null!;
    //}

    //public override CustomerEntity Update(CustomerEntity entity)
    //{
    //    return base.Update(entity);
    //}
}
