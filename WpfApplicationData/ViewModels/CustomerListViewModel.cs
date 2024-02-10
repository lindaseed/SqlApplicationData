using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SqlApplication.Dto;
using SqlApplication.Entities;
using SqlApplication.Services;
using System.Collections.ObjectModel;

namespace WpfApplicationData.ViewModels;

public partial class CustomerListViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly CustomerService _customerService;
    private ObservableCollection<Customer> customerList = [];

    public CustomerListViewModel(IServiceProvider serviceProvider, CustomerService customerService)
    {
        _serviceProvider = serviceProvider;
        _customerService = customerService;

        CustomerList = new ObservableCollection<Customer>(_customerService.GetAllCustomers());
    }

    [ObservableProperty]
    private ObservableCollection<Customer> _customerList = [];

    [RelayCommand]
    public void AddcustomerToList()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<CustomerAddViewModel>();
    }

    [RelayCommand]
    private void EditCustomer(Customer _customerForm)
    {

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<EditCustomerViewModel>();
    }

    [RelayCommand]

    public void RemoveCustomer(CustomerEntity customerEntity)
    {
        var result = _customerService.DeleteCustomer(x => x.Id == customerEntity.Id);
        CustomerList = new ObservableCollection<Customer>(_customerService.GetAllCustomers());
    }

}


