using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PruductApp.Data;
using PruductApp.Models;
using PruductApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //private ObservableCollection<OrderRowsEntity> _orderRowsEntity = new();
        private int orderRowsId;
        public OrderService(DataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> CreateOrderAsync(OrderRequest orderReq, ObservableCollection<ProductModel> productModels)
        {
            
            try
            {
                var orderEntity = new OrderEntity
                {
                    Date = DateTime.Now,
                    CustomerId = orderReq.CustomerId,
                };

                _context.Orders.Add(orderEntity);
                await _context.SaveChangesAsync();
                
                foreach (var item in productModels)
                {
                    OrderRowsEntity orderRowsEntity = new OrderRowsEntity();
                        orderRowsEntity.ProductId = item.Id;
                        orderRowsEntity.OrderId = orderEntity.Id;
                        await _context.OrderRows.AddAsync(orderRowsEntity);
                        await _context.SaveChangesAsync();
                }
                MessageBox.Show("Saved!");
                return new OkResult();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            MessageBox.Show("Fail to save!");
            return new BadRequestResult();

        }
        //private async Task<ActionResult> SaveOrderRows(OrderRowsEntity orderRowsEntity)
        //{
        //    try
        //    {
        //        _context.OrderRows.Add(orderRowsEntity);
        //        await _context.SaveChangesAsync();
        //        return new OkResult();
        //    }
        //    catch (Exception ex) { Debug.WriteLine(ex.Message); }
        //    return new BadRequestResult();


        //}
        //public async Task<ActionResult> CreateOrderAsync(OrderRequest orderReq)
        //{
        //    try
        //    {
        //        //var orderRowsRequest = new OrderRowsRequest { ProductId = orderReq.ProductId };
        //        var orderEntity = new OrderEntity
        //        {
        //            Date = DateTime.Now,
        //            CustomerId = orderReq.CustomerId,
        //        };
        //        _context.Orders.Add(orderEntity);
        //        await _context.SaveChangesAsync();
        //        var orderRowEntity = new OrderRowsEntity { ProductId = orderReq.ProductId, OrderId = orderEntity.Id };
        //        _context.OrderRows.Add(orderRowEntity);
        //        await _context.SaveChangesAsync();
        //        MessageBox.Show("Saved!");
        //        return new OkResult();
        //    }
        //    catch (Exception ex) { Debug.WriteLine(ex.Message); }
        //    return new BadRequestResult();

        //}
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
