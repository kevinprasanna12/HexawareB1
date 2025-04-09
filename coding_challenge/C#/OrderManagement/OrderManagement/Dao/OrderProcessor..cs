using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OrderManagement.Util;
using OrderManagement.Exceptions;
using System.Security.Cryptography;
using OrderManagement.Model;
using System.Runtime.InteropServices;

namespace OrderManagement.Dao
{
    public class OrderProcessor : IOrderManagementRepository
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;
        public void CreateUser(int userid,string username,string password,string role)
        {
            using(SqlConnection con = DBConnutil.GetConnection(DBConnutil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("insert into users (userid, username, password, role) values (@userid, @username, @password, @role)", con);

                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password",password);
                cmd.Parameters.AddWithValue("@role", role);

                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new Exception("Error creating user");
                }
                else
                    Console.WriteLine("Created successfully...");
                Console.ReadLine();

                con.Close();
            }

        }
        public void getAllProducts(int productid) //, string productname, string description, int price, int Quantity, string type)
        {
            using(SqlConnection con = DBConnutil.GetConnection(DBConnutil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("select * from product where productid = @productid", con);

                dr= cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while (dr.Read())
                    {
                        for(int i = 0; i < dr.FieldCount; i++)
                        {
                            string columnName = dr.GetName(i);
                            object value = dr.GetValue(i);
                            Console.WriteLine($"{columnName}: {value}");
                        }
                    }
                }
                else
                {
                    throw new Exception("Invalid product id");
                }
                Console.ReadLine ();
                con.Close();
            }
        }
        public void getOrderByUser(int userid)
        {
            using (SqlConnection con = DBConnutil.GetConnection(DBConnutil.ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("select p.productid,p.productname,p.price,e.brand,e.warrantyperiod,c.size,c.color from Products p " +
                    "left join Electronics e on p.ProductId = e.ProductId " +
                    "left join Clothing c on p.ProductId = c.productId join orders o on o.productid = p.ProductId " +
                    "where o.userid = @userid", con);
                cmd.Parameters.AddWithValue("@userid", userid);
                dr= cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            string columnName = dr.GetName(i);
                            object value = dr.GetValue(i);
                            Console.WriteLine($"{columnName}: {value}");
                        }
                    }
                }
                else
                {
                    throw new MY_Exceptions.UserNotFoundException("User not found");
                }

                Console.Read ();
                con.Close();

                
            }
        }

        public void createOrder(int UserID,int Productid)
        {
            using (SqlConnection con = DBConnutil.GetConnection(DBConnutil.ConnectionString))
            {
                con.Open();
                if (!UserExists(UserID))
                {
                    Console.WriteLine("Please create the user first");
                    Console.WriteLine("-----------------------------");
                    int userid = UserID;
                    Console.WriteLine("Enter your user_name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the password");
                    string password = Console.ReadLine();
                    Console.WriteLine("Enter you role");
                    string role = Console.ReadLine();

                    CreateUser(userid,name,password,role);
                }

                SqlCommand cmd1 = new SqlCommand("insert into Orders (userid, Productid, OrderDate) VALUES (@UId, @PId, @OrderDate", con);
                cmd1.Parameters.AddWithValue("UId", UserID);
                cmd1.Parameters.AddWithValue("PId", Productid);
                cmd1.Parameters.AddWithValue("OrderDate", DateTime.Now);

                int result = cmd1.ExecuteNonQuery();
                if (result == 0 )
                {
                    throw new MY_Exceptions.UserNotFoundException("Error in placing order");
                }
                else
                    Console.WriteLine("Ordered Successfully");
                SqlCommand cmd2 = new SqlCommand("Update products set quantityinstock = quantityinstock -1 where productid = @Productid", con);
                cmd2.Parameters.AddWithValue("Productid", Productid);
                cmd2.ExecuteNonQuery();

                Console.ReadLine();

            }
        }
        public void cancelOrder(int userid,int orderid)
        {
            using (SqlConnection con = DBConnutil.GetConnection(DBConnutil.ConnectionString))
            {
                con.Open();
                if (!UserExists(userid))
                {
                    throw new MY_Exceptions.UserNotFoundException($"{userid} not found....");
                }
                if (!OrderExists(orderid))
                {
                    throw new MY_Exceptions.OrderNotFoundException($"{orderid} not found.....");
                }

                cmd = new SqlCommand("delete from orders where orderid = @Orderid",con);
                cmd.Parameters.AddWithValue("@Orderid", orderid);
                int result = cmd.ExecuteNonQuery();
                if(result == 0 )
                {
                    throw new Exception("Error in deletion");
                }
                else
                {
                    Console.WriteLine("Cancelled successfully");
                }

                SqlCommand cmd2 = new SqlCommand("update products set quantityinstock = quantityinstock + 1 " +
                    "where productid = (select productid from orders where orderid = @Oid)", con);
                cmd2.Parameters.AddWithValue("Oid", orderid);
                cmd2.ExecuteNonQuery();

                Console.ReadLine();
                con.Close();

            }
        }
       public void Createproduct(int userid,int productid, string productname, string description, int price, int quantity, string type)
        {
            using (SqlConnection con = DBConnutil.GetConnection(DBConnutil.ConnectionString))
            {
                con.Open();
                if (!UserExists(userid))
                {
                    throw new MY_Exceptions.UserNotFoundException($"{userid} not found....");
                }
                cmd = new SqlCommand("select count(*) from users where userid=@userid and role = 'admin'", con);
                cmd.Parameters.AddWithValue("@userid", userid);
                dr = cmd.ExecuteReader();
                if(!dr.HasRows)
                {
                    Console.WriteLine("Only admin can add products");
                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand("insert into products (productid, productname, pdescription, price, quantityinstock, type) values (@pid,@pname,@des,@price,@qty,@type)", con);
                    cmd2.Parameters.AddWithValue("@pid",productid);
                    cmd2.Parameters.AddWithValue("@pname",productname);
                    cmd2.Parameters.AddWithValue("@des",description);
                    cmd2.Parameters.AddWithValue("@price",price);
                    cmd2.Parameters.AddWithValue("@qty",quantity);
                    cmd2.Parameters.AddWithValue("@type",type);

                    cmd2.ExecuteNonQuery();
                    Console.WriteLine("Product updated successfully...");
                    Console.ReadLine();
                }

            }

       }
        //-------------------------------CHECK-----------------------------------------

        public bool UserExists(int userId)
        {
            
            using (SqlConnection con = DBConnutil.GetConnection(DBConnutil.ConnectionString))
            {
                cmd = new SqlCommand("select count(*) from Users where Userid = @UserId", con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                if((int)cmd.ExecuteScalar() > 0)
                {
                    return true;
                }
                else
                    { return false; }
            }
        }
        public bool ProductExists(int productid)
        {

            using (SqlConnection con = DBConnutil.GetConnection(DBConnutil.ConnectionString))
            {
                cmd = new SqlCommand("select count(*) from products where productid = @PId", con);
                cmd.Parameters.AddWithValue("@PId", productid);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        public bool OrderExists(int orderid)
        {

            using (SqlConnection con = DBConnutil.GetConnection(DBConnutil.ConnectionString))
            {
                cmd = new SqlCommand("select count(*) FROM Users WHERE UserId = @orderid", con);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
    }
}
