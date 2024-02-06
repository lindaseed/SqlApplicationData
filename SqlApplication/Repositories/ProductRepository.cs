using Microsoft.EntityFrameworkCore;
using SqlApplication.Context;
using SqlApplication.Entities;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SqlApplication.Repositories;

public class ProductRepository(DataContext context) : BaseRepository<ProductEntity>(context)
{
    private readonly DataContext _context = context;

    //public override ProductEntity Create(ProductEntity entity)
    //{
    //    return base.Create(entity);
    //}

    //public override bool Delete(Expression<Func<ProductEntity, bool>> predicate)
    //{
    //    return base.Delete(predicate);
    //}

    //public override IEnumerable<ProductEntity> GetAll()
    //{
    //    try
    //    {
    //        return _context.Products.Include(x => x.Category).ToList();
    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR ::  "+ ex.Message); }
    //    return null!;
    //}

    //public override ProductEntity GetOne(Expression<Func<ProductEntity, bool>> predicate)
    //{
    //    try
    //    {
    //        return _context.Products.Include(x => x.Category).FirstOrDefault(predicate, null!);
    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR ::  " + ex.Message); }
    //    return null!;
    //}

    //public override ProductEntity Update(ProductEntity entity)
    //{
    //    return base.Update(entity);
    //}
}


//public class ProductRepository (string connectionString)
//{
//    private readonly string _connectionString = connectionString;

//    public int CreateProduct(ProductEntity entity)
//    {
//        using var conn = new SqlConnection(_connectionString);

//        var result = conn.ExecuteScalar<int>("", entity);
//        return result;
//    }
//}




//public ProductEntity CreateProduct(ProductEntity entity)
//{
//    _context.Products.Add(entity);
//    _context.SaveChanges();

//    return entity;
//}

//public IEnumerable<ProductEntity> GetProducts()
//{
//    return _context.Products.ToList();
//}