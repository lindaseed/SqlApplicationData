using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SqlApplication.Dto;
using SqlApplication.Services;

namespace WpfApplicationData.ViewModels;

public partial class AddAddressViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly AddressService _addressService;

    public AddAddressViewModel(IServiceProvider serviceProvider, AddressService addressService)
    {
        _serviceProvider = serviceProvider;
        _addressService = addressService;
    }

    [ObservableProperty]

    private Address _addressForm = new();

    [RelayCommand]

    private void Add()
    {
        _addressService.CreateNewAddress(AddressForm);
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddAddressViewModel>();
    }
}
