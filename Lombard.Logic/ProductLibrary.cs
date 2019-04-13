﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lombard.API.Models;

namespace Lombard.Logic
{
    public class ProductLibrary
    {
        public IEnumerable<Product> GetAllProducts(IQueryable<Product> contextProducts)
        {
            return contextProducts.ToList();
        }

        public IEnumerable<Product> CheckProductsOutage(IQueryable<Product> contextProducts)
        {
            //Może dodać parametr zamiast 10?
            return contextProducts.Where(p => p.Quantity < 10);
        }
        public Product GetProductById(int id, IEnumerable<Product> contextProducts)
        {
            return contextProducts.SingleOrDefault(p => p.ProductId == id);
        }
        public int GetProductQuantityById(int id, IEnumerable<Product> contextProducts)
        {
            if (!contextProducts.Any(p => p.ProductId == id))
                return 0;
            return contextProducts.SingleOrDefault(p => p.ProductId == id).Quantity;
        }
        public double GetProductPriceById(int id, IEnumerable<Product> contextProducts)
        {
            if (!contextProducts.Any(p => p.ProductId == id))
                return 0;
            return contextProducts.SingleOrDefault(p=>p.ProductId == id).Price;
        }
        public void AddProduct()
        {

        }
    }
}