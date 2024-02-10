using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SqlApplication.Entities;
using SqlApplication.Services;
using System.Collections.ObjectModel;

namespace WpfApplicationData.ViewModels;

public partial class AddressListViewModel : ObservableObject
{
    private readonly AddressService _addressService;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private ObservableCollection<AddressEntity> _addressList = [];

    public AddressListViewModel(AddressService addressService, IServiceProvider serviceProvider)
    {
        _addressService = addressService;
        _serviceProvider = serviceProvider;

        AddressList = new ObservableCollection<AddressEntity>(_addressService.GetAllAdddresses());
    }

    [RelayCommand]
    private void AddAddressToList()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddAddressViewModel>();
    }

    [RelayCommand]
    private void EditAddress()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<EditAddressViewModel>();
    }

    [RelayCommand]

    private void RemoveAddress(AddressEntity addressEntity)
    {
        var result = _addressService.DeleteAddress(x => x.Id ==  addressEntity.Id);
        AddressList = new ObservableCollection<AddressEntity>(_addressService.GetAllAdddresses());
    }
}
