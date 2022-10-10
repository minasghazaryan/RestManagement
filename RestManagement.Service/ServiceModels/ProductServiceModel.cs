﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestManagement.Service.ServiceModels
{
    public class ProductServiceModel
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public bool InMenue { get; set; }
    }
}
