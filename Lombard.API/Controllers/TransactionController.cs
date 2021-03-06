﻿using System.Collections.Generic;
using Lombard.API.Models;
using Lombard.API.Repository;
using Lombard.API.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace Lombard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IProductRepository _productRepository;
        private Transaction _lastTransaction;


        public TransactionController(ITransactionRepository transactionRepository, IProductRepository productRepository)
        {
            _transactionRepository = transactionRepository;
            _productRepository = productRepository;
            _lastTransaction = _transactionRepository.GetLast();
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            var transaction = _transactionRepository.GetTransactions();
            return Ok(transaction);
        }
        [HttpGet("{id}")]
        public IActionResult GetTransaction(int id)
        {
            var transaction = _transactionRepository.GetTransaction(id);
            return Ok(transaction);
        }
        [HttpGet("{month}")]
        public IActionResult GetTransactionInMonth(int month)
        {
            var transaction = _transactionRepository.GetTransactionsInMonth(month);
            return Ok(transaction);
        }

        [HttpPost]
        [Route("BuyProducts")]
        public IActionResult BuyProducts([FromBody] List<Product> products)
        {
            _lastTransaction = _transactionRepository.AddTransaction(ProductWrapper.productHistories(products), TransactionType.Bought);
            _productRepository.AddProducts(products);
            return Ok();
        }
        [HttpPost]
        [Route("SellProducts")]
        public IActionResult SellProducts([FromBody] List<Product> products)
        {
            _lastTransaction = _transactionRepository.AddTransaction(ProductWrapper.productHistories(products), TransactionType.Sold);
            _productRepository.RemoveOrUpdateProducts(products);
            return Ok();
        }

        [HttpDelete]
        [Route("RemoveLast")]
        public IActionResult RemoveTransaction()
        {

            if (_lastTransaction.TransactionType == TransactionType.Bought)
                _productRepository.RemoveOrUpdateProducts(ProductWrapper.products(_lastTransaction.ProductHistory));
            else
                _productRepository.AddProducts(ProductWrapper.products(_lastTransaction.ProductHistory));

            _lastTransaction = _transactionRepository.RemoveLastTransaction();

            return Ok();
        }
    }
}