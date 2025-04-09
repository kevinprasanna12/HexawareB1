using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int quantityInStock { get; set; }
        public string type { get; set; } 

        public Product(int ProductId, string ProductName, string Description,int Price, int QuantityInStock, string Type)
        {
            productId = ProductId;
            productName = ProductName;
            description = Description;
            price = Price;
            quantityInStock = QuantityInStock;
            type = Type;
        }
    }
}
