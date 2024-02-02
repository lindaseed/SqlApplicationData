using SqlApplication.Context;
using SqlApplication.Entities;

namespace SqlApplication.Repositories;

public class ProductRepository(DataContext context)
{
    private readonly DataContext _context = context;


    public ProductEntity CreateProduct(ProductEntity entity)
    {
        _context.Products.Add(entity);
        _context.SaveChanges();

        return entity;
    }

    public IEnumerable<ProductEntity> GetProducts()
    {
        return _context.Products.ToList();
    }
}
