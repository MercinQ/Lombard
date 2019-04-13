﻿using Lombard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lombard.API.Repository
{
    public interface IProductRepository
    {
       List<Product> GetProducts();
       void AddProducts(IEnumerable<Product> products);
    }
}
