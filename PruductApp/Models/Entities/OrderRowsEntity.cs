using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruductApp.Models.Entities
{
    public class OrderRowsEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public OrderEntity Order { get; set; }
        public ProductEntity Product { get; set; }

    }
}
