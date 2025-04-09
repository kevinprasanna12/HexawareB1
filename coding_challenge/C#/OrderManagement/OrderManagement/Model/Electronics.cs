using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model
{
    public class Electronics : Product
    {
        public string brand { get; set; }
        public int warrantyPeriod { get; set; }

        public Electronics(int productId, string productName, string description, int price, int quantityInStock, string Brand, int WarrantyPeriod) 
                            : base(productId, productName, description, price, quantityInStock, "Electronics")
        {
            brand = Brand;
            warrantyPeriod = WarrantyPeriod;
        }
    }
}
