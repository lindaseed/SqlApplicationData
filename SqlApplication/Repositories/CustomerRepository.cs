﻿using Microsoft.EntityFrameworkCore;
using SqlApplication.Context;
using SqlApplication.Entities;


namespace SqlApplication.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context)
{
    private readonly DataContext _context = context;
}
