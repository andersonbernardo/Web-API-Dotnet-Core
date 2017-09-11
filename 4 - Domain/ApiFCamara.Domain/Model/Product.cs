using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFCamara.Domain.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
    }
}
