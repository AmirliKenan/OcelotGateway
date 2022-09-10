﻿using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Model;

namespace ProductApi.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _context;

        public ProductService(ProductContext context)
        {
         
           _context = context;
        }

        public Product AddProduct(Product product)
        {
            var result = _context.Products.Add(product);
            _context.SaveChanges();
            return result.Entity;

        }

        public bool DeleteProduct(int Id)
        {
            var filteredData = _context.Products.Where(x => x.ProductId == Id).FirstOrDefault();
            var result = _context.Remove(filteredData);
            _context.SaveChanges();
            return result != null ? true : false;
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductList()
        {
            return _context.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            var result = _context.Products.Update(product);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
