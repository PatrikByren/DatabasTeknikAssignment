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
        public DateTime Date { get; set; } 
        public int CustomerId { get; set; }
        public int OrderRowsId { get; set; }
        public IEnumerable<OrderRowsEntity> OrderRows { get; set; } = new List<OrderRowsEntity>();
        public CustomerEntity Customer { get; set; } = null!;


}
}
