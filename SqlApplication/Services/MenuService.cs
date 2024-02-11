using Microsoft.EntityFrameworkCore.Infrastructure;
using SqlApplication.Dto;
using SqlApplication.Entities;
using SqlApplication.Repositories;
using System.Diagnostics;

namespace SqlApplication.Services;

public class MenuService(ProductService productService, CustomerService customerService, AddressService addressService)
{
    private readonly ProductService _productService = productService;
    private readonly CustomerService _customerService = customerService;
    private readonly AddressService _addressService = addressService;

    public void MainMenu()
    {
        Console.Clear();

        Console.WriteLine("Linda");


        while (true)
        {
            Console.WriteLine("Choose Your Option");
            Console.WriteLine();
            Console.WriteLine("1- Add Customer...");
            Console.WriteLine("2- Add Product...");
            Console.WriteLine("3- Add Address...");
            Console.WriteLine("4- Escape...");

            var option = Console.ReadLine();

            if (option == "1")
            {
                Console.Clear();
                Console.WriteLine("Customers List..");
                Console.WriteLine("1- Create Customer...");
                Console.WriteLine("2- Get All Customers...");
                Console.WriteLine("3- Get One Customer...");
                Console.WriteLine("4- Update Customer...");
                Console.WriteLine("5- Delete Customer...");
                Console.WriteLine("6- Close The List");


                var choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        CreateCustomer();
                        break;
                    case "2":
                        GetCustomers();
                        break;
                    case "3":
                        GetOneCustomer();
                        break;
                    case "4":
                        UpdateCustomer();
                        break;
                    case "5":
                        DeleteCustomerById();
                        break;
                    case "6":
                        Escape();
                        break;
                    default:
                        Console.WriteLine("SomeThing Went Wrong. Try Again...");
                        Console.ReadKey();
                        break;

                }
            }

            else if (option == "2")
            {
                Console.Clear();
                Console.WriteLine("Products List..");
                Console.WriteLine("1- Create Product...");
                Console.WriteLine("2- Get All Products...");
                Console.WriteLine("3- Get One Product...");
                Console.WriteLine("4- Update Products...");
                Console.WriteLine("5- Delete Product...");
                Console.WriteLine("6- Close The List");


                var choose = Console.ReadLine();

                switch (choose)
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
                    case "6":
                        Escape();
                        break;
                    default:
                        Console.WriteLine("SomeThing Went Wrong. Try Again...");
                        Console.ReadKey();
                        break;

                }
            }

            else if (option == "3") 
            {
                Console.Clear();
                Console.WriteLine(" Addresses..");
                Console.WriteLine("1- Create Address...");
                Console.WriteLine("2- Get All Address...");
                Console.WriteLine("3- Get One Address...");
                Console.WriteLine("4- Update Address...");
                Console.WriteLine("5- Delete Address...");
                Console.WriteLine("6- Close The List");

                var choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        CreateAddress();
                        break;
                    case "2":
                        GetAddresses();
                        break;
                    case "3":
                        GetOneAddress();
                        break;
                    case "4":
                        UpdateAddress();
                        break;
                    case "5":
                        DeleteAddressById();
                        break;
                    case "6":
                        Escape();
                        break;
                    default:
                        Console.WriteLine("SomeThing Went Wrong. Try Again...");
                        Console.ReadKey();
                        break;

                }
            }

            else if (option == "4")
            {
                Escape();
            }

            else
            {
                Console.WriteLine("number Not Found.. Ckeck Again...");
            }
        }


         void CreateCustomer()
        {
            var customer = new Customer();

            Console.Clear();
            Console.WriteLine("New Customer");

            Console.WriteLine("First Name: ");
            customer.FirstName = Console.ReadLine()!;

            Console.WriteLine("Last Name: ");
            customer.LastName = Console.ReadLine()!;

            Console.WriteLine("Email: ");
            customer.Email = Console.ReadLine()!;

            Console.WriteLine("Phone Number: ");
            customer.PhoneNumber = Console.ReadLine()!;

            Console.WriteLine("Address: ");
            customer.Address = Console.ReadLine()!;

            _customerService.CreateNewCustomer(customer);

            DisplayPressAnyKey();

        }

         void GetCustomers()
        {
            Console.Clear();
            Console.WriteLine("Get Your Customers...");

            var customers = _customerService.GetAllCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}{customer.Email} {customer.PhoneNumber} {customer.Address}");
            }
            DisplayPressAnyKey();
        }


         void GetOneCustomer()
        {
            Console.WriteLine("Search For a Customer By Writing Customer's Id...");

            var customer = _customerService.GetCustomerById(0);
            if (customer != null)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}{customer.Email} {customer.PhoneNumber} {customer.Address}");
            }
            else
            {
                Console.WriteLine("No Customer Found");
            }

            DisplayPressAnyKey();

        }


         void UpdateCustomer()
        {
            var customerToUpdate = _customerService.GetCustomerById(0);
            if (customerToUpdate != null)
            {
                customerToUpdate.Id = 0;
                _customerService.UpdateCustomer(customerToUpdate);
            }

            DisplayPressAnyKey();
        }


         void DeleteCustomerById()
        {
            Console.WriteLine("Delete Customer By Writing Customer's Id...");

            var customer = _customerService.GetCustomerById(0);

            if (customer != null)
            {
                Console.WriteLine("Customer Deleted Successefully...");

            }
            else
            {
                Console.WriteLine("SomeThing Wrong. Try Again...");
            }

            DisplayPressAnyKey();
        }


         void CreateProduct()
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

            Console.WriteLine("Company Name: ");
            var companyName = Console.ReadLine()!;

            var result = _productService.CreateNewProduct(articleNumber, title, description, price, categoryName, companyName);

            if (result != null)
            {
                Console.Clear();
                Console.WriteLine("Product Was Created");
                Console.ReadKey();
            }

            DisplayPressAnyKey();
        }


         void GetProducts()
        {
            Console.Clear();
            Console.WriteLine("Your Products...");

            var products = _productService.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ArticleNumber} {product.Title}{product.Description} {product.Price} {product.CategoryName} {product.CompanyName}");
            }
            DisplayPressAnyKey();
        }


         void GetOneProduct()
        {
            Console.WriteLine("Search For a Product By Writing Product's Id...");

            var product = _productService.GetProductById(0);
            if (product != null)
            {
                Console.WriteLine($"{product.ArticleNumber} {product.Title}{product.Description} {product.Price} {product.CategoryId} {product.CompanyId}");
            }
            else
            {
                Console.WriteLine("No Product Found");
            }

            DisplayPressAnyKey();

        }

         void UpdateProducts()
        {
            var productToUpdate = _productService.GetProductById(0);
            if (productToUpdate != null)
            {
                productToUpdate.Id = 0;
                _productService.UpdateProduct(productToUpdate);
            }

            DisplayPressAnyKey();
        }


         void DeleteProductById()
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

         void CreateAddress()
        {
            var address = new Address();

            Console.Clear();
            Console.WriteLine("New Address");

            Console.WriteLine("Street Name: ");
            address.StreetName = Console.ReadLine()!;

            Console.WriteLine("Postal Code: ");
            address.PostalCode = Console.ReadLine()!;

            Console.WriteLine("City: ");
            address.City = Console.ReadLine()!;

            _addressService.CreateNewAddress(address);

            DisplayPressAnyKey();

        }

         void GetAddresses()
        {
            Console.Clear();
            Console.WriteLine("Get Addresses...");

            var addresses = _addressService.GetAllAdddresses();

            foreach (var address in addresses)
            {
                Console.WriteLine($"{address.StreetName} {address.PostalCode}{address.City}");
            }
            DisplayPressAnyKey();
        }


         void GetOneAddress()
        {
            Console.WriteLine("Search For an Address By Writing Address's Id...");

            var adress = _addressService.GetAddressById(0);
            if (adress != null)
            {
                Console.WriteLine($"{adress.StreetName} {adress.PostalCode}{adress.City}");
            }
            else
            {
                Console.WriteLine("No Address Found");
            }

            DisplayPressAnyKey();

        }


         void UpdateAddress()
        {
            var adressToUpdate = _addressService.GetAddressById(0);
            if (adressToUpdate != null)
            {
                adressToUpdate.Id = 0;
                _addressService.UpdateAddress(adressToUpdate);
            }

            DisplayPressAnyKey();
        }


         void DeleteAddressById()
        {
            Console.WriteLine("Delete Address By Writing Address's Id...");

            var address = _addressService.GetAddressById(0);

            if (address != null)
            {
                Console.WriteLine("Address Deleted Successefully...");

            }
            else
            {
                Console.WriteLine("SomeThing Wrong. Try Again...");
            }

            DisplayPressAnyKey();
        }



        void DisplayPressAnyKey()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        void Escape()
        {
            Console.WriteLine("Are You Sure You Want To Escape?! (Y/N)");
            string svar = Console.ReadLine()!;
            if (svar.ToUpper() == "Y")
            {
                Console.WriteLine("See You Soon...");
                Environment.Exit(0);
            }
        }
    }
 }
  



   



