using Microsoft.AspNetCore.Mvc;
using PruductApp.Models;
using PruductApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PruductApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;
        private readonly OrderService _orderService;
        public MainWindow(CustomerService customerService, ProductService productService, OrderService orderService)
        {
            InitializeComponent();
            _customerService = customerService;
            _productService = productService;
            _orderService = orderService;
            PopulateCustomerComboboxAsync().ConfigureAwait(false);
            
        }
        public async Task PopulateCustomerComboboxAsync()
        {
            var collection = new ObservableCollection<KeyValuePair<int, string>>();
            foreach(var item in await _customerService.GetAllCustomersAsync())
                collection.Add(new KeyValuePair<int, string>(item.Id, item.Name));
            cb_customer.ItemsSource = collection;
            PopulateProductComboboxAsync().ConfigureAwait(false);
        }
        public async Task PopulateProductComboboxAsync()
        {
            var items = new ObservableCollection<KeyValuePair<int, string>>();
            foreach (var item in await _productService.GetAllProductAsync())
                items.Add(new KeyValuePair<int, string>(item.Id, item.Name));
            cb_product.ItemsSource = items;
        }

        private async void btn_makeOrder_Click(object sender, RoutedEventArgs e)
        {
            try 
            {

                var customer = (KeyValuePair<int, string>)cb_customer.SelectedItem;
                var product = (KeyValuePair<int, string>)cb_product.SelectedItem;
                var customerId = customer.Key;
                var productId = product.Key;
                
                var orderRequest = new OrderRequest
                {
                    CustomerId = customerId,
                    ProductId = productId
                };

                var result = await _orderService.CreateOrderAsync(orderRequest);

                if (result is OkResult)
                {
                    cb_customer.SelectedItem = null!;
                    cb_product.SelectedItem = null!;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); } 

        }
    }
}
