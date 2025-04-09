using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model
{
    public class User
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public User(int UserId, string Username, string Password, string Role)
        {
            userId = UserId;
            username = Username;
            password = Password;
            role = Role;
        }
    }
}
