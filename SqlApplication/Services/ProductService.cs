using SqlApplication.Dto;
using SqlApplication.Entities;
using SqlApplication.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SqlApplication.Services;

public class ProductService(CategoryService categoryService, CompanyService companyService, ProductRepository productRepository)
{
    private readonly CategoryService _categoryService = categoryService;
    private readonly CompanyService _companyService = companyService;
    private readonly ProductRepository _productRepository = productRepository;
    

    public ProductEntity CreateNewProduct(string articleNumber,string title, string description, decimal price, string categoryName, string companyName)
    {

        var categoryEntity = _categoryService.CreateNewCategory(categoryName);
        var companyEntity = _companyService.CreateNewCompany(companyName);

        var productEntity = new ProductEntity
        {
            ArticleNumber = articleNumber,
            Title = title,
            Description = description,
            Price = price,
            CategoryId = categoryEntity.Id,
            CompanyId = companyEntity.Id
            
        };

        productEntity = _productRepository.Create(productEntity);
        return productEntity;
    }


    public IEnumerable<Product> GetAllProducts()
    {

        var products = new List<Product>();

        try
        {
            var allProduct = _productRepository.GetAll();

            foreach (var product in allProduct)
                products.Add(new Product
                {
                    ArticleNumber = product.ArticleNumber,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryName = product.Category.CategoryName,
                    CompanyName = product.Company.CompanyName
                });

        }
        catch (Exception ex) { Debug.WriteLine("ERROR ::" + ex.Message); }

        return products;
    }

    public ProductEntity GetProductById(int id)
    {
        var productEntity = _productRepository.GetOne(x => x.Id == id);
        return productEntity;
    }

    public ProductEntity UpdateProduct(ProductEntity productEntity)
    {
        try
        {
            var entity = _productRepository.GetOne(x => x.Id == productEntity.Id);
            if (entity != null)
            {
                entity.ArticleNumber = productEntity.ArticleNumber;

                var result = _productRepository.Update(entity);
                if (result != null)
                    return new ProductEntity { Id = entity.Id, ArticleNumber = entity.ArticleNumber };
            }
        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        return null!;
    }


    public bool DeleteProduct(Expression<Func<ProductEntity, bool>> predicate)
    {

        try
        {
            var result = _productRepository.Delete(predicate);
            return result;
        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        return false;
    }
}
