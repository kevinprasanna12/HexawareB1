using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance_Management.Util;
using Finance_Management.Models;
using Finance_Management.Exceptions;
using Finance_Management.Dao;


namespace Finance_Management.Main
{
    public class FinanceApp
    {
        private static IFinanceRepository financeRepository = new FinanceRepositoryImpl();

        public static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\nFinance Management System");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Add Expense");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. Delete Expense");
                Console.WriteLine("5. Update Expense");
                Console.WriteLine("6. View All Expenses for User");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddUser();
                            break;
                        case 2:
                            AddExpense();
                            break;
                        case 3:
                            DeleteUser();
                            break;
                        case 4:
                            DeleteExpense();
                            break;
                        case 5:
                            UpdateExpense();
                            break;
                        case 6:
                            ViewAllExpenses();
                            break;
                        case 7:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter valid number");
                }
            }

        }

        private static void AddUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            User user = new User(0,username, password, email);
            bool success = financeRepository.CreateUser(user);

            if (success)
            {
                Console.WriteLine("User created successfully!");
            }
            else
            {
                Console.WriteLine("Failed to create user.");
            }
            Console.ReadLine();
        }
        private static void AddExpense()
        {
            Console.Write("Enter user ID: ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter category ID: ");
            int categoryId = int.Parse(Console.ReadLine());

            Console.Write("Enter date (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter description (optional): ");
            string description = Console.ReadLine();

            Expense expense = new Expense(0,userId, amount, categoryId, date, description);
            bool success = financeRepository.CreateExpense(expense);

            if (success)
            {
                Console.WriteLine("Expense added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add expense.");
            }
            Console.ReadLine();
        }
        private static void DeleteUser()
        {
            Console.Write("Enter user ID to delete: ");
            int userId = int.Parse(Console.ReadLine());

            bool success = financeRepository.DeleteUser(userId);

            if (success)
            {
                Console.WriteLine("User deleted successfully!");
            }
            else
            {
                Console.WriteLine("Failed to delete user.");
            }
            Console.ReadLine();
        }
        private static void DeleteExpense()
        {
            Console.Write("Enter expense ID to delete: ");
            int expenseId = int.Parse(Console.ReadLine());

            bool success = financeRepository.DeleteExpense(expenseId);

            if (success)
            {
                Console.WriteLine("Expense deleted successfully!");
            }
            else
            {
                Console.WriteLine("Failed to delete expense.");
            }
            Console.ReadLine();
        }
        private static void UpdateExpense()
        {
            try { 
            Console.Write("Enter user ID: ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("Enter expense ID to update: ");
            int expenseId = int.Parse(Console.ReadLine());

            Console.Write("Enter new amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter new category ID: ");
            int categoryId = int.Parse(Console.ReadLine());

            Console.Write("Enter new date (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter new description (optional): ");
            string description = Console.ReadLine();

            Expense expense = new Expense(expenseId ,userId, amount, categoryId, date, description);
            expense.ExpenseId = expenseId;
            bool success = financeRepository.UpdateExpense(userId, expense);

            if (success)
            {
                Console.WriteLine("Expense updated successfully!");
            }
            else
            {
                Console.WriteLine("Failed to update expense.");
            }

         }
            catch(ExpenseNotFoundException e)
            {
                Console.WriteLine("-------Error---------");
                Console.WriteLine($"Expense with ID not found for user.");
                Console.ReadLine();
            }
    }
        private static void ViewAllExpenses()
        {
            Console.WriteLine("Enter user id :");
            int userId = int.Parse(Console.ReadLine());

            financeRepository.GetAllExpenses(userId);
            Console.ReadLine();

        }


    }
}
