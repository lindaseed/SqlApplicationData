using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SqlApplication.Dto;
using SqlApplication.Entities;
using SqlApplication.Services;
using System.Collections.ObjectModel;

namespace WpfApplicationData.ViewModels;

public partial class ProductListViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ProductService _productService;

    public ProductListViewModel(IServiceProvider serviceProvider, ProductService productService)
    {
        _serviceProvider = serviceProvider;
        _productService = productService;

        ProductList = new ObservableCollection<Product>(_productService.GetAllProducts());
    }

    [ObservableProperty]
    private ObservableCollection<Product> _productList = [];

    [RelayCommand]
    private void AddProductToList()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ProductAddViewModel>();
    }

    [RelayCommand]
    private void EditProduct(Product _productForm)
    {

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<EditProductViewModel>();
    }

    [RelayCommand]

    public void RemoveProduct(ProductEntity productEntity)
    {
        var result = _productService.DeleteProduct(x => x.Id == productEntity.Id);
        ProductList = new ObservableCollection<Product>(_productService.GetAllProducts());
    }
}
