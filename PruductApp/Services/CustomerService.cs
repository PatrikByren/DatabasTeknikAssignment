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
    internal class CustomerService
    {
        private readonly DataContext _context;

        public async Task CreateCustomerAsync(CustomerRequest req)
        {
            _context.Add(new CustomerEntity 
            {
                Name = req.Name
            });
            await _context.SaveChangesAsync();
        }
        public async Task<List<CustomerEntity>> GetAllCostumerAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task <CustomerEntity> GetOneCustomerAsync(int id)
        {
            return await _context.Customers.FindAsync();
        }
        public async Task UpdateCustomerAsync(CustomerEntity costumer)
        {
            _context.Entry(costumer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCustomerAsync(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customerEntity);
            await _context.SaveChangesAsync();
        }
    }
}
