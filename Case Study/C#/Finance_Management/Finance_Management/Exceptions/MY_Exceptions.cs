using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Management.Exceptions
{
        public class UserNotFoundException : Exception 
        {
            public UserNotFoundException() : base("User doesnt exsist") { }
            public UserNotFoundException(string message) : base(message) { }
        }
        public class ExpenseNotFoundException : Exception
        {
            public ExpenseNotFoundException() : base() { }
            public ExpenseNotFoundException(string message) : base(message) { }
        }


    }
 

