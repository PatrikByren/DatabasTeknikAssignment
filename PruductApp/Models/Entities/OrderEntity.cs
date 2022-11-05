using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruductApp.Models.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; } 
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
        public ICollection<ProductEntity> Products { get; set; } //Kopplad till flera produkter
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;

    }
}
