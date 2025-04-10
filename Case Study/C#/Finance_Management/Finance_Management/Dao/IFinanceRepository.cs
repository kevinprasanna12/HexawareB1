using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance_Management.Models;

namespace Finance_Management.Dao
{
    public interface IFinanceRepository
    {
        bool CreateUser(User user);
        bool CreateExpense(Expense expense);
        bool DeleteUser(int userId);
        bool DeleteExpense(int expenseId);
        void GetAllExpenses(int userId);
        bool UpdateExpense(int userId, Expense expense);
    }
}
