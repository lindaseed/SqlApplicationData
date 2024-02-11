using SqlApplication.Dto;
using SqlApplication.Entities;
using SqlApplication.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SqlApplication.Services;

public class AddressService(AddressRepository addressRepository)
{
    private readonly AddressRepository _addressRepository = addressRepository;


    public AddressEntity CreateNewAddress(Address address)
    {
        try
        {
            var result = _addressRepository.GetOne(x => x.StreetName == address.StreetName && x.PostalCode == address.PostalCode && x.City == address.City);
            result ??= _addressRepository.Create(new AddressEntity { Address = address.PostalCode });

            return new AddressEntity { Id = result.Id, Address = result.Address};
        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        return null!;
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

        try
        {
            var entity = _addressRepository.GetOne(x => x.Id == addressEntity.Id);
            if (entity != null)
            {
                entity.StreetName = addressEntity.StreetName;
                entity.PostalCode = addressEntity.PostalCode;
                entity.City = addressEntity.City;

                var result = _addressRepository.Update(entity);
                if (result != null)
                    return new AddressEntity { Id = result.Id, StreetName = result.StreetName, PostalCode = result.PostalCode, City = result.City};
            }
        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        return null!;
    }

    public bool DeleteAddress(Expression<Func<AddressEntity, bool>> predicate)
    {

        try
        {
            var result = _addressRepository.Delete(predicate);
            return result;
        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        return false;
    }
}
