using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Dao
{
    public interface IOrderManagementRepository
    {
        void CreateUser(int userid,string username, string password,string role);

        void getAllProducts(int productid); 

        void getOrderByUser(int userid);

        void createOrder(int userid, int productid);

        void cancelOrder(int userid,int orderid);

        void Createproduct(int userid,int productid,string productname,string description,int price,int quantity,string type);
    }

}
