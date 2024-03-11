using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.ProductDto
{
    public class CreateProductDto
    {
     
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public bool ProductStatus { get; set; }
    }
}
