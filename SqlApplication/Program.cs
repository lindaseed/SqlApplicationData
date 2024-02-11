
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlApplication.Context;
using SqlApplication.Repositories;
using SqlApplication.Services;



var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Webbutveckling\cSharp\SqlApplicationData\SqlApplication\Data\local-datebase-create-tables.mdf;Integrated Security=True"));

    services.AddScoped<AddressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<CompanyRepository>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<ProductRepository>();



    services.AddScoped<AddressService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<CompanyService>();
    services.AddScoped<CustomerService>();
    services.AddScoped<ProductService>();


    services.AddSingleton<MenuServiceProduct>();
    services.AddSingleton<MenuServiceCustomers>();
    services.AddSingleton<MenuServiceAddress>();

}).Build();

builder.Start();

Console.Clear();

var menuServiceProduct = builder.Services.GetRequiredService<MenuServiceProduct>();
menuServiceProduct.ShowProductsMenu();
menuServiceProduct.CreateProduct();
menuServiceProduct.GetProducts();
menuServiceProduct.GetOneProduct();
menuServiceProduct.UpdateProducts();
menuServiceProduct.DeleteProductById();


var menuServiceCustomer = builder.Services.GetRequiredService<MenuServiceCustomers>();
menuServiceCustomer.ShowCustomerMenu();
menuServiceCustomer.CreateCustomer();
menuServiceCustomer.GetCustomers();
menuServiceCustomer.GetOneCustomer();
menuServiceCustomer.UpdateCustomer();
menuServiceCustomer.DeleteCustomerById();


var menuServiceAddress = builder.Services.GetRequiredService<MenuServiceAddress>();
menuServiceAddress.ShowAddressMenu();
menuServiceAddress.CreateAddress();
menuServiceAddress.GetAddresses();
menuServiceAddress.GetOneAddress();
menuServiceAddress.UpdateAddress();
menuServiceAddress.DeleteAddressById();

