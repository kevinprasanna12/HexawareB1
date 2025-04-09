using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Exceptions
{
    public class MY_Exceptions
    {
        public class UserNotFoundException : Exception
        {
            public UserNotFoundException(string message) : base(message) { }
        }

        public class OrderNotFoundException : Exception 
        {
            public OrderNotFoundException(string message) : base(message) { }
        }
    }
}
