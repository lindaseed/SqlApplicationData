using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SqlApplication.Dto;
using SqlApplication.Services;

namespace WpfApplicationData.ViewModels;

public partial class CustomerAddViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly CustomerService _customerService;

    public CustomerAddViewModel(IServiceProvider serviceProvider, CustomerService contactService)
    {
        _serviceProvider = serviceProvider;
        _customerService = contactService;
    }

    [ObservableProperty]
    private Customer _customerForm = new();

    [RelayCommand]

    private void Add()
    {
        _customerService.CreateNewCustomer(CustomerForm);
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<CustomerListViewModel>();
    }
}
