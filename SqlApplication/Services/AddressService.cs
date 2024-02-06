using SqlApplication.Dto;
using SqlApplication.Entities;
using SqlApplication.Repositories;
using System.Diagnostics;

namespace SqlApplication.Services;

public class AddressService(AddressRepository addressRepository)
{
    private readonly AddressRepository _addressRepository = addressRepository;


    public bool CreateNewAddress(Address address)
    {
       
        var addressEntity = _addressRepository.GetOne(x => x.StreetName == address.StreetName && x.PostalCode == address.PostalCode && x.City == address.City);
        addressEntity ??= _addressRepository.Create(new AddressEntity { Address = address.PostalCode });

        return true;

    }


    public IEnumerable<Address> GetAddresses()
    {
        var getAddress = new List<Address>();

        try
        {
            var result = _addressRepository.GetAll();

            foreach ( var item in result)
            {
                getAddress.Add(new Address
                {
                    StreetName = item.StreetName,
                    PostalCode = item.PostalCode,
                    City = item.City,
                });
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR ::" + ex.Message); }
        return getAddress;

    }

    public bool GetAddressById(int id)
    {
        var addressEntity = _addressRepository.GetOne(x => x.Id == id);
        return true;
    }

    public void UpdateAddress(Address address)
    {
        
    }

    public void DeleteAddress(int id)
    {
        _addressRepository.Delete(x => x.Id == id);
    }



}
