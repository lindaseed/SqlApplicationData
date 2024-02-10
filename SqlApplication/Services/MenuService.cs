using Microsoft.EntityFrameworkCore.Infrastructure;
using SqlApplication.Dto;
using SqlApplication.Entities;
using SqlApplication.Repositories;
using System.Diagnostics;

namespace SqlApplication.Services;

public class MenuService(ProductService productService, ProductRepository productRepository)
{
    private readonly ProductService _productService = productService;
    private readonly ProductRepository _productRepository = productRepository;



    public void ShowProductsMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Products List..");
            Console.WriteLine("1- Create Product...");
            Console.WriteLine("2- Get All Products...");
            Console.WriteLine("3- Get One Product...");
            Console.WriteLine("4- Update Products...");
            Console.WriteLine("5- Delete Product...");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateProduct();
                    break;
                case "2":
                    GetProducts();
                    break;
                case "3":
                    GetOneProduct();
                    break;
                case "4":
                    UpdateProducts();
                    break;
                case "5":
                    DeleteProductById();
                    break;
                default:
                    Console.WriteLine("Wrong...");
                    Console.ReadKey();
                    break;

            }
        }
    }
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

        //var result = _productService.CreateNewProduct(articleNumber, title, description, price, categoryName); 

        //if (result != null)
        //{
        //    Console.Clear();
        //    Console.WriteLine("Product Was Created");
        //    Console.ReadKey();
        //}

        DisplayPressAnyKey();
    }


    public void GetProducts()
    {
        Console.Clear();
        Console.WriteLine("Get Your Products...");

        var products = _productService.GetAllProducts();

        foreach (var product in products)
        {
            Console.WriteLine($"{product.ArticleNumber} {product.Title}{product.Description} {product.Price}");
        }
        DisplayPressAnyKey();
    }


    public void GetOneProduct()
    {
        Console.WriteLine("Search For a Product By Writing Product's Id...");

        var product = _productService.GetProductById(0);
        if (product != null)
        {
            Console.WriteLine($"{product.ArticleNumber} {product.Title}{product.Description} {product.Price}");
        }
        else
        {
            Console.WriteLine("No Product Found");
        }

        DisplayPressAnyKey();

    }

    public void UpdateProducts()
    {
        var productToUpdate = _productService.GetProductById(0);
        if (productToUpdate != null)
        {
            productToUpdate.Id = 0;
            _productService.UpdateProduct(productToUpdate);
        }

        DisplayPressAnyKey();
    }


    public void DeleteProductById()
    {
        Console.WriteLine("Delete Product By Writing Product's Id...");

        var product = _productService.GetProductById(0);
        
        if (product != null)
        {
            Console.WriteLine("Product Deleted Successefully...");

        }
        else
        {
            Console.WriteLine("SomeThing Wrong. Try Again...");
        }

        DisplayPressAnyKey();
    }



    private void DisplayPressAnyKey()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

   

    
}
