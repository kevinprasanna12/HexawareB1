using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Util;
using OrderManagement.Dao;
using System.Globalization;
using OrderManagement.Model;


namespace OrderManagement.Main
{
    public class MainModule
    {
        static void Main()
        {
            IOrderManagementRepository obj = new OrderProcessor();
            while (true)
            {
                Console.WriteLine("\nOrder Management System");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Create Product (Admin only)");
                Console.WriteLine("3. Create Order");
                Console.WriteLine("4. Cancel Order");
                Console.WriteLine("5. Get All Products");
                Console.WriteLine("6. Get Orders by User");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            CreateUsermenu(obj);
                            break;
                        case 2:
                            CreateProduct(obj);
                            break;
                        case 3:
                            CreateOrder(obj);
                            break;
                        case 4:
                            CancelOrder(obj);
                            break;
                        case 5:
                            GetAllProducts(obj);
                            break;
                        case 6:
                            GetOrdersByUser(obj);
                            break;
                        case 7:
                            Console.WriteLine("Exiting the system...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }

        static void CreateUsermenu(IOrderManagementRepository obj)
        {
            Console.WriteLine("Enter user id:");
            int userid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter user name");
            string username = Console.ReadLine();
            Console.WriteLine("Enter pass");
            string password = Console.ReadLine();
            Console.WriteLine("Enter role");
            string role = Console.ReadLine();

            obj.CreateUser(userid, username, password, role);

            
        }
        static void CreateProduct(IOrderManagementRepository obj)
        {
            Console.WriteLine("\nCreate New Product");

            Console.WriteLine("enter user id");
            int userid = int.Parse(Console.ReadLine());
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Price: ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity in Stock: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Type (Electronics/Clothing): ");
            string type = Console.ReadLine();


            obj.Createproduct(userid,productId,productName,description,price,quantity,type);
           
        }

        static void CreateOrder(IOrderManagementRepository obj)
        {
            Console.WriteLine("Create New Order");
            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());
            Console.Write("Enter Product id: ");
            int productid = int.Parse(Console.ReadLine());

            obj.createOrder(userId,productid);

            
           

           
        }

        static void CancelOrder(IOrderManagementRepository obj)
        {
            Console.WriteLine("\nCancel Order");
            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());
            Console.Write("Enter Order ID to cancel: ");
            int orderId = int.Parse(Console.ReadLine());

            obj.cancelOrder(userId, orderId);
            
        }

        static void GetAllProducts(IOrderManagementRepository obj)
        {
            Console.WriteLine("Enter product id");
            int productid = int.Parse(Console.ReadLine());

            obj.getAllProducts(productid);

        }

        static void GetOrdersByUser(IOrderManagementRepository obj)
        {
            Console.WriteLine("enter user id");
            int userid = int.Parse(Console.ReadLine());

            obj.getOrderByUser(userid);
        }
    }
}
