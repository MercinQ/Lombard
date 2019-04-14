﻿using Lombard.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lombard.API.Repository
{
    public class RaportRepository : IRaportRepository
    {
        private readonly DataContext _context;

        public RaportRepository (DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> CheckProductsOutage(int quant)
        {
            //Może dodać parametr zamiast 10?
            // Jest i parametr :) 
            var contextProducts = _context.Products.ToList();
            return contextProducts.Where(p => p.Quantity < quant);
        }

    }
}