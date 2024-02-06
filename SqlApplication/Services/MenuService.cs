using SqlApplication.Dto;
using SqlApplication.Entities;
using SqlApplication.Repositories;

namespace SqlApplication.Services;

public class MenuService(ProductService productService)
{
    private readonly ProductService _productService = productService;

    public void CreateProduct()
    {

        Console.Clear();

        Console.WriteLine("New Product");

        Console.WriteLine("Prpduct Article Number: ");
        var articleNumber = Console.ReadLine()!;

        Console.WriteLine("Product Title: ");
        var title = Console.ReadLine()!;

        Console.WriteLine("Product Description: ");
        var description = Console.ReadLine()!;

        Console.WriteLine("Product Price: ");
        var price = decimal.Parse(Console.ReadLine()!);

        Console.WriteLine("Category Name: ");
        var categoryName = Console.ReadLine()!;

        var result = _productService.CreateNewProduct(articleNumber, title, description, price, categoryName); 

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Product Was Created");
            Console.ReadKey();
        }
    }






    //    private readonly ProductRepository _productRepository = productRepository;

    //    public void CreateProduct()
    //    {
    //        var productEntity = new ProductEntity();

    //        Console.Clear();
    //        Console.WriteLine("Add New Product");
    //        Console.WriteLine();

    //        Console.WriteLine("Products Article Number: ");
    //        productEntity.ArticleNumber = Console.ReadLine()!;

    //        Console.WriteLine("Product Name: ");
    //        productEntity.Title = Console.ReadLine()!;

    //        Console.WriteLine("Product Description: ");
    //        productEntity.Description = Console.ReadLine()!;

    //        Console.WriteLine("Product Price:");
    //        productEntity.Price = decimal.Parse(Console.ReadLine()!);

    //        //var entity = _productRepository.Create(productEntity);
    //        //Console.WriteLine($"Product ID: {entity}");

    //        if (productEntity != null)
    //            Console.WriteLine("Product Has Been Created Successefully...");
    //        else
    //            Console.WriteLine("Something Went Wrong...");


    //        Console.ReadKey();
    //    }
}
