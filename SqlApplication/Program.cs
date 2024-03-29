﻿
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


    services.AddSingleton<MenuService>();

}).Build();

builder.Start();

Console.Clear();

var menuService = builder.Services.GetRequiredService<MenuService>();
menuService.MainMenu();


