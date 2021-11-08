using System;
using System.Collections.Generic;
using System.Text;

namespace LegoMobile
{
    class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public User(string name, string email, string token)
        {
            Name = name;
            Email = email;
            Token = token;
        }
    }
}
