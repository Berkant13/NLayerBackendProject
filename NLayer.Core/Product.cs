using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public class Product:BaseEntity
    {
       
        public string? ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        //Foreign key
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public ProductFeature? ProductFeature { get; set; }
    }
}
