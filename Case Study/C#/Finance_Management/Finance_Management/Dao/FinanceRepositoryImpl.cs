using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance_Management.Models;
using Finance_Management.Util;
using Microsoft.Data.SqlClient;
using Finance_Management.Exceptions;
using NUnit.Framework;

namespace Finance_Management.Dao
{
    public class FinanceRepositoryImpl : IFinanceRepository
    {
        static SqlDataReader dr;
        static SqlConnection connection = DBConnection.GetConnection(DBConnection.ConnectionString);
        

        public bool CreateUser(User user)
        {
            
                string query = "insert users (username, password, email) values (@Username, @Password, @Email)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Email", user.Email);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    return rowsAffected > 0;

                } 
        }
        public bool CreateExpense(Expense expense)
        {
            
                string query = "insert into Expenses (user_id, amount, category_id, date, description) " +
                              "values (@UserId, @Amount, @CategoryId, @Date, @Description)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", expense.UserId);
                    command.Parameters.AddWithValue("@Amount", expense.Amount);
                    command.Parameters.AddWithValue("@CategoryId", expense.CategoryId);
                    command.Parameters.AddWithValue("@Date", expense.Date);
                    command.Parameters.AddWithValue("@Description", expense.Description ?? (object)DBNull.Value);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    return rowsAffected > 0;
                }
            }
            
        
        public bool DeleteUser(int userId)
        {
            
                string deleteExpensesQuery = "delete from Expenses where user_id = @UserId";
                using (SqlCommand command = new SqlCommand(deleteExpensesQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                
                string deleteUserQuery = "delete from Users where user_id = @UserId";
                using (SqlCommand command = new SqlCommand(deleteUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected == 0)
                    {
                        throw new UserNotFoundException($"User with ID {userId} not found.");
                    }
                    return rowsAffected > 0;
                }
            
        }
        public bool DeleteExpense(int expenseId)
        {
            
                string query = "delete from Expenses WHERE expense_id = @ExpenseId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ExpenseId", expenseId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected == 0)
                    {
                        throw new ExpenseNotFoundException($"Expense with ID {expenseId} not found.");
                    }

                    return rowsAffected > 0;
                }
        }
            
        

        public void GetAllExpenses(int userId)
        {
            string query = "select * from expenses where user_id = @Userid";
            using(SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Userid", userId);
                connection.Open();

                dr = command.ExecuteReader();
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
                        Console.WriteLine("----------------------------");
                    }
                }
                else
                    throw new ExpenseNotFoundException("Expense not found exception");
                
                connection.Close();
               
                

            }
        }

        public bool UpdateExpense(int userId, Expense expense)
        {
            
                
                string verifyQuery = "select count(*) FROM Expenses where expense_id = @ExpenseId and user_id = @UserId";
                using (SqlCommand verifyCommand = new SqlCommand(verifyQuery, connection))
                {
                    verifyCommand.Parameters.AddWithValue("@ExpenseId", expense.ExpenseId);
                    verifyCommand.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();
                    int count = (int)verifyCommand.ExecuteScalar();

                    if (count == 0)
                    {
                        connection.Close();
                        throw new ExpenseNotFoundException();
                        
                    }
                    
                }
                

                string updateQuery = "update Expenses set amount = @Amount, category_id = @CategoryId, " +
                                    "date = @Date, description = @Description where expense_id = @ExpenseId";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@Amount", expense.Amount);
                    updateCommand.Parameters.AddWithValue("@CategoryId", expense.CategoryId);
                    updateCommand.Parameters.AddWithValue("@Date", expense.Date);
                    updateCommand.Parameters.AddWithValue("@Description", expense.Description);
                    updateCommand.Parameters.AddWithValue("@ExpenseId", expense.ExpenseId);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    connection.Close();

                    return rowsAffected > 0;
                
            }
           
        }

    }
}
