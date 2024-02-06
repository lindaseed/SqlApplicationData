using SqlApplication.Context;
using SqlApplication.Entities;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SqlApplication.Repositories;

public class AddressRepository(DataContext context) : BaseRepository<AddressEntity>(context)
{
    private readonly DataContext _context = context;
    //public override AddressEntity Create(AddressEntity entity)
    //{
    //    return base.Create(entity);
    //}

    //public override bool Delete(Expression<Func<AddressEntity, bool>> predicate)
    //{
    //    return base.Delete(predicate);
    //}

    //public override bool Exists(Expression<Func<AddressEntity, bool>> predicate)
    //{
    //    return base.Exists(predicate);
    //}

    //public override IEnumerable<AddressEntity> GetAll()
    //{
       
    //}

    //public override AddressEntity GetOne(Expression<Func<AddressEntity, bool>> predicate)
    //{
    //    return base.GetOne(predicate);
    //}

    //public override AddressEntity Update(AddressEntity entity)
    //{
    //    return base.Update(entity);
    //}
}
