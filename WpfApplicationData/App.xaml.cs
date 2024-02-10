using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlApplication.Context;
using SqlApplication.Repositories;
using SqlApplication.Services;
using System.Windows;
using WpfApplicationData.ViewModels;
using WpfApplicationData.Views;

namespace WpfApplicationData;

public partial class App : Application
{
    private static IHost? builder;

    public App()
    {
        builder = Host.CreateDefaultBuilder()
            .ConfigureServices (services =>
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

                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();

                services.AddTransient<CustomerAddViewModel>();
                services.AddTransient<CustomerAddView>();
                services.AddTransient<CustomerListViewModel>();
                services.AddTransient<CustomerListView>();
                services.AddTransient<EditCustomerViewModel>();
                services.AddTransient<EditCustomerView>();

                services.AddTransient<AddressListViewModel>();
                services.AddTransient<AddressListView>();
                services.AddTransient<EditAddressViewModel>();
                services.AddTransient<EditAddressView>();

                services.AddTransient<ProductListViewModel>();
                services.AddTransient<ProductListView>();
                services.AddTransient<ProductAddViewModel>();
                services.AddTransient<ProductAddView>();
                services.AddTransient<EditProductViewModel>();
                services.AddTransient<EditProductView>();



            }).Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        builder!.Start();
        var mainWindow = builder!.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
