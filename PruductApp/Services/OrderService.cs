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
    internal class OrderService
    {
        public readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync()
        {
            _context.Add(new OrderRequest { });
            await _context.SaveChangesAsync();
        }
        public async Task <List<OrderEntity>>GetAllOrderAsync()
        {
            return await _context.Orders.ToListAsync();
        }
        public async Task<OrderEntity> GetOneOrderAsync(int id)
        { 
            return await _context.Orders.FindAsync(id);
        }
        public async Task UpdateOrderAsync(OrderEntity order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteOrderAsync(int id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orderEntity);
            await _context.SaveChangesAsync();
        }
    }
}
