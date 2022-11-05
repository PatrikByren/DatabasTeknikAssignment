using Microsoft.EntityFrameworkCore;
using PruductApp.Data;
using PruductApp.Models;
using PruductApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruductApp.Services
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        public async Task CreateProductAsync(ProductRequest req)
        {
            _context.Add(new ProductEntity
            {
                Name = req.Name,
                Price = req.Price,
            });
            await _context.SaveChangesAsync();
        }
        public async Task<List<ProductEntity>> GettAllProductAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<ProductEntity> GetProductAsync(int id) 
        {
            try
            {
                return await _context.Products.FindAsync(id);
            }
            catch { return null; }
        }
        public async Task UpdateProductAsync(ProductEntity product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProductAsync (int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();
        }
    }
}
