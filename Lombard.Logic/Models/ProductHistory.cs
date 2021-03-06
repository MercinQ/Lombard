﻿
namespace Lombard.API.Models
{
    public class ProductHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public ProductHistory()
        {

        }
        public ProductHistory(Product product)
        {
            Name = product.Name;
            Price = product.Price;
            Quantity = product.Quantity;
        }
    }
}
