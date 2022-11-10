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
using System.Windows;

namespace PruductApp.Services
{
    public class OrderService
    {
        public readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> CreateOrderAsync(OrderRequest orderReq)
        {
            try
            {
                var orderEntity = new OrderEntity
                {
                    Date = DateTime.Now,
                    CustomerId = orderReq.CustomerId,
                };

                orderEntity.OrderRowsId = new OrderRowsEntity { ProductId = orderReq.ProductId }.Id;
                _context.Orders.Add(orderEntity);
                await _context.SaveChangesAsync();
                MessageBox.Show("Saved!");
                return new OkResult();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();

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
