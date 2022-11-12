using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruductApp.Data;
using PruductApp.Models;
using PruductApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public async Task<ActionResult> CreateProductAsync(ProductRequest req)
        {
            try
            {
                var productEntity = new ProductEntity()
                {
                    Name = req.Name,
                    Price = req.Price
                };

                _context.Products.Add(productEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult(new ProductEntity //Ändrad från Model
                {
                    Id = productEntity.Id,
                    Name = productEntity.Name,
                    Price = productEntity.Price
                });
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
        public async Task<List<ProductModel>> GetAllProductAsync()
        {
            var productModel = new List<ProductModel>();

            try
            {
                foreach (var item in await _context.Products.ToListAsync())
                    productModel.Add(new ProductModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                    });

                return productModel;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return productModel;
        }
        public async Task<ProductEntity> GetOneProductAsync(int id) 
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
