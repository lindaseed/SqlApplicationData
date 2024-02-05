using SqlApplication.Dto;
using SqlApplication.Entities;
using SqlApplication.Repositories;
using System.Diagnostics;

namespace SqlApplication.Services;

public class ProductService(CategoryRepository categoryRepository, ProductRepository productRepository)
{
    private readonly CategoryRepository _categoryRepository = categoryRepository;
    private readonly ProductRepository _productRepository = productRepository;

    public bool CreateNewProduct(Product product)
    {
        try
        {
            if (!_productRepository.Exists(x => x.ArticleNumber == product.ArticleNumber))
            {
                var categoryEntity = _categoryRepository.GetOne(x => x.CategoryName == product.CategoryName);
                categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = product.CategoryName });

                var productEntity = new ProductEntity
                {
                    ArticleNumber = product.ArticleNumber,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = categoryEntity.Id
                };

                var result = _productRepository.Create(productEntity);
                if (result != null)
                    return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR ::" + ex.Message); }

        return false;
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
















    //public void CreateNewProduct()
    //{
    //    var productEntity = new ProductEntity();

    //    Console.Clear();
    //    Console.WriteLine("Add New Product");
    //    Console.WriteLine();

    //    Console.WriteLine("Product Name: ");
    //    productEntity.Title = Console.ReadLine()!;

    //    Console.WriteLine("Product Description: ");
    //    productEntity.Description = Console.ReadLine()!;

    //    Console.WriteLine("Product Price:");
    //    productEntity.Price = decimal.Parse(Console.ReadLine()!);

    //    var entity = _productRepository.CreateProduct(productEntity);
    //    Console.WriteLine($"Product ID: {entity}");

    //    Console.ReadKey();
    //}

    //public void ShowAllProducts()
    //{
    //    Console.Clear();
    //    var products = _productRepository.GetProducts();
    //    foreach (var product in products)
    //    {
    //        Console.WriteLine($"-{product.Title} \n-{product.Description} \n-{product.Price} SEK");
    //    }
    //}
}
