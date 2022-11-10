using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruductApp.Models.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public IEnumerable<OrderRowsEntity> OrderRows { get; set; } = new List<OrderRowsEntity>();  

    }
}
