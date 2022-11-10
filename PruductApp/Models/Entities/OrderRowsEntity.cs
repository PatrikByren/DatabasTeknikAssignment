using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruductApp.Models.Entities
{
    public class OrderRowsEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public OrderEntity Order { get; set; } = null!;
        public ProductEntity Product { get; set; } = null!;

    }
}
