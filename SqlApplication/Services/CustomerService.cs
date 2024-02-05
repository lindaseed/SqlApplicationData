using SqlApplication.Dto;
using SqlApplication.Entities;
using SqlApplication.Repositories;
using System.Diagnostics;

namespace SqlApplication.Services;

public class CustomerService(AddressRepository addressRepository, CustomerRepository customerRepository)
{
    private readonly AddressRepository _addressRepository = addressRepository;
    private readonly CustomerRepository _customerRepository = customerRepository;

    public bool CreateNewCustomer(Customer customer)
    {
        try
        {
            if (!_customerRepository.Exists(x => x.FirstName == customer.FirstName && x.LastName == customer.LastName))
            {
                var addressEntity = _addressRepository.GetOne(x => x.Address == customer.Address);
                addressEntity ??= _addressRepository.Create(new AddressEntity { Address = customer.Address });

                var customerEntity = new CustomerEntity
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    AddressId = addressEntity.Id
                };

                var result = _customerRepository.Create(customerEntity);
                if (result != null)
                    return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR ::" + ex.Message); }

        return false;
    }


    public IEnumerable<Customer> GetAllCustomers()
    {
        var customers = new List<Customer>();
        try
        {
            var result = _customerRepository.GetAll();

            foreach (var item in result)
            {
                customers.Add(new Customer
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Address = item.Address.Address
                });
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR ::" + ex.Message); }

        return customers;
    }
}
