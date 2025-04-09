using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model
{
    public class Clothing : Product
    {
        public string size { get; set; }
        public string color { get; set; }

        public Clothing(int productId, string productName, string description,int price, int quantityInStock, string Size, string Color)
                        : base(productId, productName, description, price, quantityInStock, "Clothing")
        {
            size = Size;
            color = Color;
        }
    }
}
