﻿using System.ComponentModel.DataAnnotations;

namespace SqlApplication.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int AddressId { get; set; }
    public AddressEntity Address {get; set;} = null!;
   
}
