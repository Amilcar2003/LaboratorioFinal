using System;
using System.Collections.Generic;
using System.Text;

namespace LABORATORIOFINAL.Model
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public static List<User> users = new List<User>();
    }
}
