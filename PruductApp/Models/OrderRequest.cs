﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruductApp.Models
{
    public class OrderRequest
    {
        public int CustomerId { get; set; } 
        public int ProductId { get; set; }
    }
}
