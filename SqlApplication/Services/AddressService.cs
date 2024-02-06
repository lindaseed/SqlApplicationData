using SqlApplication.Dto;
using SqlApplication.Entities;
using SqlApplication.Repositories;
using System.Diagnostics;

namespace SqlApplication.Services;

public class AddressService(AddressRepository addressRepository)
{
    private readonly AddressRepository _addressRepository = addressRepository;


    public AddressEntity CreateNewAddress(Address address)
    {
       
        var addressEntity = _addressRepository.GetOne(x => x.StreetName == address.StreetName && x.PostalCode == address.PostalCode && x.City == address.City);
        addressEntity ??= _addressRepository.Create(new AddressEntity { Address = address.PostalCode });

        return addressEntity;
    }


    public AddressEntity GetAddressById(int id)
    {
        var addressEntity = _addressRepository.GetOne(x => x.Id == id);
        return addressEntity;
    }

    public IEnumerable<AddressEntity> GetAllAdddresses()
    {
       var addresses = _addressRepository.GetAll();
        return addresses;   

    }

    public AddressEntity UpdateAddress(AddressEntity addressEntity)
    {
        var updateAddress = _addressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
        return updateAddress;
        
    }

    public void DeleteAddress(int id)
    {
        _addressRepository.Delete(x => x.Id == id);
    }



}
