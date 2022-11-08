using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruductApp.Models.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; } 
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public ICollection<ProductEntity> Product { get; set; } = new List<ProductEntity>();
        public CustomerEntity Customer { get; set; } = null!;


}
}
