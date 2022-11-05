using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruductApp.Models
{
    public class ProductRequest
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
