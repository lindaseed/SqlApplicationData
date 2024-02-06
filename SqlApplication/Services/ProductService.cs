using SqlApplication.Dto;
using SqlApplication.Entities;
using SqlApplication.Repositories;
using System.Diagnostics;

namespace SqlApplication.Services;

public class ProductService(CategoryService categoryService, ProductRepository productRepository)
{
    private readonly CategoryService _categoryService = categoryService;
    private readonly ProductRepository _productRepository = productRepository;

    public ProductEntity CreateNewProduct(string articleNumber,string title, string description, decimal price, string categoryName)
    {

        var categoryEntity = _categoryService.CreateNewCategory(categoryName);

        var productEntity = new ProductEntity
        {
            ArticleNumber = articleNumber,
            Title = title,
            Description = description,
            Price = price,
            CategoryId = categoryEntity.Id
            
        };

        productEntity = _productRepository.Create(productEntity);
        return productEntity;
    }


    public IEnumerable<Product> GetAllProducts()
    {

        var products = new List<Product>();

        try
        {
            var result = _productRepository.GetAll();

            foreach (var item in result)
                products.Add(new Product
                {
                    ArticleNumber = item.ArticleNumber,
                    Title = item.Title,
                    Description = item.Description,
                    Price = item.Price,
                    CategoryName = item.Category.CategoryName
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

    public ProductEntity UpdateProduct(ProductEntity entity)
    {
        var updateProductEntity = _productRepository.Update(x => x.Id == entity.Id, entity);
        return updateProductEntity;
    }


    public void DeleteProduct(int id)
    {
        _productRepository.Delete(x => x.Id == id);
    }
}
