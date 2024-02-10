using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SqlApplication.Dto;
using SqlApplication.Services;

namespace WpfApplicationData.ViewModels;

public partial class EditAddressViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly AddressService _addressService;

    public EditAddressViewModel(IServiceProvider serviceProvider, AddressService addressService)
    {
        _serviceProvider = serviceProvider;
        _addressService = addressService;
    }

    [ObservableProperty]
    private Address _addressForm = new();


    [RelayCommand]
    private void Update()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddressListViewModel>();
    }

}
