﻿using BookReader.Data.Models;
using BookReader.Interfaces;
using BookReader.Repositories;
using BookReader.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookReader.Context
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }
    }
}
