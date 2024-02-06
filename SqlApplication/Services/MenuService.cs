using SqlApplication.Entities;
using SqlApplication.Repositories;

namespace SqlApplication.Services;

public class MenuService(ProductRepository productRepository)
{
    private readonly ProductRepository _productRepository = productRepository;

    public void CreateProduct()
    {
        var productEntity = new ProductEntity();

        Console.Clear();
        Console.WriteLine("Add New Product");
        Console.WriteLine();

        Console.WriteLine("Products Article Number: ");
        productEntity.ArticleNumber = Console.ReadLine()!;

        Console.WriteLine("Product Name: ");
        productEntity.Title = Console.ReadLine()!;

        Console.WriteLine("Product Description: ");
        productEntity.Description = Console.ReadLine()!;

        Console.WriteLine("Product Price:");
        productEntity.Price = decimal.Parse(Console.ReadLine()!);

        //var entity = _productRepository.Create(productEntity);
        //Console.WriteLine($"Product ID: {entity}");

        if (productEntity != null)
            Console.WriteLine("Product Has Been Created Successefully...");
        else
            Console.WriteLine("Something Went Wrong...");
        

        Console.ReadKey();
    }
}
