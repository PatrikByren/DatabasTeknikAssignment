using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruductApp.Models.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; } = null!;
        [ForeignKey("OrderEntity")]
        public int OrderId { get; set; }
        public ICollection<OrderEntity> Order { get; set; } = null!;

    }
}
