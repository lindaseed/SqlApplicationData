using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SqlApplication.Dto;
using SqlApplication.Services;

namespace WpfApplicationData.ViewModels;

public partial class ProductAddViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ProductService _productService;

    public ProductAddViewModel(IServiceProvider serviceProvider, ProductService productService)
    {
        _serviceProvider = serviceProvider;
        _productService = productService;
    }

    [ObservableProperty]
    private Product _productForm = new();

    [RelayCommand]

    private void Add()
    {
        //_productService.CreateNewProduct(ProductForm);
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ProductListViewModel>();

    }
}
